using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Solidario : TipoJugador
    {
        public Solidario()
        {
            this.Prioridad =  Interesado.EnumPrioridad.Solidario;
        }
    }
}
