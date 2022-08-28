using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Reflection;

namespace UI
{
    public partial class frmCategorias : Form
    {
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
        }
        private void Limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            btnInsertar.Visible = true;
            errorProvider1.Clear();
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
    }
}
