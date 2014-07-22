using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Anual_DDS_Desktop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EsAdmin = true;
            if (new frmPrincipal().ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                this.Close();
            }
        }

        private void btnInteresado_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EsAdmin = false;
            if (new frmPrincipal().ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                this.Close();
            }
        }
    }
}
