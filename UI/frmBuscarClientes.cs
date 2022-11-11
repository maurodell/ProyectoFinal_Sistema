using System;
using System.Windows.Forms;
using BLL;
using UI.Utils;

namespace UI
{
    public partial class frmBuscarClientes : Form
    {
        public frmBuscarClientes()
        {
            InitializeComponent();
            bllCliente = new BLLCliente();
        }
        BLLCliente bllCliente;
        private void frmBuscarClientes_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void Listar()
        {
            try
            {
                dgvListadoProveedor.DataSource = null;
                dgvListadoProveedor.DataSource = bllCliente.Listar();
                this.Formato();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Formato()
        {
            dgvListadoProveedor.Columns[0].Width = 50;
            dgvListadoProveedor.Columns[1].Width = 100;
            dgvListadoProveedor.Columns[2].HeaderText = "Tipo Doc.";
            dgvListadoProveedor.Columns[2].Width = 100;
            dgvListadoProveedor.Columns[3].Width = 150;
            dgvListadoProveedor.Columns[4].HeaderText = "Código";
            dgvListadoProveedor.Columns[4].Width = 50;
            dgvListadoProveedor.Columns[5].Width = 150;
            dgvListadoProveedor.Columns[6].Width = 150;
        }
        private void Buscar()
        {
            try
            {
                dgvListadoProveedor.DataSource = null;
                dgvListadoProveedor.DataSource = bllCliente.Buscar(txtBuscar.Text);
                this.Formato();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnBuscarProv_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dgvListadoProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VariableCliente.codigoCliente = Convert.ToInt32(dgvListadoProveedor.CurrentRow.Cells["codigo"].Value);
            VariableCliente.nombreCliente = Convert.ToString(dgvListadoProveedor.CurrentRow.Cells["nombre"].Value);
            this.Close();
        }
    }
}
