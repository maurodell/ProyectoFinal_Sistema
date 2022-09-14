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
    public class BLLCompra : IRepositorio<BECompra>
    {
        public BLLCompra()
        {
            mppCompra = new MPPCompra();
        }
        MPPCompra mppCompra;
        BECompra beCompra;
        Detalle detalle;
        public bool Alta(int Parametro)
        {
            return mppCompra.Alta(Parametro);
        }

        public bool Baja(int Parametro)
        {
            return mppCompra.Baja(Parametro);
        }

        public List<BECompra> Buscar(string Parametro)
        {
            return mppCompra.Buscar(Parametro);
        }

        public bool Crear(BECompra Parametro)
        {
            throw new NotImplementedException();
        }
        public bool Crear(int codigoProveedor, int codigoUsuario, string tipoComprobante, string nroComprobante, DateTime fecha, decimal impuesto, 
                            decimal total, string estadoActual, int codigoAsociado, int codigoProducto, int cantidad, decimal precio)
        {
            beCompra = new BECompra();
            detalle = new Detalle();

            return mppCompra.Crear(beCompra);
        }

        public bool Eliminar(int Parametro)
        {
            throw new NotImplementedException();
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
    }
}
