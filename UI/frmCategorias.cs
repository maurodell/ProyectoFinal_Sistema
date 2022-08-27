using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Reflection;

namespace UI
{
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
            bllCategoria = new BLLCategoria();
        }
        BLLCategoria bllCategoria;
        private void Listar()
        {
            try
            {
                dgvListadoCat.DataSource = bllCategoria.Listar();
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoCat.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Formato()
        {
            dgvListadoCat.Columns[0].Visible = false;
            dgvListadoCat.Columns[1].Visible = false;
            dgvListadoCat.Columns[2].Width = 150;
            dgvListadoCat.Columns[3].Width = 400;
            dgvListadoCat.Columns[3].HeaderText = "Descripción";
            dgvListadoCat.Columns[4].Width = 130;
        }
        private void frmCategorias_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
