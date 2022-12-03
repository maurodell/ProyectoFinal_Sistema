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
using System.Collections;

namespace UI
{
    public partial class frmConsultivoProductos : Form
    {
        public struct DatosProductos
        {
            public string nombre { get; set; }
            public int cantidad { get; set; }
            public string categoria { get; set; }
        }
        public frmConsultivoProductos()
        {
            InitializeComponent();
            bllProducto = new BLLProducto();
            listaParaGraficos = new List<BEProducto>();
        }
        BLLProducto bllProducto;
        private List<BEProducto> listaParaGraficos;
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Consultivo Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Consultivo Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Formato(bool flag)
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
            dgvProductos.Columns[4].HeaderText = flag ? "Cantidad Vendido" : "Stock";
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
        private void Listar(List<BEProducto> listaProductos, bool flag)
        {
            if (listaProductos.Count > 0 || listaProductos != null)
            {
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaProductos;
                listaParaGraficos = listaProductos;
                Formato(flag);
                ActualizarChair();
            }
            else
            {
                dgvProductos.DataSource = null;
                MensajeError("No se obtuvieron resultados");
            }

        }

        private void frmConsultivoProductos_Load(object sender, EventArgs e)
        {

        }
        private void ControlRadioButton()
        {
            if (rbtnMasVendidos.Checked == true || rbtnMenosVendidos.Checked == true)
                txtCantidad.Enabled = true;

            if (rbtnMasVendidos.Checked == false && rbtnMenosVendidos.Checked == false)
                txtCantidad.Enabled = false;
        }
        private void ControlVencer()
        {
            if (rbtnPorVencer.Checked)
            {
                menosMes.Enabled = true;
                MasMes.Enabled = true;
            }
            if (!rbtnPorVencer.Checked)
            {
                menosMes.Enabled = false;
                MasMes.Enabled = false;
            }
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            switch (ControlarSeleccion())
            {
                case "1":
                    if (txtCantidad.Text.Length > 0)
                    {
                        Listar(bllProducto.MasVendido(Convert.ToInt32(txtCantidad.Text)), true);
                    }
                    else
                    {
                        dgvProductos.DataSource = null;
                        MensajeError("Debe ingresar una cantidad de stock a filtrar");
                    }
                    break;
                case "2":
                    if (txtCantidad.Text.Length > 0)
                    {
                        Listar(bllProducto.MenosVendido(Convert.ToInt32(txtCantidad.Text)), true);
                    }
                    else
                    {
                        dgvProductos.DataSource = null;
                        MensajeError("Debe ingresar una cantidad de stock a filtrar");
                    }
                    break;
                case "3":
                    string orden = "";
                    if (MasMes.Checked)
                        orden = "mas";
                    else
                        orden = "menos";

                    Listar(bllProducto.PorVencer(orden), false);
                    break;
                case "4":
                    Listar(bllProducto.BajoStock(), false);
                    break;
                case "5":
                    Listar(bllProducto.AgruparCategoria(), false);
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

        private void rbtnMasVendidos_CheckedChanged(object sender, EventArgs e)
        {
            ControlRadioButton();
        }

        private void rbtnMenosVendidos_CheckedChanged(object sender, EventArgs e)
        {
            ControlRadioButton();
        }

        private void rbtnPorVencer_CheckedChanged(object sender, EventArgs e)
        {
            ControlVencer();
        }

        private void menosMes_CheckedChanged(object sender, EventArgs e)
        {
            if (menosMes.Checked)
                MasMes.Checked = false;
        }

        private void MasMes_CheckedChanged(object sender, EventArgs e)
        {
            if (MasMes.Checked)
                menosMes.Checked = false;
        }
        private void ActualizarChair()
        {
            chart1.Series["Series1"].Points.Clear();

            var resultado = from product in listaParaGraficos
                            //group product by product.codigoCategoria into totales
                            select new
                            {
                                nombre = product.nombre,
                                cantidad = product.stock
                            };
            ArrayList nombre = new ArrayList();
            ArrayList cantidad = new ArrayList();
            foreach (var item in resultado.OrderBy(x=>x.cantidad))
            {
                nombre.Add(item.nombre);
                cantidad.Add(item.cantidad);
            }
            chart1.Series[0].Points.DataBindXY(nombre, cantidad);
        }
    }
}