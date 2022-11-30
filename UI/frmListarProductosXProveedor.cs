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
using BE;

namespace UI
{
    public partial class frmListarProductosXProveedor : Form
    {
        private bool flag = false;
        private List<BEProveedor> listadoProveedores = new List<BEProveedor>();
        public frmListarProductosXProveedor()
        {
            InitializeComponent();
            bllProveedor = new BLLProveedor();
            listadoProveedores = bllProveedor.Listar();
            bllCompra = new BLLCompra();
        }
        BLLProveedor bllProveedor;
        BLLCompra bllCompra;
        private void Formato()
        {
            dgvProductos.Columns[0].HeaderText = "Categoría";
            dgvProductos.Columns[0].Width = 50;
            dgvProductos.Columns[1].HeaderText = "Código Barra";
            dgvProductos.Columns[1].Width = 100;
            dgvProductos.Columns[2].Width = 100;
            dgvProductos.Columns[2].HeaderText = "Nombre";
            dgvProductos.Columns[3].Width = 60;
            dgvProductos.Columns[3].HeaderText = "Precio Venta";
            dgvProductos.Columns[4].Width = 50;
            dgvProductos.Columns[4].HeaderText = "Stock";
            dgvProductos.Columns[5].Width = 100;
            dgvProductos.Columns[5].HeaderText = "Descripción";
            dgvProductos.Columns[6].Width = 50;
            dgvProductos.Columns[6].HeaderText = "Ubicación";
            dgvProductos.Columns[7].Width = 140;
            dgvProductos.Columns[7].HeaderText = "Fecha Vencimiento";
            dgvProductos.Columns[8].Width = 80;
            dgvProductos.Columns[8].HeaderText = "Imagen";
            dgvProductos.Columns[9].Width = 20;
            dgvProductos.Columns[9].HeaderText = "Estado";
            dgvProductos.Columns[9].Visible = false;
            dgvProductos.Columns[10].Width = 50;
            dgvProductos.Columns[10].HeaderText = "Código";
        }
        private void ListarComboBox()
        {
            cmbRazonSocial.DataSource = listadoProveedores;
            cmbRazonSocial.ValueMember = "codigo";
            cmbRazonSocial.DisplayMember = "razonSocial";
        }
        private void frmListarProductosXProveedor_Load(object sender, EventArgs e)
        {

        }
        private void CargarCampos()
        {
            BEProveedor proveedor = (BEProveedor)cmbRazonSocial.SelectedItem;
            txtCod.Text = Convert.ToString(proveedor.Codigo);
            txtCuit.Text = proveedor.cuit;
            txtDomicilio.Text = proveedor.domicilio;
            txtEmail.Text = proveedor.email;
            txtCondicion.Text = proveedor.condicion;
            txtProvincia.Text = proveedor.provincia;
            txtTelefono.Text = proveedor.telefono;

            ListarProductos(Convert.ToInt32(txtCod.Text));
        }
        private void ListarProductos(int codigoProveedor)
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = bllCompra.ListarProductosPorProveedor(codigoProveedor);
            Formato();
        }

        private void cmbRazonSocial_SelectedValueChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                CargarCampos();
            }

        }
        private void cmbRazonSocial_DropDown(object sender, EventArgs e)
        {
            ListarComboBox();
            flag = true;
        }
    }
}
