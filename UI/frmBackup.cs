using System;
using System.Windows.Forms;
using BLL;
using BE;
using Microsoft.VisualBasic.Devices;
using System.Xml;
using System.Data;
using System.IO;
using System.Reflection;

namespace UI
{
    public partial class frmBackup : Form
    {
        Computer thisComputer = new Computer();
        private string directorioOrigen = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml";
        private string directorioDestino = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\backUps";
        public frmBackup()
        {
            InitializeComponent();
            bllBack = new BLLBackUp();
            bllLogin = new BLLLogin();
        }
        BLLBackUp bllBack;
        BLLLogin bllLogin;
        public void CargarDgv()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = bllBack.Listar();
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int ultBackCod = bllBack.Listar().Count;
            string nombreCarpeta = "\\backup-"+(ultBackCod+1);
            if (CargarDatosUsuario())
            {
                thisComputer.FileSystem.CopyDirectory(directorioOrigen, String.Concat(directorioDestino, nombreCarpeta));
                CargarDgv();
            }
            else
            {
                MessageBox.Show("Algo salió mal, el back-up no pudo realizarce!");
            }

        }
        private bool CargarDatosUsuario()
        {
            bool resp = false;
            var usuario = bllLogin.GetUsuario();

            if (bllBack.Crear(usuario.Codigo, usuario.nombre))
            {
                resp = true;
            }
            return resp;
        }
        private void frmBackup_Load(object sender, EventArgs e)
        {
            CargarDgv();
        }
    }
}
