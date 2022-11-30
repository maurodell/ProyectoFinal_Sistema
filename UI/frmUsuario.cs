using System;
using System.Windows.Forms;
using BLL;
using System.Text.RegularExpressions;

namespace UI
{
    public partial class frmUsuario : Form
    {
        private string EmailNombreAnterior;
        public frmUsuario()
        {
            InitializeComponent();
            bllUsuario = new BLLUsuario();
            bllPermiso = new BLLPermiso();
        }
        BLLUsuario bllUsuario;
        BLLPermiso bllPermiso;
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
            dgvListadoUser.Columns[1].Width = 100;
            dgvListadoUser.Columns[2].HeaderText = "Tipo Doc.";
            dgvListadoUser.Columns[2].Width = 50;

            dgvListadoUser.Columns[3].Width = 100;
            dgvListadoUser.Columns[4].Width = 100;
            dgvListadoUser.Columns[5].HeaderText = "Estado";
            dgvListadoUser.Columns[5].Width = 50;
            dgvListadoUser.Columns[6].HeaderText = "Código";
            dgvListadoUser.Columns[6].Width = 50;
            dgvListadoUser.Columns[7].Width = 150;
            dgvListadoUser.Columns[8].Width = 100;
            dgvListadoUser.Columns[9].Width = 150;
        }
        private void Limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtClave.Clear();
            txtDocumento.Clear();
            txtDomicilio.Clear();
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
                string nombre = txtBuscar.Text.ToLower();
                if (nombre != string.Empty)
                {
                    bool respuesta = Regex.IsMatch(nombre, @"^[a-zA-Z\s\p{L}]+$");
                    if (respuesta)
                    {
                        dgvListadoUser.DataSource = bllUsuario.Buscar(txtBuscar.Text.ToLower());
                        this.Formato();
                        lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoUser.Rows.Count);
                    }
                }
                else
                {
                    this.Listar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            this.Listar();
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
                if (txtEmail.Text == string.Empty || txtNombre.Text == string.Empty || txtClave.Text == string.Empty)
                {
                    this.MensajeError("Algunos de los datos faltan o son incorrectos");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                    errorProvider1.SetError(txtEmail, "Ingresar Email");
                    errorProvider1.SetError(txtClave, "Ingresar Clave \nRepetirla en el siguiente campo");
                }
                else
                {
                    if (txtClave.Text != txtReClave.Text)
                    {
                        this.MensajeError("Las claves no coinciden.");

                    }
                    else
                    {
                        if (UserRegex())
                        {
                            respuesta = bllUsuario.Crear(txtNombre.Text.Trim().ToLower(), cmbTipoDoc.Text.Trim(), txtDomicilio.Text.Trim(),
                                                            txtDocumento.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim(), txtClave.Text.Trim());
                            if (respuesta == true)
                            {
                                this.MensajeOk("El usuario fue registrado correctamente.");
                                this.Listar();
                            }
                            else
                            {
                                this.MensajeError("El usuario no se pudo registrar.");
                            }
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
                txtDocumento.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["documento"].Value);
                cmbTipoDoc.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["tipoDocumento"].Value);
                txtTelefono.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["telefono"].Value);
                txtDomicilio.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["domicilio"].Value);

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
                if (txtCodigo.Text == string.Empty || txtEmail.Text == string.Empty || txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Algunos de los datos faltan o son incorrectos");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                    errorProvider1.SetError(txtEmail, "Ingresar Email");
                    errorProvider1.SetError(txtCodigo, "Falta Código!");
                }
                else
                {
                    if (UserRegex())
                    {
                        respuesta = bllUsuario.Modificar(Convert.ToInt32(txtCodigo.Text.Trim()), txtNombre.Text.Trim().ToLower(), cmbTipoDoc.Text.Trim(),
                                                            txtDocumento.Text.Trim(), txtDomicilio.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim(), EmailNombreAnterior);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private bool UserRegex()
        {
            bool salida = true;
            switch (true)
            {
                case bool _ when Regex.IsMatch(txtNombre.Text, @"^(?![a-zA-Z\s\p{L}]+$)"):
                    MessageBox.Show("El campo nombre solo acepta caracteres alfabéticos.", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtDocumento.Text, "^(?![0-9]+$)"):
                    MessageBox.Show("El campo documento solo acepta caracteres númericos", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtDomicilio.Text, @"^(?![a-zA-Z0-9\s\p{L}]+$)"):
                    MessageBox.Show("El campo domicilio solo acepta caracteres alfanúmericos", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtTelefono.Text, "^(?![0-9]+$)"):
                    MessageBox.Show("El campo telefono solo acepta caracteres númericos", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtEmail.Text, "^(?!([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$)"):
                    MessageBox.Show("El email ingresado debe ser valido", "ERROR");
                    salida = false;
                    break;

                default:
                    break;
            }
            return salida;
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
                int codigoControl = 0;
                foreach (DataGridViewRow row in dgvListadoUser.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigoControl = Convert.ToInt32(row.Cells[6].Value);
                    }
                }
                if (codigoControl > 0)
                {
                    DialogResult opcion;
                    opcion = MessageBox.Show("Esta seguro que va a eliminar el/los registro/s?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (opcion.Equals(DialogResult.OK))
                    {
                        int codigo;
                        bool flag = false;
                        bool flagPermisos = false;
                        foreach (DataGridViewRow row in dgvListadoUser.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                codigo = Convert.ToInt32(row.Cells[6].Value);
                                flag = bllUsuario.Eliminar(codigo);
                                flagPermisos = bllPermiso.EliminarPermisosUsuario(codigo);
                            }
                        }

                        if (flag && flagPermisos)
                        {
                            this.MensajeOk("El usuario fue eliminado correctamente.");
                            this.Listar();
                        }

                        else
                        {
                            this.MensajeError("Algo salío mal, el usuario no se pudo eliminar.");
                        }
                    }
                }
                else
                {
                    this.MensajeError("Debe seleccionar al menos un usuario.");
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
                int codigoControl = 0;
                foreach (DataGridViewRow row in dgvListadoUser.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigoControl = Convert.ToInt32(row.Cells[6].Value);
                    }
                }
                if (codigoControl > 0)
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
                                codigo = Convert.ToInt32(row.Cells[6].Value);
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
                            this.MensajeError("Algo salío mal al dar de baja el usuario.");
                        }
                    }
                }
                else
                {
                    this.MensajeError("Debe seleccionar al menos un usuario.");
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
                int codigoControl = 0;
                foreach (DataGridViewRow row in dgvListadoUser.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigoControl = Convert.ToInt32(row.Cells[6].Value);
                    }
                }
                if (codigoControl > 0)
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
                                codigo = Convert.ToInt32(row.Cells[6].Value);
                                flag = bllUsuario.Alta(codigo);
                            }
                        }

                        if (flag)
                        {
                            this.MensajeOk("El usuario fue dada de alta correctamente.");
                            this.Limpiar();
                            this.Listar();
                        }

                        else
                        {
                            this.MensajeError("Algo salío mal al dar de alta el usuario.");
                        }
                    }
                }
                else
                {
                    this.MensajeError("Debe seleccionar al menos un usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pbOcultar.BringToFront();
            txtClave.PasswordChar = '\0';
        }

        private void pbOcultar_Click(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
            txtClave.PasswordChar = '*';
        }
    }
}
