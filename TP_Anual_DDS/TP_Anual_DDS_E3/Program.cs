using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E2
{
    class Program
    {
        static void Main(string[] args)
        {
            Partido partido1 = new Partido("Caballito", DateTime.Now);

            Interesado jugador1 = new Interesado("Mauro", "Bilotti", 25,"mail1@asd.com.ar", new Estandar());
            Interesado jugador2 = new Interesado("Augusto", "Bonabia", 22, "mail2@asd.com.ar", new Estandar());
            Interesado jugador3 = new Interesado("Federico", "Belvedere", 22, "mail3@asd.com.ar", new Estandar());
            Interesado jugador4 = new Interesado("Ezequiel", "Barany", 22, "mail4@asd.com.ar", new Estandar());
            Interesado jugador5 = new Interesado("Pablo", "Furst", 21, "mail5@asd.com.ar", new Estandar());
            
            //se agrega un condicional con dos condiciones
            Interesado jugador6 = new Interesado("Enrique", "Gomez", 22, "mail6@asd.com.ar", new Condicional());
            jugador6.Tipo.AgregarCondicion(new CondicionCantidadMayoresDe20());
            jugador6.Tipo.AgregarCondicion(new CondicionLugar());

            Interesado jugador7 = new Interesado("Carlos", "Solidario", 22, "mail7@asd.com.ar", new Solidario());
            Interesado jugador8 = new Interesado("Pepe", "Perez", 22, "mail8@asd.com.ar", new Estandar());
            Interesado jugador9 = new Interesado("Roberto", "Casas", 22, "mail9@asd.com.ar", new Estandar());
            Interesado jugador10 = new Interesado("Martin", "Juarez", 22, "mail10@asd.com.ar", new Solidario());

            jugador1.listaAmigos.Add(jugador10);
            jugador1.listaAmigos.Add(jugador2);
            jugador1.listaAmigos.Add(jugador3);

            partido1.AgregarInteresado(jugador1);
            partido1.AgregarInteresado(jugador2);
            partido1.AgregarInteresado(jugador3);
            partido1.AgregarInteresado(jugador4);
            partido1.AgregarInteresado(jugador5);
            partido1.AgregarInteresado(jugador6);
            partido1.AgregarInteresado(jugador7);
            partido1.AgregarInteresado(jugador8);
            partido1.AgregarInteresado(jugador9);
            partido1.AgregarInteresado(jugador10);

            //acá comienzan las pruebas
            Interesado jugador14 = new Interesado("Un", "Condicional", 18, "mail14@asd.com.ar", new Condicional());
            Interesado jugador11 = new Interesado("Lito", "Estandar", 22, "mail11@asd.com.ar", new Estandar());
            Interesado jugador12 = new Interesado("Otro", "Estandar", 21, "mail12@asd.com.ar", new Estandar());
            Interesado jugador13 = new Interesado("Bruno", "Condicional", 19, "mail13@asd.com.ar", new Condicional());

            partido1.AgregarInteresado(jugador14);
            partido1.AgregarInteresado(jugador11);
            partido1.AgregarInteresado(jugador12);
            partido1.AgregarInteresado(jugador13);


            Interesado jugador15 = new Interesado("Paula", "Furst", 21, "mail15@asd.com.ar", new Estandar());
            partido1.DarBaja(jugador1,jugador15);
            partido1.DarBaja(jugador15);
            Console.ReadLine();
        }
    }
}
