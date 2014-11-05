using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Estandar : TipoJugador
    {
        public string Descripcion { get { return typeof(Estandar).Name; } }

        public Estandar()
        {
            this.Id_TipoJugador = 3;
            this.Prioridad = Interesado.EnumPrioridad.Estandar;
        }
    }
}
