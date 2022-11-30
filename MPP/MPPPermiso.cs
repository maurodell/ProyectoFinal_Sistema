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
        private string pathPermisos = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Permisos.XML";
        private string pathPermisoPermiso = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\PermisosPermisos.XML";
        private string pathPermisosUsuarios = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\PermisosUsuarios.XML";
        public Array TraerTodosLosPermisos()
        {
            return Enum.GetValues(typeof(BEMenuPermisos));
        }
        public IList<BEPermiso> TraerTodosPermisosConNombre()
        {
            List<BEPermiso> listaPermisos = new List<BEPermiso>();
            XDocument path = XDocument.Load(pathPermisos);
            var consulta = from permisosPatente in path.Descendants("permiso")
                            where permisosPatente.Element("menu").Value != "null"
                            select new 
                            {
                                codigo = Convert.ToInt32(permisosPatente.Attribute("codigo").Value),
                                nombre = Convert.ToString(permisosPatente.Element("nombre").Value),
                                permiso = Convert.ToString(permisosPatente.Element("menu").Value)
                            };

            foreach (var item in consulta)
            {
                BEPermiso bePerm = new BEPermiso();
                bePerm._codigo = item.codigo;
                bePerm._nombre = item.nombre;
                bePerm.Permiso = (BEMenuPermisos)Enum.Parse(typeof(BEMenuPermisos), item.permiso);
                listaPermisos.Add(bePerm);
            }
            return listaPermisos;
        }
        public IList<BEFamillia> TraerTodosRolesFamilia()
        {
            List<BEFamillia> listaFamilias = new List<BEFamillia>();
            XDocument path = XDocument.Load(pathPermisos);
            var consulta = from permisosPatente in path.Descendants("permiso")
                           where permisosPatente.Element("menu").Value.Equals("null")
                           select new
                           {
                               codigo = Convert.ToInt32(permisosPatente.Attribute("codigo").Value),
                               nombre = Convert.ToString(permisosPatente.Element("nombre").Value)
                           };

            foreach (var item in consulta)
            {
                BEFamillia bePerm = new BEFamillia();
                bePerm._codigo = item.codigo;
                bePerm._nombre = item.nombre;
                listaFamilias.Add(bePerm);
            }
            return listaFamilias;
        }
        public bool GuardarComponente(BEComponente componente, bool tipo)
        {
            //Busco el último codigo y le sumo uno
            //------------------
            int nroCodigo = 0;
            XDocument documento = XDocument.Load(pathPermisos);

            var consulta = from rolPermiso in documento.Descendants("permiso")
                           orderby rolPermiso.Element("codigo") descending
                           select rolPermiso;

            foreach (XElement EModifcar in consulta)
            {
                nroCodigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
            }
            //------------------

            XDocument crear = XDocument.Load(pathPermisos);

            nroCodigo++;
            if (tipo)
            {
                crear.Element("permisos").Add(new XElement("permiso",
                                                new XAttribute("codigo", nroCodigo),
                                                new XElement("nombre", componente._nombre),
                                                new XElement("menu", "null")));
            }
            else
            {
                crear.Element("permisos").Add(new XElement("permiso",
                                    new XAttribute("codigo", nroCodigo),
                                    new XElement("nombre", componente._nombre),
                                    new XElement("menu", componente.Permiso)));
            }

            crear.Save(pathPermisos);
            return true;
        }
        public IList<BEComponente> TraerPermisosTodos2(int codigoRol)
        {
            List<BEComponente> listaBEComponentes = new List<BEComponente>();
            BEComponente comp;
            if (!String.IsNullOrEmpty(codigoRol.ToString()))
            {
                IList<DTOPermisoPermiso> lista = ConsultaPermisoPermiso(codigoRol);

                foreach (var item in lista)
                {
                    var consulta = from permisoRol in ConsultaPermiso1(item.codigoRol)
                                    join
                                    permisoPermiso in ConsultaPermiso1(item.codigoPermiso)
                                    on item.codigoPermiso equals permisoPermiso.codigo
                                    select new
                                    {
                                        codigoRol = permisoRol.codigo,
                                        codigoMenu = permisoPermiso.codigo,
                                        nombreMenu = permisoPermiso.nombre,
                                        nombrePermiso = permisoPermiso.menu
                                    };

                    foreach (var x in consulta)
                    {
                        if (String.IsNullOrEmpty(x.nombrePermiso))
                        {
                            comp = new BEFamillia();
                            comp._codigo = x.codigoRol;
                            comp._nombre = x.nombreMenu;
                        }
                        else
                        {
                            comp = new BEPermiso();
                            comp._codigo = x.codigoMenu;
                            comp._nombre = x.nombreMenu;
                            comp.Permiso = (BEMenuPermisos)Enum.Parse(typeof(BEMenuPermisos),x.nombrePermiso);
                        }

                        listaBEComponentes.Add(comp);
                    }
                }

            }
            return listaBEComponentes;
        }
        public IList<DTOPermisoPermiso> ConsultaPermisoPermiso(int codigoPermiso)
        {
            XDocument path = XDocument.Load(pathPermisoPermiso);
            List<DTOPermisoPermiso> listaPermisoPermiso = new List<DTOPermisoPermiso>();
            var resultado = from rolPermiso in path.Descendants("permiso")
                            where rolPermiso.Element("codigoRol").Value == codigoPermiso.ToString()
                            select new
                            {
                                codigoRol = Convert.ToInt32(rolPermiso.Element("codigoRol").Value),
                                codigoPermiso = Convert.ToInt32(rolPermiso.Element("codigoMenu").Value)
                            };
            DTOPermisoPermiso objPermiso = null;
            foreach (var item in resultado)
            {
                objPermiso = new DTOPermisoPermiso();
                objPermiso.codigoRol = item.codigoRol;
                objPermiso.codigoPermiso = item.codigoPermiso;
                listaPermisoPermiso.Add(objPermiso);
            }
            return listaPermisoPermiso;
        }
        public IEnumerable<DTOPermiso> ConsultaPermiso1(int codigoFamilia)
        {
            XDocument path = XDocument.Load(pathPermisos);

            var resultado = from rolPermiso in path.Descendants("permiso")
                            where rolPermiso.Attribute("codigo").Value == codigoFamilia.ToString()
                            select new DTOPermiso
                            {
                                codigo = Convert.ToInt32(rolPermiso.Attribute("codigo").Value),
                                nombre = Convert.ToString(rolPermiso.Element("nombre").Value),
                                menu = Convert.ToString(rolPermiso.Element("menu").Value)
                            };

            return resultado;
        }
        public bool Existe(BEComponente componente, int codigo)
        {
            bool flag = false;
            foreach (var item in componente.ObjenerHijos)
            {
                if (item._codigo.Equals(codigo))
                {
                    flag = true;
                }
            }
            return flag;
        }
        public bool ExistePermisosUsuario(BEUsuario beUsuario, int codigo)
        {
            bool flag = false;
            foreach (var familia in beUsuario.listaPermisos)
            {
                if (familia.ObjenerHijos.Count > 0)
                {
                    foreach (var permiso in familia.ObjenerHijos)
                    {
                        if (permiso._codigo.Equals(codigo))
                        {
                            flag = true;
                        }
                    }
                }
                else
                {
                    if (familia._codigo.Equals(codigo))
                    {
                        flag = true;
                    }
                }

            }
            return flag;
        }
        public bool ExistePermisosUsuario2(BEComponente componente, int codigo)
        {
            bool flag = false;
            if (componente._codigo.Equals(codigo))
            {
                flag = true;
            }
            else
            {
                foreach (var item in componente.ObjenerHijos)
                {
                    flag = ExistePermisosUsuario2(item, codigo);
                    if (flag)
                    {
                        return true;
                    }
                }
            }

            return flag;
        }
        public bool GuardarPermisos(BEUsuario usuario)
        {
            try
            {
                bool limpiar = LimpiarPermisosUsuario(usuario.Codigo);
                if (limpiar)
                {
                    //TRAE EL ÚLTIMO CÓDIGO DEL PERMISO INGRESADO PARA PASAR POR CÓDIGO AL CREAR EL NUEVO PERMISO
                    //------------------
                    int nroCodigo = 0;
                    XDocument documento = XDocument.Load(pathPermisosUsuarios);

                    var consulta2 = from rolPermiso in documento.Descendants("permiso")
                                   orderby rolPermiso.Element("codigo") descending
                                   select rolPermiso;

                    foreach (XElement EModifcar in consulta2)
                    {
                        nroCodigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    }
                    //------------------

                    XDocument crear = XDocument.Load(pathPermisosUsuarios);
                    foreach (var item in usuario.listaPermisos)
                    {
                        nroCodigo++;
                        crear.Element("permisos").Add(new XElement("permiso",
                                                        new XAttribute("codigo", nroCodigo),
                                                        new XElement("codigoUsuario", usuario.Codigo),
                                                        new XElement("codigoPermiso", item._codigo)));
                    }
                    crear.Save(pathPermisosUsuarios);
                    return true;
                }
                return false;
            }
                catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool GuardarFamilia(BEFamillia beFamilia)
        {
            try
            {
                IList<BEComponente> lista = TraerPermisosTodos2(beFamilia._codigo);
                bool limpiar = false;
                if (lista.Count()>0)
                {
                    limpiar = LimpiarPermisosRolMenu(beFamilia);
                }
                else
                {
                    //rol creado sin roles persistidos
                    limpiar = true;
                }
                
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
                XDocument documento = XDocument.Load(pathPermisoPermiso);

                var consulta = from rolPermiso in documento.Descendants("permiso")
                               where rolPermiso.Element("codigoRol").Value == rol._codigo.ToString()
                               select rolPermiso;
                consulta.Remove();

                documento.Save(pathPermisoPermiso);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool LimpiarPermisosUsuario(int codigoUsuario)
        {
            try
            {
                XDocument documento = XDocument.Load(pathPermisosUsuarios);

                var consulta = from rolPermiso in documento.Descendants("permiso")
                               where rolPermiso.Element("codigoUsuario").Value == codigoUsuario.ToString()
                               select rolPermiso;

                consulta.Remove();
                documento.Save(pathPermisosUsuarios);
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
                XDocument documento = XDocument.Load(pathPermisoPermiso);

                var consulta = from rolPermiso in documento.Descendants("permiso")
                               orderby rolPermiso.Element("codigo") descending
                               select rolPermiso;

                foreach (XElement EModifcar in consulta)
                {
                    nroCodigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                }
                //------------------

                XDocument crear = XDocument.Load(pathPermisoPermiso);
                foreach (var item in rol.ObjenerHijos)
                {
                    nroCodigo++;
                    crear.Element("permisopermiso").Add(new XElement("permiso",
                                                    new XAttribute("codigo", nroCodigo),
                                                    new XElement("codigoRol", rol._codigo),
                                                    new XElement("codigoMenu", item._codigo)));
                }
                crear.Save(pathPermisoPermiso);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool ExisteRolEnUsuario2(BEUsuario beUsuario, int codigoRol)
        {
            foreach (var item in beUsuario.listaPermisos)
            {
                if (item._codigo.Equals(codigoRol))
                {
                    return true;
                }
            }
            return false;
        }
        public void CompletarRolDeUsuario(BEUsuario beUsuario)
        {
            XDocument path = XDocument.Load(pathPermisos);
            BEComponente permisos = null;
            foreach (var item in ConsultaPermisosUsuario(beUsuario.Codigo))
            {
                var resultado = from rolPermiso in path.Descendants("permiso")
                                where rolPermiso.Attribute("codigo").Value == item.codigoPermiso.ToString()
                                select new DTOPermiso
                                {
                                    codigo = Convert.ToInt32(rolPermiso.Attribute("codigo").Value),
                                    nombre = Convert.ToString(rolPermiso.Element("nombre").Value),
                                    menu = Convert.ToString(rolPermiso.Element("menu").Value)
                                };

                foreach (var x in resultado)
                {
                    if (x.menu.Equals("null"))
                    {
                        permisos = new BEFamillia();
                        permisos._codigo = x.codigo;
                        permisos._nombre = x.nombre;

                        var listaPermisos = TraerPermisosTodos2(permisos._codigo);
                        foreach (var menu in listaPermisos)
                        {
                            permisos.AgregarHijo(menu);
                        }
                    }
                    else
                    {
                        permisos = new BEPermiso();
                        permisos._codigo = x.codigo;
                        permisos._nombre = x.nombre;
                        permisos.Permiso = (BEMenuPermisos)Enum.Parse(typeof(BEMenuPermisos),x.menu);
                    }
                    beUsuario.Permisos.Add(permisos);
                }
            }

        }
        public void CompletarPermisos(BEComponente rol)
        {
            rol.VaciarHijos();
            foreach (var item in TraerPermisosTodos2(rol._codigo))
            {
                rol.AgregarHijo(item);
            }
        }
        private List<DTOPermisoPermiso> ConsultaPermisosUsuario(int codigoUsuario)
        {
            XDocument documento = XDocument.Load(pathPermisosUsuarios);
            List<DTOPermisoPermiso> listaPermisosUsuario = new List<DTOPermisoPermiso>();

            var consulta = from permisos in documento.Descendants("permiso")
                           where permisos.Element("codigoUsuario").Value == codigoUsuario.ToString()
                           select new DTOPermisoPermiso
                           {
                               codigoRol = Convert.ToInt32(permisos.Element("codigoUsuario").Value),
                               codigoPermiso = Convert.ToInt32(permisos.Element("codigoPermiso").Value)
                           };

            foreach (var item in consulta)
            {
                listaPermisosUsuario.Add(item);
            }

            return listaPermisosUsuario;
        }
        public bool BorrarRol(BEComponente beFamilia)
        {
            try
            {
                bool flag = false;
                if (!flag)
                {
                    if (beFamilia._tipo.Equals(1))
                    {
                        XDocument documento = XDocument.Load(pathPermisoPermiso);//borra el rol con los permisos del xml permisopermiso

                        var consulta = from rolPermiso in documento.Descendants("permiso")
                                       where rolPermiso.Element("codigoRol").Value == beFamilia._codigo.ToString()
                                       select rolPermiso;
                        consulta.Remove();

                        documento.Save(pathPermisoPermiso);
                    }


                    //--------------------------------

                    XDocument documento2 = XDocument.Load(pathPermisos);//borra el rol del xml permiso

                    var consulta2 = from rolPermiso in documento2.Descendants("permiso")
                                   where rolPermiso.Attribute("codigo").Value == beFamilia._codigo.ToString()
                                   select rolPermiso;
                    consulta2.Remove();

                    documento2.Save(pathPermisos);
                    flag = true;
                }
                return flag;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool EliminarPermisosUsuario(int codigoUsuario)
        {
            bool respuesta = false;
            int codigoPermiso = 0;
            XDocument documento = XDocument.Load(pathPermisosUsuarios);//borra el rol del xml permiso

            var consulta = from rolPermiso in documento.Descendants("permiso")
                           where rolPermiso.Element("codigoUsuario").Value == codigoUsuario.ToString()
                           select new
                           {
                               codigoUsuario = Convert.ToInt32(rolPermiso.Element("codigoUsuario").Value),
                               codigoPermiso = Convert.ToInt32(rolPermiso.Element("codigoPermiso").Value)
                           };

            foreach (var item in consulta)
            {
                codigoPermiso = item.codigoPermiso;
            }

            var eliminar = from rolPermiso in documento.Descendants("permiso")
                           where rolPermiso.Element("codigoUsuario").Value == codigoUsuario.ToString()
                           select rolPermiso;

            if (eliminar != null)
            {
                eliminar.Remove();

                documento.Save(pathPermisosUsuarios);

                XDocument documento2 = XDocument.Load(pathPermisoPermiso);//borra el rol del xml permiso

                var eliminar2 = from rolPermiso in documento2.Descendants("permiso")
                               where rolPermiso.Element("codigoRol").Value == codigoPermiso.ToString()
                               select rolPermiso;
                if (eliminar2 != null)
                {
                    eliminar2.Remove();

                    documento2.Save(pathPermisoPermiso);
                }
                respuesta = true;
            }
            return respuesta;
        }
    }
}
