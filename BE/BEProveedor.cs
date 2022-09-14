using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEProveedor : Localizacion
    {
        public string condicion { get; set; }
        public string razonSocial { get; set; }
        public string cuit { get; set; }
        public string provincia { get; set; }
    }
}
