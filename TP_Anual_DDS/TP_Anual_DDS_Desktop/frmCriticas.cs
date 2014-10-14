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

namespace TP_Anual_DDS_E4
{
    public partial class frmCriticas : Form
    {
        #region Constructores
        public frmCriticas(List<Partido> partidos, Interesado jugadorCritico)
        {
            InitializeComponent();
            this.ListaPartidos = partidos;
            this.JugadorCritico = jugadorCritico;
            this.ModoApertura = Modo.Realizar;
        }

        public frmCriticas(List<Partido> partidos)
        {
            InitializeComponent();
            this.ListaPartidos = partidos;
            this.ModoApertura = Modo.Ver;
        }
        #endregion

        public enum Modo
        {
            Ver, Realizar
        }

        private Modo ModoApertura { get; set; }
        public Interesado JugadorCritico { get; set; }
        public List<Partido> ListaPartidos { get; set; }

        private void frmCriticas_Load(object sender, EventArgs e)
        {
            foreach (Partido partido in ListaPartidos)
            {
                if (ModoApertura == Modo.Realizar)
                {
                    foreach (Usuario usuarioCriticado in partido.ListaJugadores)
                    {
                        if (usuarioCriticado.Interesado == JugadorCritico ||
                            partido.ListaCalificaciones.Exists(z => z.JugadorCriticado == usuarioCriticado.Interesado && z.JugadorCritico == JugadorCritico))
                            continue;

                        container.Controls.Add(new Critica(this.JugadorCritico, usuarioCriticado.Interesado, partido, this.ModoApertura));
                    }
                }
                if (ModoApertura == Modo.Ver)
                {
                    partido.ListaCalificaciones.ForEach(x => container.Controls.Add(new Critica(x.JugadorCritico, x.JugadorCriticado, partido, ModoApertura, x.Puntaje, x.Critica)));
                }
            }

        }
    }
}
