using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class ArmadorEstandar : ArmadorPartido
    {
        public ArmadorEstandar(List<Usuario> listaJugadores) : base(listaJugadores) { }

        public override List<Usuario> ArmarPrimerEquipo()
        {
            List<Usuario> listaPrimerEquipo = new List<Usuario>();
            for (int i = 0; i < 5; i++)
            {
                listaPrimerEquipo.Add(ListaJugadores[i]);
            }
            return listaPrimerEquipo;
        }

        public override List<Usuario> ArmarSegundoEquipo()
        {
            List<Usuario> listaSegundoEquipo = new List<Usuario>();
            for (int i = 5; i < ListaJugadores.Count; i++)
            {
                listaSegundoEquipo.Add(ListaJugadores[i]);
            }

            return listaSegundoEquipo;
        }
    }
}
