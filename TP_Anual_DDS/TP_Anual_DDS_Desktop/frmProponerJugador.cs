using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_E4
{
    public partial class frmProponerJugador : Form
    {
        public frmProponerJugador(Partido partido)
        {
            InitializeComponent();
            this.Partido = partido;
        }

        public Partido Partido { get; set; }
        public Usuario JugadorPropuesto { get; set; }
        private List<Usuario> listaNoPropuestos = new List<Usuario>();

        private void frmProponerJugador_Load(object sender, EventArgs e)
        {
            this.listaNoPropuestos = new List<Usuario>();
            this.listaNoPropuestos = Administrador.ObtenerInstancia().ObtenerJugadoresNoInscriptos(this.Partido);
            cmbJugadorPropuesto.DataSource = (from x in this.listaNoPropuestos select new {x.Interesado.NombreYApellido, x.Interesado.Id_Interesado}).ToList();
            cmbJugadorPropuesto.DisplayMember = "NombreYApellido";
            cmbJugadorPropuesto.ValueMember = "Id_Interesado";
        }

        private void btnProponer_Click(object sender, EventArgs e)
        {
            this.JugadorPropuesto = this.listaNoPropuestos.Single(z => z.Interesado.Id_Interesado == (int)cmbJugadorPropuesto.SelectedValue);
            DialogResult = DialogResult.OK;
        }
    }
}
