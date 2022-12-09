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
    public partial class frmCajaSalida : Form
    {
        public decimal saldo = 0M;
        public frmCajaSalida()
        {
            InitializeComponent();
        }
        void Limpiar()
        {
            txtSalida.Clear();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool respuesta = Regex.IsMatch(txtSalida.Text, "^(?![0-9]+$)");
            if (!respuesta)
            {
                if (txtSalida.Text.Length > 0)
                {
                    saldo = Convert.ToDecimal(txtSalida.Text);
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
            Limpiar();
            this.Close();
        }
    }
}
