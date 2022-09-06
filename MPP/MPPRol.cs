using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using System.IO;
using System.Reflection;

namespace MPP
{
    public class MPPRol : IRepositorio<BERol>
    {
        private string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Roles.XML";
        public bool Alta(int Parametro)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from rol in documento.Descendants("rol")
                               where rol.Attribute("codigo").Value == Parametro.ToString()
                               select rol;

                foreach (XElement EModifcar in consulta)
                {
                    EModifcar.Element("estado").Value = "1";
                }

                documento.Save(path);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public bool Baja(int Parametro)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from rol in documento.Descendants("rol")
                               where rol.Attribute("codigo").Value == Parametro.ToString()
                               select rol;

                foreach (XElement EModifcar in consulta)
                {
                    EModifcar.Element("estado").Value = "0";
                }

                documento.Save(path);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public List<BERol> Buscar(string Parametro)
        {
            try
            {
                if (Parametro.Equals(""))
                {
                    return Listar();
                }
                else
                {
                    BERol rolBuscar;
                    List<BERol> listaRolDevolver = new List<BERol>();

                    XDocument documento = XDocument.Load(path);

                    var consulta = from rol in documento.Descendants("rol")
                                   where rol.Element("nombre").Value.Contains(Parametro)
                                   select rol;

                    foreach (XElement EModifcar in consulta)
                    {
                        rolBuscar = new BERol();
                        rolBuscar.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                        rolBuscar.nombre = EModifcar.Element("nombre").Value;
                        rolBuscar.descripcion = EModifcar.Element("descripcion").Value;
                        rolBuscar.estado = Convert.ToBoolean(Convert.ToInt32(EModifcar.Element("estado").Value));

                        listaRolDevolver.Add(rolBuscar);
                    }
                    return listaRolDevolver;
                }

            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public bool Crear(BERol Parametro)
        {
            try
            {
                List<BERol> roles = Listar();
                int cantidadPart = roles.Count();

                XDocument crear = XDocument.Load(path);
                crear.Element("roles").Add(new XElement("rol",
                                                new XAttribute("codigo", (cantidadPart + 1)),
                                                new XElement("nombre", Parametro.nombre), //para pasar el código del juego que se agrega último
                                                new XElement("descripcion", Parametro.descripcion),
                                                new XElement("estado", 1)));

                if (VerificarExistencia(Parametro.nombre))
                {
                    crear.Save(path);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int Parametro)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from rol in documento.Descendants("rol")
                               where rol.Attribute("codigo").Value == Parametro.ToString()
                               select rol;
                consulta.Remove();

                documento.Save(path);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public List<BERol> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BERol> roles = new List<BERol>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        string estado = item["estado"].ToString(); //-->listo los que tengan el estado en true
                        if (estado.Equals("1"))
                        {
                            BERol rol = new BERol
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                nombre = Convert.ToString(item["nombre"]),
                                descripcion = Convert.ToString(item["descripcion"]),
                                estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                            };
                            roles.Add(rol);
                        }

                    }
                }
                return roles;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }

        public List<BERol> ListarTodos()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BERol> roles = new List<BERol>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        BERol rol = new BERol
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            nombre = Convert.ToString(item["nombre"]),
                            descripcion = Convert.ToString(item["descripcion"]),
                            estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                        };
                        roles.Add(rol);
                    }
                }
                return roles;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }

        public bool Modificar(BERol Parametro, string nombreAnterior)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from rol in documento.Descendants("rol")
                               where rol.Attribute("codigo").Value == Parametro.Codigo.ToString()
                               select rol;
                if (Parametro.nombre != nombreAnterior)
                {
                    if (VerificarExistencia(nombreAnterior))
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("descripcion").Value = Parametro.descripcion;
                        }
                        documento.Save(path);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    foreach (XElement EModifcar in consulta)
                    {
                        EModifcar.Element("descripcion").Value = Parametro.descripcion;
                    }

                    documento.Save(path);
                    return true;
                }
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        bool VerificarExistencia(string nombre)
        {
            bool resp = true;
            List<BERol> roles = Listar();

            if (roles.Count() > 0)
            {
                foreach (BERol item in roles)
                {
                    if (item.nombre == nombre)
                    {
                        resp = false;
                        break;
                    }
                }
            }
            return resp;
        }
    }
}
