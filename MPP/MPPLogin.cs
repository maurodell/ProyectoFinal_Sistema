using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using Seguridad;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using System.IO;
using System.Reflection;

namespace MPP
{
    public class MPPLogin
    {
        private string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Usuarios.XML";
        public MPPLogin()
        {
            clsEncriptado = new Encriptado();
        }
        Encriptado clsEncriptado;

        public BEUsuario ConsultarUsuario(string email, string clave)
        {
            try
            {
                BEUsuario usuarioBuscar;

                XDocument documento = XDocument.Load(path);

                string encriptado = clsEncriptado.Encriptar(clave);

                var consulta = from usuario in documento.Descendants("usuario")
                               where usuario.Element("email").Value == email && usuario.Element("clave").Value == encriptado
                               select usuario;

                usuarioBuscar = new BEUsuario();
                foreach (XElement EModifcar in consulta)
                {
                    usuarioBuscar.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    usuarioBuscar.nombre = EModifcar.Element("nombre").Value;
                    usuarioBuscar.tipoDocumento = EModifcar.Element("tipoDocumento").Value;
                    usuarioBuscar.documento = EModifcar.Element("documento").Value;
                    usuarioBuscar.telefono = EModifcar.Element("telefono").Value;
                    usuarioBuscar.email = EModifcar.Element("email").Value;
                    usuarioBuscar.clave = EModifcar.Element("clave").Value;
                    usuarioBuscar.estado = Convert.ToBoolean(Convert.ToInt32(EModifcar.Element("estado").Value));
                }
                return usuarioBuscar;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
    }
}
