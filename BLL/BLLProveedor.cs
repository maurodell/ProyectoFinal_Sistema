using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstraccion;

namespace BLL
{
    public class BLLProveedor : IRepositorio<BEProveedor>
    {
        public BLLProveedor()
        {
            mppProveedor = new MPPProveedor();
        }
        MPPProveedor mppProveedor;
        BEProveedor proveedor;
        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            throw new NotImplementedException();
        }

        public List<BEProveedor> Buscar(string Parametro)
        {
            return mppProveedor.Buscar(Parametro);
        }

        public bool Crear(BEProveedor Parametro)
        {
            throw new NotImplementedException();
        }
        public bool Crear(string condicion, string razonSocial, string cuit,
                    string provincia, string domicilio, string telefono, string email)
        {
            proveedor = new BEProveedor();
            proveedor.condicion = condicion;
            proveedor.razonSocial = razonSocial;
            proveedor.cuit = cuit;
            proveedor.provincia = provincia;
            proveedor.domicilio = domicilio;
            proveedor.telefono = telefono;
            proveedor.email = email;

            return mppProveedor.Crear(proveedor);
        }

        public bool Eliminar(int Parametro)
        {
            return mppProveedor.Eliminar(Parametro);
        }

        public List<BEProveedor> Listar()
        {
            return mppProveedor.Listar();
        }

        public List<BEProveedor> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BEProveedor Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
        public bool Modificar(int codigo, string condicion, string razonSocial, string cuit,
                    string provincia, string domicilio, string telefono, string email, string cuitAnterior)
        {
            proveedor = new BEProveedor();
            proveedor.Codigo = codigo;
            proveedor.condicion = condicion;
            proveedor.razonSocial = razonSocial;
            proveedor.cuit = cuit;
            proveedor.provincia = provincia;
            proveedor.domicilio = domicilio;
            proveedor.telefono = telefono;
            proveedor.email = email;

            return mppProveedor.Modificar(proveedor, cuitAnterior);
        }
    }
}
