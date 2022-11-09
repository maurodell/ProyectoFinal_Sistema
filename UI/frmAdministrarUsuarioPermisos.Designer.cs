
namespace UI
{
    partial class frmAdministrarUsuarioPermisos
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
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.btnConfigUser = new System.Windows.Forms.Button();
            this.btnAgregarRol = new System.Windows.Forms.Button();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.treeViewUserRol = new System.Windows.Forms.TreeView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAsignarPermiso = new System.Windows.Forms.Button();
            this.cmbPermisos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Usuarios";
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(53, 140);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(493, 39);
            this.cmbUser.TabIndex = 1;
            // 
            // btnConfigUser
            // 
            this.btnConfigUser.Location = new System.Drawing.Point(53, 220);
            this.btnConfigUser.Name = "btnConfigUser";
            this.btnConfigUser.Size = new System.Drawing.Size(217, 56);
            this.btnConfigUser.TabIndex = 2;
            this.btnConfigUser.Text = "Configurar";
            this.btnConfigUser.UseVisualStyleBackColor = true;
            this.btnConfigUser.Click += new System.EventHandler(this.btnConfigUser_Click);
            // 
            // btnAgregarRol
            // 
            this.btnAgregarRol.Location = new System.Drawing.Point(53, 578);
            this.btnAgregarRol.Name = "btnAgregarRol";
            this.btnAgregarRol.Size = new System.Drawing.Size(217, 56);
            this.btnAgregarRol.TabIndex = 5;
            this.btnAgregarRol.Text = "Asignar";
            this.btnAgregarRol.UseVisualStyleBackColor = true;
            this.btnAgregarRol.Click += new System.EventHandler(this.btnAgregarRol_Click);
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(53, 495);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(493, 39);
            this.cmbRol.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Listado de Roles";
            // 
            // treeViewUserRol
            // 
            this.treeViewUserRol.Location = new System.Drawing.Point(604, 56);
            this.treeViewUserRol.Name = "treeViewUserRol";
            this.treeViewUserRol.Size = new System.Drawing.Size(839, 974);
            this.treeViewUserRol.TabIndex = 6;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(1226, 1056);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(217, 56);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(604, 1056);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(217, 56);
            this.btnQuitar.TabIndex = 8;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAsignarPermiso
            // 
            this.btnAsignarPermiso.Location = new System.Drawing.Point(53, 936);
            this.btnAsignarPermiso.Name = "btnAsignarPermiso";
            this.btnAsignarPermiso.Size = new System.Drawing.Size(217, 56);
            this.btnAsignarPermiso.TabIndex = 11;
            this.btnAsignarPermiso.Text = "Asignar";
            this.btnAsignarPermiso.UseVisualStyleBackColor = true;
            this.btnAsignarPermiso.Click += new System.EventHandler(this.btnAsignarPermiso_Click);
            // 
            // cmbPermisos
            // 
            this.cmbPermisos.FormattingEnabled = true;
            this.cmbPermisos.Location = new System.Drawing.Point(53, 859);
            this.cmbPermisos.Name = "cmbPermisos";
            this.cmbPermisos.Size = new System.Drawing.Size(487, 39);
            this.cmbPermisos.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 812);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Listado de Permisos";
            // 
            // frmAdministrarUsuarioPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 1144);
            this.Controls.Add(this.btnAsignarPermiso);
            this.Controls.Add(this.cmbPermisos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.treeViewUserRol);
            this.Controls.Add(this.btnAgregarRol);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfigUser);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label1);
            this.Name = "frmAdministrarUsuarioPermisos";
            this.Text = "Administración de Permisos para Usuarios";
            this.Load += new System.EventHandler(this.frmAdministrarUsuarioPermisos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Button btnConfigUser;
        private System.Windows.Forms.Button btnAgregarRol;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeViewUserRol;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAsignarPermiso;
        private System.Windows.Forms.ComboBox cmbPermisos;
        private System.Windows.Forms.Label label3;
    }
}