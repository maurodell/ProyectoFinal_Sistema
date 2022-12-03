
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MasMes = new System.Windows.Forms.CheckBox();
            this.menosMes = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.rbtnAgrupCat = new System.Windows.Forms.RadioButton();
            this.rbtnBajoStock = new System.Windows.Forms.RadioButton();
            this.rbtnMenosVendidos = new System.Windows.Forms.RadioButton();
            this.rbtnPorVencer = new System.Windows.Forms.RadioButton();
            this.rbtnMasVendidos = new System.Windows.Forms.RadioButton();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MasMes);
            this.groupBox1.Controls.Add(this.menosMes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.rbtnAgrupCat);
            this.groupBox1.Controls.Add(this.rbtnBajoStock);
            this.groupBox1.Controls.Add(this.rbtnMenosVendidos);
            this.groupBox1.Controls.Add(this.rbtnPorVencer);
            this.groupBox1.Controls.Add(this.rbtnMasVendidos);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Location = new System.Drawing.Point(60, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1947, 202);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro para productos";
            // 
            // MasMes
            // 
            this.MasMes.AutoSize = true;
            this.MasMes.Enabled = false;
            this.MasMes.Location = new System.Drawing.Point(1651, 154);
            this.MasMes.Name = "MasMes";
            this.MasMes.Size = new System.Drawing.Size(244, 36);
            this.MasMes.TabIndex = 12;
            this.MasMes.Text = "Mas de un Mes";
            this.MasMes.UseVisualStyleBackColor = true;
            this.MasMes.CheckedChanged += new System.EventHandler(this.MasMes_CheckedChanged);
            // 
            // menosMes
            // 
            this.menosMes.AutoSize = true;
            this.menosMes.Checked = true;
            this.menosMes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menosMes.Enabled = false;
            this.menosMes.Location = new System.Drawing.Point(1386, 154);
            this.menosMes.Name = "menosMes";
            this.menosMes.Size = new System.Drawing.Size(170, 36);
            this.menosMes.TabIndex = 11;
            this.menosMes.Text = "Este Mes";
            this.menosMes.UseVisualStyleBackColor = true;
            this.menosMes.CheckedChanged += new System.EventHandler(this.menosMes_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cantidad de vendido a filtrar";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(454, 145);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(117, 38);
            this.txtCantidad.TabIndex = 9;
            // 
            // rbtnAgrupCat
            // 
            this.rbtnAgrupCat.AutoSize = true;
            this.rbtnAgrupCat.Location = new System.Drawing.Point(707, 67);
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
            this.rbtnBajoStock.Location = new System.Drawing.Point(1113, 67);
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
            this.rbtnMenosVendidos.Location = new System.Drawing.Point(372, 67);
            this.rbtnMenosVendidos.Name = "rbtnMenosVendidos";
            this.rbtnMenosVendidos.Size = new System.Drawing.Size(264, 36);
            this.rbtnMenosVendidos.TabIndex = 6;
            this.rbtnMenosVendidos.TabStop = true;
            this.rbtnMenosVendidos.Text = "Menos Vendidos";
            this.rbtnMenosVendidos.UseVisualStyleBackColor = true;
            this.rbtnMenosVendidos.CheckedChanged += new System.EventHandler(this.rbtnMenosVendidos_CheckedChanged);
            // 
            // rbtnPorVencer
            // 
            this.rbtnPorVencer.AutoSize = true;
            this.rbtnPorVencer.Location = new System.Drawing.Point(1372, 67);
            this.rbtnPorVencer.Name = "rbtnPorVencer";
            this.rbtnPorVencer.Size = new System.Drawing.Size(193, 36);
            this.rbtnPorVencer.TabIndex = 5;
            this.rbtnPorVencer.TabStop = true;
            this.rbtnPorVencer.Text = "Por Vencer";
            this.rbtnPorVencer.UseVisualStyleBackColor = true;
            this.rbtnPorVencer.CheckedChanged += new System.EventHandler(this.rbtnPorVencer_CheckedChanged);
            // 
            // rbtnMasVendidos
            // 
            this.rbtnMasVendidos.AutoSize = true;
            this.rbtnMasVendidos.Checked = true;
            this.rbtnMasVendidos.Location = new System.Drawing.Point(69, 67);
            this.rbtnMasVendidos.Name = "rbtnMasVendidos";
            this.rbtnMasVendidos.Size = new System.Drawing.Size(232, 36);
            this.rbtnMasVendidos.TabIndex = 4;
            this.rbtnMasVendidos.TabStop = true;
            this.rbtnMasVendidos.Text = "Más Vendidos";
            this.rbtnMasVendidos.UseVisualStyleBackColor = true;
            this.rbtnMasVendidos.CheckedChanged += new System.EventHandler(this.rbtnMasVendidos_CheckedChanged);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(1722, 62);
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
            this.dgvProductos.Location = new System.Drawing.Point(60, 292);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 102;
            this.dgvProductos.RowTemplate.Height = 40;
            this.dgvProductos.Size = new System.Drawing.Size(1946, 890);
            this.dgvProductos.TabIndex = 1;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.SystemColors.Control;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(2013, 80);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.DimGray;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1156, 1102);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Gráfico cantidad/stock";
            this.chart1.Titles.Add(title1);
            // 
            // frmConsultivoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3218, 1218);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConsultivoProductos";
            this.Text = "Consultivo";
            this.Load += new System.EventHandler(this.frmConsultivoProductos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.CheckBox menosMes;
        private System.Windows.Forms.CheckBox MasMes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}