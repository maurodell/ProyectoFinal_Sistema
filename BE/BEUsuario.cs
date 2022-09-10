
namespace BE
{
    public class BEUsuario : Localizacion
    {
        public int codigoRol { get; set; }
        public string  nombre { get; set; }
        public string tipoDocumento { get; set; }
        public string documento { get; set; }
        public string clave { get; set; }
        public bool estado { get; set; }
    }
}
