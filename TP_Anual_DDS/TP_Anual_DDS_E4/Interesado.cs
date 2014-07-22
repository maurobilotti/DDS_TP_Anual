using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Interesado 
    {
        public enum EnumPrioridad
        {
            Condicional, Solidario, Estandar
        }

        public Guid IdInteresado { get; set; }
        public TipoJugador Tipo { get; set; }

        public int Edad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public List<Interesado> listaAmigos { get; set; }
        public int Posicion { get; set; }
        public ICriterio Criterio { get; set; }
        public List<int> ListaCalificaciones { get; set; }
        public int Handicap { get; set; }
        public int CantPartidosJugados { get; set; }

        /// <summary>
        /// Constructor para jugadores amigos... ya que el admin determina el tipo después
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="edad"></param>
        /// <param name="mail"></param>
        public Interesado(string nombre, string apellido, int edad, string mail, int posicion,int handicap,int cantPartidosJugados)
        {
            this.IdInteresado = Guid.NewGuid();
            this.listaAmigos = new List<Interesado>();         
            this.ListaCalificaciones = new List<int>();
            this.Edad = edad;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = mail;
            // el tipo queda en NULL hasta que el administrador lo indique en la sobrecarga
            this.Tipo = null;
            this.Posicion = posicion;
            this.CantPartidosJugados = cantPartidosJugados;
            this.Handicap = handicap;
        }

        public Interesado(string nombre, string apellido, int edad, string mail, int posicion,int handicap,int cantPartidosJugados, TipoJugador tipo)
        {
            this.listaAmigos = new List<Interesado>();
            this.ListaCalificaciones = new List<int>();
            this.Tipo = tipo;
            this.Edad = edad;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = mail;
            this.Posicion = posicion;
            this.CantPartidosJugados = cantPartidosJugados;
            this.Handicap = handicap;
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

        public void AgregarCriterio(ICriterio criterio)
        {
            this.Criterio = criterio;
        }
    }
}
