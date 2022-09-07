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
    public class BLLPersona : IRepositorio<BEPersona>
    {
        public BLLPersona()
        {
            mppPersonas = new MPPPersona();
        }
        MPPPersona mppPersonas;
        BEPersona persona;

        public bool Crear(string tipoPersona, string nombre, string tipoDocumento,
                            string documento, string direccion, string telefono, string email)
        {
            persona = new BEPersona();
            persona.tipoPersona = tipoPersona;
            persona.nombre = nombre;
            persona.tipoDocumento = tipoDocumento;
            persona.documento = documento;
            persona.direccion = direccion;
            persona.telefono = telefono;
            persona.email = email;

            return mppPersonas.Crear(persona);
        }

        public bool Baja(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool ModificarProveedor(int codigo, string tipoPersona, string nombre, string tipoDocumento,
                            string documento, string direccion, string telefono, string email, string emailAnterior)
        {
            persona = new BEPersona();
            persona.Codigo = codigo;
            persona.tipoPersona = tipoPersona;
            persona.nombre = nombre;
            persona.tipoDocumento = tipoDocumento;
            persona.documento = documento;
            persona.direccion = direccion;
            persona.telefono = telefono;
            persona.email = email;

            return mppPersonas.ModificarProveedor(persona, emailAnterior);
        }
        public bool ModificarCliente(int codigo, string tipoPersona, string nombre, string tipoDocumento,
                    string documento, string direccion, string telefono, string email, string emailAnterior)
        {
            persona = new BEPersona();
            persona.Codigo = codigo;
            persona.tipoPersona = tipoPersona;
            persona.nombre = nombre;
            persona.tipoDocumento = tipoDocumento;
            persona.documento = documento;
            persona.direccion = direccion;
            persona.telefono = telefono;
            persona.email = email;

            return mppPersonas.ModificarCliente(persona, emailAnterior);
        }
        public bool Eliminar(int Parametro)
        {
            throw new NotImplementedException();
        }
        public bool Eliminar(int Parametro, string tipoPersona)
        {
            return mppPersonas.Eliminar(Parametro, tipoPersona);
        }
        public List<BEPersona> Listar()
        {
            throw new NotImplementedException();
        }
        public List<BEPersona> ListarProveedor()
        {
            return mppPersonas.ListarProveedores();
        }
        public List<BEPersona> ListarCliente()
        {
            return mppPersonas.ListarClientes();
        }

        public List<BEPersona> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public List<BEPersona> Buscar(string Parametro)
        {
            throw new NotImplementedException();
        }
        public List<BEPersona> BuscarProveedor(string Parametro)
        {
            return mppPersonas.BuscarProveedores(Parametro);
        }
        public List<BEPersona> BuscarCliente(string Parametro)
        {
            return mppPersonas.BuscarClientes(Parametro);
        }

        public bool Crear(BEPersona Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BEPersona Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
    }
}
