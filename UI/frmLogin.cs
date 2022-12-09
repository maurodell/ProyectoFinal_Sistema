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
using BE;
using UI.Utils;
using System.Text.RegularExpressions;
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
        public BEUsuario beUsuario;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                bool control = true;
                control = Regex.IsMatch(txtEmail.Text, "^(?!([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$)");
                if (!control)
                {
                    bool flag = bllLogin.Logueado(txtEmail.Text.Trim(), txtClave.Text.Trim());
                    control = true;
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
                            //completos las variables del frmPrincipal para habilitar los permisos(menus) pasando referencia los datos del usuario.
                            beUsuario = bllLogin.GetUsuario();
                            frmPrincipal FrmPrincipal = new frmPrincipal();
                            FrmPrincipal.codigoUsuario = beUsuario.Codigo;
                            FrmPrincipal.Nombre = beUsuario.nombre;
                            FrmPrincipal.Estado = beUsuario.estado;
                            FrmPrincipal.Email = beUsuario.email;

                            VariablesCompra.codigoUsuario = beUsuario.Codigo;//se neceista para registrar el ingreso
                            FrmPrincipal.Show();
                            FrmPrincipal.FormClosed += CerrarSesion;
                            this.Hide();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un email");
                }

            }
            catch (Exception)
            {
            }
        }
        public void CerrarSesion(object sender, FormClosedEventArgs e)
        {
            txtClave.Clear();
            txtEmail.Clear();
            this.Show();
            txtEmail.Focus();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
