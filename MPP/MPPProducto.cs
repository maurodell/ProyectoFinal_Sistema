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
        private string pathDetalleVenta = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\VentaDetalle.XML";
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

                if (!VerificarExistencia(Parametro.nombre))
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
                        string estado = item["estado"].ToString(); //-->va a listar los que tengan el estado en true
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
                            EModifcar.Element("descripcion").Value = Parametro.descripcion;
                            EModifcar.Element("ubicacion").Value = Parametro.ubicacion;
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
                        EModifcar.Element("descripcion").Value = Parametro.descripcion;
                        EModifcar.Element("ubicacion").Value = Parametro.ubicacion;
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
            bool resp = false;
            List<BEProducto> productos = Listar();

            if (productos.Count() > 0)
            {
                foreach (BEProducto item in productos)
                {
                    if (item.nombre == nombre)
                    {
                        resp = true;
                        break;
                    }
                }
            }
            return resp;
        }
        public List<BEProducto> MasVendido(int cantidad)
        {
            BEProducto productoConsulta;
            List<BEProducto> listaProductos = new List<BEProducto>();
            XDocument documento = XDocument.Load(pathDetalleVenta);

            var consulta = from producto in documento.Descendants("detalle")
                           select new
                           {
                               codigoProducto = producto.Element("codigoProducto").Value,
                               cantidad = Convert.ToInt32(producto.Element("cantidad").Value)
                           };
            var totales = (from x in consulta
                          group x by x.codigoProducto into codigo
                          select new
                          {
                              codProduct = codigo.Key,
                              total = codigo.Sum(c=>c.cantidad)
                          }).OrderByDescending(z=>z.total);
            foreach (var item in totales)
            {
                if (item.total >= cantidad)//desde aca manejo la cantidad que quiero que filtren como maximo de venta
                {
                    XDocument documento2 = XDocument.Load(path);

                    var devuelveProducto = from producto in documento2.Descendants("producto")
                                           where producto.Attribute("codigo").Value == item.codProduct
                                           select producto;

                    foreach (XElement EModifcar in devuelveProducto)
                    {
                        productoConsulta = new BEProducto();
                        productoConsulta.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                        productoConsulta.codigoCategoria = Convert.ToInt32(EModifcar.Element("codigoCategoria").Value);
                        productoConsulta.codigoBarra = EModifcar.Element("codigoBarra").Value;
                        productoConsulta.nombre = EModifcar.Element("nombre").Value;
                        productoConsulta.precioVenta = Convert.ToDecimal(EModifcar.Element("precioVenta").Value);
                        productoConsulta.stock = item.total;
                        productoConsulta.ubicacion = EModifcar.Element("ubicacion").Value;
                        productoConsulta.descripcion = EModifcar.Element("descripcion").Value;
                        productoConsulta.fechaVencimiento = Convert.ToDateTime(EModifcar.Element("fechaVencimiento").Value);
                        productoConsulta.imagen = EModifcar.Element("imagen").Value;
                        productoConsulta.estado = Convert.ToBoolean(Convert.ToInt32(EModifcar.Element("estado").Value));

                        listaProductos.Add(productoConsulta);
                    }
                }

            }
            return listaProductos;
        }
        public List<BEProducto> MenosVendido(int cantidad)
        {
            BEProducto productoConsulta;
            List<BEProducto> listaProductos = new List<BEProducto>();
            XDocument documento = XDocument.Load(pathDetalleVenta);

            var consulta = from producto in documento.Descendants("detalle")
                           select new
                           {
                               codigoProducto = producto.Element("codigoProducto").Value,
                               cantidad = Convert.ToInt32(producto.Element("cantidad").Value)
                           };
            var totales = (from x in consulta
                           group x by x.codigoProducto into codigo
                           select new
                           {
                               codProduct = codigo.Key,
                               total = codigo.Sum(c => c.cantidad)
                           }).OrderBy(z => z.total);
            foreach (var item in totales)
            {
                if (item.total <= cantidad)//desde aca manejo la cantidad que quiero que filtren como minimo de venta
                {
                    XDocument documento2 = XDocument.Load(path);

                    var devuelveProducto = from producto in documento2.Descendants("producto")
                                           where producto.Attribute("codigo").Value == item.codProduct
                                           select producto;

                    foreach (XElement EModifcar in devuelveProducto)
                    {
                        productoConsulta = new BEProducto();
                        productoConsulta.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                        productoConsulta.codigoCategoria = Convert.ToInt32(EModifcar.Element("codigoCategoria").Value);
                        productoConsulta.codigoBarra = EModifcar.Element("codigoBarra").Value;
                        productoConsulta.nombre = EModifcar.Element("nombre").Value;
                        productoConsulta.precioVenta = Convert.ToDecimal(EModifcar.Element("precioVenta").Value);
                        productoConsulta.stock = item.total;
                        productoConsulta.ubicacion = EModifcar.Element("ubicacion").Value;
                        productoConsulta.descripcion = EModifcar.Element("descripcion").Value;
                        productoConsulta.fechaVencimiento = Convert.ToDateTime(EModifcar.Element("fechaVencimiento").Value);
                        productoConsulta.imagen = EModifcar.Element("imagen").Value;
                        productoConsulta.estado = Convert.ToBoolean(Convert.ToInt32(EModifcar.Element("estado").Value));

                        listaProductos.Add(productoConsulta);
                    }
                }
            }
            return listaProductos;
        }
        public List<BEProducto> PorVencer(string orden)
        {
            List<BEProducto> listaProductos = Listar();
            List<BEProducto> listaFiltrada = new List<BEProducto>();
            bool flag = false;

            foreach (BEProducto item in listaProductos)
            {
                TimeSpan difDias = (item.fechaVencimiento - DateTime.Now);
                int dias = difDias.Days;
                if (orden.Equals("menos"))
                {
                    flag = true;
                }
                if (flag)
                {
                    if (dias <= 25)
                    {
                        listaFiltrada.Add(item);
                    }
                }
                else
                {
                    if (dias >= 30)
                    {
                        listaFiltrada.Add(item);
                    }
                }
            }

            return listaFiltrada.OrderBy(x=>x.fechaVencimiento).ToList();
        }
        public List<BEProducto> BajoStock()
        {
            List<BEProducto> listaProductos = Listar();
            List<BEProducto> filtrados = new List<BEProducto>();
            foreach (BEProducto item in listaProductos)
            {
                if (item.stock <= 15 && item.stock >= 0)
                {
                    filtrados.Add(item);
                }
            }
            return filtrados.OrderByDescending(x=>x.stock).ToList();
        }
        public List<BEProducto> AgruparCategoria()
        {
            List<BEProducto> listaProductos = Listar();
            return listaProductos.OrderByDescending(x => x.codigoCategoria).ToList();
        }
    }
}
