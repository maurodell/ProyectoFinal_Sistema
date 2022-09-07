using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstraccion;
using Seguridad;

namespace BLL
{
    public class BLLLogin
    {
        public BLLLogin()
        {
            mppLogin = new MPPLogin();
        }
        MPPLogin mppLogin;
        static BEUsuario beUsuario;

        public BEUsuario GetUsuario()
        {
            return beUsuario;
        }

        public bool Logueado(string email, string clave)
        {
            beUsuario = mppLogin.ConsultarUsuario(email, clave);

            bool flag = false;

            if (beUsuario.email != null && beUsuario.clave != null)
            {
                flag = true;
                return flag;
            }
            return flag;
        }
        public bool UsuarioActivo()
        {
            return beUsuario.estado == true ? true : false;
        }
    }
}
