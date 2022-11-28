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
        DetalleVenta detalle;
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
        public bool Crear(int codigoCliente,int codigoUsuario, string tipoComprobante, string nroComprobante, string puntoVenta, DateTime fecha, decimal impuesto,
                            decimal total, DataTable detalles)
        {
            List<DetalleVenta> listaDetalle = new List<DetalleVenta>();

            beVenta = new BEVenta();

            for (int i = 0; i < detalles.Rows.Count; i++)
            {
                detalle = new DetalleVenta();
                detalle.codigoBarra = Convert.ToInt64(detalles.Rows[i]["codigoBarra"]);
                detalle.codigoProducto = Convert.ToInt32(detalles.Rows[i]["codigoProducto"]);
                detalle.nombreProducto = Convert.ToString(detalles.Rows[i]["nombreProducto"]);
                detalle.stock = Convert.ToInt32(detalles.Rows[i]["stock"]);
                detalle.cantidad = Convert.ToInt32(detalles.Rows[i]["cantidad"]);
                detalle.precio = Convert.ToDecimal(detalles.Rows[i]["precio"]);
                detalle.descuento = Convert.ToDecimal(detalles.Rows[i]["descuento"]);
                detalle.importe = Convert.ToDecimal(detalles.Rows[i]["importe"]);
                listaDetalle.Add(detalle);
            }
            beVenta.codigoCliente = codigoCliente;
            beVenta.codigoUsuario = codigoUsuario;
            beVenta.detalles = listaDetalle;
            beVenta.tipoComprobante = tipoComprobante;
            beVenta.nroComprobante = nroComprobante;
            beVenta.puntoVenta = puntoVenta;
            beVenta.fecha = Convert.ToDateTime(fecha.ToString("dd/MM/yyyy"));
            beVenta.impuesto = impuesto;
            beVenta.total = total;

            return mppVenta.Crear(beVenta);
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
            throw new NotImplementedException();
        }
    }
}
