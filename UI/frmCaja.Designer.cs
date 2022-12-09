
namespace UI
{
    partial class frmCaja
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
            this.btnCancelarCaja = new System.Windows.Forms.Button();
            this.dgvCaja = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickFecha = new System.Windows.Forms.DateTimePicker();
            this.btnAgregarCaja = new System.Windows.Forms.Button();
            this.dgvCajaInicial = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaInicial)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelarCaja
            // 
            this.btnCancelarCaja.Location = new System.Drawing.Point(902, 69);
            this.btnCancelarCaja.Name = "btnCancelarCaja";
            this.btnCancelarCaja.Size = new System.Drawing.Size(362, 54);
            this.btnCancelarCaja.TabIndex = 3;
            this.btnCancelarCaja.Text = "Cancelar Caja";
            this.btnCancelarCaja.UseVisualStyleBackColor = true;
            this.btnCancelarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // dgvCaja
            // 
            this.dgvCaja.AllowUserToAddRows = false;
            this.dgvCaja.AllowUserToDeleteRows = false;
            this.dgvCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaja.Location = new System.Drawing.Point(50, 71);
            this.dgvCaja.Name = "dgvCaja";
            this.dgvCaja.ReadOnly = true;
            this.dgvCaja.RowHeadersWidth = 102;
            this.dgvCaja.RowTemplate.Height = 40;
            this.dgvCaja.Size = new System.Drawing.Size(3137, 913);
            this.dgvCaja.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // datePickFecha
            // 
            this.datePickFecha.Location = new System.Drawing.Point(191, 75);
            this.datePickFecha.Name = "datePickFecha";
            this.datePickFecha.Size = new System.Drawing.Size(504, 38);
            this.datePickFecha.TabIndex = 1;
            // 
            // btnAgregarCaja
            // 
            this.btnAgregarCaja.Location = new System.Drawing.Point(758, 67);
            this.btnAgregarCaja.Name = "btnAgregarCaja";
            this.btnAgregarCaja.Size = new System.Drawing.Size(91, 54);
            this.btnAgregarCaja.TabIndex = 2;
            this.btnAgregarCaja.Text = "+";
            this.btnAgregarCaja.UseVisualStyleBackColor = true;
            this.btnAgregarCaja.Click += new System.EventHandler(this.btnAgregarCaja_Click);
            // 
            // dgvCajaInicial
            // 
            this.dgvCajaInicial.AllowUserToAddRows = false;
            this.dgvCajaInicial.AllowUserToDeleteRows = false;
            this.dgvCajaInicial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajaInicial.Location = new System.Drawing.Point(43, 167);
            this.dgvCajaInicial.Name = "dgvCajaInicial";
            this.dgvCajaInicial.ReadOnly = true;
            this.dgvCajaInicial.RowHeadersWidth = 102;
            this.dgvCajaInicial.RowTemplate.Height = 40;
            this.dgvCajaInicial.Size = new System.Drawing.Size(3269, 239);
            this.dgvCajaInicial.TabIndex = 7;
            this.dgvCajaInicial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCajaInicial_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCaja);
            this.groupBox1.Location = new System.Drawing.Point(43, 483);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(3248, 1030);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Cierres de Caja";
            // 
            // btnVenta
            // 
            this.btnVenta.Enabled = false;
            this.btnVenta.Location = new System.Drawing.Point(1627, 69);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(220, 52);
            this.btnVenta.TabIndex = 9;
            this.btnVenta.Text = "Venta";
            this.btnVenta.UseVisualStyleBackColor = true;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // btnCompra
            // 
            this.btnCompra.Enabled = false;
            this.btnCompra.Location = new System.Drawing.Point(1988, 69);
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(220, 52);
            this.btnCompra.TabIndex = 10;
            this.btnCompra.Text = "Compra";
            this.btnCompra.UseVisualStyleBackColor = true;
            this.btnCompra.Click += new System.EventHandler(this.btnCompra_Click);
            // 
            // frmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3429, 1562);
            this.Controls.Add(this.btnCompra);
            this.Controls.Add(this.btnVenta);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCajaInicial);
            this.Controls.Add(this.btnAgregarCaja);
            this.Controls.Add(this.datePickFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelarCaja);
            this.Name = "frmCaja";
            this.Text = " Caja Diaria";
            this.Load += new System.EventHandler(this.frmCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaInicial)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelarCaja;
        private System.Windows.Forms.DataGridView dgvCaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickFecha;
        private System.Windows.Forms.Button btnAgregarCaja;
        private System.Windows.Forms.DataGridView dgvCajaInicial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnCompra;
    }
}