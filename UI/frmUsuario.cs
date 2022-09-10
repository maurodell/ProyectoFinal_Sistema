using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class frmUsuario : Form
    {
        private string EmailNombreAnterior;
        public frmUsuario()
        {
            InitializeComponent();
            bllUsuario = new BLLUsuario();
            bllRol = new BLLRol();
        }
        BLLUsuario bllUsuario;
        BLLRol bllRol;
        private void Listar()
        {
            try
            {
                dgvListadoUser.DataSource = null;
                dgvListadoUser.DataSource = bllUsuario.Listar();
                this.Formato();
                this.Limpiar();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoUser.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Formato()
        {
            dgvListadoUser.Columns[0].Visible = false;
            dgvListadoUser.Columns[1].HeaderText = "Cód. Rol";
            dgvListadoUser.Columns[1].Width = 50;
            dgvListadoUser.Columns[2].Width = 100;
            dgvListadoUser.Columns[3].HeaderText = "Tipo Doc.";
            dgvListadoUser.Columns[3].Width = 50;

            dgvListadoUser.Columns[4].Width = 100;
            dgvListadoUser.Columns[5].Width = 100;
            dgvListadoUser.Columns[6].HeaderText = "Estado";
            dgvListadoUser.Columns[6].Width = 50;
            dgvListadoUser.Columns[7].HeaderText = "Código";
            dgvListadoUser.Columns[7].Width = 50;
            dgvListadoUser.Columns[8].Width = 150;
            dgvListadoUser.Columns[9].Width = 100;
            dgvListadoUser.Columns[10].Width = 150;
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

            dgvListadoUser.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            chkSeleccionar.Checked = false;

            txtClave.Enabled = true;
            txtReClave.Visible = true;
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Buscar()
        {
            try
            {
                dgvListadoUser.DataSource = bllUsuario.Buscar(txtBuscar.Text);
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoUser.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void CargarRol() 
        {
            try
            {
                cmbRol.DataSource = null;
                cmbRol.DataSource = bllRol.Listar();
                cmbRol.ValueMember = "codigo";
                cmbRol.DisplayMember = "nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarRol();
            txtCodigo.Visible = false; 
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
                if (cmbRol.Text == string.Empty || txtEmail.Text == string.Empty || txtNombre.Text == string.Empty || txtClave.Text == string.Empty)
                {
                    this.MensajeError("Algunos de los datos faltan o son incorrectos");
                    errorProvider1.SetError(cmbRol, "Seleccionar un Rol");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                    errorProvider1.SetError(txtEmail, "Ingresar Email");
                    errorProvider1.SetError(txtClave, "Ingresar Clave \nRepetirla en el siguiente campo");
                }
                else
                {
                    if (txtClave.Text != txtReClave.Text)
                    {
                        this.MensajeError("Las claves no coinciden");

                    }
                    else
                    {
                        respuesta = bllUsuario.Crear(Convert.ToInt32(cmbRol.SelectedValue), txtNombre.Text.Trim(), cmbTipoDoc.Text.Trim(), txtDomicilio.Text.Trim(),
                                                        txtDocumento.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim(), txtClave.Text.Trim());
                        if (respuesta == true)
                        {
                            this.MensajeOk("El usuario fue registrado correctamente");
                            this.Listar();
                        }
                        else
                        {
                            this.MensajeError("El usuario no se pudo registrar");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Listar();
            tabControl1.SelectedIndex = 0;
        }

        private void dgvListadoUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtCodigo.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["Codigo"].Value);
                EmailNombreAnterior = Convert.ToString(dgvListadoUser.CurrentRow.Cells["email"].Value);
                txtEmail.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["email"].Value);
                txtNombre.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["nombre"].Value);
                cmbRol.SelectedValue = Convert.ToInt32(dgvListadoUser.CurrentRow.Cells["codigoRol"].Value);
                txtDocumento.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["documento"].Value);
                cmbTipoDoc.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["tipoDocumento"].Value);
                txtTelefono.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["telefono"].Value);

                tabControl1.SelectedIndex = 1;
                txtCodigo.Visible = true;
                txtClave.Enabled = false;
                txtReClave.Visible = false;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No hacer doble click sobre la columna Seleccionar");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (txtCodigo.Text == string.Empty || cmbRol.Text == string.Empty || txtEmail.Text == string.Empty || txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Algunos de los datos faltan o son incorrectos");
                    errorProvider1.SetError(cmbRol, "Seleccionar un Rol");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                    errorProvider1.SetError(txtEmail, "Ingresar Email");
                    errorProvider1.SetError(txtCodigo, "Falta Código!");
                }
                else
                {
                    respuesta = bllUsuario.Modificar(Convert.ToInt32(txtCodigo.Text.Trim()), Convert.ToInt32(cmbRol.SelectedValue), txtNombre.Text.Trim(), cmbTipoDoc.Text.Trim(),
                                                        txtDomicilio.Text.Trim(), txtDocumento.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim(), EmailNombreAnterior);
                    if (respuesta == true)
                    {
                        this.MensajeOk("Usuario actualizado correctamente");
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError("El registro no se pudo realizar \n" +
                                        "Controlar que el email de la categoría ya no exista");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvListadoUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(dgvListadoUser.Columns["Seleccionar"].Index))
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListadoUser.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);//Determino si esta o no esta marcado el checkBox(Documentacion DataGridView)
            }
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvListadoUser.Columns[0].Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;

                dgvListadoUser.DataSource = null;
                dgvListadoUser.DataSource = bllUsuario.ListarTodos();
            }
            else
            {
                dgvListadoUser.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;

                dgvListadoUser.DataSource = null;
                dgvListadoUser.DataSource = bllUsuario.Listar();
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
                    foreach (DataGridViewRow row in dgvListadoUser.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[9].Value);
                            flag = bllUsuario.Eliminar(codigo);
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

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Esta seguro que desea desactivar el/los registro/s?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion.Equals(DialogResult.OK))
                {
                    int codigo;
                    bool flag = false;
                    foreach (DataGridViewRow row in dgvListadoUser.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[9].Value);
                            flag = bllUsuario.Baja(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("El usuario fue dada de baja correctamente");
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de baja el usuario");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Esta seguro que desea activar el/los registro/s?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion.Equals(DialogResult.OK))
                {
                    int codigo;
                    bool flag = false;
                    foreach (DataGridViewRow row in dgvListadoUser.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[9].Value);
                            flag = bllUsuario.Alta(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("El usuario fue dada de alta correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de alta el usuario");
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
