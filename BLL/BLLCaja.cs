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
    public class BLLCaja : IRepositorio<BECaja>
    {
        public BLLCaja()
        {
            mppCaja = new MPPCaja();
        }
        MPPCaja mppCaja;
        public decimal CalcularVentas(DateTime Fecha)
        {
            return mppCaja.CalcularVentas(Fecha);
        }
        public decimal CalcularCompras(DateTime Fecha)
        {
            return mppCaja.CalcularCompras(Fecha);
        }
        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            throw new NotImplementedException();
        }

        public List<BECaja> Buscar(string Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Crear(BECaja Parametro)
        {
            return mppCaja.Crear(Parametro);
        }
        public bool Eliminar(int Parametro)
        {
            throw new NotImplementedException();
        }

        public List<BECaja> Listar()
        {
            return mppCaja.Listar();
        }

        public List<BECaja> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BECaja Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
    }
}
