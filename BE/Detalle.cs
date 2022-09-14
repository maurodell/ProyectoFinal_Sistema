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
        public int codigoAsociado { get; set; }
        public int codigoProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    }
}
