using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstraccion;

namespace BLL
{
    public class BLLVenta : IRepositorio<BEVenta>
    {
        public BLLVenta()
        {
            mppVenta = new MPPVenta();
        }
        MPPVenta mppVenta;
        BEVenta beVenta;
        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            throw new NotImplementedException();
        }

        public List<BEVenta> Buscar(string Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Crear(BEVenta Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int Parametro)
        {
            throw new NotImplementedException();
        }

        public List<BEVenta> Listar()
        {
            throw new NotImplementedException();
        }

        public List<BEVenta> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BEVenta Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
    }
}
