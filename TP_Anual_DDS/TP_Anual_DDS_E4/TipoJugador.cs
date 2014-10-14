using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public abstract class TipoJugador
    {
        public Interesado.EnumPrioridad Prioridad { get; set; }

        public virtual bool PuedoJugarEn(Partido partido) 
        {
            return true;
        }
        public virtual void AgregarCondicion(ICondiciones condicion){}
    }
}
