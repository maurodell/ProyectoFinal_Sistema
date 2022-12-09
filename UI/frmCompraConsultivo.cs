using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using BLL;
using UI.Utils;
using BE;
using System.Text.RegularExpressions;

namespace UI
{
    public partial class frmCompraConsultivo : Form
    {
        public frmCompraConsultivo()
        {
            InitializeComponent();
            bllCompra = new BLLCompra();
            dtDetalle = new DataTable();
        }
        BLLCompra bllCompra;
        private DataTable dtDetalle;
        private void Listar()
        {
            try
            {
                dgvListadoCompra.DataSource = null;
                dgvListadoCompra.DataSource = bllCompra.Listar();
                this.Formato();
                this.Limpiar();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);

                //solo se ejecuta la primera para ponerle un valor al nro. comprobante
                if (dgvListadoCompra.Rows.Count == 0)
                {
                    txtNumComprob.Text = "00000000";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void CrearDgvDetalle()
        {
            this.dtDetalle.Columns.Add("codigoProducto", Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("codigoBarra", Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("nombreProducto", Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precio", Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("importe", Type.GetType("System.Decimal"));

            dgvDetalle.DataSource = dtDetalle;
            dgvDetalle.Columns[0].Width = 70;
            dgvDetalle.Columns[0].HeaderText = "Código";
            dgvDetalle.Columns[1].Width = 150;
            dgvDetalle.Columns[1].HeaderText = "Código Barra";
            dgvDetalle.Columns[2].Width = 170;
            dgvDetalle.Columns[2].HeaderText = "Producto";
            dgvDetalle.Columns[3].Width = 100;
            dgvDetalle.Columns[3].HeaderText = "Cantidad";
            dgvDetalle.Columns[4].Width = 100;
            dgvDetalle.Columns[4].HeaderText = "Precio";
            dgvDetalle.Columns[5].Width = 110;
            dgvDetalle.Columns[5].HeaderText = "Importe";
        }
        private void Formato()
        {
            dgvListadoCompra.Columns[0].Visible = false;
            dgvListadoCompra.Columns[1].HeaderText = "Proveedor";
            dgvListadoCompra.Columns[1].Width = 60;
            dgvListadoCompra.Columns[2].HeaderText = "Usuario";
            dgvListadoCompra.Columns[2].Width = 60;
            dgvListadoCompra.Columns[3].HeaderText = "Tipo Comprobante";
            dgvListadoCompra.Columns[3].Width = 80;
            dgvListadoCompra.Columns[4].HeaderText = "Punto De venta";
            dgvListadoCompra.Columns[4].Width = 130;
            dgvListadoCompra.Columns[5].HeaderText = "Nro. Comprobante";
            dgvListadoCompra.Columns[5].Width = 130;
            dgvListadoCompra.Columns[6].HeaderText = "Fecha";
            dgvListadoCompra.Columns[6].Width = 150;
            dgvListadoCompra.Columns[7].HeaderText = "Impuesto";
            dgvListadoCompra.Columns[7].Width = 100;
            dgvListadoCompra.Columns[8].HeaderText = "Total";
            dgvListadoCompra.Columns[8].Width = 100;
            dgvListadoCompra.Columns[9].Width = 100;
            dgvListadoCompra.Columns[9].HeaderText = "Estado Actual";
            dgvListadoCompra.Columns[10].Visible = false;
            dgvListadoCompra.Columns[10].HeaderText = "Estado";
            dgvListadoCompra.Columns[11].HeaderText = "Código";
            dgvListadoCompra.Columns[11].Width = 60;
        }
        private void Limpiar()
        {
            txtCodProveedor.Clear();
            txtNombreProveedor.Clear();
            txtBuscarComprobante.Clear();
            txtCodigo.Clear();
            txtNumComprob.Clear();
            dtDetalle.Clear();
            txtTotal.Clear();
            txtSubTotal.Clear();
            txtTotalImpuesto.Clear();
            txtCodigo.Visible = false;
            errorProvider1.Clear();

            dgvListadoCompra.Columns[0].Visible = false;
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Buscar()
        {
            try
            {
                bool respuesta = Regex.IsMatch(txtPuntoVenta.Text, "^(?![0-9]+$)");
                if (respuesta)
                {
                    dgvListadoCompra.DataSource = null;
                    if (txtBuscarComprobante.Text != null)
                    {
                        dgvListadoCompra.DataSource = bllCompra.Buscar(txtBuscarComprobante.Text);
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un número de comprobante de compra.");
                    }
                    this.Formato();
                    lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
                }
                else
                {
                    MensajeError("Debe ingresar caracteres númericos.");
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
        private void CalcularTotales()
        {
            decimal total = 0;
            decimal subtotal = 0;
            //esta condición me aseguro que al eliminar un producto se actualice o no los totales y subtotales
            if (dgvDetalle.Rows.Count == 0)
            {
                total = 0;
            }
            else
            {
                foreach (DataRow item in dtDetalle.Rows)
                {
                    total = total + Convert.ToDecimal(item["importe"]);
                }
            }

            subtotal = total / (1 + Convert.ToDecimal(txtAlicuota.Text));
            txtTotal.Text = total.ToString("#0.00#");
            txtSubTotal.Text = subtotal.ToString("#0.00#");
            txtTotalImpuesto.Text = (total - subtotal).ToString("#0.00#");
        }
        private bool UserRegex()
        {
            bool salida = true;
            switch (true)
            {
                case bool _ when Regex.IsMatch(txtPuntoVenta.Text, "^(?![0-9]+$)"):
                    MessageBox.Show("El punto de venta solo acepta caracteres númericos", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtNumComprob.Text, "^(?![0-9]+$)"):
                    MessageBox.Show("El número de comprobante solo acepta caracteres númericos", "ERROR");
                    salida = false;
                    break;

                default:
                    break;
            }
            return salida;
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListadoCompra_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            this.Limpiar();
            int codigoCompra = Convert.ToInt32(dgvListadoCompra.CurrentRow.Cells["codigo"].Value);
            BECompra compra = bllCompra.CargarCompra(codigoCompra);
            txtCodProveedor.Text = compra.codigoProveedor.ToString();
            cmbComprobante.SelectedItem = compra.tipoComprobante;
            txtPuntoVenta.Text = compra.puntoVenta;
            txtNumComprob.Text = compra.nroComprobante;
            dateFecha.Value = compra.fecha;
            txtCodigo.Visible = true;
            txtCodigo.Text = Convert.ToString(compra.Codigo);
            txtNombreProveedor.Text = bllCompra.DevolverNombre(compra.codigoProveedor);

            foreach (var item in compra.detalles)
            {
                DataRow fila = dtDetalle.NewRow();
                fila["codigoProducto"] = item.codigoProducto;
                fila["codigoBarra"] = item.codigoBarra;
                fila["nombreProducto"] = item.nombreProducto;
                fila["cantidad"] = item.cantidad;
                fila["precio"] = item.precio;
                fila["importe"] = item.importe;
                this.dtDetalle.Rows.Add(fila);
            }
            tabControl1.SelectedIndex = 1;
            this.CalcularTotales();
        }

        private void frmCompraConsultivo_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CrearDgvDetalle();
            txtNumComprob.Enabled = false;
            txtPuntoVenta.Text = "0001";
        }
    }
}
