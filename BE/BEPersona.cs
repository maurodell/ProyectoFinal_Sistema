using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPersona : Entidad
    {
        public string tipoPersona { get; set; }
        public string nombre { get; set; }
        public string tipoDocumento { get; set; }
        public string documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}
