using System;

namespace BE
{
    public class BEProducto : Entidad
    {
        public int codigoCategoria { get; set; }
        public string codigoBarra { get; set; }
        public string nombre { get; set; }
        public decimal precioVenta { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string imagen { get; set; }
        public bool estado { get; set; }

    }
}
