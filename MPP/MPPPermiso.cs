using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using BE.DTO;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using System.IO;
using System.Reflection;

namespace MPP
{
    public class MPPPermiso
    {
        private string pathMenus = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Menus.XML";
        private string pathPermisoRolMenu = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\PermisoRolMenu.XML";
        private string pathUsuarioyRol = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\UsuarioyRol.XML";
        MPPRol mppRol;
        public List<BEPermiso> ListarMenu()
        {
            DataSet DS = new DataSet();
            DS.ReadXml(pathMenus);

            List<BEPermiso> menus = new List<BEPermiso>();

            if (DS.Tables.Count > 0)
            {
                foreach (DataRow item in DS.Tables[0].Rows)
                {
                    BEPermiso menu = new BEPermiso
                    {
                        _codigo = Convert.ToInt32(item["codigo"]),
                        _nombre = Convert.ToString(item["nombreMenu"])
                    };

                    menus.Add(menu);
                }
            }
            return menus;
        }
        public IList<BEComponente> TraerPermisosTodos(int codigoRol)
        {
            List<DTOPermisosMenuPorRol> listaMenuPorRol = new List<DTOPermisosMenuPorRol>();
            List<BEComponente> listaBEComponentes = new List<BEComponente>();
            BEComponente comp;
            if (!String.IsNullOrEmpty(codigoRol.ToString()))
            {
                var consulta2 = from rolMenu in CargarPermisosRolMenu(codigoRol)
                                join
                                nombreMenu in CargarSubMenu()
                                on rolMenu.codigoMenu equals nombreMenu.codigo
                                select new
                                {
                                    codigoRol = rolMenu.codigoRol,
                                    codigoMenu = nombreMenu.codigo,
                                    nombreMenu = nombreMenu.nombreMenu
                                };

                DTOPermisosMenuPorRol permisos;
                foreach (var item in consulta2)
                {
                    permisos = new DTOPermisosMenuPorRol();
                    permisos._codigoRol = item.codigoRol;
                    permisos._codigoMenu = item.codigoMenu;
                    permisos._nombreMenu = item.nombreMenu;
                    listaMenuPorRol.Add(permisos);
                }

                foreach (var item in listaMenuPorRol)
                {
                    comp = new BEPermiso();
                    comp._codigo = item._codigoMenu;
                    comp._nombre = item._nombreMenu;
                    listaBEComponentes.Add(comp);
                }
            }
            return listaBEComponentes;
        }
        public BEComponente TraerRol(int codigoRol)
        {
            BEComponente rolConPermisos = new BEFamillia();
            BEComponente permisos = new BEPermiso();
            BERol rolBuscado = mppRol.BuscarPorCodigo(codigoRol);
            if (rolBuscado != null) 
            { 
                rolConPermisos._codigo = rolBuscado.Codigo;
                rolConPermisos._nombre = rolBuscado.nombre;
            }
            List<BEComponente> permisosRol = TraerPermisosTodos(codigoRol).ToList();

            if (permisosRol != null)
            {
                foreach (var item in permisosRol)
                {
                    permisos._codigo = item._codigo;
                    permisos._nombre = item._nombre;
                    rolConPermisos.AgregarHijo(permisos);
                }
            }
            return rolConPermisos;
        }
        public IEnumerable<DTORolMenu> CargarPermisosRolMenu(int codigoRol)
        {
            XDocument path = XDocument.Load(pathPermisoRolMenu);

            var resultado = from rolPermiso in path.Descendants("rolpermiso")
                            where rolPermiso.Element("codigorol").Value == codigoRol.ToString()
                            select new DTORolMenu
                            {
                                codigoRol = Convert.ToInt32(rolPermiso.Element("codigorol").Value),
                                codigoMenu = Convert.ToInt32(rolPermiso.Element("codigomenu").Value)
                            };

            return resultado;
        }
        public IEnumerable<DTOMenu> CargarSubMenu()
        {
            XDocument path = XDocument.Load(pathMenus);

            var resultado = from usuarioRol in path.Descendants("rol")
                            select new DTOMenu
                            {
                                codigo = Convert.ToInt32(usuarioRol.Attribute("codigo").Value),
                                nombreMenu = Convert.ToString(usuarioRol.Element("nombreMenu").Value)
                            };

            return resultado;
        }
        public bool Existe(BEComponente componente, int codigo)
        {
            bool existe = false;
            if (componente._codigo.Equals(codigo))
            {
                existe = true;
            }
            else
            {
                foreach (var item in componente.ObjenerHijos)
                {
                    existe = Existe(item, codigo);
                    if (existe)
                    {
                        return true;
                    }
                }
            }

            return existe;
        }
        public bool GuardarFamilia(BEFamillia beFamilia)
        {
            try
            {
                bool limpiar = LimpiarPermisosRolMenu(beFamilia);
                bool creacion = CrearPermisosEnRol(beFamilia);
                if (limpiar && creacion)
                {
                    return true;
                }
                return false;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool LimpiarPermisosRolMenu(BEFamillia rol)
        {
            try
            {
                XDocument documento = XDocument.Load(pathPermisoRolMenu);

                var consulta = from rolPermiso in documento.Descendants("rolpermiso")
                               where rolPermiso.Element("codigorol").Value == rol._codigo.ToString()
                               select rolPermiso;
                consulta.Remove();

                documento.Save(pathPermisoRolMenu);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool CrearPermisosEnRol(BEFamillia rol)
        {
            try
            {
                //TRAE EL ÚLTIMO CÓDIGO DEL PERMISO INGRESADO PARA PASAR POR CÓDIGO AL CREAR EL NUEVO PERMISO
                //------------------
                int nroCodigo = 0;
                XDocument documento = XDocument.Load(pathPermisoRolMenu);

                var consulta = from rolPermiso in documento.Descendants("rolpermiso")
                               orderby rolPermiso.Element("codigo") descending
                               select rolPermiso;

                foreach (XElement EModifcar in consulta)
                {
                    nroCodigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                }
                //------------------

                XDocument crear = XDocument.Load(pathPermisoRolMenu);
                foreach (var item in rol.ObjenerHijos)
                {
                    nroCodigo++;
                    crear.Element("permisos").Add(new XElement("rolpermiso",
                                                    new XAttribute("codigo", nroCodigo),
                                                    new XElement("codigorol", rol._codigo),
                                                    new XElement("codigomenu", item._codigo)));
                }
                crear.Save(pathPermisoRolMenu);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public List<DTORolMenu> ListaRolConMenu()
        {
            DataSet DS = new DataSet();
            DS.ReadXml(pathPermisoRolMenu);

            List<DTORolMenu> permisosDeRol = new List<DTORolMenu>();

            if (DS.Tables.Count > 0)
            {
                foreach (DataRow item in DS.Tables[0].Rows)
                {
                    DTORolMenu permisos = new DTORolMenu
                    {
                        codigoRol = Convert.ToInt32(item["codigorol"]),
                        codigoMenu = Convert.ToInt32(item["codigomenu"])
                    };

                    permisosDeRol.Add(permisos);
                }
            }
            return permisosDeRol;
        }
        public bool ExisteRolEnUsuario(int codigoUsuario, int codigoRol)
        {
            List<DTOUsuarioRol> listaRoles = ConsultarUsuarioyRol(codigoUsuario).ToList();

            foreach (var item in listaRoles)
            {
                if (item.codigoRol.Equals(codigoRol))
                {
                    return false;
                }
            }
            return true;
        }
        public bool AgregarRol(int codigoUsuario, int codigoRol)
        {
            try
            {
                //TRAE EL ÚLTIMO CÓDIGO DEL PERMISO INGRESADO PARA PASAR POR CÓDIGO AL CREAR EL NUEVO PERMISO
                //------------------
                int nroCodigo = 0;
                XDocument documento = XDocument.Load(pathUsuarioyRol);

                var consulta = from rolPermiso in documento.Descendants("usuariorol")
                               orderby rolPermiso.Element("codigo") descending
                               select rolPermiso;

                foreach (XElement EModifcar in consulta)
                {
                    nroCodigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                }
                //------------------
                XDocument crear = XDocument.Load(pathUsuarioyRol);

                nroCodigo++;
                crear.Element("usuariosroles").Add(new XElement("usuariorol",
                                                new XAttribute("codigo", nroCodigo),
                                                new XElement("codigoUsuario", codigoUsuario),
                                                new XElement("codigoRol", codigoRol)));
                
                crear.Save(pathUsuarioyRol);
                return true;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
        }
        public bool ExisteMenu(string nombreMenu)
        {
            List<DTOMenu> menus = CargarSubMenu().ToList();


            foreach (var item in menus) 
            {
                if (item.nombreMenu.Equals(nombreMenu))
                {
                    return true;
                }
            }

            return false;
        }
        public IList<BEComponente> TraerRolesPorUsuario(BEUsuario usuario)
        {
            //Tengo que traer todo los permisos que tiene el usuario por los roles.
            List<DTOUsuarioRol> listaMenuPorRol = new List<DTOUsuarioRol>();

            DTOUsuarioRol userRol;
            mppRol = new MPPRol();

            //Primero busco la lista en la lista UsuarioyRol los roles por código de usuario para traerme el rol
            //y hago un join con la lista de PermisoRolMenu, para traerme el código de rol con código de menu.
            var consulta = from usuariorol in ConsultarUsuarioyRol(usuario.Codigo)
                            join
                            codigorol in ListaRolConMenu()
                            on usuariorol.codigoRol equals codigorol.codigoRol
                            select new
                            {
                                codigoUsuario = usuariorol.codigoUsuario,
                                codigoRol = codigorol.codigoRol,
                                codigoMenu = codigorol.codigoMenu
                            };


            foreach (var item in consulta)
            {
                userRol = new DTOUsuarioRol();
                userRol.codigoUsuario = item.codigoUsuario;
                userRol.codigoRol = item.codigoRol;
                userRol.codigoMenu = item.codigoMenu;
                listaMenuPorRol.Add(userRol);
            }

            //Después me traigo los nombre de menu según corresponda al usuario.
            var consulta2 = from nombreMenu in CargarSubMenu()
                            join
                            usuarioConRol in listaMenuPorRol
                            on nombreMenu.codigo equals usuarioConRol.codigoMenu
                            select new
                            {
                                codigoRol = usuarioConRol.codigoRol,
                                codigoMenu = nombreMenu.codigo,
                                nombreMenu = nombreMenu.nombreMenu,
                            };

            var roles = from rolUsuario in ConsultarUsuarioyRol(usuario.Codigo)
                        join
                        rol in mppRol.Listar()
                        on rolUsuario.codigoRol equals rol.Codigo
                        select new
                        {
                            codigoRol = rol.Codigo,
                            nombreRol = rol.nombre
                        };

            BEComponente familia;
            BEComponente permiso;
            List<BEComponente> listaRoles = new List<BEComponente>();

            foreach (var item in roles)
            {
                familia = new BEFamillia();
                familia._codigo = item.codigoRol;
                familia._nombre = item.nombreRol;

                foreach (var item2 in consulta2)
                {
                    if(item.codigoRol == item2.codigoRol)
                    {
                        permiso = new BEPermiso();
                        permiso._codigo = item2.codigoMenu;
                        permiso._nombre = item2.nombreMenu;
                        familia.AgregarHijo(permiso);
                    }
                }
                listaRoles.Add(familia);
            }
            return listaRoles;
        }
        public IEnumerable<DTOUsuarioRol> ConsultarUsuarioyRol(int codigoUsuario)
        {
            XDocument path = XDocument.Load(pathUsuarioyRol);

            var resultado = from usuarioRol in path.Descendants("usuariorol")
                            where usuarioRol.Element("codigoUsuario").Value == codigoUsuario.ToString()
                            select new DTOUsuarioRol
                            {
                                codigoUsuario = Convert.ToInt32(usuarioRol.Element("codigoUsuario").Value),
                                codigoRol = Convert.ToInt32(usuarioRol.Element("codigoRol").Value)
                            };

            return resultado;
        }
    }
}
