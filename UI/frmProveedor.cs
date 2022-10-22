using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class frmProveedor : Form
    {
        private string cuitAnterior;
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
            dgvListadoProveedor.Columns[1].Width = 100;
            dgvListadoProveedor.Columns[2].HeaderText = "Razón Social";
            dgvListadoProveedor.Columns[2].Width = 100;
            dgvListadoProveedor.Columns[3].HeaderText = "CUIT";
            dgvListadoProveedor.Columns[3].Width = 150;
            dgvListadoProveedor.Columns[4].Width = 100;
            dgvListadoProveedor.Columns[5].HeaderText = "Código";
            dgvListadoProveedor.Columns[5].Width = 50;
            dgvListadoProveedor.Columns[6].Width = 150;
            dgvListadoProveedor.Columns[7].Width = 100;
            dgvListadoProveedor.Columns[8].Width = 150;
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
            txtCuit.Clear();
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
                    respuesta = bllProveedores.Crear(cmbCondicion.Text.Trim(), txtRSocial.Text.Trim(), txtCuit.Text.Trim(), txtProvincia.Text.Trim(),
                                                    txtDomicilio.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim());
                    if (respuesta == true)
                    {
                        this.MensajeOk("El proveedor fue registrado correctamente");
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError("El proveedor no se pudo registrar, es posible que el CUIT ya exista.");
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
            try
            {
                bool respuesta = false;
                this.cuitAnterior = txtCuit.Text;
                if (txtRSocial.Text == string.Empty || txtDomicilio.Text == string.Empty || txtCuit.Text == string.Empty || txtProvincia.Text == string.Empty || cmbCondicion.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar el nombre");
                    errorProvider1.SetError(txtRSocial, "Debe ingresar Razón Social");
                    errorProvider1.SetError(txtDomicilio, "Debe ingresar Domicilio");
                    errorProvider1.SetError(txtCuit, "Debe ingresar CUIT");
                    errorProvider1.SetError(txtProvincia, "Debe ingresar una Provincia");
                    errorProvider1.SetError(cmbCondicion, "Debe ingresar condición");
                }
                else
                {
                    respuesta = bllProveedores.Modificar(Convert.ToInt32(txtCodigo.Text.Trim()), cmbCondicion.Text, txtRSocial.Text.Trim(), txtCuit.Text.Trim(), txtProvincia.Text.Trim(), txtDomicilio.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim(), cuitAnterior);
                    if (respuesta == true)
                    {
                        this.MensajeOk("El proveedor fue actualizada correctamente");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError("El registro no se pudo actualizar \n" +
                                        "Controlar que el CUIT del proveedor ya no exista");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doble click sobre la celda nombre. " + ex.Message + " | " + ex.StackTrace);
            }
        }

        private void dgvListadoProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Limpiar();
            txtCodigo.Visible = true;
            btnActualizar.Visible = true;
            btnInsertar.Visible = false;
            txtCodigo.Text = Convert.ToString(dgvListadoProveedor.CurrentRow.Cells["codigo"].Value);
            cmbCondicion.Text = Convert.ToString(dgvListadoProveedor.CurrentRow.Cells["condicion"].Value);
            txtCuit.Text = Convert.ToString(dgvListadoProveedor.CurrentRow.Cells["cuit"].Value);
            txtDomicilio.Text = Convert.ToString(dgvListadoProveedor.CurrentRow.Cells["domicilio"].Value);
            txtProvincia.Text = Convert.ToString(dgvListadoProveedor.CurrentRow.Cells["provincia"].Value);
            txtEmail.Text = Convert.ToString(dgvListadoProveedor.CurrentRow.Cells["email"].Value);
            txtRSocial.Text = Convert.ToString(dgvListadoProveedor.CurrentRow.Cells["razonSocial"].Value);
            txtTelefono.Text = Convert.ToString(dgvListadoProveedor.CurrentRow.Cells["telefono"].Value);
            tabControl1.SelectedIndex = 1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabControl1.SelectedIndex = 0;
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvListadoProveedor.Columns[0].Visible = true;
                btnEliminar.Visible = true;
            }
            else
            {
                dgvListadoProveedor.Columns[0].Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void dgvListadoProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(dgvListadoProveedor.Columns["Seleccionar"].Index))
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListadoProveedor.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);//Determino si esta o no marcado el checkBox(Documentacion DataGridView)
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Esta seguro que va a eliminar el/los registro/s?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion.Equals(DialogResult.OK))
                {
                    int codigo;
                    bool flag = false;
                    foreach (DataGridViewRow row in dgvListadoProveedor.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[5].Value);
                            flag = bllProveedores.Eliminar(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("El usuario fue eliminado correctamente");
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError("Algo salío mal, el usuario no se pudo eliminar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
