using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBackup : Entidad
    {
        public string nombreUsuario { get; set; }
        public int codigoUsuario { get; set; }
        public DateTime fecha { get; set; }
    }
}
