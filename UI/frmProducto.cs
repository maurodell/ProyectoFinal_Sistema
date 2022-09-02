using System;
using System.Windows.Forms;
using BLL;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;

namespace UI
{
    public partial class frmProducto : Form
    {
        private string rutaOrigen;
        private string rutaDestino;
        private string Directorio = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\imagenes\\";
        private string nombreAnterior;
        public frmProducto()
        {
            InitializeComponent();
            bllProducto = new BLLProducto();
            bllCategoria = new BLLCategoria();
        }
        BLLProducto bllProducto;
        BLLCategoria bllCategoria;
        private void Listar()
        {
            try
            {
                dgvListadoProd.DataSource = null;
                dgvListadoProd.DataSource = bllProducto.Listar();
                this.Formato();
                this.Limpiar();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoProd.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Buscar()
        {
            try
            {
                dgvListadoProd.DataSource = bllProducto.Buscar(txtBuscar.Text);
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoProd.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Formato()
        {
            dgvListadoProd.Columns[0].Visible = false;
            dgvListadoProd.Columns[1].HeaderText = "Categoría";
            dgvListadoProd.Columns[1].Width = 50;
            dgvListadoProd.Columns[2].HeaderText = "Código Barra";
            dgvListadoProd.Columns[2].Width = 50;
            dgvListadoProd.Columns[3].Width = 100;
            dgvListadoProd.Columns[4].Width = 150;
            dgvListadoProd.Columns[4].HeaderText = "Precio Venta";
            dgvListadoProd.Columns[5].Width = 100;
            dgvListadoProd.Columns[6].Width = 100;
            dgvListadoProd.Columns[6].HeaderText = "Descripción";
            dgvListadoProd.Columns[7].Width = 50;
            dgvListadoProd.Columns[7].HeaderText = "Ubicación";
            dgvListadoProd.Columns[8].Width = 100;
            dgvListadoProd.Columns[9].Width = 50;
            dgvListadoProd.Columns[10].Width = 50;
            dgvListadoProd.Columns[10].HeaderText = "Código";
        }
        private void Limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtCodigoBarra.Clear();
            txtDescripcion.Clear();
            txtImagen.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtUbicacion.Clear();
            picBox.Image = null;
            panelCodigo.BackgroundImage = null;
            BtnGuardar.Enabled = false;
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            txtCodigo.Visible = false;
            errorProvider1.Clear();

            this.rutaDestino = "";
            this.rutaOrigen = "";

            dgvListadoProd.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            chkSeleccionar.Checked = false;
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CargarCategoria()
        {
            try
            {
                cmbCategoria.DataSource = bllCategoria.Listar();
                cmbCategoria.ValueMember = "codigo";
                cmbCategoria.DisplayMember = "nombre";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.Listar();
            txtCodigo.Visible = false;
            this.CargarCategoria();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (file.ShowDialog() == DialogResult.OK)
            {
                picBox.Image = Image.FromFile(file.FileName);
                txtImagen.Text = file.FileName.Substring(file.FileName.LastIndexOf("\\")+1 );
                this.rutaOrigen = file.FileName;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode codigoBarra = new BarcodeLib.Barcode();
            codigoBarra.IncludeLabel = true;
            panelCodigo.BackgroundImage = codigoBarra.Encode(BarcodeLib.TYPE.CODE128, txtCodigoBarra.Text, Color.Black, Color.White, 300, 76);
            BtnGuardar.Enabled = true;

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Image imagenCodigo = (Image)panelCodigo.BackgroundImage.Clone();

            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.AddExtension = true;
            dialogo.Filter = "Image PNG (*.png)|*.png";
            dialogo.ShowDialog();
            if (!string.IsNullOrEmpty(dialogo.FileName))
            {
                imagenCodigo.Save(dialogo.FileName, ImageFormat.Png);
            }
            imagenCodigo.Dispose();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (cmbCategoria.Text == string.Empty || txtNombre.Text == string.Empty || txtPrecio.Text == string.Empty || txtStock.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos");
                    errorProvider1.SetError(cmbCategoria, "Seleccionar una categoria");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                }
                else
                {
                    //int codigoCategoria, string codigoBarra, string nombre, decimal precioVenta, int stock, string descripcion, string ubicacion, string imagen
                    respuesta = bllProducto.Insertar(Convert.ToInt32(cmbCategoria.SelectedValue), txtCodigoBarra.Text.Trim(), txtNombre.Text.Trim(), 
                                                    Convert.ToDecimal(txtPrecio.Text.Trim()), Convert.ToInt32(txtStock.Text.Trim()), txtDescripcion.Text.Trim(), txtUbicacion.Text, txtImagen.Text);
                    if (respuesta == true)
                    {
                        this.MensajeOk("El producto fue registrado correctamente");
                        if (txtImagen.Text != string.Empty)
                        {
                            this.rutaDestino = this.Directorio + txtImagen.Text;
                            File.Copy(rutaOrigen, rutaDestino);
                        }
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError("El producto no se pudo registrar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvListadoProd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                txtCodigo.Visible = true;
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtCodigo.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["codigo"].Value);
                cmbCategoria.SelectedValue = Convert.ToInt32(dgvListadoProd.CurrentRow.Cells["codigoCategoria"].Value);
                this.nombreAnterior = Convert.ToString(dgvListadoProd.CurrentRow.Cells["nombre"].Value);
                txtNombre.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["nombre"].Value);
                txtStock.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["stock"].Value);
                txtPrecio.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["precioVenta"].Value);
                txtDescripcion.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["descripcion"].Value);
                txtCodigoBarra.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["codigoBarra"].Value);
                txtUbicacion.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["ubicacion"].Value);
                string imagen;
                imagen = Convert.ToString(dgvListadoProd.CurrentRow.Cells["imagen"].Value);
                if(imagen != string.Empty)
                {
                    picBox.Image = Image.FromFile(this.Directorio + imagen);
                    txtImagen.Text = imagen;
                }
                else
                {
                    picBox.Image = null;
                    txtImagen.Text = "";
                }
                tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccionar desde la celda Nombre"+"| Error: "+ex.Message);
                throw;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (cmbCategoria.Text == string.Empty && txtNombre.Text == string.Empty && txtPrecio.Text == string.Empty && txtStock.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos");
                    errorProvider1.SetError(cmbCategoria, "Seleccionar una categoria");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                }
                else
                {
                    respuesta = bllProducto.Modificar(Convert.ToInt32(txtCodigo.Text.Trim()), this.nombreAnterior, Convert.ToInt32(cmbCategoria.SelectedValue), txtCodigoBarra.Text.Trim(), Convert.ToDecimal(txtPrecio.Text.Trim()),
                                                    Convert.ToInt32(txtStock.Text.Trim()), txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), txtUbicacion.Text, txtImagen.Text);
                    if (respuesta == true)
                    {
                        this.MensajeOk("El producto se actualizo correctamente");
                        if (txtImagen.Text != string.Empty && this.rutaOrigen != string.Empty)
                        {
                            this.rutaDestino = this.rutaDestino + txtImagen.Text;
                            File.Copy(this.rutaOrigen, rutaDestino);
                        }
                        this.Listar();
                        txtCodigo.Visible = false;
                        tabControl1.SelectedIndex = 0;
                    }
                    else
                    {
                        this.MensajeError("El producto no se pudo registrar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabControl1.SelectedIndex = 0;
        }

        private void dgvListadoProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(dgvListadoProd.Columns["Seleccionar"].Index))
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListadoProd.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);//Determino si esta o no esta marcado el checkBox(Documentacion DataGridView)
            }
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvListadoProd.Columns[0].Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;

                dgvListadoProd.DataSource = null;
                dgvListadoProd.DataSource = bllProducto.ListarTodos();
            }
            else
            {
                dgvListadoProd.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;

                dgvListadoProd.DataSource = null;
                dgvListadoProd.DataSource = bllProducto.Listar();
            }
        }
        public static bool estaListoParaUsar(string file)
        {
            try
            {
                using (FileStream inputStream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Esta seguro que va a eliminar el/los registro/s?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion.Equals(DialogResult.OK))
                {
                    int codigo;
                    bool flag = false;
                    string imagen = "";
                    foreach (DataGridViewRow row in dgvListadoProd.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[10].Value);
                            imagen = Convert.ToString(row.Cells[8].Value);
                            flag = bllProducto.Eliminar(codigo);
                        }
                    }

                    //entra en el while hasta que se libere el processor System.IO en caso que la imagen se haya actualizado o se recién guardado.
                    while (!estaListoParaUsar(this.Directorio + imagen)) { }
                    if (flag)
                    {
                        File.Delete(this.Directorio + imagen);
                        this.MensajeOk("La categoría fue eliminada correctamente");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError("Algo salío mal, la categoría no se pudo eliminar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Esta seguro que desea desactivar el/los registro/s?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion.Equals(DialogResult.OK))
                {
                    int codigo;
                    bool flag = false;
                    foreach (DataGridViewRow row in dgvListadoProd.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[10].Value);
                            flag = bllProducto.Baja(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("El producto fue dada de baja correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de baja el producto");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Esta seguro que desea desactivar el/los registro/s?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion.Equals(DialogResult.OK))
                {
                    int codigo;
                    bool flag = false;
                    foreach (DataGridViewRow row in dgvListadoProd.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[10].Value);
                            flag = bllProducto.Alta(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("El producto fue dada de alta correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de alta el producto");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
