using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;
        public int codigoUsuario;
        public int codigoRolUsuario;
        public string Nombre;
        public string Email;
        public string Rol;
        public bool Estado;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias frmCategorias = new frmCategorias();
            frmCategorias.MdiParent = this;
            frmCategorias.Show();
            frmCategorias.Size = new Size(830, 560);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            LoginInferior.Text = "Usuario: "+this.Nombre+"  -  Email: "+this.Email;

            switch (codigoRolUsuario)
            {
                case 1:
                    MenuAlmacen.Enabled = true;
                    MenuAcceso.Enabled = true;
                    MenuConsulta.Enabled = true;
                    MenuIngresos.Enabled = true;
                    MenuVentas.Enabled = true;
                    break;
                case 2:
                    MenuAlmacen.Enabled = false;
                    MenuAcceso.Enabled = false;
                    MenuConsulta.Enabled = true;
                    MenuIngresos.Enabled = false;
                    MenuVentas.Enabled = true;
                    break;
                case 3:
                    MenuAlmacen.Enabled = false;
                    MenuAcceso.Enabled = false;
                    MenuConsulta.Enabled = true;
                    MenuIngresos.Enabled = false;
                    MenuVentas.Enabled = false;
                    break;
            }
        }

        private void artToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto frmProducto = new frmProducto();
            frmProducto.MdiParent = this;
            frmProducto.Show();
            frmProducto.Size = new Size(1370, 560);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frmUsuarios = new frmUsuario();
            frmUsuarios.MdiParent = this;
            frmUsuarios.Show();
            frmUsuarios.Size = new Size(1370, 560);
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRol frmRol = new frmRol();
            frmRol.MdiParent = this;
            frmRol.Show();
            frmRol.Size = new Size(830, 560);
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("Esta seguro que desea salir del sistema?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (opcion.Equals(DialogResult.OK))
            {
                Application.Exit();
            }
        }
    }
}
