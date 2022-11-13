
namespace UI
{
    partial class frmBuscarCompraPorFechas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtTotalImp = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvDetalleVentaProd = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dateTimePHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListadoVenta = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVentaProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.txtTotalImp);
            this.panel1.Controls.Add(this.txtSubTotal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.dgvDetalleVentaProd);
            this.panel1.Location = new System.Drawing.Point(693, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2484, 1106);
            this.panel1.TabIndex = 14;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(2204, 1034);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(230, 38);
            this.txtTotal.TabIndex = 7;
            // 
            // txtTotalImp
            // 
            this.txtTotalImp.Location = new System.Drawing.Point(2204, 967);
            this.txtTotalImp.Name = "txtTotalImp";
            this.txtTotalImp.Size = new System.Drawing.Size(230, 38);
            this.txtTotalImp.TabIndex = 6;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(2204, 903);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(230, 38);
            this.txtSubTotal.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2112, 1034);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1982, 967);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = " Total Impuesto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2070, 909);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subtotal";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(2384, 24);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(50, 58);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "x";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvDetalleVentaProd
            // 
            this.dgvDetalleVentaProd.AllowUserToAddRows = false;
            this.dgvDetalleVentaProd.AllowUserToDeleteRows = false;
            this.dgvDetalleVentaProd.AllowUserToOrderColumns = true;
            this.dgvDetalleVentaProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVentaProd.Location = new System.Drawing.Point(45, 88);
            this.dgvDetalleVentaProd.Name = "dgvDetalleVentaProd";
            this.dgvDetalleVentaProd.ReadOnly = true;
            this.dgvDetalleVentaProd.RowHeadersWidth = 102;
            this.dgvDetalleVentaProd.RowTemplate.Height = 40;
            this.dgvDetalleVentaProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleVentaProd.Size = new System.Drawing.Size(2389, 790);
            this.dgvDetalleVentaProd.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1072, 37);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(192, 51);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dateTimePHasta
            // 
            this.dateTimePHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePHasta.Location = new System.Drawing.Point(679, 44);
            this.dateTimePHasta.Name = "dateTimePHasta";
            this.dateTimePHasta.Size = new System.Drawing.Size(320, 38);
            this.dateTimePHasta.TabIndex = 12;
            // 
            // dateTimePDesde
            // 
            this.dateTimePDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePDesde.Location = new System.Drawing.Point(146, 44);
            this.dateTimePDesde.Name = "dateTimePDesde";
            this.dateTimePDesde.Size = new System.Drawing.Size(320, 38);
            this.dateTimePDesde.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(574, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Desde";
            // 
            // dgvListadoVenta
            // 
            this.dgvListadoVenta.AllowUserToAddRows = false;
            this.dgvListadoVenta.AllowUserToDeleteRows = false;
            this.dgvListadoVenta.AllowUserToOrderColumns = true;
            this.dgvListadoVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListadoVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoVenta.Location = new System.Drawing.Point(37, 127);
            this.dgvListadoVenta.Name = "dgvListadoVenta";
            this.dgvListadoVenta.ReadOnly = true;
            this.dgvListadoVenta.RowHeadersWidth = 102;
            this.dgvListadoVenta.RowTemplate.Height = 40;
            this.dgvListadoVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoVenta.Size = new System.Drawing.Size(3495, 1031);
            this.dgvListadoVenta.TabIndex = 8;
            this.dgvListadoVenta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoVenta_CellDoubleClick);
            // 
            // frmBuscarCompraPorFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3600, 1262);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dateTimePHasta);
            this.Controls.Add(this.dateTimePDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListadoVenta);
            this.Name = "frmBuscarCompraPorFechas";
            this.Text = "Buscar Compras Por Fechas";
            this.Load += new System.EventHandler(this.frmBuscarCompraPorFechas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVentaProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtTotalImp;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvDetalleVentaProd;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dateTimePHasta;
        private System.Windows.Forms.DateTimePicker dateTimePDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListadoVenta;
    }
}