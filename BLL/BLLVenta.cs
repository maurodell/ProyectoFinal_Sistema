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
        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            return mppVenta.Baja(Parametro);
        }

        public List<BEVenta> Buscar(string Parametro)
        {
            return mppVenta.Buscar(Parametro);
        }
        public string BuscarCategoriaProducto(int codigoProducto)
        {
            return mppVenta.BuscarCategoriaProducto(codigoProducto);
        }
        public bool Eliminar(int Parametro)
        {
            throw new NotImplementedException();
        }
        public List<BEVenta> ListarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return mppVenta.ListarPorFecha(fechaInicio, fechaFin);
        }
            public List<BEVenta> Listar()
        {
            return mppVenta.Listar();
        }

        public List<BEVenta> ListarTodos()
        {
            return mppVenta.ListarTodos();
        }

        public bool Modificar(BEVenta Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
        public BEProducto BuscarProductoCodBarra(string Parametro)
        {
            return mppVenta.BuscarProductoCodBarra(Parametro);
        }
        public BEVenta CargarVenta(int codigoCompra)
        {
            return mppVenta.CargarVenta(codigoCompra);
        }
        public bool Crear(BEVenta Parametro)
        {
            return mppVenta.Crear(Parametro);
        }
    }
}
