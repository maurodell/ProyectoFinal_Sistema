using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            bllLogin = new BLLLogin();
        }
        BLLLogin bllLogin;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = bllLogin.Logueado(txtEmail.Text.Trim(), txtClave.Text.Trim());

                if (!flag)
                {
                    MessageBox.Show("El email o la clave es incorrecta.", "Login MarketSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!bllLogin.UsuarioActivo())
                    {
                        MessageBox.Show("Usuario no activo", "Login MarketSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        frmPrincipal frmPrincipal = new frmPrincipal();
                        frmPrincipal.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
