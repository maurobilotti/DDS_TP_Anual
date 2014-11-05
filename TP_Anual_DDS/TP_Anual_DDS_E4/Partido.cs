using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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

        public List<Calificacion> ListaCalificaciones
        {
            get { return ObtenerCalificaciones(); }
            set { }
        }

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
        private string p;
        private DateTime dateTime;
        private bool? nullable1;
        private bool? nullable2;


        #endregion

        #region Constructores

        public Partido(string lugar, DateTime fechaHora, bool confirmado, bool finalizado)
        {
            //ojo, el orden es importante
            this.Fecha_Hora = fechaHora;
            this.Lugar = lugar;
            this.Confirmado = confirmado;
            this.Finalizado = finalizado;
            ObtenerInscriptos();
            ObtenerInfractores();
            this.ListaCalificaciones = ObtenerCalificaciones();
        }

        /// <summary>
        /// obtiene la lista de criticas realizadas
        /// </summary>
        private List<Calificacion> ObtenerCalificaciones()
        {
            DDSDataContext db = new DDSDataContext();
            return (from x in db.DBCalificacion
                    join criticado in db.DBInteresado on x.Id_Jugador_Criticado equals criticado.Id_Interesado
                    join critico in db.DBInteresado on x.Id_Jugador_Critico equals critico.Id_Interesado
                    where x.Id_Partido == this.Id_Partido
                    select
                        new Calificacion(
                            new Interesado(critico.Nombre, critico.Apellido, critico.FechaNacimiento, critico.Mail,
                                (int)critico.Posicion, (int)critico.Handicap, critico.CantPartidosJugados),
                            new Interesado(criticado.Nombre, criticado.Apellido, criticado.FechaNacimiento, criticado.Mail,
                                (int)criticado.Posicion, (int)criticado.Handicap, criticado.CantPartidosJugados),
                            x.Descripcion,
                            x.Calificacion
                            )).ToList();
        }

        #endregion

        #region Métodos públicos

        public bool EstaInscripto(Interesado interesado)
        {
            return
                this.ListaJugadores.Any(
                    x =>
                        x.Interesado.Nombre == interesado.Nombre && x.Interesado.Apellido == interesado.Apellido &&
                        !this.Confirmado);
        }

        public List<Partido_Interesado_LResult> ObtenerListaJugadoresInteresados()
        {
            return new DDSDataContext().Partido_Interesado_L(this.Id_Partido).AsEnumerable().ToList();
        }

        public void AgregarCalificacion(Interesado critico, Interesado criticado, int calificacion, string critica)
        {
            this.ListaCalificaciones.Add(new Calificacion(critico, criticado, critica, calificacion));

            //registra la crítica en la base de datos
            DDSDataContext db = new DDSDataContext();
            db.Calificacion_I(this.Id_Partido, critica, critico.Id_Interesado, criticado.Id_Interesado, calificacion);
            db.SubmitChanges();
        }

        public void Guardar()
        {
            DDSDataContext db = new DDSDataContext();
            db.Partido_UI(this.Lugar, (bool)this.Confirmado,
                Convert.ToDateTime(this.Fecha_Hora.ToString("yyyy-MM-dd HH:mm")));
            db.SubmitChanges();
        }

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
                    return true;
                }
                else
                {
                    if (tipo.Prioridad == Interesado.EnumPrioridad.Solidario) //Si quiere ingresar un solidario
                    {
                        return BuscarYEliminar(tipo, usuario, Interesado.EnumPrioridad.Condicional);
                        //Busca si hay condicional y los cambia.
                    }
                    if (tipo.Prioridad == Interesado.EnumPrioridad.Estandar) //Si quiere ingresar un estandar
                    {
                        //Si hay un condicional, lo saca. Si no, busca si hay un solidario para sacarlo.
                        if (!BuscarYEliminar(tipo, usuario, Interesado.EnumPrioridad.Condicional))
                            //Busca si hay condicional.
                            return BuscarYEliminar(tipo, usuario, Interesado.EnumPrioridad.Solidario);
                        //Busca si hay solidario.
                        return true; //si eliminó un condicional
                    }
                }
                ChequearCondicionales(tipo);
            }

            return false;
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

        public void RegistrarPrimerEquipo()
        {
            foreach (Usuario usuario in ListaPrimerEquipo)
            {
                try
                {
                    DDSDataContext db = new DDSDataContext();

                    DBPartido_Interesado interesado = (from x in db.DBPartido_Interesado
                                                       where x.Id_Interesado == usuario.Interesado.Id_Interesado && x.Id_Partido == this.Id_Partido
                                                       select x).Single();
                    interesado.EquipoDesignado = 1;
                    db.SubmitChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        public void RegistrarSegundoEquipo()
        {
            foreach (Usuario usuario in ListaSegundoEquipo)
            {
                try
                {
                    DDSDataContext db = new DDSDataContext();

                    DBPartido_Interesado interesado = (from x in db.DBPartido_Interesado
                                                       where x.Id_Interesado == usuario.Interesado.Id_Interesado && x.Id_Partido == this.Id_Partido
                                                       select x).Single();
                    interesado.EquipoDesignado = 2;
                    db.SubmitChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        /// <summary>
        /// finaliza el partido en la base de datos
        /// </summary>
        public void Finalizar()
        {
            DDSDataContext db = new DDSDataContext();
            DBPartido dbPartido = (from x in db.DBPartido
                                   where x.Id_Partido == this.Id_Partido
                                   select x).SingleOrDefault();

            dbPartido.Finalizado = true;

            //obtengo todos los jugadores del partido para incrementar la cantidad de partidos jugados
            List<DBInteresado> interesados = (from x in db.DBPartido_Interesado
                                              where x.Id_Partido == this.Id_Partido && !(bool)x.Baja
                                              select x.DBInteresado).ToList();
            //sumo un partido a los jugados
            interesados.ForEach(z => z.CantPartidosJugados++);

            db.SubmitChanges();
            //añade al partido como finalizado a cada jugador
            this.ListaJugadores.ForEach(z => z.Interesado.ListaPartidosFinalizados.Add(this));
            if (!this.Finalizado)
            {
                this.Finalizado = true;
            }
        }


        /// <summary>
        /// crea una critica por cada jugador
        /// </summary>
        //private void CrearCriticasJugadores()
        //{
        //    foreach (Usuario jugadorCritico in this.ListaJugadores)
        //    {
        //        foreach (Usuario jugadorCriticado in ListaJugadores)
        //        {
        //            if (jugadorCriticado == jugadorCritico)
        //                continue;

        //            DDSDataContext db = new DDSDataContext();
        //            DBCalificacion calificacion = new DBCalificacion();
        //            calificacion.Id_Partido = this.Id_Partido;
        //            calificacion.Id_Jugador_Critico = jugadorCritico.Interesado.Id_Interesado;
        //            calificacion.Id_Jugador_Criticado = jugadorCriticado.Interesado.Id_Interesado;
        //            calificacion.Calificacion = -1;
        //            db.DBCalificacion.InsertOnSubmit(calificacion);
        //            db.SubmitChanges();
        //        }
        //    }
        //}

        /// <summary>
        /// confirma el partido en la base de datos
        /// </summary>
        public void Confirmar()
        {
            DDSDataContext db = new DDSDataContext();

            DBPartido dbPartido = (from x in db.DBPartido
                                   where x.Id_Partido == this.Id_Partido
                                   select x).SingleOrDefault();

            dbPartido.Confirmado = true;
            db.SubmitChanges();
        }

        #endregion

        #region Métodos privados

        private void RegistrarInfraccion(Usuario usuarioInfractor)
        {
            this.ListaInfractores.Add(usuarioInfractor); //Se agrega a una lista de infractores.
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
        private bool BuscarYEliminar(TipoJugador tipo, Usuario usuarioAIngresar,
            Interesado.EnumPrioridad prioridadDeIngresanteAVolar)
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

                    db.Partido_Interesado_UI(this.Id_Partido, usuarioAIngresar.Interesado.Id_Interesado,
                        tipo.Id_TipoJugador, false);
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
                    DDSDataContext db = new DDSDataContext();
                    ListaJugadores.ForEach(
                        z =>
                            z.Interesado.Criterio =
                                new PromUltimoPartido(
                                    z.Interesado.ObtenerCalificacionesPartido(
                                        ObtenerUltimoPartido(z.Interesado.Id_Interesado))));
                    break;
                case 'N':
                    ListaJugadores.ForEach(
                        z =>
                            z.Interesado.Criterio =
                                new NUltimosPartidosPromedio(z.Interesado.ListaCalificaciones,
                                    z.Interesado.CantPartidosJugados));
                    break;
                case 'M':
                    //incluye los tres criterios
                    ListaJugadores.ForEach(z => z.Interesado.Criterio = new Mix(new List<ICriterio>()
                    {
                        new Handicap(z.Interesado.Handicap),
                        new PromUltimoPartido(
                            z.Interesado.ObtenerCalificacionesPartido(ObtenerUltimoPartido(z.Interesado.Id_Interesado))),
                        new NUltimosPartidosPromedio(z.Interesado.ListaCalificaciones, z.Interesado.CantPartidosJugados)
                    }));
                    break;
            }
        }

        private int ObtenerUltimoPartido(int id_Interesado)
        {
            DDSDataContext db = new DDSDataContext();
            int idPartido = (from x in db.DBPartido_Interesado
                             join y in db.DBPartido on x.Id_Partido equals y.Id_Partido
                             where x.Id_Interesado == id_Interesado && (bool)y.Finalizado
                             orderby y.Fecha_Hora descending
                             select x.Id_Partido).FirstOrDefault();
            return idPartido;
        }

        private Interesado.EnumPrioridad ObtenerTipoJugador(Usuario usuario)
        {
            int idTipoJugador = (from x in new DDSDataContext().DBPartido_Interesado
                                 where x.Id_Partido == this.Id_Partido && x.Id_Interesado == usuario.Interesado.Id_Interesado
                                 select x.Id_TipoJugador).SingleOrDefault();
            return (Interesado.EnumPrioridad)idTipoJugador;
        }

        #endregion

        public IEnumerable<object> ObtenerEquiposDesignados(int nroEquipo)
        {
            DDSDataContext db = new DDSDataContext();
            return (from x in db.DBPartido_Interesado
                    join y in db.DBInteresado on x.Id_Interesado equals y.Id_Interesado
                    where x.Id_Partido == this.Id_Partido && !(bool)x.Baja
                          && x.EquipoDesignado == nroEquipo
                    select new
                    {
                        NombreyApellido = string.Format("{0} {1}", y.Nombre, y.Apellido),
                        y.FechaNacimiento,
                        y.Posicion,
                        y.Handicap
                    }).ToList();
        }

        public IEnumerable<object> ObtenerListaEquipo(int equipo)
        {
            return (from x in equipo == 1 ? this.ListaPrimerEquipo : ListaSegundoEquipo
                    select new
                    {
                        NombreyApellido = string.Format("{0} {1}", x.Interesado.Nombre, x.Interesado.Apellido),
                        x.Interesado.FechaNacimiento,
                        x.Interesado.Posicion,
                        x.Interesado.Handicap
                    }).ToList();
        }
    }
}
