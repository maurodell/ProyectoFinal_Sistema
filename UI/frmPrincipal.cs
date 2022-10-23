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

namespace UI
{
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;
        public int codigoUsuario;
        public int codigoRolUsuario = 0;
        public string Nombre;
        public string Email;
        public string Rol;
        public bool Estado;

        public frmPrincipal()
        {
            InitializeComponent();
            bllPermiso = new BLLPermiso();
        }
        BLLPermiso bllPermiso;
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

            //compruebo que el usuario esta logueado
            if(codigoRolUsuario > 0)
            {
                ValidarPermisos(codigoRolUsuario);
            }
        }
        public void ValidarPermisos(int codigoRolUsuario)
        {
            IList<BEComponente> rol = null;
            rol = bllPermiso.TraerPermisosTodos(codigoRolUsuario);
            HabilitarMenu(rol);
        }
        private void HabilitarMenu(IList<BEComponente> rol)
        {
            this.menuStock.Enabled = ConsultarPermiso(this.menuStock.Name, rol);
            this.submenuCategoria.Enabled = ConsultarPermiso(this.submenuCategoria.Name, rol);
            this.submenuProducto.Enabled = ConsultarPermiso(this.submenuProducto.Name, rol);
            this.menuIngresos.Enabled = ConsultarPermiso(this.menuIngresos.Name, rol);
            this.submenuCompras.Enabled = ConsultarPermiso(this.submenuCompras.Name, rol);
            this.submenuProveedores.Enabled = ConsultarPermiso(this.submenuProveedores.Name, rol);
            this.menuVentas.Enabled = ConsultarPermiso(this.menuVentas.Name, rol);
            this.submenuClientes.Enabled = ConsultarPermiso(this.submenuClientes.Name, rol);
            this.submenuVentas.Enabled = ConsultarPermiso(this.submenuVentas.Name, rol);
            this.menuAcceso.Enabled = ConsultarPermiso(this.menuAcceso.Name, rol);
            this.submenuRoles.Enabled = ConsultarPermiso(this.submenuRoles.Name, rol);
            this.submenuPermisos.Enabled = ConsultarPermiso(this.submenuPermisos.Name, rol);
            this.submenuUsuarios.Enabled = ConsultarPermiso(this.submenuUsuarios.Name, rol);
            this.menuConsulta.Enabled = ConsultarPermiso(this.menuConsulta.Name, rol);
            this.submenuConsultasVentas.Enabled = ConsultarPermiso(this.submenuConsultasVentas.Name, rol);
            this.submenuConsultasCompras.Enabled = ConsultarPermiso(this.submenuConsultasCompras.Name, rol);
            this.menuBackUp.Enabled = ConsultarPermiso(this.menuBackUp.Name, rol);
            this.submenuNuevoBackUp.Enabled = ConsultarPermiso(this.submenuNuevoBackUp.Name, rol);
            this.submenuRestore.Enabled = ConsultarPermiso(this.submenuRestore.Name, rol);
        }
        private bool ConsultarPermiso(string nombreMenu, IList<BEComponente> rol)
        {
            foreach (var item in rol)
            {
                if (item._nombre.Equals(nombreMenu)) return true;
            }
            return false;
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

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor FrmProveedor = new frmProveedor();
            FrmProveedor.MdiParent = this;
            FrmProveedor.Show();
            FrmProveedor.Size = new Size(1370, 560);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente FrmCliente = new frmCliente();
            FrmCliente.MdiParent = this;
            FrmCliente.Show();
            FrmCliente.Size = new Size(950, 560);
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompra FrmCompra = new frmCompra();
            FrmCompra.MdiParent = this;
            FrmCompra.Show();
            FrmCompra.Size = new Size(1370, 660);
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVenta FrmVenta = new frmVenta();
            FrmVenta.MdiParent = this;
            FrmVenta.Show();
            FrmVenta.Size = new Size(1370, 660);
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarPermisosRol FrmAgregarPermisos = new frmAgregarPermisosRol();
            FrmAgregarPermisos.MdiParent = this;
            FrmAgregarPermisos.Show();
        }

        private void nuevoBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup FrmBackup = new frmBackup();
            FrmBackup.MdiParent = this;
            FrmBackup.Show();
        }
    }
}
