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
    public class BLLUsuario : IRepositorio<BEUsuario>
    {
        public BLLUsuario()
        {
            mppUsuario = new MPPUsuario();
        }
        MPPUsuario mppUsuario;
        BEUsuario usuario;
        public bool Alta(int Parametro)
        {
            return mppUsuario.Alta(Parametro);
        }

        public bool Baja(int Parametro)
        {
            return mppUsuario.Baja(Parametro);
        }

        public List<BEUsuario> Buscar(string Parametro)
        {
            return mppUsuario.Buscar(Parametro);
        }
        public BEUsuario BuscarUsuario(string Parametro)
        {
            return mppUsuario.BuscarUsuario(Parametro);
        }
        public bool Crear(string nombre, string tipoDocumento, string domicilio, 
                            string documento, string telefono, string email, string clave)
        {
            Encriptado encriptar = new Encriptado();

            usuario = new BEUsuario();
            usuario.nombre = nombre;
            usuario.tipoDocumento = tipoDocumento;
            usuario.documento = documento;
            usuario.domicilio = domicilio;
            usuario.telefono = telefono;
            usuario.email = email;

            usuario.clave = encriptar.Encriptar(clave);

            return mppUsuario.Crear(usuario);
        }
        public bool Crear(BEUsuario Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int Parametro)
        {
            return mppUsuario.Eliminar(Parametro);
        }

        public List<BEUsuario> Listar()
        {
            return mppUsuario.Listar();
        }

        public List<BEUsuario> ListarTodos()
        {
            return mppUsuario.ListarTodos();
        }
        public bool Modificar(BEUsuario Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
        public bool Modificar(int codigo, string nombre, string tipoDocumento,
                            string documento, string domicilio, string telefono, string email, string emailAnterior)
        {
            usuario = new BEUsuario();
            usuario.Codigo = codigo;
            usuario.nombre = nombre;
            usuario.tipoDocumento = tipoDocumento;
            usuario.documento = documento;
            usuario.domicilio = domicilio;
            usuario.telefono = telefono;
            usuario.email = email;

            return mppUsuario.Modificar(usuario, emailAnterior);
        }
    }
}
