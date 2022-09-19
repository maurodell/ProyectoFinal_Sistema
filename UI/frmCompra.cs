using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using BLL;
using UI.Utils;
using BE;

namespace UI
{
    public partial class frmCompra : Form
    {
        public frmCompra()
        {
            InitializeComponent();
            bllCompra = new BLLCompra();
            BLLProducto = new BLLProducto();
            dtDetalle = new DataTable();
        }
        BLLCompra bllCompra;
        BLLProducto BLLProducto;
        private DataTable dtDetalle;
        private BEProducto producto;
        private void Listar()
        {
            try
            {
                dgvListadoCompra.DataSource = null;
                dgvListadoCompra.DataSource = bllCompra.Listar();
                this.Formato();
                this.Limpiar();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void CrearDgvDetalle()
        {
            this.dtDetalle.Columns.Add("codigoProducto", Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("codigo", Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("producto", Type.GetType("System.String"));
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

            dgvDetalle.Columns[1].ReadOnly = true;
            dgvDetalle.Columns[2].ReadOnly = true;
            dgvDetalle.Columns[5].ReadOnly = true;
        }
        private void Formato()
        {
            dgvListadoCompra.Columns[0].Visible = false;
            dgvListadoCompra.Columns[1].HeaderText = "Proveedor";
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
        private void FormatoProductoPanel()
        {
            //dgvProductoPanel.Columns[0].Visible = false;
            ////dgvProductoPanel.Columns[1].Visible = false;
            //dgvProductoPanel.Columns[1].HeaderText = "Categoría";
            //dgvProductoPanel.Columns[1].Width = 50;
            //dgvProductoPanel.Columns[2].HeaderText = "Código Barra";
            //dgvProductoPanel.Columns[2].Width = 50;
            //dgvProductoPanel.Columns[3].Width = 100;
            //dgvProductoPanel.Columns[4].Width = 60;
            //dgvProductoPanel.Columns[4].HeaderText = "Precio Venta";
            //dgvProductoPanel.Columns[5].Width = 50;
            //dgvProductoPanel.Columns[6].Width = 150;
            //dgvProductoPanel.Columns[6].HeaderText = "Descripción";
            //dgvProductoPanel.Columns[7].Width = 50;
            //dgvProductoPanel.Columns[7].HeaderText = "Ubicación";
            //dgvProductoPanel.Columns[8].Width = 140;
            //dgvProductoPanel.Columns[8].HeaderText = "Fecha Vencimiento";
            //dgvProductoPanel.Columns[9].Width = 80;
            //dgvProductoPanel.Columns[10].HeaderText = "Código";
            //dgvProductoPanel.Columns[10].Width = 20;
        }
        private void Limpiar()
        {
            txtBuscarComprobante.Clear();
            txtBuscarProve.Clear();
            txtCodProveedor.Clear();
            txtCodigo.Clear();
            txtCodProveedor.Clear();
            txtNumComprob.Clear();
            txtPuntoVenta.Text = "0000";
            dtDetalle.Clear();
            txtTotal.Clear();
            txtSubTotal.Clear();
            txtTotalImpuesto.Clear();
            btnInsertar.Visible = true;
            txtCodigo.Visible = false;
            errorProvider1.Clear();

            dgvListadoCompra.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
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
                dgvListadoCompra.DataSource = null;
                if (txtBuscarComprobante.Text != null)
                {
                    dgvListadoCompra.DataSource = bllCompra.Buscar(txtBuscarComprobante.Text);
                }else if (txtBuscarComprobante.Text != null && txtBuscarProve.Text != null)
                {
                    MensajeError("No puede ingresar 2 parametros a buscar");
                }
                else
                {
                    dgvListadoCompra.DataSource = bllCompra.Buscar(txtBuscarProve.Text);
                }
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void BuscarProductoCodBarra()
        {
            try
            {
                dgvListadoCompra.DataSource = null;
                if (txtBuscarComprobante.Text != null)
                {
                    MensajeError("No puede ingresar 2 parametros a buscar");
                }
                else
                {
                    dgvListadoCompra.DataSource = bllCompra.BuscarProductoCodBarra(txtCodBarra.Text);
                }
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void frmCompra_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CrearDgvDetalle();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
        private void btnBuscarProv_Click(object sender, EventArgs e)
        {
            frmBuscarProveedor FrmBuscarProveedor = new frmBuscarProveedor();
            FrmBuscarProveedor.ShowDialog();
            txtCodProveedor.Text = Convert.ToString(VariablesCompra.codigoProveedor);
            txtNombreProveedor.Text = VariablesCompra.razonSocial;
        }

        private void cmbComprobante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string texto = comboBox.SelectedItem.ToString();
            if (texto != "Recibo")
            {
                txtAlicuota.Text = "0.21";
            }
            else
            {
                txtAlicuota.Text = "0";
            }
        }

        private void txtCodBarra_KeyDown(object sender, KeyEventArgs e)
        {
            //captura el código ingresado en txtCodBarra del producto
            try 
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCodBarra.Text.Length <= 0)
                    {
                        this.MensajeError("Debe ingresar un código de barra");
                    }
                    else
                    {
                        producto = new BEProducto();
                        producto = bllCompra.BuscarProductoCodBarra(txtCodBarra.Text.Trim());

                        //vuelvo a verificar que el producto no sea null
                        if (producto != null)
                        {
                            this.AgregarDetalle(producto.Codigo, producto.codigoBarra, producto.nombre, producto.precioVenta);
                            txtCodBarra.Clear();
                        }
                        else
                        {
                            this.MensajeError("No existe el código de barra");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AgregarDetalle(int codigoProducto, string codigoBarra, string nombre, decimal precio)
        {
            bool agregar = true;

            foreach (DataRow filaControlar in dtDetalle.Rows) 
            {
                if (Convert.ToInt32(filaControlar["codigoProducto"]) == codigoProducto)
                {
                    agregar = false;
                    this.MensajeError("El producto ya se agrego al detalle");
                }
            }

            if (agregar)
            {
                DataRow fila = dtDetalle.NewRow();
                fila["codigoProducto"] = codigoProducto;
                fila["codigo"] = codigoBarra;
                fila["producto"] = nombre;
                fila["cantidad"] = 1;
                fila["precio"] = precio;
                fila["importe"] = precio;
                this.dtDetalle.Rows.Add(fila);
                this.CalcularTotales();
            }

        }
        private void CalcularTotales()
        {
            decimal total = 0;
            decimal subtotal = 0;
            if (dgvDetalle.Rows.Count == 0)//esta condición me aseguro que al eliminar un producto se actualice o no los totales y subtotales
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

            subtotal = total / (1+Convert.ToDecimal(txtAlicuota.Text));
            txtTotal.Text = total.ToString("#0.00#");
            txtSubTotal.Text = subtotal.ToString("#0.00#");
            txtTotalImpuesto.Text = (total - subtotal).ToString("#0.00#");
        }
        private void btnExplorarProd_Click(object sender, EventArgs e)
        {
            panelProducto.Visible = true;
        }

        private void btnCerrarPanel_Click(object sender, EventArgs e)
        {
            panelProducto.Visible = false;
        }

        private void btnBuscarPanel_Click(object sender, EventArgs e)
        {
            try 
            {
                dgvProductoPanel.DataSource = BLLProducto.Buscar(txtBuscarProducPanel.Text);
                this.FormatoProductoPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProductoPanel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int codigoProducto;
            string codigoBarra;
            string nombre;
            decimal precio;
            codigoProducto = Convert.ToInt32(dgvProductoPanel.CurrentRow.Cells["codigo"].Value);
            codigoBarra = Convert.ToString(dgvProductoPanel.CurrentRow.Cells["codigoBarra"].Value);
            nombre = Convert.ToString(dgvProductoPanel.CurrentRow.Cells["nombre"].Value);
            precio = Convert.ToDecimal(dgvProductoPanel.CurrentRow.Cells["precioVenta"].Value);
            this.AgregarDetalle(codigoProducto, codigoBarra, nombre, precio);
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //se crea un objeto de tipo DataRow para capturar la celda que se quiere modificar.
            //para saber el indice de la celda que se quiere modificar, como la cantidad se usa el index del parametro e
            DataRow fila = dtDetalle.Rows[e.RowIndex];
            decimal precio = Convert.ToDecimal(fila["precio"]);
            int cantidad = Convert.ToInt32(fila["cantidad"]);
            fila["importe"] = precio * cantidad;
            this.CalcularTotales();

        }

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.CalcularTotales();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (txtCodProveedor.Text == string.Empty || txtNumComprob.Text == string.Empty || dgvDetalle.Rows.Count == 0)
                {
                    this.MensajeError("Falta ingresar algunos datos");
                    errorProvider1.SetError(txtCodProveedor, "Ingresar código proveedor");
                    errorProvider1.SetError(txtNumComprob, "Ingresar número comprobante");
                    errorProvider1.SetError(dgvDetalle, "Debe ingresar al menos un producto");
                }
                else
                {
                    respuesta = bllCompra.Crear(Convert.ToInt32(txtCodProveedor.Text.Trim()), VariablesCompra.codigoUsuario, cmbComprobante.Text, txtNumComprob.Text, txtPuntoVenta.Text,
                                                dateFecha.Value, Convert.ToDecimal(txtAlicuota.Text), Convert.ToDecimal(txtTotal.Text), dtDetalle);
                    if (respuesta == true)
                    {
                        this.MensajeOk("Fue registrado de forma correctamente");
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
    }
}
