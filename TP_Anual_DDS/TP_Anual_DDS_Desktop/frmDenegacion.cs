using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Anual_DDS_E4
{
    public partial class frmDenegacion : Form
    {
        public frmDenegacion()
        {
            InitializeComponent();
        }

        public string MotivoRechazo { get; set; }

        private void btnRegistrarDenegacion_Click(object sender, EventArgs e)
        {
            this.MotivoRechazo = txtMotivo.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
