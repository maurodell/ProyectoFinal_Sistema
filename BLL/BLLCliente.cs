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
            mppCliente = new MPPCliente();
        }
        MPPCliente mppCliente;
        BECliente cliente;

        public bool Crear(string nombre, string tipoDocumento,
                            string documento, string domicilio, string telefono, string email)
        {
            cliente = new BECliente();
            cliente.nombre = nombre;
            cliente.tipoDocumento = tipoDocumento;
            cliente.documento = documento;
            cliente.domicilio = domicilio;
            cliente.telefono = telefono;
            cliente.email = email;

            return mppCliente.Crear(cliente);
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
            cliente = new BECliente();
            cliente.Codigo = codigo;
            cliente.nombre = nombre;
            cliente.tipoDocumento = tipoDocumento;
            cliente.documento = documento;
            cliente.domicilio = domicilio;
            cliente.telefono = telefono;
            cliente.email = email;

            return mppCliente.Modificar(cliente, emailAnterior);
        }
        public bool Eliminar(int Parametro)
        {
            return mppCliente.Eliminar(Parametro);
        }
        public List<BECliente> Listar()
        {
            return mppCliente.Listar();
        }

        public List<BECliente> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public List<BECliente> Buscar(string Parametro)
        {
            return mppCliente.Buscar(Parametro);
        }
        public string DevolverNombre(int codigoUsuario)
        {
            return mppCliente.DevolverNombre(codigoUsuario);
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
