using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class frmCaja : Form
    {
        frmVenta VentaForm = new frmVenta();
        frmCompra CompraForm = new frmCompra();
        private DataGridViewButtonColumn dgvButtonDeposito = new DataGridViewButtonColumn();
        private DataGridViewButtonColumn dgvButtonRetira = new DataGridViewButtonColumn();
        private DataGridViewButtonColumn dgvButtonCerrar = new DataGridViewButtonColumn();
        public static bool flagVenta = false;
        public decimal importeTotalVenta = 0M;
        public frmCaja()
        {
            InitializeComponent();
            bllCaja = new BLLCaja();
            cajaInicial = new DataTable();
            btnAgregarCaja.Enabled = true;
        }
        BLLCaja bllCaja;
        BECaja beCaja;
        private DataTable cajaInicial;
        private decimal totalCompras;
        private decimal totalVentas;
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void FormatoDataTable()
        {
            this.cajaInicial.Columns.Add("nro", Type.GetType("System.Int32"));
            this.cajaInicial.Columns.Add("fechaApertura", Type.GetType("System.DateTime"));
            this.cajaInicial.Columns.Add("fechaCierre", Type.GetType("System.DateTime"));
            this.cajaInicial.Columns.Add("saldoInicial", Type.GetType("System.Decimal"));
            this.cajaInicial.Columns.Add("deposito", Type.GetType("System.Decimal"));
            this.cajaInicial.Columns.Add("salida", Type.GetType("System.Decimal"));
            this.cajaInicial.Columns.Add("ventas", Type.GetType("System.Decimal"));
            this.cajaInicial.Columns.Add("compras", Type.GetType("System.Decimal"));
            this.cajaInicial.Columns.Add("saldoFaltante", Type.GetType("System.Decimal"));
            this.cajaInicial.Columns.Add("saldoCaja", Type.GetType("System.Decimal"));
        }
        private void DataTable()
        {
            dgvCajaInicial.Columns[0].Width = 50;
            dgvCajaInicial.Columns[0].HeaderText = "Nro";
            dgvCajaInicial.Columns[1].Width = 100;
            dgvCajaInicial.Columns[1].HeaderText = "Fecha Apertura";
            dgvCajaInicial.Columns[2].Width = 100;
            dgvCajaInicial.Columns[2].HeaderText = "Fecha Cierre";
            dgvCajaInicial.Columns[3].Width = 100;
            dgvCajaInicial.Columns[3].HeaderText = "Saldo Inicial";
            dgvCajaInicial.Columns[4].Width = 100;
            dgvCajaInicial.Columns[4].HeaderText = "Depositos";
            dgvCajaInicial.Columns[5].Width = 100;
            dgvCajaInicial.Columns[5].HeaderText = "Salidas";
            dgvCajaInicial.Columns[6].Width = 100;
            dgvCajaInicial.Columns[6].HeaderText = "Ventas";
            dgvCajaInicial.Columns[7].Width = 100;
            dgvCajaInicial.Columns[7].HeaderText = "Compras";
            dgvCajaInicial.Columns[8].Width = 100;
            dgvCajaInicial.Columns[8].HeaderText = "Faltante";
            dgvCajaInicial.Columns[9].Width = 100;
            dgvCajaInicial.Columns[9].HeaderText = "Saldo Caja";

            dgvButtonDeposito.Name = "agregar";
            dgvButtonDeposito.HeaderText = "Depositar";
            dgvButtonDeposito.Width = 70;
            dgvButtonDeposito.Text = "+";
            dgvButtonDeposito.UseColumnTextForButtonValue = true;

            dgvButtonRetira.Name = "retirar";
            dgvButtonRetira.Text = "-";
            dgvButtonRetira.HeaderText = "Retirar";
            dgvButtonRetira.Width = 50;
            dgvButtonRetira.UseColumnTextForButtonValue = true;

            dgvButtonCerrar.Name = "cerrar";
            dgvButtonCerrar.Text = "Cerrar";
            dgvButtonCerrar.HeaderText = "Cerrar Caja";
            dgvButtonCerrar.Width = 50;
            dgvButtonCerrar.UseColumnTextForButtonValue = true;
            dgvCajaInicial.Columns.Add(dgvButtonDeposito);
            dgvCajaInicial.Columns.Add(dgvButtonRetira);
            dgvCajaInicial.Columns.Add(dgvButtonCerrar);
        }
        private void ListarDataTable()
        {
            dgvCajaInicial.DataSource = null;
            dgvCajaInicial.DataSource = cajaInicial;
            DataTable();
        }
        private void Formato()
        {
            dgvCaja.Columns[0].Width = 100;
            dgvCaja.Columns[0].HeaderText = "Fecha Apertura";
            dgvCaja.Columns[1].Width = 120;
            dgvCaja.Columns[1].HeaderText = "Fecha Cierre";
            dgvCaja.Columns[2].Width = 100;
            dgvCaja.Columns[2].HeaderText = "Saldo Inicial";
            dgvCaja.Columns[3].Width = 100;
            dgvCaja.Columns[3].HeaderText = "Depositos";
            dgvCaja.Columns[4].Width = 100;
            dgvCaja.Columns[4].HeaderText = "Salidas";
            dgvCaja.Columns[5].Width = 100;
            dgvCaja.Columns[5].HeaderText = "Ventas";
            dgvCaja.Columns[6].Width = 100;
            dgvCaja.Columns[6].HeaderText = "Compras";
            dgvCaja.Columns[7].Width = 100;
            dgvCaja.Columns[7].HeaderText = "Faltante";
            dgvCaja.Columns[8].Width = 100;
            dgvCaja.Columns[8].HeaderText = "Saldo Caja";
            dgvCaja.Columns[9].Width = 50;
            dgvCaja.Columns[9].HeaderText = "Estado";
            dgvCaja.Columns[10].Width = 50;
            dgvCaja.Columns[10].HeaderText = "Nro";
        }
        private void Listar()
        {
            try
            {
                dgvCaja.DataSource = null;
                dgvCaja.DataSource = bllCaja.Listar();
                this.Formato();
            }
            catch (Exception)
            {
            }
        }
        private void Limpiar()
        {
            cajaInicial.Rows.Clear();
            dgvCajaInicial.Columns.Remove(dgvButtonCerrar);
            dgvCajaInicial.Columns.Remove(dgvButtonRetira);
            dgvCajaInicial.Columns.Remove(dgvButtonDeposito);
            this.btnCancelarCaja.Enabled = false;
        }
        private void frmCaja_Load(object sender, EventArgs e)
        {
            //VentaForm.MiEvent += new frmVenta.Delegado(PonerVenta);
            this.Listar();
            this.Formato();
            this.FormatoDataTable();
            btnCancelarCaja.Enabled = false;
        }
        public void PonerVenta(decimal venta)
        {
            try
            {
                decimal ventaCaja = 0M;
                foreach (DataGridViewRow fila in dgvCajaInicial.Rows)
                {
                    ventaCaja = Convert.ToDecimal(fila.Cells["ventas"].Value);
                }
                venta += ventaCaja;
                dgvCajaInicial.Rows[0].Cells[6].Value = venta;
                Calcular();
            }
            catch (Exception)
            {

            }
        }
        public void PonerCompra(decimal compra)
        {
            try
            {
                decimal compraCaja = 0M;
                foreach (DataGridViewRow fila in dgvCajaInicial.Rows)
                {
                    compraCaja = Convert.ToDecimal(fila.Cells["compras"].Value);
                }
                compra += compraCaja;
                dgvCajaInicial.Rows[0].Cells[7].Value = compra;
                Calcular();
            }
            catch (Exception)
            {

            }
        }
        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            Limpiar();
            this.btnAgregarCaja.Enabled = true;
        }

        private void btnAgregarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                VentaForm.MiEvent += new frmVenta.Delegado(PonerVenta);
                 CompraForm.MiEvent += new frmCompra.Delegado(PonerCompra);

                frmCajaSalgoInicial saldoInicial = new frmCajaSalgoInicial();
                saldoInicial.Fecha = Convert.ToDateTime(datePickFecha.Value);
                DialogResult respuesta = saldoInicial.ShowDialog();
                if (respuesta.Equals(DialogResult.OK))
                {
                    totalVentas = bllCaja.CalcularVentas(datePickFecha.Value);
                    totalCompras = bllCaja.CalcularCompras(datePickFecha.Value);
                    saldoInicial.Close();
                    btnAgregarCaja.Enabled = false;

                    ListarDataTable();
                    DataRow fila = cajaInicial.NewRow();
                    fila["nro"] = dgvCaja.Rows.Count + 1;
                    fila["fechaApertura"] = datePickFecha.Value;
                    //fila["fechaCierre"] = "";
                    fila["saldoInicial"] = saldoInicial.saldo;
                    fila["deposito"] = 0;
                    fila["salida"] = 0;
                    fila["ventas"] = totalVentas;
                    fila["compras"] = totalCompras;
                    fila["saldoFaltante"] = 0;
                    fila["saldoCaja"] = (saldoInicial.saldo + totalVentas) - totalCompras;
                    this.cajaInicial.Rows.Add(fila);

                    this.btnCancelarCaja.Enabled = true;
                    this.btnVenta.Enabled = true;
                    this.btnCompra.Enabled = true;
                }
            }
            catch (Exception)
            {

            }

        } 
        private void dgvCajaInicial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 10:
                        frmCajaDeposito deposito = new frmCajaDeposito();
                        DialogResult respuesta = deposito.ShowDialog();
                        decimal saldoAnterior = Convert.ToDecimal(dgvCajaInicial.Rows[e.RowIndex].Cells[4].Value);
                        if (respuesta.Equals(DialogResult.OK))
                        {
                            saldoAnterior += deposito.saldo;
                            dgvCajaInicial.Rows[e.RowIndex].Cells[4].Value = saldoAnterior;
                            Calcular();
                            deposito.Close();
                        }
                        break;
                    case 11:
                        frmCajaSalida salida = new frmCajaSalida();
                        DialogResult respuestaSalida = salida.ShowDialog();
                        decimal saldoSalida = Convert.ToDecimal(dgvCajaInicial.Rows[e.RowIndex].Cells[5].Value);
                        if (respuestaSalida.Equals(DialogResult.OK))
                        {
                            saldoSalida += salida.saldo;
                            dgvCajaInicial.Rows[e.RowIndex].Cells[5].Value = saldoSalida;
                            Calcular();
                            salida.Close();
                        }
                        break;
                    case 12:
                        DateTime horaAhora = DateTime.Now;
                        dgvCajaInicial.Rows[e.RowIndex].Cells[2].Value = horaAhora;

                        DialogResult opcion;
                        opcion = MessageBox.Show("Confirma que desea cerrar la caja diaría?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (opcion.Equals(DialogResult.OK))
                        {
                            beCaja = new BECaja();
                            beCaja.Codigo = Convert.ToInt32(dgvCajaInicial.Rows[e.RowIndex].Cells[0].Value);
                            beCaja.fechaApertura = Convert.ToDateTime(dgvCajaInicial.Rows[e.RowIndex].Cells[1].Value);
                            beCaja.fechaCierre = Convert.ToDateTime(dgvCajaInicial.Rows[e.RowIndex].Cells[2].Value);
                            beCaja.saldoInicial = Convert.ToDecimal(dgvCajaInicial.Rows[e.RowIndex].Cells[3].Value);
                            beCaja.saldoDeposito = Convert.ToDecimal(dgvCajaInicial.Rows[e.RowIndex].Cells[4].Value);
                            beCaja.saldoSalida = Convert.ToDecimal(dgvCajaInicial.Rows[e.RowIndex].Cells[5].Value);
                            beCaja.saldoVentas = Convert.ToDecimal(dgvCajaInicial.Rows[e.RowIndex].Cells[6].Value);
                            beCaja.saldoCompras = Convert.ToDecimal(dgvCajaInicial.Rows[e.RowIndex].Cells[7].Value);
                            beCaja.saldoFaltante = Convert.ToDecimal(dgvCajaInicial.Rows[e.RowIndex].Cells[8].Value);
                            beCaja.saldoFinal = Convert.ToDecimal(dgvCajaInicial.Rows[e.RowIndex].Cells[9].Value);
                            bool flag = bllCaja.Crear(beCaja);
                            if (flag)
                            {
                                this.MensajeOk("La Caja se cerro de forma correcta.");
                                this.Limpiar();
                                this.Listar();
                                this.Formato();
                                this.btnAgregarCaja.Enabled = true;
                                this.btnVenta.Enabled = false;
                                this.btnCompra.Enabled = false; 
                                this.btnCancelarCaja.Enabled = false;

                                VentaForm.MiEvent -= new frmVenta.Delegado(PonerVenta);
                                CompraForm.MiEvent -= new frmCompra.Delegado(PonerCompra);
                            }
                            else
                            {
                                this.MensajeError("Algo salío mal.");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

            }

        }
        private void Calcular()
        {
            try
            {
                decimal saldoInicial = 0M;
                decimal deposito = 0M;
                decimal salida = 0M;
                decimal compras = 0M;
                decimal ventas = 0M;
                decimal saldoCaja = 0M;
                foreach (DataGridViewRow fila in dgvCajaInicial.Rows)
                {
                    saldoInicial = Convert.ToDecimal(fila.Cells["saldoInicial"].Value);
                    deposito = Convert.ToDecimal(fila.Cells["deposito"].Value);
                    salida = Convert.ToDecimal(fila.Cells["salida"].Value);
                    ventas = Convert.ToDecimal(fila.Cells["ventas"].Value);
                    compras = Convert.ToDecimal(fila.Cells["compras"].Value);
                }
                saldoCaja = (saldoInicial + deposito + ventas) - (salida + compras);
                dgvCajaInicial.Rows[0].Cells[9].Value = saldoCaja;
            }
            catch (Exception )
            {

            }
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            try
            {
                VentaForm.Show();
                VentaForm.Size = new Size(1370, 660);
            }
            catch (Exception)
            {

            }
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            try
            {
                CompraForm.Show();
                CompraForm.Size = new Size(1370, 660);
            }
            catch (Exception )
            {

            }
        }
    }
}
