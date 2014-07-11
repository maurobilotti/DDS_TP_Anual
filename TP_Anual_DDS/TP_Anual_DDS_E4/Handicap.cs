using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Handicap : ICriterio
    {
        private int NivelJuego;

        public Handicap(int nivelJuego) 
        {
            this.NivelJuego = nivelJuego;    
        }

        public double AplicarCriterio()
        {
            return (double)this.NivelJuego;
        }
    }
}
