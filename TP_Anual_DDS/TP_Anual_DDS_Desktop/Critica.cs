using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_Desktop
{
    public partial class Critica : UserControl
    {
        public Critica(Interesado jugadorCritico,Interesado jugadorCriticado, Partido partido)
        {
            InitializeComponent();
            JugadorCriticado = jugadorCriticado;
            Partido = partido;
            JugadorCritico = jugadorCritico;
        }

        public Interesado JugadorCriticado { get; set; }
        public Partido Partido { get; set; }
        public Interesado JugadorCritico { get; set; }

        private void Critica_Load(object sender, EventArgs e)
        {
            BackColor = Color.Tomato;
            lblLugarPartido.Text = Partido.Lugar;
            lblNombre.Text = JugadorCriticado.NombreYApellido;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            BackColor = Color.LawnGreen;
            btnOK.Enabled = false;
            Partido.AgregarCalificacion(JugadorCritico,JugadorCriticado,(int)numPuntaje.Value,txtCritica.Text);
            if(Partido.ListaCalificaciones.Count(z => z.JugadorCritico == JugadorCritico) == Partido.ListaJugadores.Count - 1)
                this.JugadorCritico.ListaPartidosCriticados.Add(Partido);
        }

    }
}
