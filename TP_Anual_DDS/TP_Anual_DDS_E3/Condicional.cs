using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Condicional : TipoJugador
    {
        public List<ICondiciones> Condiciones { get; set; }

        public ICondiciones ICondiciones
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Condicional()
        {
            this.Condiciones = new List<ICondiciones>();
            this.Prioridad =  Interesado.EnumPrioridad.Condicional;
        }

        public override void AgregarCondicion(ICondiciones condicion)
        {
            Condiciones.Add(condicion);
        }

        public override bool PuedoJugarEn(Partido partido)
        {
            return Condiciones.All(z => z.EvaluarCondicion(partido));//Si cumple todas las condiciones, puede jugar.
        }

    }
}
