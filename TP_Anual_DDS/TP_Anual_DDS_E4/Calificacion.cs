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
        private string descripcion { get; set; }
        private int calificacion { get; set; }

        public Calificacion(Interesado jugadorCritico, Interesado jugadorCriticado, string descripcion, int calificacion)
        {
            this.JugadorCritico = jugadorCritico;
            this.JugadorCriticado = jugadorCriticado;
            this.descripcion = descripcion;
            this.calificacion = calificacion;
            jugadorCriticado.ListaCalificaciones.Add(calificacion);
        }
    }
}
