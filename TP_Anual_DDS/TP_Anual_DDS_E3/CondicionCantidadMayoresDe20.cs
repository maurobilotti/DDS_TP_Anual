using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class CondicionCantidadMayoresDe20 : ICondiciones
    {
        private int cantidadDeJugadores;

        public CondicionCantidadMayoresDe20()
        {
            EstablecerCondicion();
        }

        public void EstablecerCondicion()
        {
            cantidadDeJugadores = 1;
        }

        public bool EvaluarCondicion(Partido partido)
        {
            return partido.listaJugadores.Count(z => z.Edad > 20) > cantidadDeJugadores;
        }
    }
}
