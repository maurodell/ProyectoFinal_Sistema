
namespace UI
{
    partial class frmCategorias
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCat = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblTotalReg = new System.Windows.Forms.Label();
            this.dgvListadoCat = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoCat)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCat);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2166, 1062);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCat
            // 
            this.tabCat.Controls.Add(this.lblTotalReg);
            this.tabCat.Controls.Add(this.dgvListadoCat);
            this.tabCat.Location = new System.Drawing.Point(10, 48);
            this.tabCat.Name = "tabCat";
            this.tabCat.Padding = new System.Windows.Forms.Padding(3);
            this.tabCat.Size = new System.Drawing.Size(2146, 1004);
            this.tabCat.TabIndex = 0;
            this.tabCat.Text = "Listado";
            this.tabCat.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(10, 48);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(2112, 1078);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblTotalReg
            // 
            this.lblTotalReg.AutoSize = true;
            this.lblTotalReg.Location = new System.Drawing.Point(1744, 947);
            this.lblTotalReg.Name = "lblTotalReg";
            this.lblTotalReg.Size = new System.Drawing.Size(93, 32);
            this.lblTotalReg.TabIndex = 1;
            this.lblTotalReg.Text = "label1";
            // 
            // dgvListadoCat
            // 
            this.dgvListadoCat.AllowUserToAddRows = false;
            this.dgvListadoCat.AllowUserToDeleteRows = false;
            this.dgvListadoCat.AllowUserToOrderColumns = true;
            this.dgvListadoCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoCat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dgvListadoCat.Location = new System.Drawing.Point(22, 55);
            this.dgvListadoCat.Name = "dgvListadoCat";
            this.dgvListadoCat.ReadOnly = true;
            this.dgvListadoCat.RowHeadersWidth = 102;
            this.dgvListadoCat.RowTemplate.Height = 40;
            this.dgvListadoCat.Size = new System.Drawing.Size(2095, 863);
            this.dgvListadoCat.TabIndex = 0;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.MinimumWidth = 12;
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 250;
            // 
            // frmCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2206, 1097);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmCategorias";
            this.Text = "frmCategorias";
            this.Load += new System.EventHandler(this.frmCategorias_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabCat.ResumeLayout(false);
            this.tabCat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoCat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCat;
        private System.Windows.Forms.DataGridView dgvListadoCat;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTotalReg;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
    }
}