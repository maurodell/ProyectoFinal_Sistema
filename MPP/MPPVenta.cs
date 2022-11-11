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
    public class MPPVenta : IRepositorio<BEVenta>
    {
        private string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Venta.XML";
        private string pathVentaDetalle = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\VentaDetalle.XML";

        private string pathProducto = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Productos.XML";
        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            XDocument documento = XDocument.Load(path);

            var consulta = from venta in documento.Descendants("ventas")
                           where venta.Attribute("codigo").Value == Parametro.ToString()
                           select venta;

            foreach (XElement EModifcar in consulta)
            {
                //se requiere que el estado de la compra tenga una leyenda.
                EModifcar.Element("estadoActual").Value = "Anulado";
                EModifcar.Element("estado").Value = "0";
            }

            documento.Save(path);
            BEVenta ventaActualizar = CargarCompra(Parametro);//cargo la compra con el id que mandó
            ActualizarStock(ventaActualizar, false);//luego lo paso para actualizar
            return true;
        }

        public List<BEVenta> Buscar(string Parametro)
        {
            //va a buscar por nroComprobante de la venta
            try
            {
                BEVenta ventaBuscar;
                List<BEVenta> listaVentaDevolver = new List<BEVenta>();

                XDocument documento = XDocument.Load(path);

                var consulta = from venta in documento.Descendants("venta")
                               where venta.Element("nroComprobante").Value.Contains(Parametro)
                               select venta;

                foreach (XElement EModifcar in consulta)
                {
                    int codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);

                    ventaBuscar = new BEVenta();
                    ventaBuscar.Codigo = codigo;
                    ventaBuscar.codigoUsuario = Convert.ToInt32(EModifcar.Element("codigoUsuario").Value);
                    ventaBuscar.codigoCliente = Convert.ToInt32(EModifcar.Element("codigoCliente").Value);
                    ventaBuscar.tipoComprobante = EModifcar.Element("tipoComprobante").Value;
                    ventaBuscar.nroComprobante = EModifcar.Element("nroComprobante").Value;
                    ventaBuscar.puntoVenta = EModifcar.Element("puntoVenta").Value;
                    ventaBuscar.fecha = Convert.ToDateTime(EModifcar.Element("fecha").Value);
                    ventaBuscar.impuesto = Convert.ToDecimal(EModifcar.Element("impuesto").Value);
                    ventaBuscar.total = Convert.ToDecimal(EModifcar.Element("total").Value);
                    ventaBuscar.estadoActual = EModifcar.Element("estadoActual").Value;
                    ventaBuscar.estado = Convert.ToBoolean(Convert.ToInt32(EModifcar.Element("estado").Value));

                    ventaBuscar.detalles = BuscarDetallePorVenta(codigo);

                    listaVentaDevolver.Add(ventaBuscar);
                }
                return listaVentaDevolver;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public bool Crear(BEVenta Parametro)
        {
            try
            {
                List<BEVenta> ventas = ListarTodos();
                int cantidadPart = ventas.Count();
                int codigoVentas = (cantidadPart + 1);
                XDocument crear = XDocument.Load(path);
                crear.Element("ventas").Add(new XElement("venta",
                                                new XAttribute("codigo", codigoVentas),
                                                new XElement("codigoUsuario", Parametro.codigoUsuario),
                                                new XElement("codigoCliente", Parametro.codigoCliente),
                                                new XElement("tipoComprobante", Parametro.tipoComprobante),
                                                new XElement("nroComprobante", Parametro.nroComprobante),
                                                new XElement("puntoVenta", Parametro.puntoVenta),
                                                new XElement("fecha", Parametro.fecha),
                                                new XElement("impuesto", Parametro.impuesto),
                                                new XElement("total", Parametro.total),
                                                new XElement("estadoActual", "Activo"),
                                                new XElement("estado", 1)));

                List<Detalle> detalle = ListarDetalle();
                int cantidad = detalle.Count();
                XDocument crearDetalle = null;

                if (VerificarExistencia(Parametro.nroComprobante))
                {
                    foreach (var item in Parametro.detalles)
                    {
                        crearDetalle = XDocument.Load(pathVentaDetalle);
                        crearDetalle.Element("detalleventas").Add(new XElement("detalle",
                                                        new XAttribute("codigo", (cantidad + 1)),
                                                        new XElement("codigoVenta", codigoVentas),
                                                        new XElement("codigoProducto", item.codigoProducto),
                                                        new XElement("nombreProducto", item.nombreProducto),
                                                        new XElement("codigoBarra", item.codigoBarra),
                                                        new XElement("precio", item.precio),
                                                        new XElement("cantidad", item.cantidad),
                                                        new XElement("importe", item.importe)));
                        crearDetalle.Save(pathVentaDetalle);
                    }
                    if (ActualizarStock(Parametro, true))
                    {
                        crear.Save(path);
                        return true;
                    }
                    return false;
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
        public bool ActualizarStock(BEVenta detalle, bool tipo)
        {
            int stock, codProducto;
            bool flag = false;
            //si tipo es true, entonces resta stock porque es un insert y si es false es una anulación de la compra lo que suma el stock
            foreach (Detalle item in detalle.detalles)
            {
                stock = item.cantidad;
                codProducto = item.codigoProducto;

                flag = ActualizarProductoStock(stock, codProducto, tipo);
                if (!flag) return flag;
            }
            return flag;
        }
        public bool ActualizarProductoStock(int stock, int codigoProducto, bool tipo)
        {
            try
            {
                XDocument documento = XDocument.Load(pathProducto);

                var consulta = from producto in documento.Descendants("producto")
                               where producto.Attribute("codigo").Value == codigoProducto.ToString()
                               select producto;
                bool flag = false;
                if (tipo)
                {
                    foreach (XElement EModifcar in consulta)
                    {
                        int stockActual = Convert.ToInt32(EModifcar.Element("stock").Value);
                        if (stockActual > stock)
                        {
                            stockActual -= stock;
                            EModifcar.Element("stock").Value = stockActual.ToString();
                            flag = true;
                        }
                    }
                }
                else
                {
                    foreach (XElement EModifcar in consulta)
                    {
                        int stockActual = Convert.ToInt32(EModifcar.Element("stock").Value);
                        if (stockActual > stock)
                        {
                            stockActual += stock;
                            EModifcar.Element("stock").Value = stockActual.ToString();
                            flag = true;
                        }
                    }
                }

                documento.Save(pathProducto);
                return flag;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public List<BEVenta> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BEVenta> ventas = new List<BEVenta>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        string estado = item["estado"].ToString(); //-->listo los que tengan el estado en true
                        if (estado.Equals("1"))
                        {
                            BEVenta venta = new BEVenta
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                codigoUsuario = Convert.ToInt32(item["codigoUsuario"]),
                                codigoCliente = Convert.ToInt32(item["codigoCliente"]),
                                tipoComprobante = Convert.ToString(item["tipoComprobante"]),
                                nroComprobante = Convert.ToString(item["nroComprobante"]),
                                puntoVenta = Convert.ToString(item["puntoVenta"]),
                                fecha = Convert.ToDateTime(item["fecha"]),
                                impuesto = Convert.ToDecimal(item["impuesto"]),
                                total = Convert.ToDecimal(item["total"]),
                                estadoActual = Convert.ToString(item["estadoActual"]),
                                estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                            };
                            ventas.Add(venta);
                        }

                    }
                }
                return ventas;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
        public List<Detalle> ListarDetalle()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(pathVentaDetalle);

                List<Detalle> detalles = new List<Detalle>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        Detalle detalle = new Detalle
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            codigoBarra = Convert.ToInt32(item["codigoBarra"]),
                            codigoProducto = Convert.ToInt32(item["codigoProducto"]),
                            nombreProducto = Convert.ToString(item["nombreProducto"]),
                            precio = Convert.ToDecimal(item["precio"]),
                            cantidad = Convert.ToInt32(item["cantidad"]),
                            importe = Convert.ToDecimal(item["importe"])
                        };
                        detalles.Add(detalle);
                    }
                }
                return detalles;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
        public List<BEVenta> ListarTodos()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BEVenta> ventas = new List<BEVenta>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        BEVenta venta = new BEVenta
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            codigoUsuario = Convert.ToInt32(item["codigoUsuario"]),
                            codigoCliente = Convert.ToInt32(item["codigoCliente"]),
                            tipoComprobante = Convert.ToString(item["tipoComprobante"]),
                            nroComprobante = Convert.ToString(item["nroComprobante"]),
                            puntoVenta = Convert.ToString(item["puntoVenta"]),
                            fecha = Convert.ToDateTime(item["fecha"]),
                            impuesto = Convert.ToDecimal(item["impuesto"]),
                            total = Convert.ToDecimal(item["total"]),
                            estadoActual = Convert.ToString(item["estadoActual"]),
                            estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                            //Falta detalle
                        };
                        ventas.Add(venta);
                    }
                }
                return ventas;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
        public List<Detalle> BuscarDetallePorVenta(int codigoVenta)
        {
            List<Detalle> listaDetalle = new List<Detalle>();

            XDocument path = XDocument.Load(pathVentaDetalle);
            var consulta = from detalle in path.Descendants("detalle")
                           where detalle.Element("codigoVenta").Value.Equals(codigoVenta.ToString())
                           select new
                           {
                               codigo = Convert.ToInt32(detalle.Attribute("codigo").Value),
                               codigoCompra = Convert.ToInt32(detalle.Element("codigoVenta").Value),
                               codigoProducto = Convert.ToInt32(detalle.Element("codigoProducto").Value),
                               nombreProducto = Convert.ToString(detalle.Element("nombreProducto").Value),
                               codigoBarra = Convert.ToInt32(detalle.Element("codigoBarra").Value),
                               precio = Convert.ToDecimal(detalle.Element("precio").Value),
                               cantidad = Convert.ToInt32(detalle.Element("cantidad").Value),
                               importe = Convert.ToDecimal(detalle.Element("importe").Value)
                           };
            Detalle detalleCompra;
            foreach (var item in consulta)
            {
                detalleCompra = new Detalle();
                detalleCompra.Codigo = item.codigo;
                detalleCompra.codigoBarra = item.codigoBarra;
                detalleCompra.codigoCompra = item.codigoCompra;
                detalleCompra.codigoProducto = item.codigoProducto;
                detalleCompra.nombreProducto = item.nombreProducto.ToString();
                detalleCompra.cantidad = item.cantidad;
                detalleCompra.precio = item.precio;
                detalleCompra.importe = item.importe;
                listaDetalle.Add(detalleCompra);
            }
            return listaDetalle;
        }
        public BEVenta CargarCompra(int codigoVenta)
        {
            try
            {
                BEVenta ventaBuscar = null;

                XDocument documento = XDocument.Load(path);

                var consulta = from venta in documento.Descendants("venta")
                               where venta.Attribute("codigo").Value.Contains(codigoVenta.ToString())
                               select venta;

                foreach (XElement EModifcar in consulta)
                {
                    ventaBuscar = new BEVenta();
                    ventaBuscar.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    ventaBuscar.codigoUsuario = Convert.ToInt32(EModifcar.Element("codigoUsuario").Value);
                    ventaBuscar.codigoCliente = Convert.ToInt32(EModifcar.Element("codigoCliente").Value);
                    ventaBuscar.tipoComprobante = EModifcar.Element("tipoComprobante").Value;
                    ventaBuscar.nroComprobante = EModifcar.Element("nroComprobante").Value;
                    ventaBuscar.puntoVenta = EModifcar.Element("puntoVenta").Value;
                    ventaBuscar.fecha = Convert.ToDateTime(EModifcar.Element("fecha").Value);
                    ventaBuscar.impuesto = Convert.ToDecimal(EModifcar.Element("impuesto").Value);
                    ventaBuscar.total = Convert.ToDecimal(EModifcar.Element("total").Value);
                    ventaBuscar.estadoActual = EModifcar.Element("estadoActual").Value;
                    ventaBuscar.estado = Convert.ToBoolean(Convert.ToInt32(EModifcar.Element("estado").Value));

                    ventaBuscar.detalles = BuscarDetallePorVenta(codigoVenta);

                }
                return ventaBuscar;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool Modificar(BEVenta Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
        bool VerificarExistencia(string nrocomprobante)
        {
            bool resp = true;
            List<BEVenta> ventas = Listar();

            if (ventas.Count() > 0)
            {
                foreach (BEVenta item in ventas)
                {
                    if (item.nroComprobante == nrocomprobante)
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
