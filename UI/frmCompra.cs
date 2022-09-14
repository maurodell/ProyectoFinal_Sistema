using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class frmCompra : Form
    {
        public frmCompra()
        {
            InitializeComponent();
            bllCompra = new BLLCompra();
        }
        BLLCompra bllCompra;
        private void Listar()
        {
            try
            {
                dgvListadoCompra.DataSource = null;
                dgvListadoCompra.DataSource = bllCompra.Listar();
                this.Formato();
                this.Limpiar();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Formato()
        {
            dgvListadoCompra.Columns[0].Visible = false;
            dgvListadoCompra.Columns[1].Width = 150;
            dgvListadoCompra.Columns[2].Width = 400;
            dgvListadoCompra.Columns[2].HeaderText = "Descripción";
            dgvListadoCompra.Columns[3].Width = 80;
            dgvListadoCompra.Columns[4].Width = 50;
        }
        private void Limpiar()
        {
            txtBuscarComprobante.Clear();
            txtBuscarProve.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            txtCodigo.Visible = false;
            errorProvider1.Clear();

            dgvListadoCompra.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            chkSeleccionar.Checked = false;
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Categorias", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Categorias", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Buscar()
        {
            try
            {
                dgvListadoCompra.DataSource = null;
                if (txtBuscarComprobante.Text != null)
                {
                    dgvListadoCompra.DataSource = bllCompra.Buscar(txtBuscarComprobante.Text);
                }else if (txtBuscarComprobante.Text != null && txtBuscarProve.Text != null)
                {
                    MensajeError("No puede ingresar 2 parametros a buscar");
                }
                else
                {
                    dgvListadoCompra.DataSource = bllCompra.Buscar(txtBuscarProve.Text);
                }
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void frmCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
