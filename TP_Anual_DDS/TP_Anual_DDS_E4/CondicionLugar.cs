using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_E3
{
    public class CondicionLugar : ICondiciones
    {
        private string lugar;

        public CondicionLugar()
        {
            EstablecerCondicion();
        }

        public void EstablecerCondicion()
        {
            lugar = "Caballito";
        }

        public bool EvaluarCondicion(Partido partido)
        {
            return partido.Lugar == lugar;
        }
    }
}
