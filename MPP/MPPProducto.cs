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
    public class MPPProducto : IRepositorio<BEProducto>
    {
        private string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Productos.XML";
        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            throw new NotImplementedException();
        }

        public List<BEProducto> Buscar(string Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Crear(BEProducto Parametro)
        {
            try
            {
                List<BEProducto> productos = Listar();
                int cantidadPart = productos.Count();

                XDocument crear = XDocument.Load(path);
                crear.Element("productos").Add(new XElement("producto",
                                                new XAttribute("codigo", (cantidadPart + 1)),
                                                new XElement("codigoCategoria", Parametro.codigoCategoria),
                                                new XElement("codigoBarra", Parametro.codigoBarra),
                                                new XElement("nombre", Parametro.nombre), //para pasar el código del juego que se agrega último
                                                new XElement("precioVenta", Parametro.precioVenta),
                                                new XElement("stock", Parametro.stock),
                                                new XElement("descripcion", Parametro.descripcion),
                                                new XElement("ubicacion", Parametro.ubicacion),
                                                new XElement("imagen", Parametro.imagen),
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
            throw new NotImplementedException();
        }

        public List<BEProducto> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BEProducto> productos = new List<BEProducto>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        string estado = item["estado"].ToString(); //-->listo los que tengan el estado en true
                        if (estado.Equals("1"))
                        {
                            BEProducto producto = new BEProducto
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                codigoCategoria = Convert.ToInt32(item["codigoCategoria"]),
                                codigoBarra = Convert.ToString(item["codigoBarra"]),
                                nombre = Convert.ToString(item["nombre"]),
                                precioVenta = Convert.ToDecimal(item["precioVenta"]),
                                stock = Convert.ToInt32(item["stock"]),
                                descripcion = Convert.ToString(item["descripcion"]),
                                ubicacion = Convert.ToString(item["ubicacion"]),
                                imagen = Convert.ToString(item["imagen"]),
                                estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                            };
                            productos.Add(producto);
                        }

                    }
                }
                return productos;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }

        public List<BEProducto> ListarTodos()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BEProducto> productos = new List<BEProducto>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        BEProducto producto = new BEProducto
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            codigoCategoria = Convert.ToInt32(item["codigoCategoria"]),
                            codigoBarra = Convert.ToString(item["codigoBarra"]),
                            nombre = Convert.ToString(item["nombre"]),
                            precioVenta = Convert.ToDecimal(item["precioVenta"]),
                            stock = Convert.ToInt32(item["stock"]),
                            descripcion = Convert.ToString(item["descripcion"]),
                            ubicacion = Convert.ToString(item["ubicacion"]),
                            imagen = Convert.ToString(item["imagen"]),
                            estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                        };
                        productos.Add(producto);
                    }
                }
                return productos;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }

        public bool Modificar(BEProducto Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
        bool VerificarExistencia(string nombre)
        {
            bool resp = true;
            List<BEProducto> productos = Listar();

            if (productos.Count() > 0)
            {
                foreach (BEProducto item in productos)
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
