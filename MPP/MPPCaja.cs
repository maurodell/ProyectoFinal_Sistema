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
    public class MPPCaja
    {
        private string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Caja.XML";
        private string pathVenta = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Venta.XML";
        private string pathCompra = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Compras.XML";
        public decimal CalcularVentas(DateTime Fecha)
        {
            List<decimal> listaTotales = new List<decimal>();
            XDocument documento = XDocument.Load(pathVenta);

            var consulta = from venta in documento.Descendants("venta")
                           where Convert.ToDateTime(venta.Element("fecha").Value) >= Convert.ToDateTime(Fecha.ToString("dd/MM/yyyy"))
                           select venta;

            foreach (XElement EModifcar in consulta)
            {
                decimal total = Convert.ToDecimal(EModifcar.Element("total").Value);
                listaTotales.Add(total);
            }
            decimal sumarTotal = .0m;
            foreach (decimal item in listaTotales)
            {
                sumarTotal += item;
            }
            return sumarTotal;
        }
        public decimal CalcularCompras(DateTime Fecha)
        {
            List<decimal> listaTotales = new List<decimal>();
            XDocument documento = XDocument.Load(pathCompra);

            var consulta = from venta in documento.Descendants("compra")
                           where Convert.ToDateTime(venta.Element("fecha").Value) >= Convert.ToDateTime(Fecha.ToString("dd/MM/yyyy"))
                           select venta;

            foreach (XElement EModifcar in consulta)
            {
                decimal total = Convert.ToDecimal(EModifcar.Element("total").Value);
                listaTotales.Add(total);
            }
            decimal sumarTotal = .0m;
            foreach (decimal item in listaTotales)
            {
                sumarTotal += item;
            }
            return sumarTotal;
        }
        public bool Crear(BECaja caja)
        {
            try
            {
                List<BECaja> cajas = ListarTodos();
                int cantidadPart = cajas.Count();
                int codigoCaja= (cantidadPart + 1);
                XDocument crear = XDocument.Load(path);
                crear.Element("cajasdiarias").Add(new XElement("caja",
                                                new XAttribute("codigo", codigoCaja),
                                                new XElement("cajaInicial", caja.cajaInicial),
                                                new XElement("ingresosVenta", caja.ingresosVenta),
                                                new XElement("egresosCompra", caja.egresosCompra),
                                                new XElement("saldoFinal", caja.saldoFinal),
                                                new XElement("codigoUsuario", caja.codigoUsuario),
                                                new XElement("fecha", caja.fecha),
                                                new XElement("estado", 1)));

                crear.Save(path);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public List<BECaja> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BECaja> cajas = new List<BECaja>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        string estado = item["estado"].ToString(); //-->listo los que tengan el estado en true
                        if (estado.Equals("1"))
                        {
                            BECaja caja = new BECaja
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                cajaInicial = Convert.ToDecimal(item["cajaInicial"]),
                                ingresosVenta = Convert.ToDecimal(item["ingresosVenta"]),
                                egresosCompra = Convert.ToDecimal(item["egresosCompra"]),
                                saldoFinal = Convert.ToDecimal(item["saldoFinal"]),
                                codigoUsuario = Convert.ToInt32(item["codigoUsuario"]),
                                fecha = Convert.ToDateTime(item["fecha"]),
                                estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                            };
                            cajas.Add(caja);
                        }

                    }
                }
                return cajas;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
        public List<BECaja> ListarTodos()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BECaja> cajas = new List<BECaja>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        BECaja caja = new BECaja
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            cajaInicial = Convert.ToDecimal(item["cajaInicial"]),
                            ingresosVenta = Convert.ToDecimal(item["ingresosVenta"]),
                            egresosCompra = Convert.ToDecimal(item["egresosCompra"]),
                            saldoFinal = Convert.ToDecimal(item["saldoFinal"]),
                            codigoUsuario = Convert.ToInt32(item["codigoUsuario"]),
                            fecha = Convert.ToDateTime(item["fecha"]),
                            estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                        };
                        cajas.Add(caja);
                    }
                }
                return cajas;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
    }
}
