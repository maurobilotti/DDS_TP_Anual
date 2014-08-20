using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_E4
{
    public class Calificacion
    {
        public Interesado JugadorCritico { get; set; }
        public Interesado JugadorCriticado { get; set; }
        public string Critica { get; set; }
        public int Puntaje { get; set; }

        public Calificacion(Interesado jugadorCritico, Interesado jugadorCriticado, string critica, int puntaje)
        {
            this.JugadorCritico = jugadorCritico;
            this.JugadorCriticado = jugadorCriticado;
            this.Critica = critica;
            this.Puntaje = puntaje;
            jugadorCriticado.ListaCalificaciones.Add(puntaje);
        }
    }
}
