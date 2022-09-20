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
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from producto in documento.Descendants("producto")
                               where producto.Attribute("codigo").Value == Parametro.ToString()
                               select producto;

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

                var consulta = from producto in documento.Descendants("producto")
                               where producto.Attribute("codigo").Value == Parametro.ToString()
                               select producto;

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

        public List<BEProducto> Buscar(string Parametro)
        {
            try
            {
                BEProducto productBuscar;
                List<BEProducto> listaProductosDevolver = new List<BEProducto>();

                XDocument documento = XDocument.Load(path);

                var consulta = from producto in documento.Descendants("producto")
                               where producto.Element("nombre").Value.Contains(Parametro)
                               select producto;

                foreach (XElement EModifcar in consulta)
                {
                    productBuscar = new BEProducto();
                    productBuscar.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    productBuscar.codigoCategoria = Convert.ToInt32(EModifcar.Element("codigoCategoria").Value);
                    productBuscar.codigoBarra = EModifcar.Element("codigoBarra").Value;
                    productBuscar.nombre = EModifcar.Element("nombre").Value;
                    productBuscar.precioVenta = Convert.ToDecimal(EModifcar.Element("precioVenta").Value);
                    productBuscar.stock = Convert.ToInt32(EModifcar.Element("stock").Value);
                    productBuscar.descripcion = EModifcar.Element("descripcion").Value;
                    productBuscar.fechaVencimiento = Convert.ToDateTime(EModifcar.Element("fechaVencimiento").Value);
                    productBuscar.imagen = EModifcar.Element("imagen").Value;
                    productBuscar.estado = Convert.ToBoolean(Convert.ToInt32(EModifcar.Element("estado").Value));

                    listaProductosDevolver.Add(productBuscar);
                }
                return listaProductosDevolver;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
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
                                                new XElement("nombre", Parametro.nombre),
                                                new XElement("precioVenta", Parametro.precioVenta),
                                                new XElement("stock", Parametro.stock),
                                                new XElement("descripcion", Parametro.descripcion),
                                                new XElement("ubicacion", Parametro.ubicacion),
                                                new XElement("fechaVencimiento", Parametro.fechaVencimiento),
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
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from producto in documento.Descendants("producto")
                               where producto.Attribute("codigo").Value == Parametro.ToString()
                               select producto;
                consulta.Remove();

                documento.Save(path);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
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
                                fechaVencimiento = Convert.ToDateTime(item["fechaVencimiento"]),
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
                            fechaVencimiento = Convert.ToDateTime(item["fechaVencimiento"]),
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
        public bool ActualizarStock(int stock, int codigoProducto)
        {
            try
            {
                BEProducto productoAActualizar= Listar().Find(x => x.Codigo == codigoProducto);

                XDocument documento = XDocument.Load(path);

                var consulta = from producto in documento.Descendants("producto")
                               where producto.Attribute("codigo").Value == codigoProducto.ToString()
                               select producto;

                foreach (XElement EModifcar in consulta)
                {
                    EModifcar.Element("stock").Value = Convert.ToString(productoAActualizar.stock + stock);
                }
                documento.Save(path);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool Modificar(BEProducto Parametro, string nombreAnterior)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from producto in documento.Descendants("producto")
                               where producto.Attribute("codigo").Value == Parametro.Codigo.ToString()
                               select producto;
                if (Parametro.nombre != nombreAnterior)
                {
                    if (VerificarExistencia(nombreAnterior))
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("codigoCategoria").Value = Convert.ToString(Parametro.codigoCategoria);
                            EModifcar.Element("codigoBarra").Value = Parametro.codigoBarra;
                            EModifcar.Element("precioVenta").Value = Convert.ToString(Parametro.precioVenta);
                            EModifcar.Element("stock").Value = Convert.ToString(Parametro.stock);
                            EModifcar.Element("descripcion").Value = Parametro.descripcion;
                            EModifcar.Element("fechaVencimiento").Value = Convert.ToString(Parametro.fechaVencimiento);
                            EModifcar.Element("imagen").Value = Parametro.imagen;
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
                        EModifcar.Element("codigoCategoria").Value = Convert.ToString(Parametro.codigoCategoria);
                        EModifcar.Element("codigoBarra").Value = Parametro.codigoBarra;
                        EModifcar.Element("precioVenta").Value = Convert.ToString(Parametro.precioVenta);
                        EModifcar.Element("stock").Value = Convert.ToString(Parametro.stock);
                        EModifcar.Element("descripcion").Value = Parametro.descripcion;
                        EModifcar.Element("fechaVencimiento").Value = Convert.ToString(Parametro.fechaVencimiento);
                        EModifcar.Element("imagen").Value = Parametro.imagen;
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
