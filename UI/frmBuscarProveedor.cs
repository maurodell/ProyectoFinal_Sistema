using System;
using System.Windows.Forms;
using BLL;
using UI.Utils;
using System.Text.RegularExpressions;

namespace UI
{
    public partial class frmBuscarProveedor : Form
    {
        public frmBuscarProveedor()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Formato()
        {
            dgvListadoProveedor.Columns[0].Width = 100;
            dgvListadoProveedor.Columns[1].HeaderText = "Razón Social";
            dgvListadoProveedor.Columns[1].Width = 100;
            dgvListadoProveedor.Columns[2].HeaderText = "CUIT";
            dgvListadoProveedor.Columns[2].Width = 100;
            dgvListadoProveedor.Columns[3].Width = 150;
            dgvListadoProveedor.Columns[4].HeaderText = "Código";
            dgvListadoProveedor.Columns[4].Width = 100;
            dgvListadoProveedor.Columns[5].Width = 50;
            dgvListadoProveedor.Columns[6].Width = 150;
            dgvListadoProveedor.Columns[7].Width = 100;
        }
        private void Buscar()
        {
            try
            {
                string nombre = txtBuscar.Text.ToLower();
                bool respuesta = Regex.IsMatch(nombre, "^(?![a-zA-Z][a-zA-Z])");
                if (respuesta)
                {
                    dgvListadoProveedor.DataSource = null;
                    dgvListadoProveedor.DataSource = bllProveedores.Buscar(nombre);
                    this.Formato();
                }
                else
                {
                    MessageBox.Show("El nombre solo acepta caracteres", "ERROR");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void frmBuscarProveedor_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnBuscarProv_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dgvListadoProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VariablesCompra.codigoProveedor = Convert.ToInt32(dgvListadoProveedor.CurrentRow.Cells["codigo"].Value);
            VariablesCompra.razonSocial = Convert.ToString(dgvListadoProveedor.CurrentRow.Cells["razonSocial"].Value);
            this.Close();
        }
    }
}
