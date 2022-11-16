using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using BE;
using System.Collections.Generic;
using System.Linq;

namespace UI
{
    public partial class frmBuscarCompraPorFechas : Form
    {
        public struct DatosProductos
        {
            public string nombre { get; set; }
            public int cantidad { get; set; }
            public string categoria { get; set; }
        }
        public frmBuscarCompraPorFechas()
        {
            InitializeComponent();
            bllCompra = new BLLCompra();
        }
        BLLCompra bllCompra;
        List<BECompra> listaCompras;
        List<DatosProductos> listaProductos;
        private void frmBuscarCompraPorFechas_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        private void Formato()
        {
            dgvListadoVenta.Columns[0].HeaderText = "Código Usuario";
            dgvListadoVenta.Columns[0].Width = 50;
            dgvListadoVenta.Columns[1].HeaderText = "Tipo Comprobante";
            dgvListadoVenta.Columns[1].Width = 100;
            dgvListadoVenta.Columns[2].HeaderText = "Punto De venta";
            dgvListadoVenta.Columns[2].Width = 80;
            dgvListadoVenta.Columns[3].HeaderText = "Nro. Comprobante";
            dgvListadoVenta.Columns[3].Width = 100;
            dgvListadoVenta.Columns[4].HeaderText = "Fecha";
            dgvListadoVenta.Columns[4].Width = 100;
            dgvListadoVenta.Columns[5].HeaderText = "Impuesto";
            dgvListadoVenta.Columns[5].Width = 100;
            dgvListadoVenta.Columns[6].HeaderText = "Total";
            dgvListadoVenta.Columns[6].Width = 100;
            dgvListadoVenta.Columns[7].HeaderText = "Estado Actual";
            dgvListadoVenta.Columns[7].Width = 70;
            //dgvListadoVenta.Columns[8].Width = 100;
            //dgvListadoVenta.Columns[8].HeaderText = "Estado";
            dgvListadoVenta.Columns[8].Visible = false;
            dgvListadoVenta.Columns[9].HeaderText = "Código";
            dgvListadoVenta.Columns[9].Width = 60;

            dgvListadoVenta.Columns[6].DefaultCellStyle.Format = "N3";
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listaCompras = new List<BECompra>();
            dgvListadoVenta.DataSource = null;
            listaCompras = bllCompra.ListarPorFecha(Convert.ToDateTime(dateTimePDesde.Value), Convert.ToDateTime(dateTimePHasta.Value));
            dgvListadoVenta.DataSource = listaCompras;
            Formato();
            if (listaCompras.Count > 0)
            {
                CargaPanelCantidades();
                CargarPanelTotalEgresos();
                ConsultaStockMovido();
                ActualizarChartProductos();
                ActualizarChartCategorias();
            }
            else
            {
                totalLbl.Text = "$ 0";
                stockLbl.Text = "0 units";
                cantLbl.Text = "0";
                gananciaLblTotal.Text = "$ 0";
            }
        }
        private void LimpiarDetalle()
        {
            txtSubTotal.Clear();
            txtTotal.Clear();
            txtTotalImp.Clear();
            dgvDetalleVentaProd.DataSource = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            LimpiarDetalle();
        }

        private void dgvListadoVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int codigoCompra = Convert.ToInt32(dgvListadoVenta.CurrentRow.Cells["codigo"].Value);
                BECompra compra = bllCompra.CargarCompra(codigoCompra);

                dgvDetalleVentaProd.DataSource = null;
                dgvDetalleVentaProd.DataSource = compra.detalles;
                decimal subtotal, total = 0;
                foreach (var item in compra.detalles)
                {
                    total = total + item.importe;
                }

                subtotal = total / (1 + Convert.ToDecimal(compra.impuesto));
                txtTotal.Text = total.ToString("#0.00#");
                txtSubTotal.Text = subtotal.ToString("#0.0#");
                txtTotalImp.Text = (total - subtotal).ToString("#0.0#");
                panel1.Visible = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void CargaPanelCantidades()
        {
            if (dgvListadoVenta.Rows != null)
            {
                cantLbl.Text = dgvListadoVenta.RowCount.ToString();
            }
        }
        private void CargarPanelTotalEgresos()
        {
            try
            {
                decimal total = 0M;
                decimal ganancia = 0M;
                foreach (var item in listaCompras)
                {
                    BECompra compra = bllCompra.CargarCompra(item.Codigo);
                    foreach (Detalle item2 in compra.detalles)
                    {
                        total += item2.importe;
                    }
                }
                if (total >= 1)
                {
                    decimal porcentaje = 1.40M;
                    totalLbl.Text = $"${total}";
                    ganancia = (total / porcentaje); //como cada producto tiene un 40% de ganancia de esta forma le saco ese porcentaje para saber mi ganacia
                    gananciaLblTotal.Text = "$" + (total - ganancia).ToString("#0.0#");
                }
            }
            catch (Exception)
            {

            }
        }
        private void ConsultaStockMovido()
        {
            try
            {
                int stock = 0;
                foreach (var item in listaCompras)
                {
                    BECompra compra = bllCompra.CargarCompra(item.Codigo);
                    foreach (Detalle item2 in compra.detalles)
                    {
                        stock += item2.cantidad;
                    }
                }
                if (stock >= 1)
                {
                    stockLbl.Text = stock.ToString() + " units";
                }
            }
            catch (Exception)
            {

            }
        }
        private void ActualizarChartProductos()
        {
            try
            {
                DatosProductos control;
                listaProductos = new List<DatosProductos>();
                chart1.Series.Clear();
                //de la lista de ventas, busco el detalle de los productos de venta para crearme una nueva lista de objetos DatosProducto.
                foreach (var venta in listaCompras)
                {
                    BECompra compraEncontrada = bllCompra.CargarCompra(venta.Codigo);
                    foreach (Detalle detalle in compraEncontrada.detalles)
                    {
                        control = new DatosProductos();
                        control.nombre = detalle.nombreProducto;
                        control.cantidad = detalle.cantidad;
                        control.categoria = bllCompra.BuscarCategoriaProducto(detalle.codigoProducto);
                        listaProductos.Add(control);
                    }
                }

                var resultado = from product in listaProductos
                                group product by new { product.categoria, product.nombre } into totales
                                select new
                                {
                                    categoria = totales.Key.categoria,
                                    nombre = totales.Key.nombre,
                                    cantidad = totales.Sum(x => x.cantidad)
                                };

                DatosProductos productoGrafico;
                List<DatosProductos> listaProGraf = new List<DatosProductos>();
                foreach (var item in resultado)
                {
                    productoGrafico = new DatosProductos();
                    productoGrafico.nombre = item.nombre;
                    productoGrafico.categoria = item.categoria;
                    productoGrafico.cantidad = item.cantidad;
                    listaProGraf.Add(productoGrafico);
                }

                //---------------------------------------------------------------------

                foreach (var item2 in listaProGraf)
                {
                    Series serie = chart1.Series.Add(item2.nombre);
                    serie.Label = item2.cantidad.ToString();
                    serie.Points.Add(item2.cantidad);
                }
            }
            catch (Exception)
            {

            }
        }
        private void ActualizarChartCategorias()
        {
            try
            {
                chart2.Series["Series1"].Points.Clear();

                var resultado = from product in listaProductos
                                group product by product.categoria into totales
                                select new
                                {
                                    categoria = totales.Key,
                                    cantidad = totales.Sum(x => x.cantidad)
                                };
                DatosProductos productoGrafico;
                List<DatosProductos> listaProGraf2 = new List<DatosProductos>();
                foreach (var item in resultado)
                {
                    productoGrafico = new DatosProductos();
                    productoGrafico.categoria = item.categoria;
                    productoGrafico.cantidad = item.cantidad;
                    listaProGraf2.Add(productoGrafico);
                }

                foreach (var item2 in listaProGraf2)
                {
                    chart2.Series["Series1"].Points.AddXY(item2.categoria, item2.cantidad);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
