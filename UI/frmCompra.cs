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
            bllProducto = new BLLProducto();
            dtDetalle = new DataTable();
        }
        BLLCompra bllCompra;
        BLLProducto bllProducto;
        private DataTable dtDetalle;
        private BEProducto producto;
        private int codigoProducto;
        private string codigoBarra;
        private string nombre;
        private decimal precio;
        private int posicion;
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

            dgvDetalle.Columns[1].ReadOnly = true;
            dgvDetalle.Columns[2].ReadOnly = true;
            dgvDetalle.Columns[5].ReadOnly = true;
        }
        private void Formato()
        {
            dgvListadoCompra.Columns[0].Visible = false;
            dgvListadoCompra.Columns[1].HeaderText = "Código Usuario";
            dgvListadoCompra.Columns[1].Width = 50;
            dgvListadoCompra.Columns[2].HeaderText = "Tipo Comprobante";
            dgvListadoCompra.Columns[2].Width = 100;
            dgvListadoCompra.Columns[3].HeaderText = "Punto De venta";
            dgvListadoCompra.Columns[3].Width = 80;
            dgvListadoCompra.Columns[4].HeaderText = "Nro. Comprobante";
            dgvListadoCompra.Columns[4].Width = 100;
            dgvListadoCompra.Columns[5].HeaderText = "Fecha";
            dgvListadoCompra.Columns[5].Width = 100;
            dgvListadoCompra.Columns[6].HeaderText = "Impuesto";
            dgvListadoCompra.Columns[6].Width = 150;
            dgvListadoCompra.Columns[7].HeaderText = "Total";
            dgvListadoCompra.Columns[7].Width = 100;
            dgvListadoCompra.Columns[8].HeaderText = "Estado Actual";
            dgvListadoCompra.Columns[8].Width = 100;
            dgvListadoCompra.Columns[9].Width = 100;
            dgvListadoCompra.Columns[9].HeaderText = "Estado";
            dgvListadoCompra.Columns[9].Visible = false;
            dgvListadoCompra.Columns[10].HeaderText = "Código";
            dgvListadoCompra.Columns[10].Width = 40;
        }
        private void FormatoProductoPanel()
        {
            dgvProductoPanel.Columns[0].HeaderText = "Código Categ.";
            dgvProductoPanel.Columns[0].Width = 50;
            dgvProductoPanel.Columns[1].HeaderText = "Código Barra";
            dgvProductoPanel.Columns[1].Width = 50;
            dgvProductoPanel.Columns[2].Width = 100;
            dgvProductoPanel.Columns[3].Width = 60;
            dgvProductoPanel.Columns[3].HeaderText = "Precio";
            dgvProductoPanel.Columns[4].Width = 50;
            dgvProductoPanel.Columns[5].Width = 140;
            dgvProductoPanel.Columns[5].HeaderText = "Descripción";
            dgvProductoPanel.Columns[6].Width = 50;
            dgvProductoPanel.Columns[6].HeaderText = "Ubicación";
            dgvProductoPanel.Columns[6].Width = 80;
            dgvProductoPanel.Columns[7].Width = 140;
            dgvProductoPanel.Columns[7].HeaderText = "Fecha Vencimiento";
            dgvProductoPanel.Columns[8].Width = 80;
            dgvProductoPanel.Columns[9].Width = 20;
            dgvProductoPanel.Columns[10].HeaderText = "Código";
            dgvProductoPanel.Columns[10].Width = 50;
        }
        private void Limpiar()
        {
            txtBuscarComprobante.Clear();
            txtCodigo.Clear();
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
            btnAnular.Visible = false;
            chkSeleccionar.Checked = false;
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
                dgvListadoCompra.DataSource = null;
                if (txtBuscarComprobante.Text != null)
                {
                    dgvListadoCompra.DataSource = bllCompra.Buscar(txtBuscarComprobante.Text);
                }
                else
                {
                    MessageBox.Show("Debe ingresar un número de comprobante de compra");
                }
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        //private void BuscarProductoCodBarra()
        //{
        //    try
        //    {
        //        dgvListadoCompra.DataSource = null;
        //        if (txtBuscarComprobante.Text != null)
        //        {
        //            MensajeError("No puede ingresar 2 parametros a buscar");
        //        }
        //        else
        //        {
        //            dgvListadoCompra.DataSource = bllCompra.BuscarProductoCodBarra(txtCodBarra.Text);
        //        }
        //        this.Formato();
        //        lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + ex.StackTrace);
        //    }
        //}
        private void frmCompra_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CrearDgvDetalle();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
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
                fila["codigoBarra"] = codigoBarra;
                fila["nombreProducto"] = nombre;
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
            dgvProductoPanel.DataSource = bllProducto.Listar();
            this.FormatoProductoPanel();
        }

        private void btnCerrarPanel_Click(object sender, EventArgs e)
        {
            panelProducto.Visible = false;
        }

        private void btnBuscarPanel_Click(object sender, EventArgs e)
        {
            try 
            {
                dgvProductoPanel.DataSource = bllProducto.Buscar(txtBuscarProducPanel.Text.Trim());
                this.FormatoProductoPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProductoPanel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
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

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (txtNumComprob.Text == string.Empty || dgvDetalle.Rows.Count == 0)
                {
                    this.MensajeError("Falta ingresar algunos datos");

                    errorProvider1.SetError(txtNumComprob, "Ingresar número comprobante");
                    errorProvider1.SetError(dgvDetalle, "Debe ingresar al menos un producto");
                }
                else
                {
                    respuesta = bllCompra.Crear(VariablesCompra.codigoUsuario, cmbComprobante.Text, txtNumComprob.Text, txtPuntoVenta.Text,
                                                dateFecha.Value, Convert.ToDecimal(txtAlicuota.Text), Convert.ToDecimal(txtTotal.Text), dtDetalle);
                    if (respuesta == true)
                    {
                        this.MensajeOk("Fue registrado de forma correctamente");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError("El registro no se pudo realizar\n" +
                                            "Puede ser que el número de comprobante ya exísta.\n" +
                                            "O el stock ingresado no alcance.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0)
            {
                dgvDetalle.Rows.RemoveAt(posicion);
                this.CalcularTotales();
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = dgvDetalle.CurrentRow.Index;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabControl1.SelectedIndex = 0;
            btnInsertar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void dgvListadoCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Limpiar();
            int codigoCompra = Convert.ToInt32(dgvListadoCompra.CurrentRow.Cells["codigo"].Value);
            BECompra compra = bllCompra.CargarCompra(codigoCompra);
            cmbComprobante.SelectedItem = compra.tipoComprobante;
            txtPuntoVenta.Text = compra.puntoVenta;
            txtNumComprob.Text = compra.nroComprobante;
            dateFecha.Value = compra.fecha;
            txtCodigo.Visible = true;
            txtCodigo.Text = Convert.ToString(compra.Codigo);

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
            btnInsertar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void dgvListadoCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(dgvListadoCompra.Columns["Seleccionar"].Index))
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListadoCompra.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);//Determino si esta o no esta marcado el checkBox(Documentacion DataGridView)
            }
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvListadoCompra.Columns[0].Visible = true;
                btnAnular.Visible = true;

                dgvListadoCompra.DataSource = null;
                dgvListadoCompra.DataSource = bllCompra.ListarTodos();
            }
            else
            {
                dgvListadoCompra.Columns[0].Visible = false;
                btnAnular.Visible = false;

                dgvListadoCompra.DataSource = null;
                dgvListadoCompra.DataSource = bllCompra.Listar();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Esta seguro que desea anular el/los registro/s?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion.Equals(DialogResult.OK))
                {
                    int codigo;
                    int estado;
                    bool flag = false;
                    foreach (DataGridViewRow row in dgvListadoCompra.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            estado = Convert.ToInt32(row.Cells[9].Value);
                            if (estado.Equals(1))
                            {
                                codigo = Convert.ToInt32(row.Cells[10].Value);
                                flag = bllCompra.Baja(codigo);
                            }
                            else
                            {
                                MensajeError("Imposible anular la compra dado que ya está dada de baja.");
                            }

                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("La compra fue dada de baja correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de baja la compra");
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
