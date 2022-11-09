
namespace UI
{
    partial class frmAgregarPermisosRol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbListadoRoles = new System.Windows.Forms.ComboBox();
            this.btnConfigRol = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAsignarMenu = new System.Windows.Forms.Button();
            this.cmbPermisos = new System.Windows.Forms.ComboBox();
            this.treeViewPermisos = new System.Windows.Forms.TreeView();
            this.btnGuardarPerm = new System.Windows.Forms.Button();
            this.btnQuitarPerm = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNombreMenu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregarMenu = new System.Windows.Forms.Button();
            this.cmbMenus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregarRol = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.btnBorrarRol = new System.Windows.Forms.Button();
            this.btnBorrarPermiso = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listado de Roles";
            // 
            // cmbListadoRoles
            // 
            this.cmbListadoRoles.FormattingEnabled = true;
            this.cmbListadoRoles.Location = new System.Drawing.Point(47, 158);
            this.cmbListadoRoles.Name = "cmbListadoRoles";
            this.cmbListadoRoles.Size = new System.Drawing.Size(457, 39);
            this.cmbListadoRoles.TabIndex = 2;
            // 
            // btnConfigRol
            // 
            this.btnConfigRol.Location = new System.Drawing.Point(47, 280);
            this.btnConfigRol.Name = "btnConfigRol";
            this.btnConfigRol.Size = new System.Drawing.Size(199, 58);
            this.btnConfigRol.TabIndex = 3;
            this.btnConfigRol.Text = "Configurar";
            this.btnConfigRol.UseVisualStyleBackColor = true;
            this.btnConfigRol.Click += new System.EventHandler(this.btnConfigRol_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBorrarRol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnConfigRol);
            this.groupBox1.Controls.Add(this.cmbListadoRoles);
            this.groupBox1.Location = new System.Drawing.Point(49, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 386);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rol";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBorrarPermiso);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnAsignarMenu);
            this.groupBox2.Controls.Add(this.cmbPermisos);
            this.groupBox2.Location = new System.Drawing.Point(614, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 386);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Listado Permisos";
            // 
            // btnAsignarMenu
            // 
            this.btnAsignarMenu.Location = new System.Drawing.Point(47, 280);
            this.btnAsignarMenu.Name = "btnAsignarMenu";
            this.btnAsignarMenu.Size = new System.Drawing.Size(180, 58);
            this.btnAsignarMenu.TabIndex = 3;
            this.btnAsignarMenu.Text = "Asignar";
            this.btnAsignarMenu.UseVisualStyleBackColor = true;
            this.btnAsignarMenu.Click += new System.EventHandler(this.btnAsignarMenu_Click);
            // 
            // cmbPermisos
            // 
            this.cmbPermisos.FormattingEnabled = true;
            this.cmbPermisos.Location = new System.Drawing.Point(47, 158);
            this.cmbPermisos.Name = "cmbPermisos";
            this.cmbPermisos.Size = new System.Drawing.Size(450, 39);
            this.cmbPermisos.TabIndex = 2;
            // 
            // treeViewPermisos
            // 
            this.treeViewPermisos.Location = new System.Drawing.Point(1206, 62);
            this.treeViewPermisos.Name = "treeViewPermisos";
            this.treeViewPermisos.Size = new System.Drawing.Size(588, 829);
            this.treeViewPermisos.TabIndex = 6;
            // 
            // btnGuardarPerm
            // 
            this.btnGuardarPerm.Location = new System.Drawing.Point(1614, 916);
            this.btnGuardarPerm.Name = "btnGuardarPerm";
            this.btnGuardarPerm.Size = new System.Drawing.Size(180, 58);
            this.btnGuardarPerm.TabIndex = 4;
            this.btnGuardarPerm.Text = "Guardar";
            this.btnGuardarPerm.UseVisualStyleBackColor = true;
            this.btnGuardarPerm.Click += new System.EventHandler(this.btnGuardarPerm_Click);
            // 
            // btnQuitarPerm
            // 
            this.btnQuitarPerm.Location = new System.Drawing.Point(1206, 916);
            this.btnQuitarPerm.Name = "btnQuitarPerm";
            this.btnQuitarPerm.Size = new System.Drawing.Size(180, 58);
            this.btnQuitarPerm.TabIndex = 7;
            this.btnQuitarPerm.Text = "Quitar";
            this.btnQuitarPerm.UseVisualStyleBackColor = true;
            this.btnQuitarPerm.Click += new System.EventHandler(this.btnQuitarPerm_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNombreMenu);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnAgregarMenu);
            this.groupBox3.Controls.Add(this.cmbMenus);
            this.groupBox3.Location = new System.Drawing.Point(614, 520);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 454);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Crear Permisos";
            // 
            // txtNombreMenu
            // 
            this.txtNombreMenu.Location = new System.Drawing.Point(47, 250);
            this.txtNombreMenu.Name = "txtNombreMenu";
            this.txtNombreMenu.Size = new System.Drawing.Size(358, 38);
            this.txtNombreMenu.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Listado Menu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nombre";
            // 
            // btnAgregarMenu
            // 
            this.btnAgregarMenu.Location = new System.Drawing.Point(47, 349);
            this.btnAgregarMenu.Name = "btnAgregarMenu";
            this.btnAgregarMenu.Size = new System.Drawing.Size(180, 58);
            this.btnAgregarMenu.TabIndex = 3;
            this.btnAgregarMenu.Text = "Agregar";
            this.btnAgregarMenu.UseVisualStyleBackColor = true;
            this.btnAgregarMenu.Click += new System.EventHandler(this.btnAgregarMenu_Click);
            // 
            // cmbMenus
            // 
            this.cmbMenus.FormattingEnabled = true;
            this.cmbMenus.Location = new System.Drawing.Point(47, 121);
            this.cmbMenus.Name = "cmbMenus";
            this.cmbMenus.Size = new System.Drawing.Size(364, 39);
            this.cmbMenus.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre";
            // 
            // btnAgregarRol
            // 
            this.btnAgregarRol.Location = new System.Drawing.Point(53, 349);
            this.btnAgregarRol.Name = "btnAgregarRol";
            this.btnAgregarRol.Size = new System.Drawing.Size(199, 58);
            this.btnAgregarRol.TabIndex = 3;
            this.btnAgregarRol.Text = "Agregar";
            this.btnAgregarRol.UseVisualStyleBackColor = true;
            this.btnAgregarRol.Click += new System.EventHandler(this.btnAgregarRol_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNombreRol);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.btnAgregarRol);
            this.groupBox4.Location = new System.Drawing.Point(49, 520);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(450, 454);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Crear Rol";
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(53, 156);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(358, 38);
            this.txtNombreRol.TabIndex = 4;
            // 
            // btnBorrarRol
            // 
            this.btnBorrarRol.Location = new System.Drawing.Point(305, 280);
            this.btnBorrarRol.Name = "btnBorrarRol";
            this.btnBorrarRol.Size = new System.Drawing.Size(199, 58);
            this.btnBorrarRol.TabIndex = 4;
            this.btnBorrarRol.Text = "Borrar";
            this.btnBorrarRol.UseVisualStyleBackColor = true;
            this.btnBorrarRol.Click += new System.EventHandler(this.btnBorrarRol_Click);
            // 
            // btnBorrarPermiso
            // 
            this.btnBorrarPermiso.Location = new System.Drawing.Point(298, 280);
            this.btnBorrarPermiso.Name = "btnBorrarPermiso";
            this.btnBorrarPermiso.Size = new System.Drawing.Size(199, 58);
            this.btnBorrarPermiso.TabIndex = 5;
            this.btnBorrarPermiso.Text = "Borrar";
            this.btnBorrarPermiso.UseVisualStyleBackColor = true;
            this.btnBorrarPermiso.Click += new System.EventHandler(this.btnBorrarPermiso_Click);
            // 
            // frmAgregarPermisosRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1834, 1009);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnQuitarPerm);
            this.Controls.Add(this.btnGuardarPerm);
            this.Controls.Add(this.treeViewPermisos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAgregarPermisosRol";
            this.Text = "Permisos Rol";
            this.Activated += new System.EventHandler(this.frmAgregarPermisosRol_Activated);
            this.Load += new System.EventHandler(this.frmAgregarPermisosRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbListadoRoles;
        private System.Windows.Forms.Button btnConfigRol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAsignarMenu;
        private System.Windows.Forms.ComboBox cmbPermisos;
        private System.Windows.Forms.TreeView treeViewPermisos;
        private System.Windows.Forms.Button btnGuardarPerm;
        private System.Windows.Forms.Button btnQuitarPerm;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNombreMenu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarMenu;
        private System.Windows.Forms.ComboBox cmbMenus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregarRol;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Button btnBorrarRol;
        private System.Windows.Forms.Button btnBorrarPermiso;
    }
}