using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using BLL;
using UI.Utils;
using BE;

namespace UI
{
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
            dtDetalle = new DataTable();
            bllVenta = new BLLVenta();
        }
        private BLLVenta bllVenta;
        private DataTable dtDetalle;
        private void Listar()
        {
            try
            {
                dgvListadoCompra.DataSource = null;
                dgvListadoCompra.DataSource = bllVenta.Listar();
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
            dgvListadoCompra.Columns[1].HeaderText = "Cliente";
            dgvListadoCompra.Columns[1].Width = 100;
            dgvListadoCompra.Columns[2].HeaderText = "Usuario";
            dgvListadoCompra.Columns[2].Width = 100;
            dgvListadoCompra.Columns[3].HeaderText = "Tipo Comprobante";
            dgvListadoCompra.Columns[3].Width = 80;
            dgvListadoCompra.Columns[4].HeaderText = "Punto De venta";
            dgvListadoCompra.Columns[4].Width = 100;
            dgvListadoCompra.Columns[5].HeaderText = "Nro. Comprobante";
            dgvListadoCompra.Columns[5].Width = 100;
            dgvListadoCompra.Columns[6].HeaderText = "Fecha";
            dgvListadoCompra.Columns[6].Width = 150;
            dgvListadoCompra.Columns[7].HeaderText = "Impuesto";
            dgvListadoCompra.Columns[7].Width = 100;
            dgvListadoCompra.Columns[8].HeaderText = "Total";
            dgvListadoCompra.Columns[8].Width = 100;
            dgvListadoCompra.Columns[9].Width = 100;
            dgvListadoCompra.Columns[9].HeaderText = "Estado Actual";
            dgvListadoCompra.Columns[10].Visible = false;
            dgvListadoCompra.Columns[10].HeaderText = "Estado";
            dgvListadoCompra.Columns[11].HeaderText = "Código";
            dgvListadoCompra.Columns[11].Width = 100;
        }
        private void Limpiar()
        {
            txtBuscarComprobante.Clear();
            txtCodProveedor.Clear();
            txtCodigo.Clear();
            txtCodProveedor.Clear();
            txtNumComprob.Clear();
            txtPuntoVenta.Text = "0000";
            dtDetalle.Clear();
            txtTotal.Clear();
            txtSubTotal.Clear();
            txtTotalImpuesto.Clear();
            btnInsertar.Visible = true;
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
                dgvListadoCompra.DataSource = bllVenta.Buscar(txtBuscarComprobante.Text);
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void frmVenta_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
    }
}
