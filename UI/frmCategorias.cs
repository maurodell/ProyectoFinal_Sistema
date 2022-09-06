using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class frmCategorias : Form
    {
        private string CategoriaNombreAnterior;
        public frmCategorias()
        {
            InitializeComponent();
            bllCategoria = new BLLCategoria();
        }
        BLLCategoria bllCategoria;
        private void Listar()
        {
            try
            {
                dgvListadoCat.DataSource = null;
                dgvListadoCat.DataSource = bllCategoria.Listar();
                this.Formato();
                this.Limpiar();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCat.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Formato()
        {
            dgvListadoCat.Columns[0].Visible = false;
            dgvListadoCat.Columns[1].Width = 150;
            dgvListadoCat.Columns[2].Width = 400;
            dgvListadoCat.Columns[2].HeaderText = "Descripción";
            dgvListadoCat.Columns[3].Width = 80;
            dgvListadoCat.Columns[4].Width = 50;
        }
        private void frmCategorias_Load(object sender, EventArgs e)
        {
            this.Listar();
            txtCodigo.Visible = false;
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

            dgvListadoCat.Columns[0].Visible = false;
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
                dgvListadoCat.DataSource = null;
                dgvListadoCat.DataSource = bllCategoria.Buscar(txtBuscar.Text);
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCat.Rows.Count);
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
                    this.MensajeError("Falta ingresar el nombre");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                }
                else
                {
                    respuesta = bllCategoria.Insertar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    if (respuesta == true) 
                    {
                        this.MensajeOk("La categoría fue registrada correctamente");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Listar();
            tabControl1.SelectedIndex = 0;
        }

        private void dgvListadoCat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtCodigo.Text = Convert.ToString(dgvListadoCat.CurrentRow.Cells["Codigo"].Value);
                CategoriaNombreAnterior = Convert.ToString(dgvListadoCat.CurrentRow.Cells["Nombre"].Value);
                txtNombre.Text = Convert.ToString(dgvListadoCat.CurrentRow.Cells["Nombre"].Value);
                txtDescripcion.Text = Convert.ToString(dgvListadoCat.CurrentRow.Cells["descripcion"].Value);
                tabControl1.SelectedIndex = 1;
                txtCodigo.Visible = true;
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
                if (txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar el nombre");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                }
                else
                {
                    respuesta = bllCategoria.Modificar(Convert.ToInt32(txtCodigo.Text.Trim()), CategoriaNombreAnterior, txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    if (respuesta == true)
                    {
                        this.MensajeOk("La categoría fue actualizada correctamente");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError("El registro no se pudo realizar \n"+
                                        "Controlar que el nombre de la categoría ya no exista");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvListadoCat.Columns[0].Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;

                dgvListadoCat.DataSource = null;
                dgvListadoCat.DataSource = bllCategoria.ListarTodos();
            }
            else
            {
                dgvListadoCat.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;

                dgvListadoCat.DataSource = null;
                dgvListadoCat.DataSource = bllCategoria.Listar();
            }
        }

        private void dgvListadoCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(dgvListadoCat.Columns["Seleccionar"].Index))
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListadoCat.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);//Determino si esta o no esta marcado el checkBox(Documentacion DataGridView)
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
                    foreach (DataGridViewRow row in dgvListadoCat.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[4].Value);
                            flag = bllCategoria.Eliminar(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("La categoría fue eliminada correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal, la categoría no se pudo eliminar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.StackTrace);
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
                    foreach (DataGridViewRow row in dgvListadoCat.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[4].Value);
                            flag = bllCategoria.Alta(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("La categoría fue dada de alta correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de alta la categoría");
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
                    foreach (DataGridViewRow row in dgvListadoCat.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[4].Value);
                            flag = bllCategoria.Baja(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("La categoría fue dada de baja correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de baja la categoría");
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
