using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Partido
    {
        #region Propiedades
        public int Id_Partido
        {
            get
            {
                return (from x in new DDSDataContext().DBPartido
                        where x.Lugar.Contains(this.Lugar)
                              && x.Fecha_Hora == Fecha_Hora
                        select x.Id_Partido).SingleOrDefault();

            }
        }
        public DateTime Fecha_Hora { get; set; }
        public string Lugar { get; set; }
        public List<Usuario> ListaJugadores { get; set; }
        private List<Usuario> ListaInfractores { get; set; }
        public List<Calificacion> ListaCalificaciones { get; set; }

        public List<Usuario> ListaPrimerEquipo
        {
            get { return this.ArmadorPartido.ArmarPrimerEquipo(); }
        }

        public List<Usuario> ListaSegundoEquipo
        {
            get { return this.ArmadorPartido.ArmarSegundoEquipo(); }
        }

        public ArmadorPartido ArmadorPartido { get; set; }
        public bool Confirmado { get; set; }
        public bool Finalizado = false;


        #endregion

        #region Constructores

        public Partido() { }
        public Partido(string lugar, DateTime fechaHora)
        {
            //ojo, el orden es importante
            this.Fecha_Hora = fechaHora;
            this.Lugar = lugar;

            ObtenerInscriptos();
            ObtenerInfractores();
            this.ListaCalificaciones = new List<Calificacion>();

        }

        #endregion

        #region Métodos públicos

        public bool AgregarJugador(Usuario usuario, int idTipoJugador, List<int> condiciones)
        {
            TipoJugador tipo = new Estandar();
            switch (idTipoJugador)
            {
                case 1:
                    tipo = new Condicional();
                    break;
                case 2:
                    tipo = new Solidario();
                    break;
            }

            if (tipo.PuedoJugarEn(this))
            {
                if (ListaJugadores.Count < 10)
                {
                    ListaJugadores.Add(usuario);
                    //se inserta la persona para el partido en cuestion
                    DDSDataContext db = new DDSDataContext();
                    db.Partido_Interesado_UI(this.Id_Partido, usuario.Interesado.Id_Interesado, idTipoJugador, false);
                    db.SubmitChanges();
                }
                else
                {
                    if (tipo.Prioridad == Interesado.EnumPrioridad.Solidario)//Si quiere ingresar un solidario
                    {
                        BuscarYEliminar(tipo, usuario, Interesado.EnumPrioridad.Condicional);//Busca si hay condicional y los cambia.
                    }
                    if (tipo.Prioridad == Interesado.EnumPrioridad.Estandar)//Si quiere ingresar un estandar
                    {
                        //Si hay un condicional, lo saca. Si no, busca si hay un solidario para sacarlo.
                        if (!BuscarYEliminar(tipo, usuario, Interesado.EnumPrioridad.Condicional))//Busca si hay condicional.
                            BuscarYEliminar(tipo, usuario, Interesado.EnumPrioridad.Solidario);//Busca si hay solidario.
                    }
                }
                ChequearCondicionales(tipo);
            }
            return true;
        }

        public void DarBaja(Usuario usuarioBaja)
        {
            RemoverJugador(usuarioBaja);
            RegistrarInfraccion(usuarioBaja);
        }

        public void DarBaja(Usuario usuarioBaja, Usuario usuarioAlta)
        {
            RemoverJugador(usuarioBaja);
            AgregarJugador(usuarioAlta, 3, null);
        }

        #endregion

        #region Métodos privados

        private void RegistrarInfraccion(Usuario usuarioInfractor)
        {
            this.ListaInfractores.Add(usuarioInfractor);//Se agrega a una lista de infractores.
            DDSDataContext db = new DDSDataContext();
            db.Infraccion_I(usuarioInfractor.Id_Usuario);
            db.SubmitChanges();
        }

        private void RemoverJugador(Usuario usuarioBaja)
        {
            this.ListaJugadores.Remove(usuarioBaja);


            DDSDataContext db = new DDSDataContext();
            db.Partido_Interesado_D((int)this.Id_Partido, (int)usuarioBaja.Interesado.Id_Interesado);
            db.SubmitChanges();

        }

        private void ChequearCondicionales(TipoJugador tipo)
        {
            foreach (Usuario usuario in this.ListaJugadores)
            {
                if (!tipo.PuedoJugarEn(this))
                {
                    this.ListaJugadores.Remove(usuario);
                }
            }
        }
        /// <summary>
        /// Busca en la lista de interesados inscriptos los que tienen menor prioridad y los vuela.
        /// </summary>
        /// <param name="interesadoAIngresar"></param>
        /// <param name="prioridadDeIngresanteAVolar">Busca interesados segun esto</param>
        private bool BuscarYEliminar(TipoJugador tipo, Usuario usuarioAIngresar, Interesado.EnumPrioridad prioridadDeIngresanteAVolar)
        {
            foreach (Usuario usuario in this.ListaJugadores)
            {
                if (ObtenerTipoJugador(usuario) == prioridadDeIngresanteAVolar)
                {
                    DDSDataContext db = new DDSDataContext();
                    //se elimina el jugador por prioridad de la lista y de la base
                    ListaJugadores.Remove(usuario);
                    db.Partido_Interesado_D(this.Id_Partido, usuario.Interesado.Id_Interesado);

                    //se agrega un nuevo jugador por ganar en prioridad, también a la lista y a la base

                    db.Partido_Interesado_UI(this.Id_Partido, usuarioAIngresar.Interesado.Id_Interesado, tipo.Id_TipoJugador, false);
                    db.SubmitChanges();
                    ListaJugadores.Add(usuarioAIngresar);

                    if (ListaJugadores.Count == 10)
                        return true;
                }
            }
            return false;
        }

        private void ObtenerInscriptos()
        {
            this.ListaJugadores = new List<Usuario>();
            //ejecuta el SP Partido_ObtenerInteresados y lo mapea a los tipos de la solucion
            this.ListaJugadores = (from x in new DDSDataContext().Partido_ObtenerInteresados(this.Id_Partido)
                                   select new Usuario(x.Nombre_Usuario, x.Password_Usuario,
                                       new Interesado(x.Nombre, x.Apellido, (DateTime)x.FechaNacimiento, x.Mail, (int)x.Posicion,
                                           (int)x.Handicap, x.CantPartidosJugados))).ToList();
        }

        private void ObtenerInfractores()
        {
            this.ListaInfractores = new List<Usuario>();
            //ejecuta el SP Infraccion_L y lo mapea a los tipos de la solucion
            this.ListaInfractores = (from x in new DDSDataContext().Infraccion_L()
                                     select new Usuario(x.Nombre_Usuario, x.Password_Usuario,
                                         new Interesado(x.Nombre, x.Apellido, x.FechaNacimiento, x.Mail, (int)x.Posicion,
                                             (int)x.Handicap, x.CantPartidosJugados))).ToList();
        }

        public void AgregarCriterio(char opcion)
        {
            //agrega el criterio por cada jugador y ordena la lista según el mismo
            switch (opcion)
            {
                case 'H':
                    ListaJugadores.ForEach(z => z.Interesado.Criterio = new Handicap(z.Interesado.Handicap));
                    break;
                case 'P':
                    ListaJugadores.ForEach(z => z.Interesado.Criterio = new PromUltimoPartido(z.Interesado.ListaCalificaciones));
                    break;
                case 'N':
                    ListaJugadores.ForEach(z => z.Interesado.Criterio = new PromUltimosNPartidos(z.Interesado.ListaCalificaciones, z.Interesado.CantPartidosJugados));
                    break;
                case 'M':
                    //incluye los tres criterios
                    ListaJugadores.ForEach(z => z.Interesado.Criterio = new Mix(new List<ICriterio>()
                    {
                        new Handicap(z.Interesado.Handicap),
                        new PromUltimoPartido(z.Interesado.ListaCalificaciones),
                        new PromUltimosNPartidos(z.Interesado.ListaCalificaciones,z.Interesado.CantPartidosJugados)
                    }));
                    break;
            }
            //ordeno la lista por posición y aplicando el criterio especificado
            this.ListaJugadores = (from x in ListaJugadores orderby x.Interesado.Posicion, x.Interesado.Criterio.AplicarCriterio() select x).ToList();
        }
        #endregion


        public bool EstaInscripto(Interesado interesado)
        {
            return this.ListaJugadores.Any(x => x.Interesado.Nombre == interesado.Nombre && x.Interesado.Apellido == interesado.Apellido);
        }

        private Interesado.EnumPrioridad ObtenerTipoJugador(Usuario usuario)
        {
            int idTipoJugador = (from x in new DDSDataContext().DBPartido_Interesado
                where x.Id_Partido == this.Id_Partido && x.Id_Interesado == usuario.Interesado.Id_Interesado
                select x.Id_TipoJugador).SingleOrDefault();
            return (Interesado.EnumPrioridad) idTipoJugador;
        }

        public void AgregarCalificacion(Interesado critico, Interesado criticado, int puntaje, string critica)
        {
            this.ListaCalificaciones.Add(new Calificacion(critico, criticado, critica, puntaje));
        }

        public void Guardar()
        {
            DDSDataContext db = new DDSDataContext();
            db.Partido_UI(this.Lugar, (bool)this.Confirmado,
                Convert.ToDateTime(this.Fecha_Hora.ToString("yyyy-MM-dd HH:mm")));
            db.SubmitChanges();
        }

        public List<Partido_Interesado_LResult> ObtenerListaJugadoresInteresados()
        {
            return new DDSDataContext().Partido_Interesado_L(this.Id_Partido).AsEnumerable().ToList();
        }
    }
}
