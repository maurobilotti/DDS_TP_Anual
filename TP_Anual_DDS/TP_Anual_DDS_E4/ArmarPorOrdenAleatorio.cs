using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class ArmarPorOrdenAleatorio : ArmadorPartido
    {
        public ArmarPorOrdenAleatorio(List<Usuario> listaJugadores) : base(listaJugadores) { }

        public override List<Usuario> ArmarPrimerEquipo()
        {
            List<Usuario> listaPrimerEquipo = new List<Usuario>();
            foreach (var jugador in this.ListaJugadores)
            {
                //si las posiciones son 1, 4, 5, 8 o 9, va a la lista del primer equipo
                switch (jugador.Interesado.Posicion)
                {
                    case 1:
                    case 4:
                    case 5:
                    case 8:
                    case 9:
                    case 11:
                        listaPrimerEquipo.Add(jugador);
                        break;
                }
            }
            return listaPrimerEquipo;
        }

        public override List<Usuario> ArmarSegundoEquipo()
        {
            List<Usuario> listaSegundoEquipo = new List<Usuario>();

            foreach (var jugador in this.ListaJugadores)
            {
                //si las posiciones son 1, 4, 5, 8 o 9, va a la lista del primer equipo
                switch (jugador.Interesado.Posicion)
                {
                    case 2:
                    case 3:
                    case 6:
                    case 7:
                    case 10:
                        listaSegundoEquipo.Add(jugador);
                        break;
                }
            }

            return listaSegundoEquipo;
        }
    }
}
