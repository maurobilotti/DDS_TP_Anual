using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS
{
    public class Partido
    {
        public DateTime Hora { get; set; }
        public List<Interesado> Jugadores { get; set;}
        public string Lugar { get; set; }

        public Partido(string lugar, DateTime hora)
        {
            
            Jugadores = new List<Interesado>();
            this.Lugar = lugar;
            this.Hora = hora;
            Console.WriteLine("Se pactado un partido en {0} en la fecha {1}.",this.Lugar,this.Hora.ToString("yyyy MMMM dd hh:mm"));
        }

        public void AgregarInteresado(Interesado interesado)
        {
            if (interesado.PuedoJugarEn(this))
            {
                Console.WriteLine("El jugador {0} {1} ha sido añadido a la lista.",interesado.Nombre,interesado.Apellido);
                this.Jugadores.Add(interesado);
            }
        }
    }
}
