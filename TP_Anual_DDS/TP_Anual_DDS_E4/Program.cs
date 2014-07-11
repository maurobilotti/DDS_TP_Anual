using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            #region Creacion de un partido
            admin.CrearPartido("Caballito", DateTime.Now);
            #endregion

            #region Crear jugadores principales
            admin.CrearJugador("Mauro", "Bilotti", 25, "mail1@dds.com.ar", 1, 8, 1, new Estandar());
            admin.CrearJugador("Augusto", "Bonabia", 22, "mail2@dds.com.ar", 3, 6, 1, new Estandar());
            //admin.CrearJugador("Federico", "Belvedere", 22, "mail3@dds.com.ar", 10, 1, 10, new Estandar());
            //admin.CrearJugador("Pablo", "Furst", 21, "mail5@dds.com.ar", 8, 4, 2, new Estandar());
            //Interesado jugadorPrincipal3 = new Interesado();
            //Interesado jugadorPrincipal4 = new Interesado("Ezequiel", "Barany", 22, "mail4@dds.com.ar", new Estandar());

            ////se agrega un condicional con dos condiciones
            //Interesado jugadorPrincipal6 = new Interesado("Enrique", "Gomez", 22, "mail6@dds.com.ar", new Condicional());
            //jugadorPrincipal6.Tipo.AgregarCondicion(new CondicionCantidadMayoresDe20());
            //jugadorPrincipal6.Tipo.AgregarCondicion(new CondicionLugar());

            #endregion

            

            #region Se proponen los jugadores por cada jugador principal
            admin.AgregarSugeridos();
            #endregion

            #region Criticas post-partido
            admin.AgregarCalificaciones();
            #endregion


            #region Criterio de ordenamiento
            admin.CrearCriterio();
            #endregion

            admin.ArmarEquipos();

            Console.ReadLine();
        }
    }
}
