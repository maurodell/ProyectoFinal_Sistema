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

namespace UI
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
            bllBack = new BLLBackUp();
        }
        BLLBackUp bllBack;
        public void CargarDgv()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = bllBack.Listar();
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //crear carpeta  
            CargarDgv();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            CargarDgv();
        }
    }
}
