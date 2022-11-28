using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECaja : Entidad
    {
        public decimal cajaInicial { get; set; }
        public decimal ingresosVenta { get; set; }
        public decimal egresosCompra { get; set; }
        public decimal saldoFinal { get; set; }
        public int codigoUsuario { get; set; }
        public DateTime fecha { get; set; }
        public bool estado { get; set; }
    }
}
