using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E3
{
    public class Estandar : TipoJugador
    {
        public Estandar() {
            this.Prioridad =  Interesado.EnumPrioridad.Estandar;
        }
    }
}
