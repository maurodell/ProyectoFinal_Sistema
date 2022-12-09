using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECaja : Entidad
    {
        public DateTime fechaApertura { get; set; }
        public DateTime fechaCierre { get; set; }
        public decimal saldoInicial { get; set; }
        public decimal saldoDeposito { get; set; }
        public decimal saldoSalida { get; set; }
        public decimal saldoVentas { get; set; }
        public decimal saldoCompras { get; set; }
        public decimal saldoFaltante { get; set; }
        public decimal saldoFinal { get; set; }
        public bool estado { get; set; }
    }
}
