using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public abstract class ArmadorPartido
    {
        public List<Interesado> ListaJugadores { get; set; }

        protected ArmadorPartido(List<Interesado> listaJugadores)
        {
            this.ListaJugadores = new List<Interesado>();
            this.ListaJugadores = listaJugadores;
        }

        public abstract List<Interesado> ArmarPrimerEquipo();
        public abstract List<Interesado> ArmarSegundoEquipo();
    }
}
