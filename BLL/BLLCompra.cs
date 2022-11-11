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
        public BEProducto BuscarProductoCodBarra(string Parametro)
        {
            return mppCompra.BuscarProductoCodBarra(Parametro);
        }
        public bool Crear(BECompra Parametro)
        {
            throw new NotImplementedException();
        }
        public bool Crear(int codigoUsuario, string tipoComprobante, string nroComprobante, string puntoVenta, DateTime fecha, decimal impuesto, 
                            decimal total, DataTable detalles)
        {
            List<Detalle> listaDetalle = new List<Detalle>();

            beCompra = new BECompra();

            for (int i=0; i<detalles.Rows.Count; i++)
            {
                detalle = new Detalle();
                detalle.codigoBarra = Convert.ToInt32(detalles.Rows[i]["codigoBarra"]);
                detalle.codigoProducto = Convert.ToInt32(detalles.Rows[i]["codigoProducto"]);
                detalle.nombreProducto = Convert.ToString(detalles.Rows[i]["nombreProducto"]);
                detalle.cantidad = Convert.ToInt32(detalles.Rows[i]["cantidad"]);
                detalle.precio = Convert.ToInt32(detalles.Rows[i]["precio"]);
                detalle.importe = Convert.ToInt32(detalles.Rows[i]["importe"]);
                listaDetalle.Add(detalle);
            }
            beCompra.codigoUsuario = codigoUsuario;
            beCompra.detalles = listaDetalle;
            beCompra.tipoComprobante = tipoComprobante;
            beCompra.nroComprobante = nroComprobante;
            beCompra.puntoVenta = puntoVenta;
            beCompra.fecha = fecha;
            beCompra.impuesto = impuesto;
            beCompra.total = total;

            return mppCompra.Crear(beCompra);
        }
        public bool CrearDetalle()
        {
            detalle = new Detalle();

            return false;
        }
        
        public BECompra CargarCompra(int codigoCompra)
        {
            return mppCompra.CargarCompra(codigoCompra);
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
