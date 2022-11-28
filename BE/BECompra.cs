using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECompra : Entidad
    {
        public int codigoProveedor { get; set; }
        public int codigoUsuario { get; set; }
        public string tipoComprobante { get; set; }
        public string puntoVenta { get; set; }
        public string nroComprobante { get; set; }
        public DateTime fecha { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }
        public string estadoActual { get; set; }
        public bool estado { get; set; }
        public List<Detalle> detalles { get; set; }
    }
}
