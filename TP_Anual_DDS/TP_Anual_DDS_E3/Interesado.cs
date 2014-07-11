using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E3
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

     
        /// <summary>
        /// Constructor para jugadores amigos... ya que el admin determina el tipo después
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="edad"></param>
        /// <param name="mail"></param>
        public Interesado(string nombre, string apellido, int edad, string mail)
        {
            this.listaAmigos = new List<Interesado>();            
            this.Edad = edad;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = mail;
            // el tipo queda en NULL hasta que el administrador lo confirme
            this.Tipo = null;
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

            if (listaAmigos.Count > 0)
            {
                foreach (Interesado amigo in listaAmigos)
                {
                    mail.To += amigo.Mail + "; ";
                }

                if (mail.To != null)
                {
                    if (mail.EnviarMail())
                    {
                        Console.WriteLine("El interesado: " + this.Nombre + " le envió mail a: " + mail.To);
                    }
                }
                else
                {
                    Console.WriteLine("Ninguno de los amigos de " + this.Nombre + " tiene un mail configurado.");
                } 
            }
        }

        public void AgregarAmigo(Interesado amigo)
        {
            this.listaAmigos.Add(amigo);
        }
    }
}
