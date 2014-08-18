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
    public partial class frmCriticas : Form
    {
        public frmCriticas(List<Partido> partidos, Interesado jugadorCritico)
        {
            InitializeComponent();
            this.ListaPartidos = partidos;
            this.JugadorCritico = jugadorCritico;
        }

        public Interesado JugadorCritico { get; set; }
        public List<Partido> ListaPartidos { get; set; }


        private void frmCriticas_Load(object sender, EventArgs e)
        {
            foreach (Partido partido in ListaPartidos)
            {
                foreach (Interesado jugadorCriticado in partido.ListaJugadores)
                {
                    if (jugadorCriticado == JugadorCritico ||
                        partido.ListaCalificaciones.Exists(z => z.JugadorCriticado == jugadorCriticado && z.JugadorCritico == JugadorCritico))
                        continue;

                    container.Controls.Add(new Critica(this.JugadorCritico, jugadorCriticado, partido));
                }
            }

        }
    }
}
