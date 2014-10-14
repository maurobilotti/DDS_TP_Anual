using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Administrador
    {
        private static Administrador _instancia = null;
        private List<Partido> listaPartidos { get; set; }
        private List<Usuario> listaUsuarios { get; set; }
        private List<Usuario> listaUsuariosPropuestos { get; set; }
        private List<Denegacion> listaDenegaciones { get; set; }

        private Administrador()
        {
            this.listaPartidos = new List<Partido>();
            this.listaUsuarios = new List<Usuario>();
            this.listaUsuariosPropuestos = new List<Usuario>();
            this.listaDenegaciones = new List<Denegacion>();
        }

        public static Administrador ObtenerInstancia()
        {
            if (null == _instancia)
                _instancia = new Administrador();
            return _instancia;
        }

        public List<Usuario> CargarUsuariosIniciales()
        {
            //listaUsuarios = (from x in new BaseDatos(string.Format("SELECT Nombre_Usuario,Password_Usuario,Confirmado FROM Usuario"))
            //                     .ObtenerDataTable().AsEnumerable() 
            //                 select new Usuario(x["Nombre_Usuario"].ToString(),))
            BaseDatos bd = new BaseDatos("Usuario_L");
            bd.pTipoComando = CommandType.StoredProcedure;
            listaUsuarios = (from x in bd.ObtenerDataTable().AsEnumerable()
                select
                    new Usuario(x.Field<string>("Nombre_Usuario"), x.Field<string>("Password_Usuario"),
                        new Interesado(
                            x.Field<string>("Nombre"),
                            x.Field<string>("Apellido"),
                            x.Field<int>("Edad"),
                            x.Field<string>("Mail"),
                            x.Field<int>("Posicion"),
                            x.Field<int>("Handicap"),
                            x.Field<int>("CantPartidosJugados")))).ToList();
            return listaUsuarios;
        }

        public void CrearPartido(Partido partido)
        {
            this.listaPartidos.Add(partido);
        }

        public List<Partido> ObtenerPartidos()
        {
            this.listaPartidos = (from x in new BaseDatos("SELECT Lugar,Fecha_Hora,Confirmado FROM Partido").ObtenerDataTable().AsEnumerable()
                                  select new Partido(x["Lugar"].ToString(), (DateTime)x["Fecha_Hora"])).ToList();

            return this.listaPartidos;
        }

        public void CrearUsuario(Usuario usuario)
        {
            this.listaUsuarios.Add(usuario);
        }

        public void QuitarUsuarioPropuesto(Usuario usuario)
        {
            this.listaUsuariosPropuestos.Remove(usuario);
        }

        public Usuario ObtenerUsuario(int id)
        {
            return this.listaUsuarios.SingleOrDefault(x => x.IdUsuario == id);
        }

        public Usuario ObtenerUsuario(string usuario, string contrasena)
        {
            return listaUsuarios.SingleOrDefault(z => z.contrasena.Equals(contrasena) && z.usuario.Equals(usuario));
        }

        public Partido ObtenerPartido(int id)
        {
            return this.listaPartidos.SingleOrDefault(x => x.IdPartido == id);
        }

        public List<Usuario> ObtenerJugadoresNoInscriptos(Partido partido)
        {
            return this.listaUsuarios.Where(x => !x.Interesado.EstasInscriptoEn(partido)).ToList();
        }

        public void CrearUsuarioPropuesto(Usuario usuario)
        {
            this.listaUsuariosPropuestos.Add(usuario);
        }

        public List<Usuario> ObtenerUsuariosPropuestos()
        {
            return this.listaUsuariosPropuestos;
        }

        public void RegistrarMotivoRechazo(Usuario usuario, string motivo)
        {
            this.listaDenegaciones.Add(new Denegacion(usuario.Interesado, motivo, DateTime.Now));
        }

        public void CompletarJugadoresPartido(Partido partido)
        {
            while (partido.ListaJugadores.Count < 10)
            {
                foreach (Usuario jugador in this.listaUsuarios)
                {
                    partido.ListaJugadores.Add(jugador);
                }
            }
        }

        public bool DebeCriticas(Usuario usuario)
        {
            return this.listaPartidos.Any(z => z.Finalizado
                    && z.ListaJugadores.Contains(usuario)
                    && !usuario.Interesado.ListaPartidosCriticados.Contains(z));
        }

        public List<Partido> ObtenerPartidosDeInteresado(Usuario usuario)
        {
            return this.listaPartidos.Where(z => z.ListaJugadores.Contains(usuario)).ToList();
        }

    }
}
