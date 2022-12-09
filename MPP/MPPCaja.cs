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
                XDocument crear = XDocument.Load(path);
                crear.Element("cajasdiarias").Add(new XElement("caja",
                                                new XAttribute("nro", caja.Codigo),
                                                new XElement("fechaApertura", caja.fechaApertura),
                                                new XElement("fechaCierre", caja.fechaCierre),
                                                new XElement("saldoInicial", caja.saldoInicial),
                                                new XElement("saldoDeposito", caja.saldoDeposito),
                                                new XElement("saldoSalida", caja.saldoSalida),
                                                new XElement("saldoVentas", caja.saldoVentas),
                                                new XElement("saldoCompras", caja.saldoCompras),
                                                new XElement("saldoFaltante", caja.saldoFaltante),
                                                new XElement("saldoFinal", caja.saldoFinal),
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
                                Codigo = Convert.ToInt32(item["nro"]),
                                fechaApertura = Convert.ToDateTime(item["fechaApertura"]),
                                fechaCierre = Convert.ToDateTime(item["fechaCierre"]),
                                saldoInicial = Convert.ToDecimal(item["saldoInicial"]),
                                saldoDeposito = Convert.ToDecimal(item["saldoDeposito"]),
                                saldoSalida = Convert.ToDecimal(item["saldoSalida"]),
                                saldoVentas = Convert.ToDecimal(item["saldoVentas"]),
                                saldoCompras = Convert.ToDecimal(item["saldoCompras"]),
                                saldoFaltante = Convert.ToDecimal(item["saldoFaltante"]),
                                saldoFinal = Convert.ToDecimal(item["saldoFinal"]),
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
                            Codigo = Convert.ToInt32(item["nro"]),
                            fechaApertura = Convert.ToDateTime(item["fechaApertura"]),
                            fechaCierre = Convert.ToDateTime(item["fechaCierre"]),
                            saldoInicial = Convert.ToDecimal(item["saldoInicial"]),
                            saldoDeposito = Convert.ToDecimal(item["saldoDeposito"]),
                            saldoSalida = Convert.ToDecimal(item["saldoSalida"]),
                            saldoVentas = Convert.ToDecimal(item["saldoVentas"]),
                            saldoCompras = Convert.ToDecimal(item["saldoCompras"]),
                            saldoFaltante = Convert.ToDecimal(item["saldoFaltante"]),
                            saldoFinal = Convert.ToDecimal(item["saldoFinal"]),
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
