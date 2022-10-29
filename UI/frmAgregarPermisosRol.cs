using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class frmAgregarPermisosRol : Form
    {
        public frmAgregarPermisosRol()
        {
            InitializeComponent();
            bllPermiso = new BLLPermiso();
            bllRol = new BLLRol();
        }
        BLLPermiso bllPermiso;
        BLLRol bllRol;
        BEFamillia beFamilia;
        frmPrincipal principalMenu;
        private void LlenarCmbMenus()
        {
            this.cmbMenus.DataSource = null;
            this.cmbMenus.DataSource = bllPermiso.ListarMenu();
            cmbMenus.ValueMember = "_codigo";
            cmbMenus.DisplayMember = "_nombre";
        }
        private void LlenarCmbRoles()
        {
            this.cmbListadoRoles.DataSource = null;
            this.cmbListadoRoles.DataSource = bllRol.Listar();
            cmbListadoRoles.ValueMember = "codigo";
            cmbListadoRoles.DisplayMember = "nombre";
        }
        private void btnConfigRol_Click(object sender, EventArgs e)
        {
            var tmp = (BERol)this.cmbListadoRoles.SelectedItem;
            if (tmp.estado)
            {
                beFamilia = new BEFamillia();
                beFamilia._codigo = tmp.Codigo;
                beFamilia._nombre = tmp.nombre;

                MostrarPermisos(true);
            }

        }
        public void MostrarPermisos(bool esRol)
        {
            IList<BEComponente> rol = null;
            if (esRol)
            {
                //traigo los permisos del rol
                rol = bllPermiso.TraerPermisosTodos(beFamilia._codigo);

                if (rol.Count > 0)
                {
                    foreach (BEComponente i in rol)
                    {
                        beFamilia.AgregarHijo(i);
                    }
                }
                else
                {
                    MessageBox.Show("ROL sin permisos");
                }
            }
            else
            {
                rol = beFamilia.ObjenerHijos;
            }

            this.treeViewPermisos.Nodes.Clear();
            TreeNode root = new TreeNode(beFamilia._nombre);
            root.Tag = beFamilia;
            this.treeViewPermisos.Nodes.Add(root);

            foreach (var item in rol)
            {
                MostrarTreeView(root, item);
            }
            treeViewPermisos.ExpandAll();
        }
        public void MostrarTreeView(TreeNode tn, BEComponente componente)
        {
            TreeNode nodo = new TreeNode(componente._nombre);
            tn.Tag = componente;
            tn.Nodes.Add(nodo);
            if (componente.ObjenerHijos != null)
                foreach (var item in componente.ObjenerHijos)
                {  //funcion recursiva
                    MostrarTreeView(nodo, item);
                }
        }
        private void frmAgregarPermisosRol_Load(object sender, EventArgs e)
        {
            LlenarCmbMenus();
            LlenarCmbRoles();
        }

        private void frmAgregarPermisosRol_Activated(object sender, EventArgs e)
        {
            LlenarCmbRoles();
        }

        private void btnAsignarMenu_Click(object sender, EventArgs e)
        {
            if (beFamilia != null)
            {
                var permiso = (BEPermiso)cmbMenus.SelectedItem;
                if (permiso != null)
                {
                    bool existe = bllPermiso.Existe(beFamilia, permiso._codigo);
                    if (existe)
                    {
                        MessageBox.Show("El permiso ya fue agregado al Rol");
                    }
                    else
                    {
                        beFamilia.AgregarHijo(permiso);
                        MostrarPermisos(false);
                    }
                }
            }
            treeViewPermisos.ExpandAll();
        }

        private void btnGuardarPerm_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllPermiso.GuardarFamilia(beFamilia))
                {
                    MessageBox.Show("Permisos guardados correctamente");
                    ActualizarTabControls();
                }
                else
                {
                    MessageBox.Show("Algo salio mal, los permisos no se pudieron guardar " +
                                    "\n Contactar al provedor del sistema.");
                }
            }
            catch (Exception ex)
            { }
        }
        //Ver la forma de actualizar en tiempo real el tab de menu
        private void ActualizarTabControls()
        {
            principalMenu = new frmPrincipal();
            principalMenu.ValidarPermisos(beFamilia._codigo);
        }

        private void btnQuitarPerm_Click(object sender, EventArgs e)
        {
            var rol = (BERol)cmbListadoRoles.SelectedItem;
            var nodo = treeViewPermisos.SelectedNode;
            bool respuesta = bllPermiso.QuitarPermisoRol(rol.Codigo, nodo.Text);
            if (respuesta)
            {
                MostrarPermisos(true);
                MessageBox.Show("El permiso se quito de forma correcta");
            }
            else
            {
                MessageBox.Show("Algo salió mal, el permido no pudo ser quitado");
            }
        }
    }
}
