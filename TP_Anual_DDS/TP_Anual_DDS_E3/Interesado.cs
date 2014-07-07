using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E2
{
    public class Interesado 
    {
        public enum EnumPrioridad
        {
            Condicional, Solidario, Estandar
        }

        public TipoJugador Tipo { get; set; }

        public int Edad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public List<Interesado> listaAmigos { get; set; }

        public TipoJugador TipoJugador
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public IMail IMail
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Interesado Amigos
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Interesado(string nombre, string apellido, int edad, string mail, TipoJugador tipo)
        {
            this.listaAmigos = new List<Interesado>();
            this.Tipo = tipo;
            this.Edad = edad;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = mail;
        }

        public void EstasIncriptoEn(Partido partido)
        {
            Mail mail = new Mail();
            mail.From = this.Mail;
            mail.Cuerpo = "Cuerpo del mensaje.";
            
            foreach(Interesado amigo in listaAmigos)
            {
                mail.To += amigo.Mail + "; "; 
            }

            if (mail.To != null)
            {
                if (mail.EnviarMail())
                {
                    Console.WriteLine("El interesado: " + this.Nombre + "Le envió mail a: " + mail.To);
                }
            }
            else 
            {
                Console.WriteLine("Ninguno de los amigos de " + this.Nombre + "tiene un mail configurado.");
            }
        }       
    }
}
