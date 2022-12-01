
namespace UI
{
    partial class frmConsultivoProductos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnAgrupCat = new System.Windows.Forms.RadioButton();
            this.rbtnBajoStock = new System.Windows.Forms.RadioButton();
            this.rbtnMenosVendidos = new System.Windows.Forms.RadioButton();
            this.rbtnPorVencer = new System.Windows.Forms.RadioButton();
            this.rbtnMasVendidos = new System.Windows.Forms.RadioButton();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnAgrupCat);
            this.groupBox1.Controls.Add(this.rbtnBajoStock);
            this.groupBox1.Controls.Add(this.rbtnMenosVendidos);
            this.groupBox1.Controls.Add(this.rbtnPorVencer);
            this.groupBox1.Controls.Add(this.rbtnMasVendidos);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Location = new System.Drawing.Point(60, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1947, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro para productos";
            // 
            // rbtnAgrupCat
            // 
            this.rbtnAgrupCat.AutoSize = true;
            this.rbtnAgrupCat.Location = new System.Drawing.Point(1262, 79);
            this.rbtnAgrupCat.Name = "rbtnAgrupCat";
            this.rbtnAgrupCat.Size = new System.Drawing.Size(335, 36);
            this.rbtnAgrupCat.TabIndex = 8;
            this.rbtnAgrupCat.TabStop = true;
            this.rbtnAgrupCat.Text = "Agrupar Por Categoría";
            this.rbtnAgrupCat.UseVisualStyleBackColor = true;
            // 
            // rbtnBajoStock
            // 
            this.rbtnBajoStock.AutoSize = true;
            this.rbtnBajoStock.Location = new System.Drawing.Point(995, 79);
            this.rbtnBajoStock.Name = "rbtnBajoStock";
            this.rbtnBajoStock.Size = new System.Drawing.Size(188, 36);
            this.rbtnBajoStock.TabIndex = 7;
            this.rbtnBajoStock.TabStop = true;
            this.rbtnBajoStock.Text = "Bajo Stock";
            this.rbtnBajoStock.UseVisualStyleBackColor = true;
            // 
            // rbtnMenosVendidos
            // 
            this.rbtnMenosVendidos.AutoSize = true;
            this.rbtnMenosVendidos.Location = new System.Drawing.Point(380, 79);
            this.rbtnMenosVendidos.Name = "rbtnMenosVendidos";
            this.rbtnMenosVendidos.Size = new System.Drawing.Size(264, 36);
            this.rbtnMenosVendidos.TabIndex = 6;
            this.rbtnMenosVendidos.TabStop = true;
            this.rbtnMenosVendidos.Text = "Menos Vendidos";
            this.rbtnMenosVendidos.UseVisualStyleBackColor = true;
            // 
            // rbtnPorVencer
            // 
            this.rbtnPorVencer.AutoSize = true;
            this.rbtnPorVencer.Location = new System.Drawing.Point(723, 79);
            this.rbtnPorVencer.Name = "rbtnPorVencer";
            this.rbtnPorVencer.Size = new System.Drawing.Size(193, 36);
            this.rbtnPorVencer.TabIndex = 5;
            this.rbtnPorVencer.TabStop = true;
            this.rbtnPorVencer.Text = "Por Vencer";
            this.rbtnPorVencer.UseVisualStyleBackColor = true;
            // 
            // rbtnMasVendidos
            // 
            this.rbtnMasVendidos.AutoSize = true;
            this.rbtnMasVendidos.Checked = true;
            this.rbtnMasVendidos.Location = new System.Drawing.Point(69, 79);
            this.rbtnMasVendidos.Name = "rbtnMasVendidos";
            this.rbtnMasVendidos.Size = new System.Drawing.Size(232, 36);
            this.rbtnMasVendidos.TabIndex = 4;
            this.rbtnMasVendidos.TabStop = true;
            this.rbtnMasVendidos.Text = "Más Vendidos";
            this.rbtnMasVendidos.UseVisualStyleBackColor = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(1722, 74);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(173, 47);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(60, 272);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 102;
            this.dgvProductos.RowTemplate.Height = 40;
            this.dgvProductos.Size = new System.Drawing.Size(1946, 910);
            this.dgvProductos.TabIndex = 1;
            // 
            // frmConsultivoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2094, 1218);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConsultivoProductos";
            this.Text = "Consultivo";
            this.Load += new System.EventHandler(this.frmConsultivoProductos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnMenosVendidos;
        private System.Windows.Forms.RadioButton rbtnPorVencer;
        private System.Windows.Forms.RadioButton rbtnMasVendidos;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.RadioButton rbtnAgrupCat;
        private System.Windows.Forms.RadioButton rbtnBajoStock;
    }
}