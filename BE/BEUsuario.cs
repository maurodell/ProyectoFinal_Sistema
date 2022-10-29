
using System.Collections.Generic;

namespace BE
{
    public class BEUsuario : Localizacion
    {
        public string  nombre { get; set; }
        public string tipoDocumento { get; set; }
        public string documento { get; set; }
        public string clave { get; set; }
        public bool estado { get; set; }

        public List<BEComponente> listaPermisos;

        public BEUsuario()
        {
            listaPermisos = new List<BEComponente>();
        }

        public List<BEComponente> Permisos
        {
            get
            {
                return listaPermisos;
            }
        }
    }
}
