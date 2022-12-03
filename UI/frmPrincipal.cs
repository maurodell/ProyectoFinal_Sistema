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
        public int codigoUsuario = 0;
        public string Nombre;
        public string Email;
        public string Rol;
        public bool Estado;

        public frmPrincipal()
        {
            InitializeComponent();
            bllPermiso = new BLLPermiso();
            bllUsuario = new BLLUsuario();
        }
        BLLPermiso bllPermiso;
        BEUsuario beUsuario;
        BLLUsuario bllUsuario;
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
            if(Email != null)
            {
                ValidarPermisos();
            }
        }
        public void ValidarPermisos()
        {
            beUsuario = bllUsuario.BuscarUsuario(Email);
            IList<BEComponente> rol = null;
            bllPermiso.CompletarRolDeUsuario(beUsuario);
            HabilitarMenu(rol);
        }
        private void HabilitarMenu(IList<BEComponente> rol)
        {

            this.menuStock.Enabled = ConsultarPermiso(this.menuStock.Name);
            this.submenuCategoria.Enabled = ConsultarPermiso(this.submenuCategoria.Name);
            this.submenuProducto.Enabled = ConsultarPermiso(this.submenuProducto.Name);
            this.menuIngresos.Enabled = ConsultarPermiso(this.menuIngresos.Name);
            this.submenuCompras.Enabled = ConsultarPermiso(this.submenuCompras.Name);
            this.submenuProveedores.Enabled = ConsultarPermiso(this.submenuProveedores.Name);
            this.menuVentas.Enabled = ConsultarPermiso(this.menuVentas.Name);
            this.submenuClientes.Enabled = ConsultarPermiso(this.submenuClientes.Name);
            this.submenuVentas.Enabled = ConsultarPermiso(this.submenuVentas.Name);
            this.menuAcceso.Enabled = ConsultarPermiso(this.menuAcceso.Name);
            this.submenuPermisos.Enabled = ConsultarPermiso(this.submenuPermisos.Name);
            this.submenuUsuarios.Enabled = ConsultarPermiso(this.submenuUsuarios.Name);
            this.menuConsulta.Enabled = ConsultarPermiso(this.menuConsulta.Name);
            this.submenuConsultasVentas.Enabled = ConsultarPermiso(this.submenuConsultasVentas.Name);
            this.submenuConsultasCompras.Enabled = ConsultarPermiso(this.submenuConsultasCompras.Name);
            this.menuBackUp.Enabled = ConsultarPermiso(this.menuBackUp.Name);
            this.menuCaja.Enabled = ConsultarPermiso(this.menuCaja.Name);
            this.submenuConsultivo.Enabled = ConsultarPermiso(this.submenuConsultivo.Name);
            this.submenuConsultaProveedor.Enabled = ConsultarPermiso(this.submenuConsultaProveedor.Name);
        }
        private bool ConsultarPermiso(string nombreMenu)
        {

            foreach (var rolUser in beUsuario.Permisos)
            {
                if (rolUser.ObjenerHijos.Count > 0)//consulto si es un permiso o un rol(familia)
                {
                    //familia
                    foreach (var menu in rolUser.ObjenerHijos)
                    {
                        if (menu.Permiso.ToString().Equals(nombreMenu)) return true;
                    }
                }
                else
                {
                    //permiso
                    if (rolUser.Permiso.ToString().Equals(nombreMenu)) return true;
                }
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
            FrmAgregarPermisos.Size = new Size(800, 500);
        }

        private void nuevoBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup FrmBackup = new frmBackup();
            FrmBackup.MdiParent = this;
            FrmBackup.Show();
        }

        private void menuStrip_Validated(object sender, EventArgs e)
        {

        }

        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministrarUsuarioPermisos FrmAdminPermisos = new frmAdministrarUsuarioPermisos();
            FrmAdminPermisos.MdiParent = this;
            FrmAdminPermisos.Show();
            FrmAdminPermisos.Size = new Size(600, 580);
        }
        private void submenuConsultasVentas_Click(object sender, EventArgs e)
        {
            frmBuscarVentasPorFechas BuscarFechasVentas = new frmBuscarVentasPorFechas();
            BuscarFechasVentas.MdiParent = this;
            BuscarFechasVentas.Show();
            BuscarFechasVentas.Size = new Size(1370, 680);
        }

        private void submenuConsultasCompras_Click(object sender, EventArgs e)
        {
            frmBuscarCompraPorFechas BuscarFechasCompras = new frmBuscarCompraPorFechas();
            BuscarFechasCompras.MdiParent = this;
            BuscarFechasCompras.Show();
            BuscarFechasCompras.Size = new Size(1370, 680);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("Desea cerrar sesión?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (opcion.Equals(DialogResult.OK))
            {
                this.Close();
            }
        }

        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCaja Caja = new frmCaja();
            Caja.MdiParent = this;
            Caja.Show();
            Caja.Size = new Size(730, 580);
        }

        private void menuBackUp_Click(object sender, EventArgs e)
        {
            frmBackup FrmBackup = new frmBackup();
            FrmBackup.MdiParent = this;
            FrmBackup.Show();
        }

        private void consultasProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListarProductosXProveedor Consulta = new frmListarProductosXProveedor();
            Consulta.MdiParent = this;
            Consulta.Show();
            Consulta.Size = new Size(1220, 560);
        }

        private void consultivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultivoProductos Consultivo = new frmConsultivoProductos();
            Consultivo.MdiParent = this;
            Consultivo.Show();
            Consultivo.Size = new Size(1220, 560);
        }
    }
}
