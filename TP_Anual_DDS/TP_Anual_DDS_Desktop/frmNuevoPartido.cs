using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Anual_DDS_E4;
using System.Data.SqlServerCe;


namespace TP_Anual_DDS_E4
{
    public partial class frmNuevoPartido : Form
    {
        public frmNuevoPartido()
        {
            InitializeComponent();
        }

        public Partido Partido { get; set; }
        //private DbPartido DbPartido { get; set; }

        private void btnGuardarPartido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLugar.Text))
                return;

            this.Partido = new Partido(txtLugar.Text, dateFecha.Value, false, false);
            this.Partido.Guardar();
            DialogResult = DialogResult.OK;
        }


        public Partido ObtenerPartido()
        {
            return this.Partido;
        }


    }
}
