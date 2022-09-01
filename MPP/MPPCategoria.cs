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
    public class MPPCategoria : IRepositorio<BECategoria>
    {
        private string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)+"\\archivos_xml"+"\\Categorias.XML";

        public bool Alta(int Parametro)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from categoria in documento.Descendants("categoria")
                               where categoria.Attribute("codigo").Value == Parametro.ToString()
                               select categoria;

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

                var consulta = from categoria in documento.Descendants("categoria")
                               where categoria.Attribute("codigo").Value == Parametro.ToString()
                               select categoria;

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

        public bool Crear(BECategoria Parametro)
        {
            try
            {
                List<BECategoria> categorias = Listar();
                int cantidadPart = categorias.Count();

                XDocument crear = XDocument.Load(path);
                crear.Element("categorias").Add(new XElement("categoria",
                                                new XAttribute("codigo", (cantidadPart + 1)),
                                                new XElement("nombre", Parametro.nombre), //para pasar el código del juego que se agrega último
                                                new XElement("descripcion", Parametro.descripcion),
                                                new XElement("estado", 1)));
                
                if(VerificarExistencia(Parametro.nombre))
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

                var consulta = from categoria in documento.Descendants("categoria")
                               where categoria.Attribute("codigo").Value == Parametro.ToString()
                               select categoria;
                consulta.Remove();

                documento.Save(path);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public List<BECategoria> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BECategoria> categorias = new List<BECategoria>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        string estado = item["estado"].ToString(); //-->listo los que tengan el estado en true
                        if (estado.Equals("1"))
                        {
                            BECategoria categoria = new BECategoria
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                nombre = Convert.ToString(item["nombre"]),
                                descripcion = Convert.ToString(item["descripcion"]),
                                estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                            };
                            categorias.Add(categoria);
                        }

                    }
                }
                return categorias;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
        public List<BECategoria> ListarTodos()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BECategoria> categorias = new List<BECategoria>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {

                        BECategoria categoria = new BECategoria
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            nombre = Convert.ToString(item["nombre"]),
                            descripcion = Convert.ToString(item["descripcion"]),
                            estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                        };
                        categorias.Add(categoria);
                    }
                }
                return categorias;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }

        public List<BECategoria> Buscar(String Parametro)
        {
            try
            {
                BECategoria catBuscar;
                List<BECategoria> listaCategoriaDevolver = new List<BECategoria>();

                XDocument documento = XDocument.Load(path);

                var consulta = from categoria in documento.Descendants("categoria")
                               where categoria.Element("nombre").Value.Contains(Parametro)
                               select categoria;

                foreach (XElement EModifcar in consulta)
                {
                    catBuscar = new BECategoria();
                    catBuscar.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    catBuscar.nombre = EModifcar.Element("nombre").Value;
                    catBuscar.descripcion = EModifcar.Element("descripcion").Value;

                    listaCategoriaDevolver.Add(catBuscar);
                }
                return listaCategoriaDevolver;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public bool Modificar(BECategoria Parametro, string nombreAnterior)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from categoria in documento.Descendants("categoria")
                               where categoria.Attribute("codigo").Value == Parametro.Codigo.ToString()
                               select categoria;
                if (Parametro.nombre != nombreAnterior)
                {
                    if (VerificarExistencia(Parametro.nombre))
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
            List<BECategoria> categorias = Listar();

            if (categorias.Count() > 0)
            {
                foreach (BECategoria item in categorias)
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
