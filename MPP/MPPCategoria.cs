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

namespace MPP
{
    public class MPPCategoria : IRepositorio<Categoria>
    {
        public bool Alta(int Parametro)
        {
            try
            {
                XDocument documento = XDocument.Load("Categorias.XML");

                var consulta = from categoria in documento.Descendants("categoria")
                               where categoria.Element("codigo").Value == Parametro.ToString()
                               select categoria;

                foreach (XElement EModifcar in consulta)
                {
                    EModifcar.Element("estado").Value = "1";
                }

                documento.Save("Categorias.XML");
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
                XDocument documento = XDocument.Load("Categorias.XML");

                var consulta = from categoria in documento.Descendants("categoria")
                               where categoria.Element("codigo").Value == Parametro.ToString()
                               select categoria;

                foreach (XElement EModifcar in consulta)
                {
                    EModifcar.Element("estado").Value = "0";
                }

                documento.Save("Categorias.XML");
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public bool Crear(Categoria Parametro)
        {
            try
            {
                List<Categoria> categorias = Listar();
                int cantidadPart = categorias.Count();

                XDocument crear = XDocument.Load("Categorias.XML");
                crear.Element("categorias").Add(new XElement("categoria",
                                                new XAttribute("codigo", (cantidadPart + 1)),
                                                new XElement("nombre", Parametro.nombre), //para pasar el código del juego que se agrega último
                                                new XElement("descripcion", Parametro.descripcion),
                                                new XElement("estado", 1)));
                
                if(VerificarExistencia(Parametro.nombre))
                {
                    crear.Save("Categorias.XML");
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
                XDocument documento = XDocument.Load("Categorias.XML");

                var consulta = from categoria in documento.Descendants("categoria")
                               where categoria.Element("codigo").Value == Parametro.ToString()
                               select categoria;
                consulta.Remove();

                documento.Save("Categorias.XML");
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public List<Categoria> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml("Categorias.XML");

                List<Categoria> categorias = new List<Categoria>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        string estado = item["estado"].ToString(); //-->listo los que tengan el estado en true
                        if (estado.Equals("1"))
                        {
                            Categoria categoria = new Categoria
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                nombre = Convert.ToString(item["nombre"]),
                                descripcion = Convert.ToString(item["descripcion"]),
                                estado = Convert.ToBoolean(item["estado"])
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

        public List<Categoria> Buscar(Categoria Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Categoria Parametro)
        {
            try
            {
                XDocument documento = XDocument.Load("Categorias.XML");

                var consulta = from categoria in documento.Descendants("categoria")
                               where categoria.Element("codigo").Value == Parametro.Codigo.ToString()
                               select categoria;

                foreach (XElement EModifcar in consulta)
                {
                    EModifcar.Element("nombre").Value = Parametro.nombre;
                    EModifcar.Element("descripcion").Value = Parametro.descripcion;
                }
                if (VerificarExistencia(Parametro.nombre))
                {
                    documento.Save("Categorias.XML");
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
        bool VerificarExistencia(string nombre)
        {
            bool resp = true;
            List<Categoria> categorias = Listar();

            if (categorias.Count() > 0)
            {
                foreach (Categoria item in categorias)
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
