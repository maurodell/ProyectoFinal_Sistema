
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
            this.cmbMenus = new System.Windows.Forms.ComboBox();
            this.treeViewPermisos = new System.Windows.Forms.TreeView();
            this.btnGuardarPerm = new System.Windows.Forms.Button();
            this.btnQuitarPerm = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.cmbListadoRoles.Size = new System.Drawing.Size(364, 39);
            this.cmbListadoRoles.TabIndex = 2;
            // 
            // btnConfigRol
            // 
            this.btnConfigRol.Location = new System.Drawing.Point(47, 240);
            this.btnConfigRol.Name = "btnConfigRol";
            this.btnConfigRol.Size = new System.Drawing.Size(199, 58);
            this.btnConfigRol.TabIndex = 3;
            this.btnConfigRol.Text = "Configurar";
            this.btnConfigRol.UseVisualStyleBackColor = true;
            this.btnConfigRol.Click += new System.EventHandler(this.btnConfigRol_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnConfigRol);
            this.groupBox1.Controls.Add(this.cmbListadoRoles);
            this.groupBox1.Location = new System.Drawing.Point(49, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 386);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rol";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnAsignarMenu);
            this.groupBox2.Controls.Add(this.cmbMenus);
            this.groupBox2.Location = new System.Drawing.Point(613, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 386);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Listado Menu";
            // 
            // btnAsignarMenu
            // 
            this.btnAsignarMenu.Location = new System.Drawing.Point(47, 240);
            this.btnAsignarMenu.Name = "btnAsignarMenu";
            this.btnAsignarMenu.Size = new System.Drawing.Size(180, 58);
            this.btnAsignarMenu.TabIndex = 3;
            this.btnAsignarMenu.Text = "Asignar";
            this.btnAsignarMenu.UseVisualStyleBackColor = true;
            this.btnAsignarMenu.Click += new System.EventHandler(this.btnAsignarMenu_Click);
            // 
            // cmbMenus
            // 
            this.cmbMenus.FormattingEnabled = true;
            this.cmbMenus.Location = new System.Drawing.Point(47, 158);
            this.cmbMenus.Name = "cmbMenus";
            this.cmbMenus.Size = new System.Drawing.Size(364, 39);
            this.cmbMenus.TabIndex = 2;
            // 
            // treeViewPermisos
            // 
            this.treeViewPermisos.Location = new System.Drawing.Point(1206, 62);
            this.treeViewPermisos.Name = "treeViewPermisos";
            this.treeViewPermisos.Size = new System.Drawing.Size(537, 426);
            this.treeViewPermisos.TabIndex = 6;
            // 
            // btnGuardarPerm
            // 
            this.btnGuardarPerm.Location = new System.Drawing.Point(1206, 520);
            this.btnGuardarPerm.Name = "btnGuardarPerm";
            this.btnGuardarPerm.Size = new System.Drawing.Size(180, 58);
            this.btnGuardarPerm.TabIndex = 4;
            this.btnGuardarPerm.Text = "Guardar";
            this.btnGuardarPerm.UseVisualStyleBackColor = true;
            this.btnGuardarPerm.Click += new System.EventHandler(this.btnGuardarPerm_Click);
            // 
            // btnQuitarPerm
            // 
            this.btnQuitarPerm.Location = new System.Drawing.Point(1563, 520);
            this.btnQuitarPerm.Name = "btnQuitarPerm";
            this.btnQuitarPerm.Size = new System.Drawing.Size(180, 58);
            this.btnQuitarPerm.TabIndex = 7;
            this.btnQuitarPerm.Text = "Quitar";
            this.btnQuitarPerm.UseVisualStyleBackColor = true;
            // 
            // frmAgregarPermisosRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1834, 650);
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
        private System.Windows.Forms.ComboBox cmbMenus;
        private System.Windows.Forms.TreeView treeViewPermisos;
        private System.Windows.Forms.Button btnGuardarPerm;
        private System.Windows.Forms.Button btnQuitarPerm;
    }
}