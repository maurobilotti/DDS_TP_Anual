using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Solidario : TipoJugador
    {
        public string Descripcion { get { return typeof(Solidario).Name; } }

        public Solidario()
        {
            this.Id_TipoJugador = 2;
            this.Prioridad =  Interesado.EnumPrioridad.Solidario;
        }
    }
}
