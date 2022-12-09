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
        private void Formato()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[1].HeaderText = "Nombre Usuario";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[2].HeaderText = "Cod. Usuario";
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[3].HeaderText = "Fecha";
            dataGridView1.Columns[4].Width = 50;
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Back-Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Back-Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void CargarDgv()
        {
            try
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = bllBack.Listar();
                Formato();
            }
            catch (Exception)
            {

            }
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                int ultBackCod = bllBack.Listar().Count;
                string nombreCarpeta = "\\"+(ultBackCod+1);
                if (CargarDatosUsuario())
                {
                    thisComputer.FileSystem.CopyDirectory(directorioOrigen, String.Concat(directorioDestino, nombreCarpeta));
                    CargarDgv();
                }
                else
                {
                    MensajeError("Algo salió mal, el back-up no pudo realizarce!");
                }
            }
            catch (Exception)
            {

            }
        }
        private bool CargarDatosUsuario()
        {
            try
            {
                bool resp = false;
                var usuario = bllLogin.GetUsuario();

                if (bllBack.Crear(usuario.Codigo, usuario.nombre))
                {
                    resp = true;
                }
                return resp;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void frmBackup_Load(object sender, EventArgs e)
        {
            CargarDgv();
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dataGridView1.Columns[0].Visible = true;
            }
            else
            {
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(dataGridView1.Columns["Seleccionar"].Index))
            {
                DataGridViewCheckBoxCell chkSelec = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells["Seleccionar"];
                chkSelec.Value = !Convert.ToBoolean(chkSelec.Value);//Determino si esta o no esta marcado el checkBox(Documentacion DataGridView)
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkSeleccionar.Checked)
                {
                    MensajeError("Primero hacer check en Seleccionar");
                }
                else
                {
                    DialogResult opcion;
                    opcion = MessageBox.Show("Esta seguro que desea realizar un restore?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (opcion.Equals(DialogResult.OK))
                    {
                        int codigo;
                        bool flag = false;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                codigo = Convert.ToInt32(row.Cells[4].Value);
                                flag = bllBack.Restore(codigo);
                            }
                        }

                        if (flag)
                        {
                            MensajeOk("Restore realizado correctamente!");
                        }
                        else
                        {
                            MensajeError("Algo salío mal!");
                        }
                    }
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
