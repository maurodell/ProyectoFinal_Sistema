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
            bllProveedores = new BLLProveedor();
        }
        BLLProveedor bllProveedores;
        private void Listar()
        {
            try
            {
                dgvListadoProveedor.DataSource = null;
                dgvListadoProveedor.DataSource = bllProveedores.Listar();
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
            txtRSocial.Clear();
            txtCodigo.Clear();
            txtDomicilio.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtProvincia.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            txtCodigo.Visible = false;
            errorProvider1.Clear();

            dgvListadoProveedor.Columns[0].Visible = false;
            btnEliminar.Visible = false;
            chkSeleccionar.Checked = false;
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
                dgvListadoProveedor.DataSource = null;
                dgvListadoProveedor.DataSource = bllProveedores.Buscar(txtBuscar.Text);
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

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (txtRSocial.Text == string.Empty || txtCuit.Text == string.Empty || txtDomicilio.Text == string.Empty || txtProvincia.Text == string.Empty || cmbCondicion.Text == string.Empty)
                {
                    this.MensajeError("Algunos de los datos faltan o son incorrectos");
                    errorProvider1.SetError(cmbCondicion, "Seleccionar condición frente al IVA");
                    errorProvider1.SetError(txtRSocial, "Ingresar Razón Social");
                    errorProvider1.SetError(txtCuit, "Ingresar CUIT");
                    errorProvider1.SetError(txtDomicilio, "Ingresar domicilio del proveedor");
                    errorProvider1.SetError(txtProvincia, "Ingresar Provincia");
                }
                else
                {
                    respuesta = bllProveedores.Crear(cmbCondicion.Text.Trim(), txtRSocial.Text.Trim(), Convert.ToInt32(txtCuit.Text.Trim()), txtProvincia.Text.Trim(),
                                                    txtDomicilio.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim());
                    if (respuesta == true)
                    {
                        this.MensajeOk("El proveedor fue registrado correctamente");
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError("El proveedor no se pudo registrar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
