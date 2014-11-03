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
            Condicional = 1, Solidario = 2, Estandar = 3
        }

        public int Id_Interesado
        {
            get
            {
                DDSDataContext db = new DDSDataContext();
                return (from x in db.DBInteresado
                        where x.Nombre == Nombre && x.Apellido == Apellido
                        select x.Id_Interesado).SingleOrDefault();
            }
        }

        public DateTime FechaNacimiento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public List<Interesado> ListaAmigos { get; set; }
        public int Posicion { get; set; }
        public ICriterio Criterio { get; set; }
        public List<int> ListaCalificaciones { get; set; }
        public int Handicap { get; set; }
        public int CantPartidosJugados { get; set; }
        public string NombreYApellido
        {
            get { return Nombre + " " + Apellido; }
        }

        public List<Partido> ListaPartidosFinalizados { get; set; }
        public List<Partido> ListaPartidosCriticados { get; set; }

        /// <summary>
        /// Constructor para jugadores amigos... ya que el admin determina el tipo después
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="mail"></param>
        public Interesado(string nombre, string apellido, DateTime fechaNacimiento, string mail, int posicion, int handicap, int cantPartidosJugados)
        {
            this.ListaAmigos = new List<Interesado>();
            this.ListaCalificaciones = new List<int>();
            this.ListaPartidosCriticados = new List<Partido>();
            CargarPartidosFinalizados();
            this.FechaNacimiento = fechaNacimiento;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = mail;
            this.Posicion = posicion;
            this.CantPartidosJugados = cantPartidosJugados;
            this.Handicap = handicap;
        }

        private void CargarPartidosFinalizados()
        {
            this.ListaPartidosFinalizados = new List<Partido>();
            DDSDataContext db = new DDSDataContext();
            this.ListaPartidosFinalizados = (from x in db.Interesado_ObtenerPartidosFinalizados(this.Id_Interesado)
                select new Partido(x.Lugar, (DateTime) x.Fecha_Hora, x.Confirmado.Value, x.Finalizado.Value)).ToList();
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

        //public void IncriptoEn(Partido partido)
        //{
        //    Mail mail = new Mail();
        //    mail.From = this.Mail;
        //    mail.Cuerpo = "Cuerpo del mensaje.";

        //    if (ListaAmigos.Count > 0)
        //    {
        //        foreach (Interesado amigo in ListaAmigos)
        //        {
        //            mail.To += amigo.Mail + "; ";
        //        }

        //        if (mail.To != null)
        //        {
        //            if (mail.EnviarMail())
        //            {
        //                Console.WriteLine("El interesado: " + this.Nombre + " le envió mail a: " + mail.To);
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Ninguno de los amigos de " + this.Nombre + " tiene un mail configurado.");
        //        }
        //    }
        //}

        public void Guardar(int idUsuario)
        {
            DDSDataContext db = new DDSDataContext();
            db.Interesado_UI((int)idUsuario, this.Nombre, this.Apellido, this.FechaNacimiento, this.Mail, this.Posicion, this.Handicap, new Handicap(this.Handicap).Descripcion);
            db.SubmitChanges();
        }
    }
}
