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
    public class MPPCompra : IRepositorio<BECompra>
    {
        private string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Compras.XML";
        private string pathDetalle = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\DetalleCompra.XML";

        private string pathProducto = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Productos.XML";
        MPPProducto mppProducto = new MPPProducto();
        MPPCategoria mppCategoria = new MPPCategoria();
        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            XDocument documento = XDocument.Load(path);

            var consulta = from compra in documento.Descendants("compra")
                           where compra.Attribute("codigo").Value == Parametro.ToString()
                           select compra;

            foreach (XElement EModifcar in consulta)
            {
                //se requiere que el estado de la compra tenga una leyenda.
                EModifcar.Element("estadoActual").Value = "Anulado";
                EModifcar.Element("estado").Value = "0";
            }
            
            documento.Save(path);
            BECompra compraActualizar = CargarCompra(Parametro);//cargo la compra con el id que mandó
            ActualizarStock(compraActualizar, true);//luego lo paso para actualizar
            return true;
        }

        public List<BECompra> Buscar(string Parametro)
        {
            //va a buscar por nroComprobante de la compra
            try
            {
                BECompra compraBuscar;
                List<BECompra> listaCompraDevolver = new List<BECompra>();

                XDocument documento = XDocument.Load(path);

                var consulta = from compra in documento.Descendants("compra")
                               where compra.Element("nroComprobante").Value.Contains(Parametro)
                               select compra;

                foreach (XElement EModifcar in consulta)
                {
                    int codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);

                    compraBuscar = new BECompra();
                    compraBuscar.Codigo = codigo;
                    compraBuscar.codigoUsuario = Convert.ToInt32(EModifcar.Element("codigoUsuario").Value);
                    compraBuscar.tipoComprobante = EModifcar.Element("tipoComprobante").Value;
                    compraBuscar.nroComprobante = EModifcar.Element("nroComprobante").Value;
                    compraBuscar.puntoVenta = EModifcar.Element("puntoVenta").Value;
                    compraBuscar.fecha = Convert.ToDateTime(EModifcar.Element("fecha").Value);
                    compraBuscar.impuesto = Convert.ToDecimal(EModifcar.Element("impuesto").Value);
                    compraBuscar.total = Convert.ToDecimal(EModifcar.Element("total").Value);
                    compraBuscar.estadoActual = EModifcar.Element("estadoActual").Value;
                    compraBuscar.estado = Convert.ToBoolean(Convert.ToInt32(EModifcar.Element("estado").Value));

                    compraBuscar.detalles = BuscarDetallePorCompra(codigo);

                    listaCompraDevolver.Add(compraBuscar);
                }
                return listaCompraDevolver;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public string BuscarCategoriaProducto(int codigoProducto)
        {
            try
            {
                string nombreCategoria = "";
                XDocument documento = XDocument.Load(pathProducto);

                var consulta = from producto in documento.Descendants("producto")
                               where producto.Attribute("codigo").Value == codigoProducto.ToString()
                               select producto;

                foreach (XElement EModifcar in consulta)
                {
                    int codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    nombreCategoria = mppCategoria.BuscarNombreCategoria(codigo);
                }
                return nombreCategoria;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool Crear(BECompra Parametro)
        {
            try
            {
                List<BECompra> compra = ListarTodos();
                int cantidadPart = compra.Count();
                int codigoCompra = (cantidadPart + 1);
                XDocument crear = XDocument.Load(path);
                crear.Element("compras").Add(new XElement("compra",
                                                new XAttribute("codigo", codigoCompra),
                                                new XElement("codigoProveedor", Parametro.codigoProveedor),
                                                new XElement("codigoUsuario", Parametro.codigoUsuario),
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
                        crearDetalle = XDocument.Load(pathDetalle);
                        crearDetalle.Element("detallecompra").Add(new XElement("detalle",
                                                        new XAttribute("codigo", (cantidad + 1)),
                                                        new XElement("codigoCompra", codigoCompra),
                                                        new XElement("codigoProducto", item.codigoProducto),
                                                        new XElement("nombreProducto", item.nombreProducto),
                                                        new XElement("codigoBarra", item.codigoBarra),
                                                        new XElement("precio", item.precio),
                                                        new XElement("cantidad", item.cantidad),
                                                        new XElement("importe", item.importe)));
                        crearDetalle.Save(pathDetalle);
                    }
                    if (ActualizarStock(Parametro, false))
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
        public List<Detalle> BuscarDetallePorCompra(int codigoCompra)
        {
            List<Detalle> listaDetalle = new List<Detalle>();

            XDocument path = XDocument.Load(pathDetalle);
            var consulta = from detalle in path.Descendants("detalle")
                           where detalle.Element("codigoCompra").Value.Equals(codigoCompra.ToString())
                           select new
                           {
                               codigo = Convert.ToInt32(detalle.Attribute("codigo").Value),
                               codigoCompra = Convert.ToInt32(detalle.Element("codigoCompra").Value),
                               codigoProducto = Convert.ToInt32(detalle.Element("codigoProducto").Value),
                               nombreProducto = Convert.ToString(detalle.Element("nombreProducto").Value),
                               codigoBarra = Convert.ToInt64(detalle.Element("codigoBarra").Value),
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
        public BECompra CargarCompra(int codigoCompra)
        {
            try
            {
                BECompra compraBuscar = null;

                XDocument documento = XDocument.Load(path);

                var consulta = from compra in documento.Descendants("compra")
                               where compra.Attribute("codigo").Value.Contains(codigoCompra.ToString())
                               select compra;

                foreach (XElement EModifcar in consulta)
                {
                    compraBuscar = new BECompra();
                    compraBuscar.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    compraBuscar.codigoProveedor = Convert.ToInt32(EModifcar.Element("codigoProveedor").Value);
                    compraBuscar.codigoUsuario = Convert.ToInt32(EModifcar.Element("codigoUsuario").Value);
                    compraBuscar.tipoComprobante = EModifcar.Element("tipoComprobante").Value;
                    compraBuscar.nroComprobante = EModifcar.Element("nroComprobante").Value;
                    compraBuscar.puntoVenta = EModifcar.Element("puntoVenta").Value;
                    compraBuscar.fecha = Convert.ToDateTime(EModifcar.Element("fecha").Value);
                    compraBuscar.impuesto = Convert.ToDecimal(EModifcar.Element("impuesto").Value);
                    compraBuscar.total = Convert.ToDecimal(EModifcar.Element("total").Value);
                    compraBuscar.estadoActual = EModifcar.Element("estadoActual").Value;
                    compraBuscar.estado = Convert.ToBoolean(Convert.ToInt32(EModifcar.Element("estado").Value));

                    compraBuscar.detalles = BuscarDetallePorCompra(codigoCompra);

                }
                return compraBuscar;
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
        public bool ActualizarStock(BECompra detalle, bool tipo)
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
                if (tipo)//si ingresa al if es una anulación de una compra por lo que se descuenta el stock agregado
                {
                    foreach (XElement EModifcar in consulta)
                    {
                        int stockActual = Convert.ToInt32(EModifcar.Element("stock").Value);

                        stockActual -= stock;
                        EModifcar.Element("stock").Value = stockActual.ToString();
                        flag = true;

                    }
                }
                else//si ingresa al else es una compra
                {
                    foreach (XElement EModifcar in consulta)
                    {
                        int stockActual = Convert.ToInt32(EModifcar.Element("stock").Value);

                        stockActual += stock;
                        EModifcar.Element("stock").Value = stockActual.ToString();
                        flag = true;
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
        public List<BECompra> ListarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from comprasBuscar in documento.Descendants("compra")
                               where Convert.ToDateTime(comprasBuscar.Element("fecha").Value) >= Convert.ToDateTime(fechaInicio.ToString("dd/MM/yyyy"))
                               && Convert.ToDateTime(comprasBuscar.Element("fecha").Value) <= Convert.ToDateTime(fechaFin.ToString("dd/MM/yyyy"))
                               select comprasBuscar;
                //------------------------

                List<BECompra> compras = new List<BECompra>();

                foreach (XElement EModifcar in consulta)
                {
                    BECompra compra = new BECompra
                    {
                        Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value),
                        codigoProveedor = Convert.ToInt32(EModifcar.Element("codigoProveedor").Value),
                        codigoUsuario = Convert.ToInt32(EModifcar.Element("codigoUsuario").Value),
                        tipoComprobante = Convert.ToString(EModifcar.Element("tipoComprobante").Value),
                        nroComprobante = Convert.ToString(EModifcar.Element("nroComprobante").Value),
                        puntoVenta = Convert.ToString(EModifcar.Element("puntoVenta").Value),
                        fecha = Convert.ToDateTime(EModifcar.Element("fecha").Value),
                        impuesto = Convert.ToDecimal(EModifcar.Element("impuesto").Value),
                        total = Decimal.Parse(EModifcar.Element("total").Value),
                        estadoActual = Convert.ToString(EModifcar.Element("estadoActual").Value),
                        estado = Convert.ToBoolean(Convert.ToInt32(EModifcar.Element("estado").Value))
                    };
                    compras.Add(compra);
                }

                return compras;
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
                DS.ReadXml(pathDetalle);

                List<Detalle> detalles = new List<Detalle>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                            Detalle detalle = new Detalle
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                codigoCompra = Convert.ToInt32(item["codigoCompra"]),
                                codigoBarra = Convert.ToInt64(item["codigoBarra"]),
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
        public List<BECompra> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BECompra> compras = new List<BECompra>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        string estado = item["estado"].ToString(); //-->listo los que tengan el estado en true
                        if (estado.Equals("1"))
                        {
                            BECompra compra = new BECompra
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                codigoProveedor = Convert.ToInt32(item["codigoProveedor"]),
                                codigoUsuario = Convert.ToInt32(item["codigoUsuario"]),
                                tipoComprobante = Convert.ToString(item["tipoComprobante"]),
                                nroComprobante = Convert.ToString(item["nroComprobante"]),
                                puntoVenta = Convert.ToString(item["puntoVenta"]),
                                fecha = Convert.ToDateTime(item["fecha"]),
                                impuesto = Convert.ToDecimal(item["impuesto"]),
                                total = Convert.ToDecimal(item["total"]),
                                estadoActual = Convert.ToString(item["estadoActual"]),
                                estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                            };
                            compras.Add(compra);
                        }

                    }
                }
                return compras;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }

        public List<BECompra> ListarTodos()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BECompra> compras = new List<BECompra>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        BECompra compra = new BECompra
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            codigoProveedor = Convert.ToInt32(item["codigoProveedor"]),
                            codigoUsuario = Convert.ToInt32(item["codigoUsuario"]),
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
                        compras.Add(compra);
                    }
                }
                return compras;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }

        public bool Modificar(BECompra Parametro, string parametro2)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from compra in documento.Descendants("compra")
                               where compra.Attribute("codigo").Value == Parametro.Codigo.ToString()
                               select compra;

                if (VerificarExistencia(parametro2))
                {
                    foreach (XElement EModifcar in consulta)
                    {
                        EModifcar.Element("codigoProveedor").Value = Convert.ToString(Parametro.codigoProveedor);
                        EModifcar.Element("codigoUsuario").Value = Convert.ToString(Parametro.codigoUsuario);
                        EModifcar.Element("tipoComprobante").Value = Parametro.tipoComprobante;
                        EModifcar.Element("nroComprobante").Value = Parametro.nroComprobante;
                        EModifcar.Element("fecha").Value = Convert.ToString(Parametro.fecha);
                        EModifcar.Element("impuesto").Value = Convert.ToString(Parametro.impuesto);
                        EModifcar.Element("total").Value = Convert.ToString(Parametro.total);
                    }
                    documento.Save(path);
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
        public BEProducto BuscarProductoCodBarra(string codBarra)
        {
            try
            {
                //Me traigo la lista de productos
                BEProducto producto = mppProducto.Listar().Find(x=>(x.codigoBarra.Equals(codBarra)));
                //verifico que me devuelva un producto
                if(producto != null)
                    return producto;

                return null;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        bool VerificarExistencia(string nrocomprobante)
        {
            bool resp = true;
            List<BECompra> compras = Listar();

            if (compras.Count() > 0)
            {
                foreach (BECompra item in compras)
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
