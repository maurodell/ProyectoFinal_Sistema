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
using System.Runtime.InteropServices;

namespace UI
{
    public partial class frmVenta : Form
    {
        public delegate void Delegado(decimal mensaje);
        public event Delegado MiEvent;
        public decimal totalFinal = 0;
        public frmVenta()
        {
            InitializeComponent();
            dtDetalle = new DataTable();
            bllVenta = new BLLVenta();
            bllProducto = new BLLProducto();
            bllCliente = new BLLCliente();
        }
        private BLLVenta bllVenta;
        private DataTable dtDetalle;
        BEProducto producto;
        BEVenta beVenta;
        BLLProducto bllProducto;
        BLLCliente bllCliente;
        private int codigoProducto;
        private string codigoBarra;
        private string nombre;
        private decimal precio;
        private int stock;
        private int posicion;

        //-----------------------------------------------------------------------------------
        //Deshabilitar botón cerrar del formulario
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);
        const int MF_BYCOMMAND = 0;
        const int MF_DISABLED = 2;
        const int SC_CLOSE = 0xF060;
        //------------------------------------------------------------------------------------
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
            try
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
            catch (Exception)
            {

            }
        }
        //esta condición me aseguro que al eliminar un producto se actualice o no los totales y subtotales
        private void CalcularTotales()
        {
            try
            {
                decimal subtotal = 0;
                if (dgvDetalle.Rows.Count == 0)
                {
                    totalFinal = 0;
                }
                else
                {
                    foreach (DataRow item in dtDetalle.Rows)
                    {
                        totalFinal = totalFinal + Convert.ToDecimal(item["importe"]);
                    }
                }

                subtotal = totalFinal / (1 + Convert.ToDecimal(txtAlicuota.Text));
                txtTotal.Text = totalFinal.ToString("#0,0#");
                txtSubTotal.Text = subtotal.ToString("#0,0#");
                txtTotalImpuesto.Text = (totalFinal - subtotal).ToString("#0,0#");
                subtotal = 0;
            }
            catch (Exception)
            {

            }

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

                //solo se ejecuta la primera vez para ponerle un valor al nro. comprobante
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
            tabControl1.SelectedIndex = 1;
            this.Listar();
            this.ListarCondicion();
            this.CrearDgvDetalle();
            btnImprimir.Visible = false;
            txtNumComprob.Enabled = false;
            txtPuntoVenta.Text = "0001";

            //--------------------------------------------------------
            //Deshabilitar boton cerrar del formulario
            var sm = GetSystemMenu(Handle, false);
            EnableMenuItem(sm, SC_CLOSE, MF_BYCOMMAND | MF_DISABLED);
            //--------------------------------------------------------
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarClientes FrmBuscarClientes = new frmBuscarClientes();
                FrmBuscarClientes.ShowDialog();
                txtCodCliente.Text = Convert.ToString(VariableCliente.codigoCliente);
                txtNombreCliente.Text = VariableCliente.nombreCliente;

                if (txtNombreCliente.Text.Length > 0)
                {
                    setNroComproantesAutomatico(dgvListadoCompra);
                }
            }
            catch (Exception)
            {

            }

        }
        private void setNroComproantesAutomatico(DataGridView dgvCompra)
        {
            try
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
            catch (Exception)
            {

            }

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
            try
            {
                panelProducto.Visible = true;
                dgvProductoPanel.DataSource = bllProducto.Listar();
                this.FormatoProductoPanel();
            }
            catch (Exception)
            {

            }
        }
        private void btnCerrarPanel_Click(object sender, EventArgs e)
        {
            panelProducto.Visible = false;
        }
        private void btnBuscarPanel_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = Regex.IsMatch(txtBuscarProducPanel.Text, @"^(?![a-zA-Z\s\p{L}]+$)");
                if (respuesta)
                {
                    string texto = txtBuscarProducPanel.Text.Trim().ToLower();
                    dgvProductoPanel.DataSource = bllProducto.Buscar(texto);
                    this.FormatoProductoPanel();
                }
                else
                {
                    MessageBox.Show("Solo acepta caracteres", "ERROR");
                }

            }
            catch (Exception)
            {

            }
        }

        private void dgvProductoPanel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                codigoProducto = Convert.ToInt32(dgvProductoPanel.CurrentRow.Cells["codigo"].Value);
                codigoBarra = Convert.ToString(dgvProductoPanel.CurrentRow.Cells["codigoBarra"].Value);
                nombre = Convert.ToString(dgvProductoPanel.CurrentRow.Cells["nombre"].Value);
                precio = Convert.ToDecimal(dgvProductoPanel.CurrentRow.Cells["precioVenta"].Value);
                stock = Convert.ToInt32(dgvProductoPanel.CurrentRow.Cells["stock"].Value);
                if (stock == 0)
                {
                    MensajeError("El producto no tiene stock");
                }
                else if(stock >= 1 && stock <= 15)
                {
                    this.AgregarDetalle(codigoProducto, codigoBarra, nombre, precio, stock);
                    MensajeOk("El stock del producto está bajo");
                }
                else
                {
                    this.AgregarDetalle(codigoProducto, codigoBarra, nombre, precio, stock);
                }
            }
            catch (Exception)
            {

            }

        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal total = 0M;
                decimal calcularDescuento = 0M;
                decimal descuento = 0M;
                int cantidad = 0;
                string nombreProducto = "";
                int stock = 0;
                decimal precio = 0M;
                DataRow fila = dtDetalle.Rows[e.RowIndex];
                string desc = Convert.ToString(fila["descuento"]);
                string cant = Convert.ToString(fila["cantidad"]);

                if (desc.Equals(string.Empty))
                {
                    fila["descuento"] = 0;
                }
                else if(cant.Equals(string.Empty))
                {
                    fila["cantidad"] = 1;
                }

                nombreProducto = Convert.ToString(fila["nombreProducto"]);
                stock = Convert.ToInt32(fila["stock"]);
                precio = Convert.ToDecimal(fila["precio"]);
                descuento = Convert.ToDecimal(fila["descuento"]);
                cantidad = Convert.ToInt32(fila["cantidad"]);

                if (cantidad > stock)
                {
                    this.MensajeError($"La cantidad del producto:{nombreProducto}, debe ser menor o igual al stock");
                    fila["cantidad"] = 1;
                }
                else if(descuento > 0)
                {
                    total = precio * cantidad;
                    calcularDescuento = (descuento / 100) * total;
                    fila["importe"] = total - calcularDescuento;
                    this.CalcularTotales();
                }
                else
                {
                    fila["importe"] = precio * cantidad;
                    this.CalcularTotales();
                }
            }
            catch (Exception)
            {

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
                    if (UserRegex())
                    {
                        List<DetalleVenta> listaDetalle = new List<DetalleVenta>();
                        DetalleVenta detalle;
                        for (int i = 0; i < dtDetalle.Rows.Count; i++)
                        {
                            detalle = new DetalleVenta();
                            detalle.codigoBarra = Convert.ToInt64(dtDetalle.Rows[i]["codigoBarra"]);
                            detalle.codigoProducto = Convert.ToInt32(dtDetalle.Rows[i]["codigoProducto"]);
                            detalle.nombreProducto = Convert.ToString(dtDetalle.Rows[i]["nombreProducto"]);
                            detalle.stock = Convert.ToInt32(dtDetalle.Rows[i]["stock"]);
                            detalle.cantidad = Convert.ToInt32(dtDetalle.Rows[i]["cantidad"]);
                            detalle.precio = Convert.ToDecimal(dtDetalle.Rows[i]["precio"]);
                            detalle.descuento = Convert.ToDecimal(dtDetalle.Rows[i]["descuento"]);
                            detalle.importe = Convert.ToDecimal(dtDetalle.Rows[i]["importe"]);
                            listaDetalle.Add(detalle);
                        }
                        beVenta = new BEVenta();
                        beVenta.codigoCliente = Convert.ToInt32(txtCodCliente.Text.Trim());
                        beVenta.codigoUsuario = VariablesCompra.codigoUsuario;
                        beVenta.tipoComprobante = cmbComprobante.Text;
                        beVenta.nroComprobante = txtNumComprob.Text;
                        beVenta.puntoVenta = txtPuntoVenta.Text;
                        beVenta.fecha = Convert.ToDateTime(dateFecha.Value.ToString("dd/MM/yyyy"));
                        beVenta.total = Convert.ToDecimal(txtTotal.Text);
                        beVenta.impuesto = Convert.ToDecimal(txtAlicuota.Text.Trim());
                        beVenta.detalles = listaDetalle;

                        respuesta = bllVenta.Crear(beVenta);
                        if (respuesta == true)
                        {
                            this.MensajeOk("Fue registrado de forma correctamente");
                            this.Listar();
                            this.MiEvent(Convert.ToDecimal(totalFinal));
                            this.Limpiar();
                            totalFinal = 0;
                        }
                        else
                        {
                            this.MensajeError("El registro no se pudo realizar\n" +
                                                "Puede ser que el número de comprobante ya exísta.\n" +
                                                "O quizás el stock ingresado no alcance.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private bool UserRegex()
        {
            bool salida = true;
            switch (true)
            {
                case bool _ when Regex.IsMatch(txtPuntoVenta.Text, "^(?![0-9]+$)"):
                    MessageBox.Show("El punto de venta solo caracteres númericos", "ERROR");
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            btnInsertar.Enabled = true;
            btnEliminar.Enabled = true;
            btnImprimir.Visible = false;
            this.Close();
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
            try
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
                btnInsertar.Enabled = false;
                btnEliminar.Enabled = false;
                btnImprimir.Visible = true;
            }
            catch (Exception)
            {

            }

        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {

            }

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoControl = 0;
                foreach (DataGridViewRow row in dgvListadoCompra.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigoControl = Convert.ToInt32(row.Cells[11].Value);
                    }
                }
                if (codigoControl > 0)
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
                            this.MensajeOk("La venta fue dada de baja correctamente.");
                            this.Limpiar();
                            this.Listar();
                        }
                        else
                        {
                            this.MensajeError("Algo salío mal al dar de baja la venta.");
                        }
                    }
                }
                else
                {
                    this.MensajeError("Debe seleccionar al menos una venta.");
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog guardarArchivo = new SaveFileDialog();
                guardarArchivo.FileName = dateFecha.Value.ToString("ddMMyyyy")+txtNumComprob.Text+".pdf";
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
            catch (Exception){ }
        }
        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult dialogo = MessageBox.Show("Cierra definitivamente la carga de Venta del Día?", "Cierre", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    this.Hide();
                }
                else
                {
                    e.Cancel = false;
                }
            }
            catch (Exception){  }
        }

        private void frmVenta_Resize(object sender, EventArgs e)
        {
            var sm = GetSystemMenu(Handle, false);
            EnableMenuItem(sm, SC_CLOSE, MF_BYCOMMAND | MF_DISABLED);
        }
    }
    enum Comprobantes { Exento, No_responsable, Consumidor_Final, Responsable_Inscripto, No_categorizado }
}
