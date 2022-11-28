using System;
using System.Windows.Forms;
using BLL;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace UI
{
    public partial class frmProducto : Form
    {
        private string rutaOrigen;
        private string rutaDestino;
        private string Directorio = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\imagenes\\";
        private string Directorio2 = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\imagenes";
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
            dgvListadoProd.Columns[4].Width = 60;
            dgvListadoProd.Columns[4].HeaderText = "Precio Venta";
            dgvListadoProd.Columns[5].Width = 50;
            dgvListadoProd.Columns[6].Width = 150;
            dgvListadoProd.Columns[6].HeaderText = "Descripción";
            dgvListadoProd.Columns[7].Width = 50;
            dgvListadoProd.Columns[7].HeaderText = "Ubicación";
            dgvListadoProd.Columns[8].Width = 140;
            dgvListadoProd.Columns[8].HeaderText = "Fecha Vencimiento";
            dgvListadoProd.Columns[9].Width = 80;
            dgvListadoProd.Columns[9].HeaderText = "Imagen";
            dgvListadoProd.Columns[10].Width = 20;
            dgvListadoProd.Columns[10].HeaderText = "Est.";
            dgvListadoProd.Columns[11].Width = 50;
            dgvListadoProd.Columns[11].HeaderText = "Código";
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
        private bool UserRegex()
        {
            bool salida = true;
            if (cmbCategoria.Text == string.Empty || txtNombre.Text == string.Empty || txtPrecio.Text == string.Empty || txtUbicacion.Text == string.Empty || txtCodigoBarra.Text == string.Empty)
            {
                switch (true)
                {
                    case bool _ when Regex.IsMatch(txtNombre.Text, @"^(?![a-zA-Z\s\p{L}]+$)"):
                        MessageBox.Show("El nombre acepta caracteres alfabéticos", "ERROR");
                        salida = false;
                        break;
                    case bool _ when Regex.IsMatch(txtPrecio.Text, @"^(?![0-9\p{N}]+$)"):
                        MessageBox.Show("El precio solo acepta caracteres númericos.\nControlar espacios en blanco.", "ERROR");
                        salida = false;
                        break;
                    case bool _ when Regex.IsMatch(txtUbicacion.Text, "^(?![a-zA-Z0-9]+$)"):
                        MessageBox.Show("La ubicación solo acepta caracteres alfanúmericos.\nControlar espacios en blanco.", "ERROR");
                        salida = false;
                        break;
                    case bool _ when Regex.IsMatch(txtCodigoBarra.Text, "^(?![a-zA-Z0-9]+$)"):
                        MessageBox.Show("El código de barra solo acepta caracteres alfanúmericos.\nControlar espacios en blanco.", "ERROR");
                        salida = false;
                        break;

                    default:
                        break;
                }
            }

            return salida;
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode codigoBarra = new BarcodeLib.Barcode();
            codigoBarra.IncludeLabel = true;
            if (!String.IsNullOrEmpty(txtCodigoBarra.Text))
            {
                panelCodigo.BackgroundImage = codigoBarra.Encode(BarcodeLib.TYPE.CODE128, txtCodigoBarra.Text, Color.Black, Color.White, 300, 76);
            }
            else
            {
                this.MensajeError("Debe completar el campo, Código de Barra!");
            }

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
                DateTime hoy = DateTime.Now;
                //evaluar los meses q se cargar dateTFecha.Value >= hoy.AddMonths(2) || 
                if (cmbCategoria.Text == string.Empty || txtNombre.Text == string.Empty || txtPrecio.Text == string.Empty || txtUbicacion.Text == string.Empty || txtCodigoBarra.Text == string.Empty)
                {
                    this.MensajeError("Algunos de los datos faltan o son incorrectos");
                    errorProvider1.SetError(cmbCategoria, "Seleccionar una categoria");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                    errorProvider1.SetError(dateTFecha, "Fecha de vencimiento superior o igual a 2 meses de la fecha actual");
                    errorProvider1.SetError(txtPrecio, "El precio es necesario");
                    errorProvider1.SetError(txtUbicacion, "Debe completar la ubicación del producto en el deposito");
                    errorProvider1.SetError(txtCodigoBarra, "Debe completar el código de barra, este puede ser scaneado");
                }
                else
                {
                    if (UserRegex())
                    {
                        string nombreImagen = txtImagen.Text;
                        string nombreImagenGuardar = "";
                        bool flag = false;
                        DirectoryInfo di = new DirectoryInfo(Directorio2);
                        foreach (var fi in di.GetFiles())
                        {
                            nombreImagenGuardar = fi.Name;
                            if (nombreImagenGuardar.Equals(nombreImagen))
                            {
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            respuesta = bllProducto.Insertar(Convert.ToInt32(cmbCategoria.SelectedValue), txtCodigoBarra.Text.Trim(), txtNombre.Text.Trim().ToLower(),
                                                            Convert.ToDecimal(txtPrecio.Text.Trim()), txtDescripcion.Text.Trim(), txtUbicacion.Text, dateTFecha.Value, txtImagen.Text);
                            if (respuesta)
                            {
                                if (txtImagen.Text != string.Empty)
                                {
                                    this.rutaDestino = this.Directorio + txtImagen.Text;
                                    File.Copy(rutaOrigen, rutaDestino);
                                }
                                this.MensajeOk("El producto fue registrado correctamente");
                                this.Listar();
                            }
                            else
                            {
                                this.MensajeError("El producto no se pudo registrar");
                            }
                        }
                        else
                        {
                            MensajeError("El nombre de la imagen de producto ya existe");
                        }
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
                txtPrecio.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["precioVenta"].Value);
                txtDescripcion.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["descripcion"].Value);
                txtCodigoBarra.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["codigoBarra"].Value);
                dateTFecha.Value = Convert.ToDateTime(dgvListadoProd.CurrentRow.Cells["fechaVencimiento"].Value);
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
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (cmbCategoria.Text == string.Empty && txtNombre.Text == string.Empty && txtPrecio.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos");
                    errorProvider1.SetError(cmbCategoria, "Seleccionar una categoria");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                }
                else
                {
                    if (UserRegex())
                    {
                        string nombreImagen = txtImagen.Text;
                        string nombreImagenGuardar = "";
                        bool flag = false;
                        DirectoryInfo di = new DirectoryInfo(Directorio2);
                        foreach (var fi in di.GetFiles())
                        {
                            nombreImagenGuardar = fi.Name;
                            if (nombreImagenGuardar.Equals(nombreImagen))
                            {
                                flag = true;
                            }
                        }
                        if (flag)
                        {
                            respuesta = bllProducto.Modificar(Convert.ToInt32(txtCodigo.Text.Trim()), this.nombreAnterior.ToLower(), Convert.ToInt32(cmbCategoria.SelectedValue), txtCodigoBarra.Text.Trim(), Convert.ToDecimal(txtPrecio.Text.Trim()),
                                                            txtNombre.Text.Trim().ToLower(), txtDescripcion.Text.Trim(), txtUbicacion.Text, txtImagen.Text, dateTFecha.Value);
                            if (respuesta)
                            {
                                this.MensajeOk("El producto se actualizo correctamente");
                                this.Listar();
                                txtCodigo.Visible = false;
                                tabControl1.SelectedIndex = 0;
                            }
                            else
                            {
                                this.MensajeError("El producto no se pudo actualizar");
                            }
                        }
                        else
                        {
                            respuesta = bllProducto.Modificar(Convert.ToInt32(txtCodigo.Text.Trim()), this.nombreAnterior.ToLower(), Convert.ToInt32(cmbCategoria.SelectedValue), txtCodigoBarra.Text.Trim(), Convert.ToDecimal(txtPrecio.Text.Trim()),
                                                    txtNombre.Text.Trim().ToLower(), txtDescripcion.Text.Trim(), txtUbicacion.Text, txtImagen.Text, dateTFecha.Value);
                            if (respuesta)
                            {
                                if (txtImagen.Text != string.Empty && this.rutaOrigen != string.Empty)
                                {
                                    this.rutaDestino = this.Directorio + txtImagen.Text;
                                    File.Copy(this.rutaOrigen, rutaDestino);
                                }
                                this.MensajeOk("El producto se actualizo correctamente");
                                this.Listar();
                                txtCodigo.Visible = false;
                                tabControl1.SelectedIndex = 0;
                            }
                            else
                            {
                                this.MensajeError("El producto no se pudo actualizar");
                            }
                        }
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
                int codigoProd = 0;
                foreach (DataGridViewRow row in dgvListadoProd.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigoProd = Convert.ToInt32(row.Cells[11].Value);
                    }
                }
                if (codigoProd>0)
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
                                codigo = Convert.ToInt32(row.Cells[11].Value);
                                imagen = Convert.ToString(row.Cells[9].Value);
                                flag = bllProducto.Eliminar(codigo);
                            }
                        }

                        //entra en el while hasta que se libere el processor System.IO en caso que la imagen se haya actualizado o se recién guardado.
                        //while (!estaListoParaUsar(this.Directorio + imagen)) { }
                        if (flag)
                        {
                            File.Delete(this.Directorio + imagen);
                            this.MensajeOk("El producto fue eliminado correctamente");
                            this.Limpiar();
                            this.Listar();
                        }
                        else
                        {
                            this.MensajeError("Algo salío mal, la categoría no se pudo eliminar");
                        }
                    }
                }
                else
                {
                    this.MensajeError("Debe seleccionar un producto.");
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
                            codigo = Convert.ToInt32(row.Cells[11].Value);
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
                            codigo = Convert.ToInt32(row.Cells[11].Value);
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
