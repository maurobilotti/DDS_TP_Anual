using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class ArmarPorParidad : ArmadorPartido 
    {
        public ArmarPorParidad(List<Interesado> listaJugadores) : base(listaJugadores) { }
        
        public override List<Interesado> ArmarPrimerEquipo()
        {
            return this.ListaJugadores.Where(x => x.Posicion % 2 == 1).ToList();    
        }

        public override List<Interesado> ArmarSegundoEquipo()
        {
            return this.ListaJugadores.Where(x => x.Posicion % 2 == 0).ToList(); 
        }
    }
}
