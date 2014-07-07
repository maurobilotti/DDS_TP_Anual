using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creacion de un partido
            Partido partido = new Partido("Caballito", DateTime.Now); 
            #endregion            

            #region Crear jugadores principales
            Interesado jugadorPrincipal1 = new Interesado("Mauro", "Bilotti", 25, "mail1@dds.com.ar", new Estandar());
            Interesado jugadorPrincipal2 = new Interesado("Augusto", "Bonabia", 22, "mail2@dds.com.ar", new Estandar());
            //Interesado jugadorPrincipal3 = new Interesado("Federico", "Belvedere", 22, "mail3@dds.com.ar", new Estandar());
            //Interesado jugadorPrincipal4 = new Interesado("Ezequiel", "Barany", 22, "mail4@dds.com.ar", new Estandar());
            //Interesado jugadorPrincipal5 = new Interesado("Pablo", "Furst", 21, "mail5@dds.com.ar", new Estandar());
            ////se agrega un condicional con dos condiciones
            //Interesado jugadorPrincipal6 = new Interesado("Enrique", "Gomez", 22, "mail6@dds.com.ar", new Condicional());
            //jugadorPrincipal6.Tipo.AgregarCondicion(new CondicionCantidadMayoresDe20());
            //jugadorPrincipal6.Tipo.AgregarCondicion(new CondicionLugar());           

            #endregion

            #region Agregar jugadores principales
            //se agregan los pricipales al partido, que son los que juega siempre y sugieren amigos
            partido.AgregarInteresado(jugadorPrincipal1);
            partido.AgregarInteresado(jugadorPrincipal2);
            //partido.AgregarInteresado(jugadorPrincipal3);
            //partido.AgregarInteresado(jugadorPrincipal4);
            //partido.AgregarInteresado(jugadorPrincipal5);
            //partido.AgregarInteresado(jugadorPrincipal6);
            #endregion

            #region Se proponen los jugadores por cada jugador principal

            partido.AgregarSugeridos();
            #endregion            

            #region Criticas post-partido
            Console.WriteLine("Presione una tecla para finalizar el partido e ingresar las criticas a cada jugador");
            Console.ReadKey();

            partido.AgregarCalificaciones();
            #endregion

            #region se da de baja un jugador
            Interesado jugadorPrincipal15 = new Interesado("Paula", "Furst", 21, "mail15@dds.com.ar", new Estandar());
            partido.DarBaja(jugadorPrincipal1, jugadorPrincipal15);
            partido.DarBaja(jugadorPrincipal15); 
            #endregion

            Console.ReadLine();
        }
    }
}
