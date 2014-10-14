using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TP_Anual_DDS_E4
{
    public class Interesado 
    {
        public enum EnumPrioridad
        {
            Condicional, Solidario, Estandar
        }

        public int Id_Usuario { get; set; }

        public int Id_Interesado
        {
            get
            {
                return (from x in new DDSDataContext().DBInteresados
                                      where x.Nombre == Nombre && x.Apellido == Apellido
                                      select x.Id_Interesado).SingleOrDefault();
            }
        }

        public TipoJugador Tipo { get; set; }
        public int Edad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public List<Interesado> ListaAmigos { get; set; }
        public int Posicion { get; set; }
        public ICriterio Criterio { get; set; }
        public List<int> ListaCalificaciones { get; set; }
        public int Handicap { get; set; }
        public int CantPartidosJugados { get; set; }
        public string NombreYApellido{
            get { return Nombre + " " + Apellido; }
        }

        public List<Partido> ListaPartidosFinalizados { get; set; }
        public List<Partido> ListaPartidosCriticados { get; set; }

        /// <summary>
        /// Constructor para jugadores amigos... ya que el admin determina el tipo después
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="edad"></param>
        /// <param name="mail"></param>
        public Interesado(string nombre, string apellido, int edad, string mail, int posicion, int handicap, int cantPartidosJugados)
        {
            this.ListaAmigos = new List<Interesado>();
            this.ListaCalificaciones = new List<int>();
            this.ListaPartidosCriticados = new List<Partido>();
            this.ListaPartidosFinalizados = new List<Partido>();
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

        public Interesado(string nombre, string apellido, int edad, string mail, int posicion, int handicap, int cantPartidosJugados, string tipo)
        {
            this.ListaAmigos = new List<Interesado>();
            this.ListaPartidosCriticados = new List<Partido>();
            this.ListaPartidosFinalizados = new List<Partido>();
            this.ListaCalificaciones = new List<int>();
            this.Edad = edad;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = mail;
            this.Posicion = posicion;
            this.CantPartidosJugados = cantPartidosJugados;
            this.Handicap = handicap;
            switch (tipo)
            {
                case "Estandar":
                    Tipo = new Estandar();
                    break;
                case "Condicional":
                    Tipo = new Condicional();
                    break;
                case "Solidario":
                    Tipo = new Solidario();
                    break;
                default:
                    break;

            }
        }

        public bool EstasInscriptoEn(Partido partido)
        {
            return partido.ListaJugadores.Any(z => z.Interesado.Nombre == this.Nombre && z.Interesado.Apellido == this.Apellido);
        }

        public void AgregarAmigo(Interesado amigo)
        {
            this.ListaAmigos.Add(amigo);
        }

        public void AgregarCriterio(ICriterio criterio)
        {
            this.Criterio = criterio;
        }

        public static DataTable ObtenerTipoJugadores()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("Descripcion", typeof(string));

            tabla.Rows.Add((int)EnumPrioridad.Condicional, EnumPrioridad.Condicional);
            tabla.Rows.Add((int)EnumPrioridad.Estandar, EnumPrioridad.Estandar);
            tabla.Rows.Add((int)EnumPrioridad.Solidario, EnumPrioridad.Solidario);

            return tabla;
        }

        public void IncriptoEn(Partido partido)
        {
            Mail mail = new Mail();
            mail.From = this.Mail;
            mail.Cuerpo = "Cuerpo del mensaje.";

            if (ListaAmigos.Count > 0)
            {
                foreach (Interesado amigo in ListaAmigos)
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

        public void Guardar(int idUsuario)
        {
            ActualizarYGuardar(idUsuario);
        }

        public void Actualizar(int idUsuario)
        {
            ActualizarYGuardar(idUsuario);
        }

        private void ActualizarYGuardar(int idUsuario)
        {
            DDSDataContext db = new DDSDataContext();
            db.Interesado_UI((int) idUsuario, this.Nombre, this.Apellido, this.Edad, this.Mail,
                new Estandar().Descripcion, this.Posicion, this.Handicap, new Handicap(this.Handicap).Descripcion);
            db.SubmitChanges();
        }

    }
}
