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
    public class BLLCompra : IRepositorio<BECompra>
    {
        public BLLCompra()
        {
            mppCompra = new MPPCompra();
        }
        MPPCompra mppCompra;
        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            return mppCompra.Baja(Parametro);
        }

        public List<BECompra> Buscar(string Parametro)
        {
            return mppCompra.Buscar(Parametro);
        }
        public BEProducto BuscarProductoCodBarra(string Parametro)
        {
            return mppCompra.BuscarProductoCodBarra(Parametro);
        }
        public string BuscarCategoriaProducto(int codigoProducto)
        {
            return mppCompra.BuscarCategoriaProducto(codigoProducto);
        }
        public bool Crear(BECompra Parametro)
        {
            return mppCompra.Crear(Parametro);
        }
        public BECompra CargarCompra(int codigoCompra)
        {
            return mppCompra.CargarCompra(codigoCompra);
        }
        public bool Eliminar(int Parametro)
        {
            throw new NotImplementedException();
        }
        public List<BECompra> ListarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return mppCompra.ListarPorFecha(fechaInicio, fechaFin);
        }
        public List<BECompra> Listar()
        {
            return mppCompra.Listar();
        }

        public List<BECompra> ListarTodos()
        {
            return mppCompra.ListarTodos();
        }

        public bool Modificar(BECompra Parametro, string parametro2)
        {
            return mppCompra.Modificar(Parametro, parametro2);
        }
        public string DevolverNombre(int codigoProveedor)
        {
            return mppCompra.DevolverNombre(codigoProveedor);
        }
        public List<BEProducto> ListarProductosPorProveedor(int codigoProveedor)
        {
            return mppCompra.ListarProductosPorProveedor(codigoProveedor);
        }
    }
}
