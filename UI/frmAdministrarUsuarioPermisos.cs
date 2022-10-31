using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class frmAdministrarUsuarioPermisos : Form
    {
        public frmAdministrarUsuarioPermisos()
        {
            InitializeComponent();
            bllUsuario = new BLLUsuario();
            bllRol = new BLLRol();
            bllPermiso = new BLLPermiso();
        }
        BEUsuario beUsuario;
        BLLUsuario bllUsuario;
        BLLRol bllRol;
        BLLPermiso bllPermiso;
        BEComponente beRoles;
        private void btnConfigUser_Click(object sender, EventArgs e)
        {
            beUsuario = (BEUsuario)this.cmbUser.SelectedItem;
            if(beUsuario.estado)
            {
                MostrarPermisos(true);
            }
        }
        public void MostrarPermisos(bool esRol)
        {
            IList<BEComponente> rol = null;
            if (esRol)
            {
                //traigo los permisos del rol
                rol = bllPermiso.TraerRolesPorUsuario(beUsuario);

                //Tengo que traerme los roles con sus permisos y listarlo al usuario
                if (rol.Count > 0)
                {
                    foreach (BEComponente i in rol)
                    {
                        if (i._tipo == 1)
                        {
                            beRoles = new BEFamillia();
                            beRoles._nombre = i._nombre;
                            beRoles._codigo = i._codigo;
                        }
                        else
                        {
                            beRoles = new BEPermiso();
                            beRoles._nombre = i._nombre;
                            beRoles._codigo = i._codigo;
                            beRoles.AgregarHijo(i);
                        }
                        beUsuario.listaPermisos.Add(beRoles);
                    }
                }
                else
                {
                    MessageBox.Show("ROL sin permisos");
                }
            }
            else
            {
                rol = beRoles.ObjenerHijos;
            }
            
            this.treeViewUserRol.Nodes.Clear();
            TreeNode root = new TreeNode(beUsuario.nombre);
            root.Tag = beUsuario;
            this.treeViewUserRol.Nodes.Add(root);

            foreach (var item in rol)
            {
                MostrarTreeView(root, item);
            }
            treeViewUserRol.ExpandAll();
        }
        public void MostrarPermisosAgregados(List<BEComponente> listaRoles)
        {
            //limpio la lista de permisos del usuario para no agregar permisos ya agregados.
            beUsuario.listaPermisos.Clear();

            //Tengo que traerme los roles con sus permisos y listarlo al usuario
            if (listaRoles.Count > 0)
            {
                foreach (BEComponente i in listaRoles)
                {
                    if (i._tipo == 1)
                    {
                        beRoles = new BEFamillia();
                        beRoles._nombre = i._nombre;
                        beRoles._codigo = i._codigo;
                    }
                    else
                    {
                        beRoles = new BEPermiso();
                        beRoles._nombre = i._nombre;
                        beRoles._codigo = i._codigo;
                        beRoles.AgregarHijo(i);
                    }
                    beUsuario.listaPermisos.Add(beRoles);
                }
            }
            else
            {
                MessageBox.Show("ROL sin permisos");
            }

            this.treeViewUserRol.Nodes.Clear();
            TreeNode root = new TreeNode(beUsuario.nombre);
            root.Tag = beUsuario;
            this.treeViewUserRol.Nodes.Add(root);

            foreach (var item in listaRoles)
            {
                MostrarTreeView(root, item);
            }
            treeViewUserRol.ExpandAll();
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
        private void ActualizarComboBoxUsuario()
        {
            this.cmbUser.DataSource = null;
            this.cmbUser.DataSource = bllUsuario.Listar();
            cmbUser.ValueMember = "codigo";
            cmbUser.DisplayMember = "nombre";
        }
        private void ActualizarComboBoxRol()
        {
            this.cmbRol.DataSource = null;
            this.cmbRol.DataSource = bllRol.Listar();
            cmbRol.ValueMember = "codigo";
            cmbRol.DisplayMember = "nombre";
        }

        private void frmAdministrarUsuarioPermisos_Load(object sender, EventArgs e)
        {
            ActualizarComboBoxUsuario();
            ActualizarComboBoxRol();
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            if (beUsuario != null) 
            {
                var rol = (BERol)cmbRol.SelectedItem;
                bool existe = bllPermiso.ExisteRolEnUsuario(beUsuario.Codigo, rol.Codigo);
                if (!existe)
                {
                    MessageBox.Show("El Rol ya fue agregado al Usuario");
                }
                else
                {
                    List<BEComponente> listaRoles = bllPermiso.TraerRolesPorUsuario(beUsuario).ToList();//me traigo los roles que tiene el usuario para luego agregar el rol con sus permisos
                    BEComponente rolAAgregar = bllPermiso.TraerRol(rol.Codigo);
                    listaRoles.Add(rolAAgregar);
                    MostrarPermisosAgregados(listaRoles);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Usuario!");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<BEComponente> list = beUsuario.Permisos;
            if (bllPermiso.AgregarRol(beUsuario.Codigo, list))
            {
                MessageBox.Show("El guardado fue correcto");
            }
            else
            {
                MessageBox.Show("Algo salió mal!");
            }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            bool respuesta = false;
            var nodoRol = treeViewUserRol.SelectedNode;
            if (beUsuario != null)
            {
                respuesta = bllPermiso.QuitarRolAUsuario(beUsuario.Codigo, nodoRol.Text);
                if (respuesta)
                {
                    MostrarPermisos(true);
                    MessageBox.Show("El rol fue eliminado");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario");
            }
        }
    }
}
