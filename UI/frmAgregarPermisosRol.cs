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
            btnQuitarPerm.Enabled = false;
        }
        BLLPermiso bllPermiso;
        BEFamillia beFamilia;
        private void LlenarCmbMenus()
        {
            this.cmbMenus.DataSource = null;
            this.cmbMenus.DataSource = bllPermiso.TraerTodosLosPermisos();
        }
        public void LlenarCmbPermisos()
        {
            this.cmbPermisos.DataSource = null;
            this.cmbPermisos.DataSource = bllPermiso.TraerTodosPermisosConNombre();
        }
        public void LlenarCmbRolFamilia()
        {
            this.cmbListadoRoles.DataSource = null;
            this.cmbListadoRoles.DataSource = bllPermiso.TraerTodosRolesFamilia();
        }
        private void LlenarCmbGeneral()
        {
            LlenarCmbPermisos();
            LlenarCmbRolFamilia();
        }
        private void btnConfigRol_Click(object sender, EventArgs e)
        {
            try
            {
                btnQuitarPerm.Enabled = true;
                var tmp = (BEFamillia)this.cmbListadoRoles.SelectedItem;
                if (tmp != null)
                {
                    beFamilia = new BEFamillia();
                    beFamilia._codigo = tmp._codigo;
                    beFamilia._nombre = tmp._nombre;

                    MostrarPermisos(true);
                }
            }
            catch (Exception)
            {

            }


        }
        public void MostrarPermisos(bool esRol)
        {
            try
            {
                IList<BEComponente> rol = null;
                if (esRol)
                {
                    //traigo los permisos del rol
                    rol = bllPermiso.TraerPermisosTodos2(beFamilia._codigo);

                    if (rol.Count > 0)
                    {
                        foreach (var item in rol)
                        {
                            beFamilia.AgregarHijo(item);
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
            catch (Exception)
            {

            }

        }
        public void MostrarTreeView(TreeNode tn, BEComponente componente)
        {
            try
            {
                TreeNode nodo = new TreeNode(componente._nombre);
                tn.Tag = componente;
                tn.Nodes.Add(nodo);
                if (componente.ObjenerHijos != null)
                {
                    foreach (var item in componente.ObjenerHijos)
                    {  //funcion recursiva
                        MostrarTreeView(nodo, item);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void frmAgregarPermisosRol_Load(object sender, EventArgs e)
        {
            LlenarCmbMenus();
            LlenarCmbGeneral();
        }

        private void frmAgregarPermisosRol_Activated(object sender, EventArgs e)
        {
            LlenarCmbGeneral();
        }

        private void btnAsignarMenu_Click(object sender, EventArgs e)
        {
            try
            {
                if (beFamilia != null)
                {
                    var permiso = (BEPermiso)cmbPermisos.SelectedItem;
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
            catch (Exception)
            {

            }

        }

        private void btnGuardarPerm_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllPermiso.GuardarFamilia(beFamilia))
                {
                    MessageBox.Show("Permisos guardados correctamente");
                    btnQuitarPerm.Enabled = false;
                    treeViewPermisos.Nodes.Clear();
                }
                else
                {
                    MessageBox.Show("Algo salio mal, los permisos no se pudieron guardar " +
                                    "\n Contactar al provedor del sistema.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuitarPerm_Click(object sender, EventArgs e)
        {
            try
            {
                if (beFamilia.ObjenerHijos.Count > 0)
                {
                    var nodo = treeViewPermisos.SelectedNode;

                    List<BEComponente> listaHijos = new List<BEComponente>(beFamilia.ObjenerHijos);
                    BEComponente eliminar = listaHijos.Find(x => x._nombre == nodo.Text);

                    listaHijos.Remove(eliminar);
                    beFamilia.VaciarHijos();

                    foreach (var item in listaHijos)
                    {
                        beFamilia.AgregarHijo(item);
                    }

                    MostrarPermisos(false);
                }
                else
                {
                    MessageBox.Show("Primero debe seleccionar un Rol");
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            try
            {
                BEFamillia bePermiso = new BEFamillia();
                bePermiso._nombre = txtNombreRol.Text;

                bool respuesta = bllPermiso.GuardarComponente(bePermiso, true);
                if (respuesta)
                {
                    LlenarCmbGeneral();
                    MessageBox.Show("El rol se guardo de forma correcta.");
                    txtNombreRol.Clear();
                }
                else
                {
                    MessageBox.Show("Algo salió mal.");
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnAgregarMenu_Click(object sender, EventArgs e)
        {
            try
            {
                BEPermiso bePermiso = new BEPermiso();
                bePermiso._nombre = txtNombreMenu.Text;
                bePermiso.Permiso = (BEMenuPermisos)this.cmbMenus.SelectedItem;

                bool respuesta = bllPermiso.GuardarComponente(bePermiso, false);
                if (respuesta)
                {
                    LlenarCmbGeneral();
                    MessageBox.Show("El permiso se guardo de forma correcta.");
                    txtNombreMenu.Clear();
                }
                else
                {
                    MessageBox.Show("Algo salió mal.");
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnBorrarRol_Click(object sender, EventArgs e)
        {
            try
            {
                var tmp = (BEFamillia)this.cmbListadoRoles.SelectedItem;
                BEComponente rol = null;
                bool flag = false;
                if (tmp != null)
                {
                    DialogResult opcion;
                    opcion = MessageBox.Show("Esta seguro que va a eliminar el rol?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (opcion.Equals(DialogResult.OK))
                    {
                        rol = new BEFamillia();
                        rol._codigo = tmp._codigo;
                        rol._nombre = tmp._nombre;
                        flag = bllPermiso.BorrarRol(rol);

                        if (flag)
                        {
                            LlenarCmbGeneral();
                            MessageBox.Show("El rol se borro de forma correcta");
                        }
                        else
                        {
                            MessageBox.Show("Algo salió mal!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un rol a eliminar");
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnBorrarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                var tmp = (BEPermiso)this.cmbPermisos.SelectedItem;
                BEComponente permiso = null;
                bool flag = false;
                if (tmp != null)
                {
                    DialogResult opcion;
                    opcion = MessageBox.Show("Esta seguro que va a eliminar el permiso?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (opcion.Equals(DialogResult.OK))
                    {
                        permiso = new BEPermiso();
                        permiso._codigo = tmp._codigo;
                        permiso._nombre = tmp._nombre;
                        permiso.Permiso = tmp.Permiso;
                        flag = bllPermiso.BorrarRol(permiso);

                        if (flag)
                        {
                            LlenarCmbGeneral();
                            MessageBox.Show("El permiso se borro de forma correcta");
                        }
                        else
                        {
                            MessageBox.Show("Algo salió mal!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un rol a eliminar");
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
