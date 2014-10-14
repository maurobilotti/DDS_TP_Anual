using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_E4
{
    public partial class frmCriterios : Form
    {
        public frmCriterios(Partido partido)
        {
            InitializeComponent();
            this.Partido = partido;
        }

        public Partido Partido { get; set; }

        private void frmCriterios_Load(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Tipo", typeof (ArmadorPartido));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Rows.Add(new ArmarPorParidad(this.Partido.ListaJugadores), typeof (ArmarPorParidad).Name);
            tabla.Rows.Add(new ArmarPorOrdenAleatorio(this.Partido.ListaJugadores), typeof(ArmarPorOrdenAleatorio).Name);

            cmbCriterio.DataSource = tabla;
            cmbCriterio.DisplayMember = "Descripcion";
            cmbCriterio.ValueMember = "Tipo";

        }

        private void btnAplicarCriterio_Click(object sender, EventArgs e)
        {
            Partido.ArmadorPartido = (ArmadorPartido)cmbCriterio.SelectedValue;
            DialogResult = DialogResult.OK;
        }
    }
}
