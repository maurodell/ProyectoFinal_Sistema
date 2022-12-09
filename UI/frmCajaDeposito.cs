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
    public partial class frmCajaDeposito : Form
    {
        public decimal saldo = 0M;
        public frmCajaDeposito()
        {
            InitializeComponent();
        }
        void Limpiar()
        {
            txtDeposito.Clear();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool respuesta = Regex.IsMatch(txtDeposito.Text, "^(?![0-9]+$)");
            if (!respuesta)
            {
                if (txtDeposito.Text.Length > 0)
                {
                    saldo = Convert.ToDecimal(txtDeposito.Text);
                    this.DialogResult = DialogResult.OK;
                    Limpiar();
                }
                else
                {
                    Limpiar();
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
            txtDeposito.Clear();
            this.Close();
        }
    }
}
