using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using BLL;
using UI.Utils;
using BE;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;

namespace UI
{
    public partial class frmVentaConsultivo : Form
    {
        private decimal total = 0;
        public frmVentaConsultivo()
        {
            InitializeComponent();
            dtDetalle = new DataTable();
            bllVenta = new BLLVenta();
            bllCliente = new BLLCliente();
        }
        private BLLVenta bllVenta;
        private DataTable dtDetalle;
        BLLCliente bllCliente;

        private void CrearDgvDetalle()
        {
            this.dtDetalle.Columns.Add("codigoProducto", Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("codigoBarra", Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("nombreProducto", Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("stock", Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("cantidad", Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precio", Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("importe", Type.GetType("System.Decimal"));

            dgvDetalle.DataSource = dtDetalle;
            dgvDetalle.Columns[0].Width = 50;
            dgvDetalle.Columns[0].HeaderText = "Código";
            dgvDetalle.Columns[1].Width = 110;
            dgvDetalle.Columns[1].HeaderText = "Código Barra";
            dgvDetalle.Columns[2].Width = 100;
            dgvDetalle.Columns[2].HeaderText = "Producto";
            dgvDetalle.Columns[3].Width = 100;
            dgvDetalle.Columns[3].HeaderText = "Stock";
            dgvDetalle.Columns[4].Width = 70;
            dgvDetalle.Columns[4].HeaderText = "Cantidad";
            dgvDetalle.Columns[5].Width = 100;
            dgvDetalle.Columns[5].HeaderText = "Precio";
            dgvDetalle.Columns[6].Width = 70;
            dgvDetalle.Columns[6].HeaderText = "Descuento";
            dgvDetalle.Columns[7].Width = 100;
            dgvDetalle.Columns[7].HeaderText = "Importe";
        }
        //esta condición me aseguro que al eliminar un producto se actualice o no los totales y subtotales
        private void CalcularTotales()
        {
            decimal subtotal = 0;
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
            txtTotal.Text = total.ToString("#0,0#");
            txtSubTotal.Text = subtotal.ToString("#0,0#");
            txtTotalImpuesto.Text = (total - subtotal).ToString("#0,0#");
        }
        private void Listar()
        {
            try
            {
                dgvListadoCompra.DataSource = null;
                dgvListadoCompra.DataSource = bllVenta.Listar();
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
        private void Formato()
        {
            dgvListadoCompra.Columns[0].Visible = false;
            dgvListadoCompra.Columns[1].HeaderText = "Cliente";
            dgvListadoCompra.Columns[1].Width = 100;
            dgvListadoCompra.Columns[2].HeaderText = "Usuario";
            dgvListadoCompra.Columns[2].Width = 100;
            dgvListadoCompra.Columns[3].HeaderText = "Tipo Comprobante";
            dgvListadoCompra.Columns[3].Width = 80;
            dgvListadoCompra.Columns[4].HeaderText = "Punto De venta";
            dgvListadoCompra.Columns[4].Width = 100;
            dgvListadoCompra.Columns[5].HeaderText = "Nro. Comprobante";
            dgvListadoCompra.Columns[5].Width = 100;
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
            dgvListadoCompra.Columns[11].Width = 100;
        }
        private void Limpiar()
        {
            txtBuscarComprobante.Clear();
            txtCodCliente.Clear();
            txtNombreCliente.Clear();
            txtCodigo.Clear();
            txtCodCliente.Clear();
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
            MessageBox.Show(mensaje, "Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Buscar()
        {
            try
            {
                bool respuesta = Regex.IsMatch(txtBuscarComprobante.Text, "^[0-9]+$");
                if (respuesta)
                {
                    dgvListadoCompra.DataSource = null;
                    dgvListadoCompra.DataSource = bllVenta.Buscar(txtBuscarComprobante.Text);
                    this.Formato();
                    lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
                }
                else
                {
                    MensajeError("Debe ingresar solo el número de comprobante");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void ListarCondicion()
        {
            cmbComprobante.DataSource = Enum.GetValues(typeof(Comprobantes));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
        private void setNroComproantesAutomatico(DataGridView dgvCompra)
        {
            long valor = 0;
            foreach (DataGridViewRow item in dgvCompra.Rows)
            {
                long valor2 = Convert.ToInt64(item.Cells[5].Value);
                if (valor2 > valor)
                {
                    valor = valor2;
                }
            }
            txtNumComprob.Text = (valor + 1).ToString();
        }
        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog guardarArchivo = new SaveFileDialog();
            guardarArchivo.FileName = dateFecha.Value.ToString("ddMMyyyy") + txtNumComprob.Text + ".pdf";
            string maquetaHtml = Properties.Resources.plantilla.ToString();

            maquetaHtml = maquetaHtml.Replace("@PUNTO", txtPuntoVenta.Text);
            maquetaHtml = maquetaHtml.Replace("@COMPROBANTE", txtNumComprob.Text);
            maquetaHtml = maquetaHtml.Replace("@CLIENTE", txtNombreCliente.Text);
            maquetaHtml = maquetaHtml.Replace("@DOCUMENTO", cmbComprobante.Text);
            maquetaHtml = maquetaHtml.Replace("@FECHA", dateFecha.Value.ToString("dd/MM/yyyy"));

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["nombreProducto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["precio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["importe"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            maquetaHtml = maquetaHtml.Replace("@FILAS", filas);
            maquetaHtml = maquetaHtml.Replace("@TOTAL", txtTotal.Text);

            if (guardarArchivo.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardarArchivo.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();

                    pdfDoc.Add(new Phrase(""));

                    using (StringReader sr = new StringReader(maquetaHtml))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();

                    stream.Close();//en memoria.
                }
            }
        }

        private void dgvListadoCompra_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            this.Limpiar();
            int codigoventa = Convert.ToInt32(dgvListadoCompra.CurrentRow.Cells["codigo"].Value);
            BEVenta venta = bllVenta.CargarVenta(codigoventa);
            txtCodCliente.Text = Convert.ToString(venta.codigoCliente);
            cmbComprobante.SelectedItem = venta.tipoComprobante;
            txtPuntoVenta.Text = venta.puntoVenta;
            txtNumComprob.Text = venta.nroComprobante;
            dateFecha.Value = venta.fecha;
            txtCodigo.Visible = true;
            txtCodigo.Text = Convert.ToString(venta.Codigo);
            txtNombreCliente.Text = bllCliente.DevolverNombre(Convert.ToInt32(txtCodCliente.Text));
            foreach (var item in venta.detalles)
            {
                DataRow fila = dtDetalle.NewRow();
                fila["codigoProducto"] = item.codigoProducto;
                fila["codigoBarra"] = item.codigoBarra;
                fila["nombreProducto"] = item.nombreProducto;
                fila["stock"] = item.stock;
                fila["cantidad"] = item.cantidad;
                fila["precio"] = item.precio;
                fila["descuento"] = item.descuento;
                fila["importe"] = item.importe;
                this.dtDetalle.Rows.Add(fila);
            }
            tabControl1.SelectedIndex = 1;
            this.CalcularTotales();
            btnImprimir.Visible = true;
        }

        private void frmVentaConsultivo_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.ListarCondicion();
            this.CrearDgvDetalle();
            btnImprimir.Visible = false;
            txtNumComprob.Enabled = false;
            txtPuntoVenta.Text = "0001";
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
