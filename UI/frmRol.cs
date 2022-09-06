using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class frmRol : Form
    {
        private string RolNombreAnterior;
        public frmRol()
        {
            InitializeComponent();
            bllRol = new BLLRol();
        }
        BLLRol bllRol;
        private void Listar()
        {
            try
            {
                dgvListadoRol.DataSource = null;
                dgvListadoRol.DataSource = bllRol.Listar();
                this.Formato();
                this.Limpiar();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoRol.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Formato()
        {
            dgvListadoRol.Columns[0].Visible = false;
            dgvListadoRol.Columns[1].Width = 150;
            dgvListadoRol.Columns[2].Width = 400;
            dgvListadoRol.Columns[2].HeaderText = "Descripción";
            dgvListadoRol.Columns[3].Width = 80;
            dgvListadoRol.Columns[4].Width = 50;
        }
        private void Limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            txtCodigo.Visible = false;
            errorProvider1.Clear();

            dgvListadoRol.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
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
                dgvListadoRol.DataSource = bllRol.Buscar(txtBuscar.Text);
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoRol.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void frmRol_Load(object sender, EventArgs e)
        {
            this.Listar();
            txtCodigo.Visible = false;
        }

        private void dgvListadoRol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtCodigo.Text = Convert.ToString(dgvListadoRol.CurrentRow.Cells["Codigo"].Value);
                RolNombreAnterior = Convert.ToString(dgvListadoRol.CurrentRow.Cells["nombre"].Value);
                txtNombre.Text = Convert.ToString(dgvListadoRol.CurrentRow.Cells["nombre"].Value);
                txtDescripcion.Text = Convert.ToString(dgvListadoRol.CurrentRow.Cells["descripcion"].Value);
                tabControl1.SelectedIndex = 1;
                txtCodigo.Visible = true;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No hacer doble click sobre la columna Seleccionar");
            }
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvListadoRol.Columns[0].Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;

                dgvListadoRol.DataSource = null;
                dgvListadoRol.DataSource = bllRol.ListarTodos();
            }
            else
            {
                dgvListadoRol.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;

                dgvListadoRol.DataSource = null;
                dgvListadoRol.DataSource = bllRol.Listar();
            }
        }

        private void dgvListadoRol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(dgvListadoRol.Columns["Seleccionar"].Index))
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListadoRol.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);//Determino si esta o no esta marcado el checkBox(Documentacion DataGridView)
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Listar();
            tabControl1.SelectedIndex = 0;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar el nombre");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                }
                else
                {
                    respuesta = bllRol.Crear(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    if (respuesta == true)
                    {
                        this.MensajeOk("Rol registrado correctamente");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError("El registro no se pudo realizar");
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
                if (txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar el nombre");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                }
                else
                {
                    respuesta = bllRol.Modificar(Convert.ToInt32(txtCodigo.Text.Trim()), RolNombreAnterior, txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    if (respuesta == true)
                    {
                        this.MensajeOk("Rol actualizado correctamente");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError("El registro no se pudo realizar \n" +
                                        "Controlar que el nombre del Rol ya no exista");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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
                    foreach (DataGridViewRow row in dgvListadoRol.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[4].Value);
                            flag = bllRol.Eliminar(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("Rol eliminado correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal, el rol no se pudo eliminar");
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
                    foreach (DataGridViewRow row in dgvListadoRol.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[4].Value);
                            flag = bllRol.Baja(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("Rol dada de baja correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de baja el Rol");
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
                    foreach (DataGridViewRow row in dgvListadoRol.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[4].Value);
                            flag = bllRol.Alta(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("Rol dada de alta correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de alta el Rol");
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
