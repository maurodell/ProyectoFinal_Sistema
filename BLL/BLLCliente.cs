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
    public class BLLCliente : IRepositorio<BECliente>
    {
        public BLLCliente()
        {
            mppPersonas = new MPPCliente();
        }
        MPPCliente mppPersonas;
        BECliente persona;

        public bool Crear(string nombre, string tipoDocumento,
                            string documento, string domicilio, string telefono, string email)
        {
            persona = new BECliente();
            persona.nombre = nombre;
            persona.tipoDocumento = tipoDocumento;
            persona.documento = documento;
            persona.domicilio = domicilio;
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

        public bool Modificar(int codigo, string nombre, string tipoDocumento,
                            string documento, string domicilio, string telefono, string email, string emailAnterior)
        {
            persona = new BECliente();
            persona.Codigo = codigo;
            persona.nombre = nombre;
            persona.tipoDocumento = tipoDocumento;
            persona.documento = documento;
            persona.domicilio = domicilio;
            persona.telefono = telefono;
            persona.email = email;

            return mppPersonas.Modificar(persona, emailAnterior);
        }
        public bool Eliminar(int Parametro)
        {
            return mppPersonas.Eliminar(Parametro);
        }
        public List<BECliente> Listar()
        {
            return mppPersonas.Listar();
        }

        public List<BECliente> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public List<BECliente> Buscar(string Parametro)
        {
            return mppPersonas.Buscar(Parametro);
        }
        public bool Crear(BECliente Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BECliente Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
    }
}
