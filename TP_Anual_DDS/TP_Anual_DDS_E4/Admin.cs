using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Admin
    {
        private Partido partido { get; set; }

        public Admin()
        {

        }

        public void CrearPartido(string lugar, DateTime fechaHora)
        {
            this.partido = new Partido(lugar, fechaHora);
        }

        public void CrearJugador(string nombre, string apellido, int edad, string mail, int posicion, int handicap, int cantPartidosJugados)
        {
            Interesado jugador = new Interesado(nombre, apellido, edad, mail, posicion, handicap, cantPartidosJugados);
            partido.AgregarInteresado(jugador);
        }

        public void CrearJugador(string nombre, string apellido, int edad, string mail, int posicion, int handicap, int cantPartidosJugados, TipoJugador tipo)
        {
            Interesado jugador = new Interesado(nombre, apellido, edad, mail, posicion, handicap, cantPartidosJugados, tipo);
            partido.AgregarInteresado(jugador);
        }

        public void AgregarSugeridos()
        {
            Console.WriteLine("Presione una tecla para comenzar con las sugerencias de jugadores.");
            Console.ReadKey();
            this.partido.AgregarSugeridos();
        }

        public void AgregarCalificaciones()
        {
            Console.WriteLine("Presione una tecla para finalizar el partido e ingresar las criticas a cada jugador");
            Console.ReadKey();
            this.partido.AgregarCalificaciones();
        }

        public void CrearCriterio()
        {
            bool esValido = false;
            while (!esValido)
            {
                Console.WriteLine("Ingrese con que criterio desea ordenar la lista de jugadores: (H: Handicap, P: Promedio últimos partidos, " +
                              " N: Promedio últimos N partidos, M: Mix)");
                char opcion = (char)Console.Read();//lo paso a Mayús                
                esValido = (opcion == 'H' || opcion == 'P' || opcion == 'N' || opcion == 'M');
                if (esValido)
                    partido.AgregarCriterio(opcion);
            }
        }

        public void ArmarEquipos()
        {
            Console.WriteLine("Presione una tecla para finalizar el partido e ingresar las criticas a cada jugador");
            Console.ReadKey();
            bool esValido = false;
            char opcion = 'P';
            while (!esValido)
            {
                Console.WriteLine("Indique como desea armar los equipos. (P: Paridad , A: Orden semi-aleatorio)");
                Console.ReadLine();
                string opcionAux = Console.ReadLine();
                opcion = opcionAux[0];

                //lo paso a Mayús
                opcion = (char)opcion.ToString().ToUpper()[0];
                esValido = (opcion == 'P' || opcion == 'A');
            }

            if (opcion == 'P')
                partido.ArmadorPartido = new ArmarPorParidad(partido.ListaJugadores);
            else
                partido.ArmadorPartido = new ArmarPorOrdenAleatorio(partido.ListaJugadores);
            partido.ArmarEquipos();

        }
    }
}
