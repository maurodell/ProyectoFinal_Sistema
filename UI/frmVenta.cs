using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using BLL;
using UI.Utils;
using BE;

namespace UI
{
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
            dtDetalle = new DataTable();
            bllVenta = new BLLVenta();
            bllProducto = new BLLProducto();
        }
        private BLLVenta bllVenta;
        private DataTable dtDetalle;
        BEProducto producto;
        BLLProducto bllProducto;

        private int codigoProducto;
        private string codigoBarra;
        private string nombre;
        private decimal precio;
        private int stock;
        private int posicion;
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

            dgvDetalle.Columns[1].ReadOnly = true;
            dgvDetalle.Columns[2].ReadOnly = true;
            dgvDetalle.Columns[3].ReadOnly = true;
            dgvDetalle.Columns[7].ReadOnly = true;
        }
        private void AgregarDetalle(int codigoProducto, string codigoBarra, string nombre, decimal precio, int stock)
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
                fila["stock"] = stock;
                fila["cantidad"] = 1;
                fila["precio"] = precio;
                fila["descuento"] = 0;
                fila["importe"] = precio;
                this.dtDetalle.Rows.Add(fila);
                this.CalcularTotales();
            }

        }
        //esta condición me aseguro que al eliminar un producto se actualice o no los totales y subtotales
        private void CalcularTotales()
        {
            decimal total = 0;
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
            txtTotal.Text = total.ToString("#0.00#");
            txtSubTotal.Text = subtotal.ToString("#0.00#");
            txtTotalImpuesto.Text = (total - subtotal).ToString("#0.00#");
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
            txtCodCliente.Clear();
            txtNombreCliente.Clear();
            txtCodigo.Clear();
            txtCodCliente.Clear();
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
                dgvListadoCompra.DataSource = bllVenta.Buscar(txtBuscarComprobante.Text);
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
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
        private void frmVenta_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.ListarCondicion();
            this.CrearDgvDetalle();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarClientes FrmBuscarClientes = new frmBuscarClientes();
            FrmBuscarClientes.ShowDialog();
            txtCodCliente.Text = Convert.ToString(VariableCliente.codigoCliente);
            txtNombreCliente.Text = VariableCliente.nombreCliente;
        }

        private void txtCodBarra_KeyDown(object sender, KeyEventArgs e)
        {
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
                        producto = bllVenta.BuscarProductoCodBarra(txtCodBarra.Text.Trim());

                        //vuelvo a verificar que el producto no sea null
                        if (producto != null)
                        {
                            this.AgregarDetalle(producto.Codigo, producto.codigoBarra, producto.nombre, producto.precioVenta, producto.stock);
                            txtCodBarra.Clear();
                        }
                        else
                        {
                            this.MensajeError("No existe el código de barra o no hay stock");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            stock = Convert.ToInt32(dgvProductoPanel.CurrentRow.Cells["stock"].Value);
            this.AgregarDetalle(codigoProducto, codigoBarra, nombre, precio, stock);
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRow fila = dtDetalle.Rows[e.RowIndex];
            string nombreProducto = Convert.ToString(fila["nombreProducto"]);
            int stock = Convert.ToInt32(fila["stock"]);
            decimal precio = Convert.ToDecimal(fila["precio"]);
            decimal descuento = Convert.ToDecimal(fila["descuento"]);
            int cantidad = Convert.ToInt32(fila["cantidad"]);
            if (cantidad > stock)
            {
                this.MensajeError($"La cantidad del producto:{nombreProducto}, debe ser menor o igual al stock");
                fila["cantidad"] = 1;
            }
            else
            {
                fila["importe"] = precio * cantidad;
                this.CalcularTotales();
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (txtNumComprob.Text == string.Empty || dgvDetalle.Rows.Count == 0 || txtNombreCliente.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos");

                    errorProvider1.SetError(txtNumComprob, "Ingresar número comprobante");
                    errorProvider1.SetError(dgvDetalle, "Debe ingresar al menos un producto");
                    errorProvider1.SetError(txtNombreCliente, "Debe ingresar un cliente");
                }
                else
                {
                    respuesta = bllVenta.Crear(Convert.ToInt32(txtCodCliente.Text.Trim()), VariablesCompra.codigoUsuario, cmbComprobante.Text, txtNumComprob.Text, txtPuntoVenta.Text,
                                                dateFecha.Value, Convert.ToDecimal(txtAlicuota.Text.Trim()), Convert.ToDecimal(txtTotal.Text), dtDetalle);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabControl1.SelectedIndex = 0;
            btnInsertar.Enabled = true;
            btnEliminar.Enabled = true;
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

        private void dgvListadoCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            btnInsertar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvListadoCompra.Columns[0].Visible = true;
                btnAnular.Visible = true;

                dgvListadoCompra.DataSource = null;
                dgvListadoCompra.DataSource = bllVenta.ListarTodos();
            }
            else
            {
                dgvListadoCompra.Columns[0].Visible = false;
                btnAnular.Visible = false;

                dgvListadoCompra.DataSource = null;
                dgvListadoCompra.DataSource = bllVenta.Listar();
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
                            estado = Convert.ToInt32(row.Cells[10].Value);
                            if (estado.Equals(1))
                            {
                                codigo = Convert.ToInt32(row.Cells[11].Value);
                                flag = bllVenta.Baja(codigo);
                            }
                            else
                            {
                                MensajeError("Imposible anular la compra dado que ya está dada de baja.");
                            }

                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("La venta fue dada de baja correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de baja la venta");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvListadoCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(dgvListadoCompra.Columns["Seleccionar"].Index))
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListadoCompra.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);//Determino si esta o no esta marcado el checkBox(Documentacion DataGridView)
            }
        }
    }
    enum Comprobantes { Exento, No_responsable, Consumidor_Final, Responsable_Inscripto, No_categorizado }
}
