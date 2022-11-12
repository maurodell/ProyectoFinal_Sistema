
namespace UI
{
    partial class frmVenta
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
            this.components = new System.ComponentModel.Container();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPuntoVenta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtAlicuota = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNumComprob = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbComprobante = new System.Windows.Forms.ComboBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnular = new System.Windows.Forms.Button();
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarComprobante = new System.Windows.Forms.TextBox();
            this.lblTotalReg = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.tabCat = new System.Windows.Forms.TabPage();
            this.dgvListadoCompra = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.dgvProductoPanel = new System.Windows.Forms.DataGridView();
            this.btnCerrarPanel = new System.Windows.Forms.Button();
            this.btnBuscarPanel = new System.Windows.Forms.Button();
            this.txtBuscarProducPanel = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtTotalImpuesto = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.btnExplorarProd = new System.Windows.Forms.Button();
            this.txtCodBarra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductoPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // dateFecha
            // 
            this.dateFecha.Location = new System.Drawing.Point(2172, 50);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(472, 38);
            this.dateFecha.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2020, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 32);
            this.label13.TabIndex = 15;
            this.label13.Text = "Fecha (*)";
            // 
            // txtPuntoVenta
            // 
            this.txtPuntoVenta.Location = new System.Drawing.Point(834, 132);
            this.txtPuntoVenta.Name = "txtPuntoVenta";
            this.txtPuntoVenta.Size = new System.Drawing.Size(247, 38);
            this.txtPuntoVenta.TabIndex = 14;
            this.txtPuntoVenta.Text = "0000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(607, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 32);
            this.label8.TabIndex = 13;
            this.label8.Text = "Punto Venta (*)";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(1451, 50);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(225, 51);
            this.btnBuscarCliente.TabIndex = 10;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtAlicuota
            // 
            this.txtAlicuota.Enabled = false;
            this.txtAlicuota.Location = new System.Drawing.Point(2413, 132);
            this.txtAlicuota.Name = "txtAlicuota";
            this.txtAlicuota.Size = new System.Drawing.Size(231, 38);
            this.txtAlicuota.TabIndex = 12;
            this.txtAlicuota.Text = "0.21";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2225, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 32);
            this.label9.TabIndex = 11;
            this.label9.Text = "Alicuota IVA";
            // 
            // txtNumComprob
            // 
            this.txtNumComprob.Location = new System.Drawing.Point(1472, 132);
            this.txtNumComprob.Name = "txtNumComprob";
            this.txtNumComprob.Size = new System.Drawing.Size(678, 38);
            this.txtNumComprob.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1132, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(330, 32);
            this.label7.TabIndex = 6;
            this.label7.Text = "Número Comprobante (*)";
            // 
            // cmbComprobante
            // 
            this.cmbComprobante.FormattingEnabled = true;
            this.cmbComprobante.Location = new System.Drawing.Point(267, 132);
            this.cmbComprobante.Name = "cmbComprobante";
            this.cmbComprobante.Size = new System.Drawing.Size(316, 39);
            this.cmbComprobante.TabIndex = 5;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Location = new System.Drawing.Point(436, 56);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(968, 38);
            this.txtNombreCliente.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 32);
            this.label6.TabIndex = 3;
            this.label6.Text = "Comprobante (*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cliente (*)";
            // 
            // btnAnular
            // 
            this.btnAnular.Location = new System.Drawing.Point(441, 1265);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(341, 50);
            this.btnAnular.TabIndex = 6;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // chkSeleccionar
            // 
            this.chkSeleccionar.AutoSize = true;
            this.chkSeleccionar.Location = new System.Drawing.Point(22, 1272);
            this.chkSeleccionar.Name = "chkSeleccionar";
            this.chkSeleccionar.Size = new System.Drawing.Size(203, 36);
            this.chkSeleccionar.TabIndex = 5;
            this.chkSeleccionar.Text = "Seleccionar";
            this.chkSeleccionar.UseVisualStyleBackColor = true;
            this.chkSeleccionar.CheckedChanged += new System.EventHandler(this.chkSeleccionar_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1318, 86);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(193, 49);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar Por Número Comprobante";
            // 
            // txtBuscarComprobante
            // 
            this.txtBuscarComprobante.Location = new System.Drawing.Point(22, 92);
            this.txtBuscarComprobante.Name = "txtBuscarComprobante";
            this.txtBuscarComprobante.Size = new System.Drawing.Size(1242, 38);
            this.txtBuscarComprobante.TabIndex = 2;
            // 
            // lblTotalReg
            // 
            this.lblTotalReg.AutoSize = true;
            this.lblTotalReg.Location = new System.Drawing.Point(3049, 1273);
            this.lblTotalReg.Name = "lblTotalReg";
            this.lblTotalReg.Size = new System.Drawing.Size(93, 32);
            this.lblTotalReg.TabIndex = 1;
            this.lblTotalReg.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateFecha);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtPuntoVenta);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnBuscarCliente);
            this.groupBox1.Controls.Add(this.txtAlicuota);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.txtNumComprob);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbComprobante);
            this.groupBox1.Controls.Add(this.txtNombreCliente);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCodCliente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(44, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(3439, 196);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cabecera";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(3201, 129);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(200, 38);
            this.txtCodigo.TabIndex = 6;
            this.txtCodigo.Visible = false;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Enabled = false;
            this.txtCodCliente.Location = new System.Drawing.Point(216, 56);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(194, 38);
            this.txtCodCliente.TabIndex = 2;
            // 
            // tabCat
            // 
            this.tabCat.Controls.Add(this.btnAnular);
            this.tabCat.Controls.Add(this.chkSeleccionar);
            this.tabCat.Controls.Add(this.btnBuscar);
            this.tabCat.Controls.Add(this.label1);
            this.tabCat.Controls.Add(this.txtBuscarComprobante);
            this.tabCat.Controls.Add(this.lblTotalReg);
            this.tabCat.Controls.Add(this.dgvListadoCompra);
            this.tabCat.Location = new System.Drawing.Point(10, 48);
            this.tabCat.Name = "tabCat";
            this.tabCat.Padding = new System.Windows.Forms.Padding(3);
            this.tabCat.Size = new System.Drawing.Size(3538, 1352);
            this.tabCat.TabIndex = 0;
            this.tabCat.Text = "Listado";
            this.tabCat.UseVisualStyleBackColor = true;
            // 
            // dgvListadoCompra
            // 
            this.dgvListadoCompra.AllowUserToAddRows = false;
            this.dgvListadoCompra.AllowUserToDeleteRows = false;
            this.dgvListadoCompra.AllowUserToOrderColumns = true;
            this.dgvListadoCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListadoCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dgvListadoCompra.Location = new System.Drawing.Point(22, 195);
            this.dgvListadoCompra.Name = "dgvListadoCompra";
            this.dgvListadoCompra.ReadOnly = true;
            this.dgvListadoCompra.RowHeadersWidth = 102;
            this.dgvListadoCompra.RowTemplate.Height = 40;
            this.dgvListadoCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoCompra.Size = new System.Drawing.Size(3495, 1031);
            this.dgvListadoCompra.TabIndex = 0;
            this.dgvListadoCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoCompra_CellContentClick);
            this.dgvListadoCompra.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoCompra_CellDoubleClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.MinimumWidth = 12;
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCat);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(3558, 1410);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEliminar);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btnCancelar);
            this.tabPage2.Controls.Add(this.btnInsertar);
            this.tabPage2.Location = new System.Drawing.Point(10, 48);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(3538, 1352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gestión";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(146, 1273);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(561, 51);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.panelProducto);
            this.groupBox2.Controls.Add(this.dgvDetalle);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtTotal);
            this.groupBox2.Controls.Add(this.txtTotalImpuesto);
            this.groupBox2.Controls.Add(this.txtSubTotal);
            this.groupBox2.Controls.Add(this.btnExplorarProd);
            this.groupBox2.Controls.Add(this.txtCodBarra);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(44, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(3445, 973);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(1889, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 69);
            this.label15.TabIndex = 23;
            this.label15.Text = "I";
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelProducto.Controls.Add(this.dgvProductoPanel);
            this.panelProducto.Controls.Add(this.btnCerrarPanel);
            this.panelProducto.Controls.Add(this.btnBuscarPanel);
            this.panelProducto.Controls.Add(this.txtBuscarProducPanel);
            this.panelProducto.Controls.Add(this.label14);
            this.panelProducto.Location = new System.Drawing.Point(207, 150);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(2893, 774);
            this.panelProducto.TabIndex = 22;
            this.panelProducto.Visible = false;
            // 
            // dgvProductoPanel
            // 
            this.dgvProductoPanel.AllowUserToAddRows = false;
            this.dgvProductoPanel.AllowUserToDeleteRows = false;
            this.dgvProductoPanel.AllowUserToOrderColumns = true;
            this.dgvProductoPanel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductoPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductoPanel.Location = new System.Drawing.Point(88, 172);
            this.dgvProductoPanel.Name = "dgvProductoPanel";
            this.dgvProductoPanel.ReadOnly = true;
            this.dgvProductoPanel.RowHeadersWidth = 102;
            this.dgvProductoPanel.RowTemplate.Height = 40;
            this.dgvProductoPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductoPanel.Size = new System.Drawing.Size(2742, 564);
            this.dgvProductoPanel.TabIndex = 4;
            this.dgvProductoPanel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductoPanel_CellDoubleClick);
            // 
            // btnCerrarPanel
            // 
            this.btnCerrarPanel.Location = new System.Drawing.Point(2709, 26);
            this.btnCerrarPanel.Name = "btnCerrarPanel";
            this.btnCerrarPanel.Size = new System.Drawing.Size(152, 59);
            this.btnCerrarPanel.TabIndex = 3;
            this.btnCerrarPanel.Text = "Cerrar";
            this.btnCerrarPanel.UseVisualStyleBackColor = true;
            this.btnCerrarPanel.Click += new System.EventHandler(this.btnCerrarPanel_Click);
            // 
            // btnBuscarPanel
            // 
            this.btnBuscarPanel.Location = new System.Drawing.Point(1516, 68);
            this.btnBuscarPanel.Name = "btnBuscarPanel";
            this.btnBuscarPanel.Size = new System.Drawing.Size(232, 59);
            this.btnBuscarPanel.TabIndex = 2;
            this.btnBuscarPanel.Text = "Buscar";
            this.btnBuscarPanel.UseVisualStyleBackColor = true;
            this.btnBuscarPanel.Click += new System.EventHandler(this.btnBuscarPanel_Click);
            // 
            // txtBuscarProducPanel
            // 
            this.txtBuscarProducPanel.Location = new System.Drawing.Point(98, 79);
            this.txtBuscarProducPanel.Name = "txtBuscarProducPanel";
            this.txtBuscarProducPanel.Size = new System.Drawing.Size(1367, 38);
            this.txtBuscarProducPanel.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(92, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(254, 32);
            this.label14.TabIndex = 0;
            this.label14.Text = "Buscar por nombre";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(102, 159);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersWidth = 102;
            this.dgvDetalle.RowTemplate.Height = 40;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(2149, 777);
            this.dgvDetalle.TabIndex = 21;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellContentClick);
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2691, 837);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 32);
            this.label12.TabIndex = 20;
            this.label12.Text = "Total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2691, 372);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(202, 32);
            this.label11.TabIndex = 19;
            this.label11.Text = "Total Impuesto";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2691, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 32);
            this.label10.TabIndex = 18;
            this.label10.Text = "SubTotal";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(2686, 886);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(720, 38);
            this.txtTotal.TabIndex = 17;
            // 
            // txtTotalImpuesto
            // 
            this.txtTotalImpuesto.Enabled = false;
            this.txtTotalImpuesto.Location = new System.Drawing.Point(2697, 422);
            this.txtTotalImpuesto.Name = "txtTotalImpuesto";
            this.txtTotalImpuesto.Size = new System.Drawing.Size(709, 38);
            this.txtTotalImpuesto.TabIndex = 16;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Location = new System.Drawing.Point(2687, 267);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(719, 38);
            this.txtSubTotal.TabIndex = 15;
            // 
            // btnExplorarProd
            // 
            this.btnExplorarProd.Location = new System.Drawing.Point(2026, 66);
            this.btnExplorarProd.Name = "btnExplorarProd";
            this.btnExplorarProd.Size = new System.Drawing.Size(225, 51);
            this.btnExplorarProd.TabIndex = 13;
            this.btnExplorarProd.Text = "Explorar";
            this.btnExplorarProd.UseVisualStyleBackColor = true;
            this.btnExplorarProd.Click += new System.EventHandler(this.btnExplorarProd_Click);
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.Location = new System.Drawing.Point(254, 73);
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.Size = new System.Drawing.Size(1580, 38);
            this.txtCodBarra.TabIndex = 1;
            this.txtCodBarra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodBarra_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1939, 1283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "(*) Datos obligatorios";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(2952, 1273);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(537, 51);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(2294, 1273);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(561, 51);
            this.btnInsertar.TabIndex = 4;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // frmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3613, 1473);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmVenta";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this.frmVenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabCat.ResumeLayout(false);
            this.tabCat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductoPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPuntoVenta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtAlicuota;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNumComprob;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbComprobante;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.CheckBox chkSeleccionar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarComprobante;
        private System.Windows.Forms.Label lblTotalReg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TabPage tabCat;
        private System.Windows.Forms.DataGridView dgvListadoCompra;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.DataGridView dgvProductoPanel;
        private System.Windows.Forms.Button btnCerrarPanel;
        private System.Windows.Forms.Button btnBuscarPanel;
        private System.Windows.Forms.TextBox txtBuscarProducPanel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtTotalImpuesto;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Button btnExplorarProd;
        private System.Windows.Forms.TextBox txtCodBarra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnInsertar;
    }
}