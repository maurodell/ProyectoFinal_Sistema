using System;
using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class frmProveedor : Form
    {
        public frmProveedor()
        {
            InitializeComponent();
            bllPersona = new BLLPersona();
        }
        BLLPersona bllPersona;
        private void Listar()
        {
            try
            {
                dgvListadoProveedor.DataSource = null;
                dgvListadoProveedor.DataSource = bllPersona.ListarProveedor();
                this.Formato();
                this.Limpiar();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoProveedor.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Formato()
        {
            dgvListadoProveedor.Columns[0].Visible = false;
            dgvListadoProveedor.Columns[1].HeaderText = "Tipo Persona";
            dgvListadoProveedor.Columns[1].Width = 100;
            dgvListadoProveedor.Columns[2].Width = 100;
            dgvListadoProveedor.Columns[3].HeaderText = "Tipo Documento";
            dgvListadoProveedor.Columns[3].Width = 80;

            dgvListadoProveedor.Columns[4].Width = 100;
            dgvListadoProveedor.Columns[5].Width = 100;
            dgvListadoProveedor.Columns[6].Width = 200;
            dgvListadoProveedor.Columns[7].Width = 150;
            dgvListadoProveedor.Columns[8].Width = 50;
            dgvListadoProveedor.Columns[8].HeaderText = "Código";
        }
        private void Limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtClave.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtReClave.Clear();
            txtTelefono.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            txtCodigo.Visible = false;
            errorProvider1.Clear();

            dgvListadoProveedor.Columns[0].Visible = false;
            btnEliminar.Visible = false;
            chkSeleccionar.Checked = false;

            txtClave.Enabled = true;
            txtReClave.Visible = true;
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Buscar()
        {
            try
            {
                dgvListadoProveedor.DataSource = bllPersona.BuscarProveedor(txtBuscar.Text);
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoProveedor.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void frmProveedor_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
    }
}
