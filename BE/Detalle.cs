using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Detalle : Entidad
    {
        //es el código de la compra o la venta, según corresponda
        public int codigoCompra { get; set; }
        public int codigoBarra { get; set; }
        public int codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal importe { get; set; }
    }
}
