using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public abstract class ArmadorPartido
    {
        public List<Usuario> ListaJugadores { get; set; }

        protected ArmadorPartido(List<Usuario> listaJugadores)
        {
            this.ListaJugadores = new List<Usuario>();
            this.ListaJugadores = listaJugadores;
        }

        public abstract List<Usuario> ArmarPrimerEquipo();
        public abstract List<Usuario> ArmarSegundoEquipo();
    }
}
