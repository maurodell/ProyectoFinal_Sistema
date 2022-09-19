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
        MPPProducto mppProducto = new MPPProducto();
        public bool Alta(int Parametro)
        {
            XDocument documento = XDocument.Load(path);

            var consulta = from compra in documento.Descendants("compra")
                           where compra.Attribute("codigo").Value == Parametro.ToString()
                           select compra;

            foreach (XElement EModifcar in consulta)
            {
                EModifcar.Element("estadoActual").Value = "Activo";
                EModifcar.Element("estado").Value = "1";
            }

            documento.Save(path);
            return true;
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
            return true;
        }

        public List<BECompra> Buscar(string Parametro)
        {
            //va a buscar por nroComprobante o por nombre de proveedor.
            try
            {
                BECompra compraBuscar;
                List<BECompra> listaCompraDevolver = new List<BECompra>();

                XDocument documento = XDocument.Load(path);

                var consulta = from compra in documento.Descendants("compra")
                               where compra.Element("razonSocial").Value.Contains(Parametro) || compra.Element("nroComprobante").Value.Contains(Parametro)
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

                    //falta detalle

                    listaCompraDevolver.Add(compraBuscar);
                }
                return listaCompraDevolver;
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
                List<BECompra> compra = Listar();
                int cantidadPart = compra.Count();

                XDocument crear = XDocument.Load(path);
                crear.Element("compras").Add(new XElement("compra",
                                                new XAttribute("codigo", (cantidadPart + 1)),
                                                new XElement("codigoProveedor", Parametro.codigoProveedor),
                                                new XElement("codigoUsuario", Parametro.codigoUsuario),
                                                new XElement("tipoComprobante", Parametro.tipoComprobante),
                                                new XElement("nroComprobante", Parametro.nroComprobante),
                                                new XElement("puntoVenta", Parametro.puntoVenta),
                                                new XElement("fecha", Parametro.fecha),
                                                new XElement("impuesto", Parametro.impuesto),
                                                new XElement("total", Parametro.total),
                                                new XElement("estadoActual", Parametro.estadoActual),
                                                new XElement("estado", 1)));
                                                
                                                //falta detalle
                if (VerificarExistencia(Parametro.nroComprobante))
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
        public Detalle CrearDetalle(Detalle detalle)
        {
            return null;
        }
        public bool Eliminar(int Parametro)
        {
            throw new NotImplementedException();
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
                                //Falta detalle
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
