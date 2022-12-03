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
    public class BLLProducto : IRepositorio<BEProducto>
    {
        public BLLProducto()
        {
            mppProducto = new MPPProducto();
        }
        MPPProducto mppProducto;
        public bool Alta(int Parametro)
        {
            return mppProducto.Alta(Parametro);
        }

        public bool Baja(int Parametro)
        {
            return mppProducto.Baja(Parametro);
        }

        public List<BEProducto> Buscar(string Parametro)
        {
            return mppProducto.Buscar(Parametro);
        }

        public bool Crear(BEProducto Parametro)
        {
            return mppProducto.Crear(Parametro);
        }
        public bool Eliminar(int Parametro)
        {
            return mppProducto.Eliminar(Parametro);
        }

        public List<BEProducto> Listar()
        {
            return mppProducto.Listar();
        }

        public List<BEProducto> ListarTodos()
        {
            return mppProducto.ListarTodos();
        }
        public bool Modificar(BEProducto Parametro, string parametro2)
        {
            return mppProducto.Modificar(Parametro, parametro2);
        }
        public List<BEProducto> MasVendido(int cantidad)
        {
            return mppProducto.MasVendido(cantidad);
        }
        public List<BEProducto> MenosVendido(int cantidad)
        {
            return mppProducto.MenosVendido(cantidad);
        }
        public List<BEProducto> PorVencer(string orden)
        {
            return mppProducto.PorVencer(orden);
        }
        public List<BEProducto> BajoStock()
        {
            return mppProducto.BajoStock();
        }
        public List<BEProducto> AgruparCategoria()
        {
            return mppProducto.AgruparCategoria();
        }
    }
}
