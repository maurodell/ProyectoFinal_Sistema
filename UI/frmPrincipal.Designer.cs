
namespace UI
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStock = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIngresos = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAcceso = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuPermisos = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuConsultasVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuConsultasCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBackUp = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuNuevoBackUp = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.LoginInferior = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStock,
            this.menuIngresos,
            this.menuVentas,
            this.menuAcceso,
            this.menuConsulta,
            this.menuBackUp,
            this.helpMenu,
            this.menuSalir});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(16, 5, 0, 5);
            this.menuStrip.Size = new System.Drawing.Size(1685, 58);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.Validated += new System.EventHandler(this.menuStrip_Validated);
            // 
            // menuStock
            // 
            this.menuStock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuCategoria,
            this.submenuProducto});
            this.menuStock.Name = "menuStock";
            this.menuStock.Size = new System.Drawing.Size(114, 48);
            this.menuStock.Text = "Stock";
            // 
            // submenuCategoria
            // 
            this.submenuCategoria.Name = "submenuCategoria";
            this.submenuCategoria.Size = new System.Drawing.Size(325, 54);
            this.submenuCategoria.Text = "Categorías";
            this.submenuCategoria.Click += new System.EventHandler(this.categoríasToolStripMenuItem_Click);
            // 
            // submenuProducto
            // 
            this.submenuProducto.Name = "submenuProducto";
            this.submenuProducto.Size = new System.Drawing.Size(325, 54);
            this.submenuProducto.Text = "Producto";
            this.submenuProducto.Click += new System.EventHandler(this.artToolStripMenuItem_Click);
            // 
            // menuIngresos
            // 
            this.menuIngresos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuProveedores,
            this.submenuCompras});
            this.menuIngresos.Name = "menuIngresos";
            this.menuIngresos.Size = new System.Drawing.Size(155, 48);
            this.menuIngresos.Text = "Ingresos";
            // 
            // submenuProveedores
            // 
            this.submenuProveedores.Name = "submenuProveedores";
            this.submenuProveedores.Size = new System.Drawing.Size(350, 54);
            this.submenuProveedores.Text = "Proveedores";
            this.submenuProveedores.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // submenuCompras
            // 
            this.submenuCompras.Name = "submenuCompras";
            this.submenuCompras.Size = new System.Drawing.Size(350, 54);
            this.submenuCompras.Text = "Compras";
            this.submenuCompras.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
            // 
            // menuVentas
            // 
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuClientes,
            this.submenuVentas});
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(130, 48);
            this.menuVentas.Text = "Ventas";
            // 
            // submenuClientes
            // 
            this.submenuClientes.Name = "submenuClientes";
            this.submenuClientes.Size = new System.Drawing.Size(289, 54);
            this.submenuClientes.Text = "Clientes";
            this.submenuClientes.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // submenuVentas
            // 
            this.submenuVentas.Name = "submenuVentas";
            this.submenuVentas.Size = new System.Drawing.Size(289, 54);
            this.submenuVentas.Text = "Ventas";
            this.submenuVentas.Click += new System.EventHandler(this.ventasToolStripMenuItem1_Click);
            // 
            // menuAcceso
            // 
            this.menuAcceso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuUsuarios,
            this.submenuPermisos,
            this.administrarUsuariosToolStripMenuItem});
            this.menuAcceso.Name = "menuAcceso";
            this.menuAcceso.Size = new System.Drawing.Size(149, 48);
            this.menuAcceso.Text = "Accesos";
            // 
            // submenuUsuarios
            // 
            this.submenuUsuarios.Name = "submenuUsuarios";
            this.submenuUsuarios.Size = new System.Drawing.Size(454, 54);
            this.submenuUsuarios.Text = "Usuarios";
            this.submenuUsuarios.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // submenuPermisos
            // 
            this.submenuPermisos.Name = "submenuPermisos";
            this.submenuPermisos.Size = new System.Drawing.Size(454, 54);
            this.submenuPermisos.Text = "Permisos";
            this.submenuPermisos.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // administrarUsuariosToolStripMenuItem
            // 
            this.administrarUsuariosToolStripMenuItem.Name = "administrarUsuariosToolStripMenuItem";
            this.administrarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(454, 54);
            this.administrarUsuariosToolStripMenuItem.Text = "Administrar usuarios";
            this.administrarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administrarUsuariosToolStripMenuItem_Click);
            // 
            // menuConsulta
            // 
            this.menuConsulta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuConsultasVentas,
            this.submenuConsultasCompras});
            this.menuConsulta.Name = "menuConsulta";
            this.menuConsulta.Size = new System.Drawing.Size(171, 48);
            this.menuConsulta.Text = "Consultas";
            // 
            // submenuConsultasVentas
            // 
            this.submenuConsultasVentas.Name = "submenuConsultasVentas";
            this.submenuConsultasVentas.Size = new System.Drawing.Size(448, 54);
            this.submenuConsultasVentas.Text = "Consultas ventas";
            this.submenuConsultasVentas.Click += new System.EventHandler(this.submenuConsultasVentas_Click);
            // 
            // submenuConsultasCompras
            // 
            this.submenuConsultasCompras.Name = "submenuConsultasCompras";
            this.submenuConsultasCompras.Size = new System.Drawing.Size(448, 54);
            this.submenuConsultasCompras.Text = "Consultas compras";
            this.submenuConsultasCompras.Click += new System.EventHandler(this.submenuConsultasCompras_Click);
            // 
            // menuBackUp
            // 
            this.menuBackUp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuNuevoBackUp,
            this.submenuRestore});
            this.menuBackUp.Name = "menuBackUp";
            this.menuBackUp.Size = new System.Drawing.Size(154, 48);
            this.menuBackUp.Text = "Back-Up";
            // 
            // submenuNuevoBackUp
            // 
            this.submenuNuevoBackUp.Name = "submenuNuevoBackUp";
            this.submenuNuevoBackUp.Size = new System.Drawing.Size(448, 54);
            this.submenuNuevoBackUp.Text = "Nuevo";
            this.submenuNuevoBackUp.Click += new System.EventHandler(this.nuevoBackUpToolStripMenuItem_Click);
            // 
            // submenuRestore
            // 
            this.submenuRestore.Name = "submenuRestore";
            this.submenuRestore.Size = new System.Drawing.Size(448, 54);
            this.submenuRestore.Text = "Restore";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(125, 48);
            this.helpMenu.Text = "Ay&uda";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(440, 54);
            this.contentsToolStripMenuItem.Text = "&Contenido";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(440, 54);
            this.indexToolStripMenuItem.Text = "&Índice";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(440, 54);
            this.searchToolStripMenuItem.Text = "&Buscar";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(437, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(440, 54);
            this.aboutToolStripMenuItem.Text = "&Acerca de... ...";
            // 
            // menuSalir
            // 
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(97, 48);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStrip.Location = new System.Drawing.Point(0, 58);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.toolStrip.Size = new System.Drawing.Size(1685, 51);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(58, 44);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoginInferior});
            this.statusStrip.Location = new System.Drawing.Point(0, 1026);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(3, 0, 37, 0);
            this.statusStrip.Size = new System.Drawing.Size(1685, 54);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // LoginInferior
            // 
            this.LoginInferior.Name = "LoginInferior";
            this.LoginInferior.Size = new System.Drawing.Size(205, 41);
            this.LoginInferior.Text = "Proyecto Final";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 1080);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "frmPrincipal";
            this.Text = "Sistema";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel LoginInferior;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem menuStock;
        private System.Windows.Forms.ToolStripMenuItem submenuCategoria;
        private System.Windows.Forms.ToolStripMenuItem submenuProducto;
        private System.Windows.Forms.ToolStripMenuItem menuIngresos;
        private System.Windows.Forms.ToolStripMenuItem submenuProveedores;
        private System.Windows.Forms.ToolStripMenuItem submenuCompras;
        private System.Windows.Forms.ToolStripMenuItem menuVentas;
        private System.Windows.Forms.ToolStripMenuItem submenuClientes;
        private System.Windows.Forms.ToolStripMenuItem submenuVentas;
        private System.Windows.Forms.ToolStripMenuItem menuAcceso;
        private System.Windows.Forms.ToolStripMenuItem submenuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuConsulta;
        private System.Windows.Forms.ToolStripMenuItem submenuConsultasVentas;
        private System.Windows.Forms.ToolStripMenuItem submenuConsultasCompras;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.ToolStripMenuItem submenuPermisos;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem menuBackUp;
        private System.Windows.Forms.ToolStripMenuItem submenuNuevoBackUp;
        private System.Windows.Forms.ToolStripMenuItem submenuRestore;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuariosToolStripMenuItem;
    }
}



