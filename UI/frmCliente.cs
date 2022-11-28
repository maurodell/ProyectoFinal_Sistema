using System;
using System.Windows.Forms;
using BLL;
using System.Text.RegularExpressions;

namespace UI
{
    public partial class frmCliente: Form
    {
        private string EmailNombreAnterior;
        public frmCliente()
        {
            InitializeComponent();
            bllCliente = new BLLCliente();
        }
        BLLCliente bllCliente;
        private void Listar()
        {
            try
            {
                dgvListadoUser.DataSource = null;
                dgvListadoUser.DataSource = bllCliente.Listar();
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
            dgvListadoUser.Columns[2].Width = 100;
            dgvListadoUser.Columns[3].Width = 150;
            dgvListadoUser.Columns[4].HeaderText = "Código";
            dgvListadoUser.Columns[4].Width = 50;
            dgvListadoUser.Columns[5].Width = 150;
            dgvListadoUser.Columns[6].Width = 150;
            dgvListadoUser.Columns[7].Width = 150;
        }
        private void Limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDomicilio.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            txtCodigo.Visible = false;
            errorProvider1.Clear();

            dgvListadoUser.Columns[0].Visible = false;
            btnEliminar.Visible = false;
            chkSeleccionar.Checked = false;
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        dgvListadoUser.DataSource = bllCliente.Buscar(nombre);
                        this.Formato();
                        lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoUser.Rows.Count);
                    }
                    else
                    {
                        MessageBox.Show("El nombre solo acepta caracteres", "ERROR");
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Algunos de los datos faltan o son incorrectos");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");

                }
                else
                {
                    if (UserRegex())
                    {
                        respuesta = bllCliente.Crear(txtNombre.Text.Trim().ToLower(), cmbTipoDoc.Text.Trim(), txtDocumento.Text.Trim(), 
                                                        txtDomicilio.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim());
                        if (respuesta == true)
                        {
                            this.MensajeOk("El cliente fue registrado correctamente");
                            this.Listar();
                        }
                        else
                        {
                            this.MensajeError("El cliente no se pudo registrar");
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
                txtCodigo.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["codigo"].Value);
                EmailNombreAnterior = Convert.ToString(dgvListadoUser.CurrentRow.Cells["email"].Value);
                txtEmail.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["email"].Value);
                txtNombre.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["nombre"].Value);
                txtDocumento.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["documento"].Value);
                cmbTipoDoc.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["tipoDocumento"].Value);
                txtTelefono.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["telefono"].Value);
                txtDomicilio.Text = Convert.ToString(dgvListadoUser.CurrentRow.Cells["domicilio"].Value);

                tabControl1.SelectedIndex = 1;
                txtCodigo.Visible = true;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("NO hacer doble click sobre la columna Seleccionar");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (txtCodigo.Text == string.Empty || txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Algunos de los datos faltan o son incorrectos");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                    errorProvider1.SetError(txtCodigo, "Falta Código!");
                }
                else
                {
                    if (UserRegex())
                    {
                        respuesta = bllCliente.Modificar(Convert.ToInt32(txtCodigo.Text.Trim()), txtNombre.Text.Trim().ToLower(), cmbTipoDoc.Text.Trim(),
                                                            txtDocumento.Text.Trim(), txtDomicilio.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim(), EmailNombreAnterior);
                        if (respuesta == true)
                        {
                            this.MensajeOk("Cliente actualizado correctamente");
                            this.Listar();
                        }
                        else
                        {
                            this.MensajeError("El registro no se pudo realizar \n" +
                                            "Controlar que el email del cliente ya no exista");
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
                    MessageBox.Show("El nombre solo acepta caracteres alfabéticos", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtDocumento.Text, "^(?![0-9]+$)"):
                    MessageBox.Show("El documento solo acepta caracteres númericos\nControlar espacios en blanco.", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtDomicilio.Text, @"^(?![a-zA-Z0-9\s\p{L}]+$)"):
                    MessageBox.Show("El domicilio solo acepta caracteres alfanúmericos", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtTelefono.Text, "^(?![0-9]+$)"):
                    MessageBox.Show("El telefono solo acepta caracteres númericos\nControlar espacios en blanco.", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtEmail.Text, "^(?!([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$)"):
                    MessageBox.Show("Debe ingresar un email valido\nControlar espacios en blanco.", "ERROR");
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
                btnEliminar.Visible = true;
            }
            else
            {
                dgvListadoUser.Columns[0].Visible = false;
                btnEliminar.Visible = false;
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
                        codigoControl = Convert.ToInt32(row.Cells[4].Value);
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
                        foreach (DataGridViewRow row in dgvListadoUser.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                codigo = Convert.ToInt32(row.Cells[4].Value);
                                flag = bllCliente.Eliminar(codigo);
                            }
                        }

                        if (flag)
                        {
                            this.MensajeOk("El cliente fue eliminado correctamente.");
                            this.Listar();
                        }

                        else
                        {
                            this.MensajeError("Algo salío mal, el cliente no se pudo eliminar.");
                        }
                    }
                }
                else
                {
                    this.MensajeError("Debe seleccionar al menos un cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.Listar();
            txtCodigo.Visible = false;
        }
    }
}