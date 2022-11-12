using System;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class frmBuscarVentasPorFechas : Form
    {
        public frmBuscarVentasPorFechas()
        {
            InitializeComponent();
            bllVenta = new BLLVenta();
        }
        BLLVenta bllVenta;
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

            dgvListadoVenta.Columns[7].DefaultCellStyle.Format = "N3";
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
            dgvListadoVenta.DataSource = null;
            dgvListadoVenta.DataSource = bllVenta.ListarPorFecha(Convert.ToDateTime(dateTimePDesde.Value), Convert.ToDateTime(dateTimePHasta.Value));
            Formato();
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
    }
}
