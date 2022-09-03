
namespace BE
{
    public class BEUsuario : Entidad
    {
        public int codigoRol { get; set; }
        public string  nombre { get; set; }
        public string tipoDocumento { get; set; }
        public string documento { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string clave { get; set; }
        public bool estado { get; set; }
    }
}
