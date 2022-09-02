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
        BEProducto BEproducto;
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
            throw new NotImplementedException();
        }
        public bool Insertar(int codigoCategoria, string codigoBarra, string nombre, decimal precioVenta, int stock, string descripcion, string ubicacion, DateTime fechaVencimiento, string imagen)
        {
            BEproducto = new BEProducto();
            BEproducto.codigoCategoria = codigoCategoria;
            BEproducto.codigoBarra = codigoBarra;
            BEproducto.nombre = nombre;
            BEproducto.precioVenta = precioVenta;
            BEproducto.stock = stock;
            BEproducto.descripcion = descripcion;
            BEproducto.ubicacion = ubicacion;
            BEproducto.fechaVencimiento = fechaVencimiento;
            BEproducto.imagen = imagen;

            return mppProducto.Crear(BEproducto);
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
        public bool Modificar(int codigo, string nombreAnterior, int codigoCategoria, string codigoBarra, decimal precioVenta, int stock, string nombre, string descripcion, string ubicacion, string imagen)
        {
            BEproducto = new BEProducto();
            BEproducto.Codigo = codigo;
            BEproducto.codigoCategoria = codigoCategoria;
            BEproducto.codigoBarra = codigoBarra.Count() > 0 ? codigoBarra : "";
            BEproducto.nombre = nombre;
            BEproducto.precioVenta = precioVenta;
            BEproducto.stock = stock;
            BEproducto.descripcion = descripcion;
            BEproducto.ubicacion = ubicacion;
            BEproducto.imagen = imagen;

            return mppProducto.Modificar(BEproducto, nombreAnterior);
        }
        public bool Modificar(BEProducto Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
    }
}
