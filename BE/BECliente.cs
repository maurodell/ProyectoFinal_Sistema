using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECliente : Localizacion
    {
        public string nombre { get; set; }
        public string tipoDocumento { get; set; }
        public string documento { get; set; }
    }
}
