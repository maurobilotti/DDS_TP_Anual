using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class ArmarPorOrdenAleatorio : ArmadorPartido
    {
        public ArmarPorOrdenAleatorio(List<Interesado> listaJugadores) : base(listaJugadores) { }

        public override List<Interesado> ArmarPrimerEquipo()
        {
            List<Interesado> listaPrimerEquipo = new List<Interesado>();
            foreach (var jugador in this.ListaJugadores)
            {
                //si las posiciones son 1, 4, 5, 8 o 9, va a la lista del primer equipo
                switch (jugador.Posicion)
                {
                    case 1:
                    case 4:
                    case 5:
                    case 8:
                    case 9:
                        listaPrimerEquipo.Add(jugador);
                        break;
                }
            }
            return listaPrimerEquipo;
        }

        public override List<Interesado> ArmarSegundoEquipo()
        {
            List<Interesado> listaSegundoEquipo = new List<Interesado>();

            foreach (var jugador in this.ListaJugadores)
            {
                //si las posiciones son 1, 4, 5, 8 o 9, va a la lista del primer equipo
                switch (jugador.Posicion)
                {
                    case 2:
                    case 3:
                    case 5:
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
