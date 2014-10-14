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

namespace TP_Anual_DDS_E4
{
    public partial class Critica : UserControl
    {
        public Critica(Interesado jugadorCritico,Interesado jugadorCriticado, Partido partido, frmCriticas.Modo modo, int puntaje = 5 ,string critica = "")
        {
            InitializeComponent();
            JugadorCriticado = jugadorCriticado;
            Partido = partido;
            JugadorCritico = jugadorCritico;
            _modoApertura = modo;
            txtCritica.Text = critica;
            numPuntaje.Value = puntaje;
        }

        private readonly frmCriticas.Modo _modoApertura;
        public Interesado JugadorCriticado { get; set; }
        public Partido Partido { get; set; }
        public Interesado JugadorCritico { get; set; }

        private void Critica_Load(object sender, EventArgs e)
        {
            BackColor = _modoApertura == frmCriticas.Modo.Realizar ? Color.Tomato : Color.LimeGreen;
            //si se pide realizar la critica habilito los controles
            numPuntaje.Enabled = txtCritica.Enabled = btnOK.Visible = _modoApertura == frmCriticas.Modo.Realizar;

            lblLugarPartido.Text = Partido.Lugar;
            lblCriticado.Text = JugadorCriticado.NombreYApellido;
            lblCritico.Text = JugadorCritico.NombreYApellido;
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
