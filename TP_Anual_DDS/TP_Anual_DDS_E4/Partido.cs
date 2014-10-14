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
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_E4
{
    public class Partido : Entidad
    {
        #region Propiedades
        public int IdPartido
        {
            get
            {
                string consulta = string.Format("SELECT Id_Partido FROM " +
                    " Partido WHERE Lugar LIKE '{0}' AND Fecha_Hora = convert(datetime,'{1}',111)", this.Lugar, this.FechaHora.ToString("yyyy-MM-dd HH:mm"));
                return (int) new BaseDatos(consulta).ObtenerUnicoCampo();

            }
        }
        public DateTime FechaHora { get; set; }
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
            ObtenerInscriptos();
            ObtenerInfractores();
            this.ListaCalificaciones = new List<Calificacion>();
            this.FechaHora = fechaHora;
            this.Lugar = lugar;
        }

        #endregion

        #region Métodos públicos



        public bool AgregarInteresado(Usuario usuario)
        {
            if (usuario.Interesado.Tipo.PuedoJugarEn(this))
            {
                if (ListaJugadores.Count < 10)
                {
                    ListaJugadores.Add(usuario);
                    usuario.Interesado.IncriptoEn(this);
                    if (ListaJugadores.Count == 10)
                        return false;
                }
                else
                {
                    if (usuario.Interesado.Tipo.Prioridad == Interesado.EnumPrioridad.Solidario)//Si quiere ingresar un solidario
                    {
                        BuscarYEliminar(usuario, Interesado.EnumPrioridad.Condicional);//Busca si hay condicional y los cambia.
                    }
                    if (usuario.Interesado.Tipo.Prioridad == Interesado.EnumPrioridad.Estandar)//Si quiere ingresar un estandar
                    {
                        //Si hay un condicional, lo saca. Si no, busca si hay un solidario para sacarlo.
                        if (!BuscarYEliminar(usuario, Interesado.EnumPrioridad.Condicional))//Busca si hay condicional.
                            BuscarYEliminar(usuario, Interesado.EnumPrioridad.Solidario);//Busca si hay solidario.
                    }
                }
                ChequearCondicionales();
                List<Parametro> parametros = new List<Parametro>()
                {
                    new Parametro("@Id_Partido", SqlDbType.Int, this.IdPartido),
                    new Parametro("@Id_Interesado",SqlDbType.Int, usuario.Interesado.IdInteresado)
                };
                base.Guardar("Partido_Interesado_UI",parametros);
            }
            return true;
        }

        public void DarBaja(Usuario usuarioBaja)
        {
            this.ListaJugadores.Remove(usuarioBaja);
            this.ListaInfractores.Add(usuarioBaja);//Se agrega a una lista de infractores.
        }

        public void DarBaja(Usuario usuarioBaja, Usuario usuarioAlta)
        {
            this.ListaJugadores.Remove(usuarioBaja);
            this.ListaJugadores.Add(usuarioAlta);
        }

        #endregion

        #region Métodos privados

        private void ChequearCondicionales()
        {
            foreach (Usuario usuario in this.ListaJugadores)
            {
                if (!usuario.Interesado.Tipo.PuedoJugarEn(this))
                {
                    this.ListaJugadores.Remove(usuario);
                    Console.WriteLine("Fue sacado de la lista: " + usuario.Interesado.Nombre + " por dejar de cumplir sus condiciones.");
                }
            }
        }
        /// <summary>
        /// Busca en la lista de interesados inscriptos los que tienen menor prioridad y los vuela.
        /// </summary>
        /// <param name="interesadoAIngresar"></param>
        /// <param name="prioridadDeIngresanteAVolar">Busca interesados segun esto</param>
        private bool BuscarYEliminar(Usuario usuarioAIngresar, Interesado.EnumPrioridad prioridadDeIngresanteAVolar)
        {
            foreach (Usuario usuario in this.ListaJugadores)
            {
                if (usuario.Interesado.Tipo.Prioridad == prioridadDeIngresanteAVolar)
                {
                    ListaJugadores.Remove(usuario);
                    ListaJugadores.Add(usuarioAIngresar);
                    usuarioAIngresar.Interesado.IncriptoEn(this);
                    if (ListaJugadores.Count == 10)
                        return false;
                    return true;
                }
            }
            return false;
        }

        private List<Usuario> ObtenerInscriptos()
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("@Id_Partido", SqlDbType.Int, this.IdPartido)
            };

            DataTable dt = base.Obtener("Partido_ObtenerInteresados", parametros);
            
            return ListaJugadores = (from x in dt.AsEnumerable() 
                                     select new Usuario(x.Field<string>("Nombre_Usuario"),x.Field<string>("Password_Usuario"), 
                                         new Interesado(
                                        x.Field<string>("Nombre"),
                                        x.Field<string>("Apellido"),
                                        x.Field<int>("Edad"),
                                        x.Field<string>("Mail"),
                                        x.Field<int>("Posicion"),
                                        x.Field<int>("Handicap"),
                                        x.Field<int>("CantPartidosJugados"),
                                        x.Field<string>("Tipo_Jugador")))).ToList();
        }

        private List<Usuario> ObtenerInfractores()
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("@Id_Partido", SqlDbType.Int, this.IdPartido)
            };

            DataTable dt = base.Obtener("Partido_ObtenerInfractores", parametros);

            return ListaJugadores = (from x in dt.AsEnumerable()
                                     select new Usuario(x.Field<string>("Nombre_Usuario"), x.Field<string>("Password_Usuario"),
                                         new Interesado(
                                        x.Field<string>("Nombre"),
                                        x.Field<string>("Apellido"),
                                        x.Field<int>("Edad"),
                                        x.Field<string>("Mail"),
                                        x.Field<int>("Posicion"),
                                        x.Field<int>("Handicap"),
                                        x.Field<int>("CantPartidosJugados"),
                                        x.Field<string>("Tipo_Jugador")))).ToList();
        }

        private void AgregarCalificacion(Calificacion calificacion)
        {
            ListaCalificaciones.Add(calificacion);
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


        public void AgregarCalificacion(Interesado critico, Interesado criticado, int puntaje, string critica)
        {
            this.ListaCalificaciones.Add(new Calificacion(critico, criticado, critica, puntaje));
        }

        public void Guardar()
        {
            ActualizarYGuardar();
        }

        public void Actualizar()
        {
            ActualizarYGuardar();
        }

        private void ActualizarYGuardar()
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("@Lugar", SqlDbType.NVarChar, Lugar),
                new Parametro("@Confirmado", SqlDbType.Bit, Confirmado),
                new Parametro("@Fecha_Hora", SqlDbType.DateTime, FechaHora.ToString("yyyy-MM-dd HH:mm")),
            };

            base.Guardar("Partido_UI", parametros);
        }

    }
}
