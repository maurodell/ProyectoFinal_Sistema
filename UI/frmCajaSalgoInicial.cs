using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace UI
{
    public partial class frmCajaSalgoInicial : Form
    {
        public DateTime Fecha = new DateTime();
        public decimal saldo = 0M;
        public frmCajaSalgoInicial()
        {
            InitializeComponent();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool respuesta = Regex.IsMatch(txtSaldoInicial.Text, "^(?![0-9]+$)");
            if (!respuesta)
            {
                if (txtSaldoInicial.Text.Length > 0)
                {
                    saldo = Convert.ToDecimal(txtSaldoInicial.Text);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Acepta caracteres númericos\nControlar espacios en blanco.", "ERROR");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmCajaSalgoInicial_Load(object sender, EventArgs e)
        {
            txtFechaSaldoInicial.Text = Fecha.ToShortDateString();
        }
    }
}
