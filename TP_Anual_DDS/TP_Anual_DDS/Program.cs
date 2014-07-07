using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS
{
    class Program
    {
        static void Main(string[] args)
        {
            Partido partido1 = new Partido("Caballito",DateTime.Now);

            Interesado jugador1 = new Estandar("Mauro","Bilotti",25);
            Interesado jugador2 = new Estandar("Augusto","Bonabia",22);
            Interesado jugador3 = new Estandar("Federico", "Belvedere",22);
            Interesado jugador4 = new Estandar("Ezequiel", "Barany", 22);
            Interesado jugador5 = new Estandar("Pablo", "Furst", 21);
            //se agrega un condicional con dos condiciones
            Condicional jugador6 = new Condicional("Enrique", "Gomez", 22);
            jugador6.AgregarCondicion(new CondicionCantidadMayoresDe20());
            jugador6.AgregarCondicion(new CondicionLugar());
            
            Interesado jugador7 = new Solidario("Carlos", "Solidario", 22);
            Interesado jugador8 = new Estandar("Pepe", "Perez", 22);
            Interesado jugador9 = new Estandar("Roberto", "Casas", 22);
            Interesado jugador10 = new Solidario("Martin", "Juarez", 22);

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
            Interesado jugador14 = new Condicional("Un", "Condicional", 18);
            Interesado jugador11 = new Estandar("Lito", "Estandar", 22);
            Interesado jugador12 = new Estandar("Otro", "Estandar",21);
            Interesado jugador13 = new Condicional("Bruno","Condicional",19);

            partido1.AgregarInteresado(jugador14);
            partido1.AgregarInteresado(jugador11);
            partido1.AgregarInteresado(jugador12);
            partido1.AgregarInteresado(jugador13);
            

            Console.ReadLine();
        }
    }
}
