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

namespace UI
{
    public partial class frmCaja : Form
    {
        public frmCaja()
        {
            InitializeComponent();
            bllCaja = new BLLCaja();
        }
        BLLCaja bllCaja;
        private decimal totalVentas;
        private decimal totalCompras;
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Formato()
        {
            dgvCaja.Columns[0].HeaderText = "Caja Inicial";
            dgvCaja.Columns[0].Width = 60;
            dgvCaja.Columns[1].HeaderText = "Ventas";
            dgvCaja.Columns[1].Width = 100;
            dgvCaja.Columns[2].HeaderText = "Compras";
            dgvCaja.Columns[2].Width = 100;
            dgvCaja.Columns[3].HeaderText = "Saldo Final";
            dgvCaja.Columns[3].Width = 100;
            dgvCaja.Columns[4].HeaderText = "Usuario";
            dgvCaja.Columns[4].Width = 50;
            dgvCaja.Columns[5].HeaderText = "Fecha";
            dgvCaja.Columns[5].Width = 120;
            dgvCaja.Columns[6].HeaderText = "Estado";
            dgvCaja.Columns[6].Width = 50;
            dgvCaja.Columns[7].HeaderText = "Código";
            dgvCaja.Columns[7].Width = 60;
        }
        private void Listar()
        {
            try
            {
                dgvCaja.DataSource = null;
                dgvCaja.DataSource = bllCaja.Listar();
                this.Formato();
                //this.Limpiar();
                //lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCompra.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Limpiar()
        {
            txtIngresosVentas.Clear();
            txtPagosProv.Clear();
            txtSaldoFinal.Clear();
            txtSaldoInicial.Clear();
            btnCerrarCaja.Enabled = false;
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (txtSaldoInicial.Text != string.Empty)
            {
                btnCerrarCaja.Enabled = true;
                DateTime fecha = Convert.ToDateTime(datePickFecha.Value.ToString("dd/MM/yyyy"));
                totalVentas = bllCaja.CalcularVentas(fecha);
                txtIngresosVentas.Text = totalVentas.ToString();

                totalCompras = bllCaja.CalcularCompras(fecha);
                txtPagosProv.Text = totalCompras.ToString();

                decimal saldoInicial = Convert.ToDecimal(txtSaldoInicial.Text);
                decimal saldoFinal = (saldoInicial + totalVentas) - totalCompras;
                txtSaldoFinal.Text = saldoFinal.ToString();
            }
            else
            {
                MensajeError("Debe ingresar un saldo Inicial de caja");
            }

        }

        private void frmCaja_Load(object sender, EventArgs e)
        {
            this.Listar();
            btnCerrarCaja.Enabled = false;
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
            bool flag = bllCaja.Crear(date, Convert.ToDecimal(txtIngresosVentas.Text.Trim()), Convert.ToDecimal(txtPagosProv.Text.Trim()),
                                    Convert.ToDecimal(txtSaldoInicial.Text.Trim()), Convert.ToDecimal(txtSaldoFinal.Text.Trim()), VariablesCompra.codigoUsuario);
            if (flag)
            {
                this.Listar();
                this.Limpiar();
                MensajeOk("Asiento contable realizado correctamente.");
            }
            else
            {
                MensajeError("Algo salío mal, no se puedo gerenerar el asiento contable.");
            }
        }
    }
}
