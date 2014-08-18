using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_Desktop
{
    public partial class frmProponerJugador : Form
    {
        public frmProponerJugador(Partido partido)
        {
            InitializeComponent();
            this.Partido = partido;
        }

        public Partido Partido { get; set; }
        public Interesado JugadorPropuesto { get; set; }

        private void frmProponerJugador_Load(object sender, EventArgs e)
        {
            cmbJugadorPropuesto.DataSource = Administrador.ObtenerInstancia().ObtenerJugadoresNoInscriptos(this.Partido);
            cmbJugadorPropuesto.DisplayMember = "NombreYApellido";
        }

        private void btnProponer_Click(object sender, EventArgs e)
        {
            this.JugadorPropuesto = (Interesado)cmbJugadorPropuesto.SelectedValue;
            DialogResult = DialogResult.OK;
        }
    }
}
