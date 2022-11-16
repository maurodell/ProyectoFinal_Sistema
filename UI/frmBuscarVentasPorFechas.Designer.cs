
namespace UI
{
    partial class frmBuscarVentasPorFechas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimePHasta = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtTotalImp = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvDetalleVentaProd = new System.Windows.Forms.DataGridView();
            this.dgvListadoVenta = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cantLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.totalLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.stockLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gananciaLblTotal = new System.Windows.Forms.Label();
            this.gananciaLbl = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVentaProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoVenta)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(581, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // dateTimePDesde
            // 
            this.dateTimePDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePDesde.Location = new System.Drawing.Point(153, 67);
            this.dateTimePDesde.Name = "dateTimePDesde";
            this.dateTimePDesde.Size = new System.Drawing.Size(320, 38);
            this.dateTimePDesde.TabIndex = 4;
            // 
            // dateTimePHasta
            // 
            this.dateTimePHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePHasta.Location = new System.Drawing.Point(686, 67);
            this.dateTimePHasta.Name = "dateTimePHasta";
            this.dateTimePHasta.Size = new System.Drawing.Size(320, 38);
            this.dateTimePHasta.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1079, 60);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(192, 51);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.panel1.Location = new System.Drawing.Point(700, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2484, 1106);
            this.panel1.TabIndex = 7;
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
            // dgvListadoVenta
            // 
            this.dgvListadoVenta.AllowUserToAddRows = false;
            this.dgvListadoVenta.AllowUserToDeleteRows = false;
            this.dgvListadoVenta.AllowUserToOrderColumns = true;
            this.dgvListadoVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListadoVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoVenta.Location = new System.Drawing.Point(45, 150);
            this.dgvListadoVenta.Name = "dgvListadoVenta";
            this.dgvListadoVenta.ReadOnly = true;
            this.dgvListadoVenta.RowHeadersWidth = 102;
            this.dgvListadoVenta.RowTemplate.Height = 40;
            this.dgvListadoVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoVenta.Size = new System.Drawing.Size(3495, 788);
            this.dgvListadoVenta.TabIndex = 1;
            this.dgvListadoVenta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoCompra_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.Controls.Add(this.cantLbl);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(45, 986);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 106);
            this.panel2.TabIndex = 8;
            // 
            // cantLbl
            // 
            this.cantLbl.AutoSize = true;
            this.cantLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantLbl.Location = new System.Drawing.Point(29, 46);
            this.cantLbl.Name = "cantLbl";
            this.cantLbl.Size = new System.Drawing.Size(43, 46);
            this.cantLbl.TabIndex = 1;
            this.cantLbl.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(265, 32);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cantidad de Ventas";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel3.Controls.Add(this.totalLbl);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(45, 1122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 106);
            this.panel3.TabIndex = 9;
            // 
            // totalLbl
            // 
            this.totalLbl.AutoSize = true;
            this.totalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLbl.Location = new System.Drawing.Point(29, 46);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(43, 46);
            this.totalLbl.TabIndex = 1;
            this.totalLbl.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 32);
            this.label9.TabIndex = 0;
            this.label9.Text = "Total Ingresos";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel4.Controls.Add(this.stockLbl);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(45, 1258);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(324, 106);
            this.panel4.TabIndex = 10;
            // 
            // stockLbl
            // 
            this.stockLbl.AutoSize = true;
            this.stockLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockLbl.Location = new System.Drawing.Point(29, 46);
            this.stockLbl.Name = "stockLbl";
            this.stockLbl.Size = new System.Drawing.Size(43, 46);
            this.stockLbl.TabIndex = 1;
            this.stockLbl.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 32);
            this.label8.TabIndex = 0;
            this.label8.Text = "Stock movido";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel5.Controls.Add(this.gananciaLblTotal);
            this.panel5.Controls.Add(this.gananciaLbl);
            this.panel5.Location = new System.Drawing.Point(45, 1394);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(324, 106);
            this.panel5.TabIndex = 11;
            // 
            // gananciaLblTotal
            // 
            this.gananciaLblTotal.AutoSize = true;
            this.gananciaLblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gananciaLblTotal.Location = new System.Drawing.Point(29, 46);
            this.gananciaLblTotal.Name = "gananciaLblTotal";
            this.gananciaLblTotal.Size = new System.Drawing.Size(43, 46);
            this.gananciaLblTotal.TabIndex = 1;
            this.gananciaLblTotal.Text = "0";
            // 
            // gananciaLbl
            // 
            this.gananciaLbl.AutoSize = true;
            this.gananciaLbl.Location = new System.Drawing.Point(31, 0);
            this.gananciaLbl.Name = "gananciaLbl";
            this.gananciaLbl.Size = new System.Drawing.Size(209, 32);
            this.gananciaLbl.TabIndex = 0;
            this.gananciaLbl.Text = "Total Ganancia";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(452, 973);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(2224, 527);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "Productos Vendidos";
            this.chart1.Titles.Add(title1);
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(2717, 973);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            series2.IsValueShownAsLabel = true;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(823, 527);
            this.chart2.TabIndex = 13;
            this.chart2.Text = "chart2";
            title2.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            title2.Name = "Title1";
            title2.Text = "Categoria Productos";
            this.chart2.Titles.Add(title2);
            // 
            // frmBuscarVentasPorFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3640, 1553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dateTimePHasta);
            this.Controls.Add(this.dateTimePDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListadoVenta);
            this.Name = "frmBuscarVentasPorFechas";
            this.Text = "Buscar Ventas Por Fechas";
            this.Load += new System.EventHandler(this.frmBuscarVentasPorFechas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVentaProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoVenta)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePDesde;
        private System.Windows.Forms.DateTimePicker dateTimePHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvDetalleVentaProd;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtTotalImp;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvListadoVenta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label cantLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label totalLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label stockLbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label gananciaLblTotal;
        private System.Windows.Forms.Label gananciaLbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}