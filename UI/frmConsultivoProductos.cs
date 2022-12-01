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
    public partial class frmConsultivoProductos : Form
    {
        private int totalLista = 0;
        public frmConsultivoProductos()
        {
            InitializeComponent();
            bllProducto = new BLLProducto();
        }
        BLLProducto bllProducto;
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Consultivo Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Consultivo Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Formato()
        {
            dgvProductos.Columns[0].HeaderText = "Categoría";
            dgvProductos.Columns[0].Width = 50;
            dgvProductos.Columns[1].HeaderText = "Código Barra";
            dgvProductos.Columns[1].Width = 100;
            dgvProductos.Columns[1].Visible = false;
            dgvProductos.Columns[2].Width = 100;
            dgvProductos.Columns[2].HeaderText = "Nombre";
            dgvProductos.Columns[3].Width = 60;
            dgvProductos.Columns[3].HeaderText = "Precio Venta";
            dgvProductos.Columns[4].Width = 50;
            dgvProductos.Columns[4].HeaderText = "Cantidad Vendido";
            dgvProductos.Columns[5].Width = 100;
            dgvProductos.Columns[5].HeaderText = "Descripción";
            dgvProductos.Columns[6].Width = 50;
            dgvProductos.Columns[6].Visible = false;
            dgvProductos.Columns[6].HeaderText = "Ubicación";
            dgvProductos.Columns[7].Width = 140;
            dgvProductos.Columns[7].HeaderText = "Fecha Vencimiento";
            dgvProductos.Columns[8].Width = 80;
            dgvProductos.Columns[8].HeaderText = "Imagen";
            dgvProductos.Columns[8].Visible = false;
            dgvProductos.Columns[9].Width = 20;
            dgvProductos.Columns[9].HeaderText = "Estado";
            dgvProductos.Columns[9].Visible = false;
            dgvProductos.Columns[10].Width = 50;
            dgvProductos.Columns[10].HeaderText = "Código";
        }
        private void Listar(List<BEProducto> listaProductos)
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaProductos;
            Formato();
        }

        private void frmConsultivoProductos_Load(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            switch (ControlarSeleccion())
            {
                case "1":
                    Listar(bllProducto.MasVendido());
                    break;
                case "2":
                    Listar(bllProducto.MenosVendido());
                    break;
                case "3":
                    Listar(bllProducto.PorVencer());
                    break;
                case "4":
                    Listar(bllProducto.BajoStock());
                    break;
                case "5":
                    Listar(bllProducto.AgruparCategoria());
                    break;
                case "x":
                    MensajeError("Algo salío mal, debe seleccionar un filtro!");
                    break;
                default:
                    MensajeError("Algo salío mal");
                    break;
            }
        }
        private string ControlarSeleccion()
        {
            if (rbtnMasVendidos.Checked)
            {
                return "1";
            }
            if (rbtnMenosVendidos.Checked)
            {
                return "2";
            }
            if (rbtnPorVencer.Checked)
            {
                return "3";
            }
            if (rbtnBajoStock.Checked)
            {
                return "4";
            }
            if (rbtnAgrupCat.Checked)
            {
                return "5";
            }
            return "x";
        }
    }
}
