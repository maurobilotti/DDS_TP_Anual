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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAgregarPartido_Click(object sender, EventArgs e)
        {
            frmNuevoPartido frm = new frmNuevoPartido();
            if (frm.ShowDialog() == DialogResult.OK)
            { 
                
            }
        }
    }
}
