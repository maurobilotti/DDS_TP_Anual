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
    public partial class frmPrincipal : Form
    {
        #region Propiedades
        public bool EsAdmin { get; set; }
        public List<Partido> ListaPartidos { get; set; } 
        #endregion

        public frmPrincipal()
        {
            InitializeComponent();
            this.ListaPartidos = new List<Partido>();
            HabilitarControles();
            Actualizar();
        }

        private void btnAgregarPartido_Click(object sender, EventArgs e)
        {
            var frm = new frmNuevoPartido();
            if (frm.ShowDialog() == DialogResult.OK)
            { 
                this.ListaPartidos.Add(frm.ObtenerPartido());  
                Actualizar();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.EsAdmin = Properties.Settings.Default.EsAdmin;

            HabilitarControles();

        }

        private void HabilitarControles()
        {
            btnNuevoPartido.Enabled = btnCriterios.Enabled = btnConfirmar.Enabled = EsAdmin;
            btnInscribirse.Enabled = !EsAdmin;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Actualizar()
        {
            gridPartidos.DataSource = null;
            try
            {
                //gridPartidos.DataSource = (from x in new Model2Container().DbPartidoSet select x).ToList();
            }
            catch (Exception)
            {
                
            }

            //gridInteresados.DataSource = null;
            //77gridInteresados.DataSource = Lista;
        }

        private void gridPartidos_Click(object sender, EventArgs e)
        {
            var idSeleccionado = new Guid(gridPartidos.SelectedCells[0].Value.ToString());
            Partido partido = ListaPartidos.Single(z => z.IdPartido == idSeleccionado);
            gridInteresados.DataSource = partido.ListaJugadores;
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (gridPartidos.SelectedRows.Count == 1)
            {
                var idSeleccionado = new Guid(gridPartidos.SelectedCells[0].Value.ToString());
                Partido partido = ListaPartidos.Single(z => z.IdPartido == idSeleccionado);

                var frmJugador =new frmNuevoJugador();
                if (frmJugador.ShowDialog() == DialogResult.OK)
                {
                    partido.ListaJugadores.Add(frmJugador.ObtenerJugador());
                }
            }
        }
    }
}
