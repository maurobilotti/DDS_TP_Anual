using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Calificacion
    {
        private Interesado jugadorCritico { get; set; }
        private Interesado jugadorCriticado { get; set; }
        private string descripcion { get; set; }
        private int calificacion { get; set; }

        public Calificacion(Interesado jugadorCritico, Interesado jugadorCriticado, string descripcion, int calificacion)
        {
            this.jugadorCritico = jugadorCritico;
            this.jugadorCriticado = jugadorCriticado;
            this.descripcion = descripcion;
            this.calificacion = calificacion;
        }
    }
}
