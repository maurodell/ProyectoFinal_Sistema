using System;
using System.Windows.Forms;
using BLL;
using BE;


namespace UI
{
    public partial class frmBuscarCompraPorFechas : Form
    {
        public frmBuscarCompraPorFechas()
        {
            InitializeComponent();
            bllCompra = new BLLCompra();
        }
        BLLCompra bllCompra;
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
            dgvListadoVenta.DataSource = null;
            dgvListadoVenta.DataSource = bllCompra.ListarPorFecha(Convert.ToDateTime(dateTimePDesde.Value), Convert.ToDateTime(dateTimePHasta.Value));
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
    }
}
