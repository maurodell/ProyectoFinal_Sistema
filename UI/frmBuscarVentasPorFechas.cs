using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using BE;
using System.Collections.Generic;
using System.Linq;

namespace UI
{
    public struct DatosProductos
    {
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public string categoria { get; set; }
    }
    public partial class frmBuscarVentasPorFechas : Form
    {
        public frmBuscarVentasPorFechas()
        {
            InitializeComponent();
            bllVenta = new BLLVenta();
        }
        BLLVenta bllVenta;
        private List<BEVenta> listaVentas;
        List<DatosProductos> listaProductos;
        private void Formato()
        {
            dgvListadoVenta.Columns[0].HeaderText = "Cliente";
            dgvListadoVenta.Columns[0].Width = 100;
            dgvListadoVenta.Columns[1].HeaderText = "Usuario";
            dgvListadoVenta.Columns[1].Width = 100;
            dgvListadoVenta.Columns[2].HeaderText = "Tipo Comprobante";
            dgvListadoVenta.Columns[2].Width = 80;
            dgvListadoVenta.Columns[3].HeaderText = "Punto De venta";
            dgvListadoVenta.Columns[3].Width = 100;
            dgvListadoVenta.Columns[4].HeaderText = "Nro. Comprobante";
            dgvListadoVenta.Columns[4].Width = 100;
            dgvListadoVenta.Columns[5].HeaderText = "Fecha";
            dgvListadoVenta.Columns[5].Width = 150;
            dgvListadoVenta.Columns[6].HeaderText = "Impuesto";
            dgvListadoVenta.Columns[6].Width = 100;
            dgvListadoVenta.Columns[7].HeaderText = "Total";
            dgvListadoVenta.Columns[7].Width = 100;
            dgvListadoVenta.Columns[8].Width = 100;
            dgvListadoVenta.Columns[8].HeaderText = "Estado Actual";
            dgvListadoVenta.Columns[9].Visible = false;
            dgvListadoVenta.Columns[9].HeaderText = "Estado";
            dgvListadoVenta.Columns[10].HeaderText = "Código";
            dgvListadoVenta.Columns[10].Width = 100;

            //dgvListadoVenta.Columns[7].DefaultCellStyle.Format = "N3";
        }
        private void dgvListadoCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int codigoventa = Convert.ToInt32(dgvListadoVenta.CurrentRow.Cells["codigo"].Value);
                BEVenta venta = bllVenta.CargarVenta(codigoventa);

                dgvDetalleVentaProd.DataSource = null;
                dgvDetalleVentaProd.DataSource = venta.detalles;
                decimal subtotal, total = 0;
                foreach (var item in venta.detalles)
                {
                    total = total + item.importe;
                }

                subtotal = total / (1 + Convert.ToDecimal(venta.impuesto));
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

        private void frmBuscarVentasPorFechas_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listaVentas = new List<BEVenta>();
            dgvListadoVenta.DataSource = null;
            listaVentas = bllVenta.ListarPorFecha(Convert.ToDateTime(dateTimePDesde.Value), Convert.ToDateTime(dateTimePHasta.Value));
            dgvListadoVenta.DataSource = listaVentas;
            Formato();
            if (listaVentas.Count > 0)
            {
                CargaPanelCantidades();
                CargarPanelTotalIngresos();
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
        private void CargaPanelCantidades()
        {
            if (dgvListadoVenta.Rows != null)
            {
                cantLbl.Text = dgvListadoVenta.RowCount.ToString();
            }
        }
        private void CargarPanelTotalIngresos()
        {
            try
            {
                decimal total = 0M;
                decimal ganancia = 0M;
                foreach (var item in listaVentas)
                {
                    BEVenta venta = bllVenta.CargarVenta(item.Codigo);
                    foreach (DetalleVenta item2 in venta.detalles)
                    {
                        total += item2.importe;
                    }
                }
                if (total >= 1)
                {
                    decimal porcentaje = 1.40M;
                    totalLbl.Text = $"${total}";
                    ganancia = (total / porcentaje); //como cada producto tiene un 40% de ganancia de esta forma le saco ese porcentaje para saber mi ganacia
                    gananciaLblTotal.Text = "$"+(total-ganancia).ToString("#0.0#");
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
                foreach (var item in listaVentas)
                {
                    BEVenta venta = bllVenta.CargarVenta(item.Codigo);
                    foreach (DetalleVenta item2 in venta.detalles)
                    {
                        stock += item2.cantidad;
                    }
                }
                if (stock >= 1)
                {
                    stockLbl.Text = stock.ToString()+" units";
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
                foreach (var venta in listaVentas)
                {
                    BEVenta ventaEncontrada = bllVenta.CargarVenta(venta.Codigo);
                    foreach (DetalleVenta detalle in ventaEncontrada.detalles)
                    {
                        control = new DatosProductos();
                        control.nombre = detalle.nombreProducto;
                        control.cantidad = detalle.cantidad;
                        control.categoria = bllVenta.BuscarCategoriaProducto(detalle.codigoProducto);
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
