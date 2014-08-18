using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Administrador
    {
        private static Administrador _instancia = null;
        private List<Partido> listaPartidos;
        private List<Usuario> listaUsuarios;
        private List<Usuario> listaUsuariosPropuestos;
        private List<Denegacion> listaDenegaciones;

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

        public Guid CrearPartido(Partido partido)
        {
            this.listaPartidos.Add(partido);
            return partido.IdPartido;
        }

        public List<Partido> ObtenerPartidos()
        {
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

        public Usuario ObtenerUsuario(Guid id)
        {
            return this.listaUsuarios.SingleOrDefault(x => x.IdUsuario == id);
        }

        public Usuario ObtenerUsuario(string usuario, string contrasena)
        {
            return this.listaUsuarios.SingleOrDefault(x => x.contrasena == contrasena && x.usuario == usuario);
        }

        public Partido ObtenerPartido(Guid id)
        {
            return this.listaPartidos.SingleOrDefault(x => x.IdPartido == id);
        }

        public List<Interesado> ObtenerJugadoresNoInscriptos(Partido partido)
        {
            return this.listaUsuarios.Where(x => !x.Interesado.EstasInscriptoEn(partido)).Select(z => z.Interesado).ToList();
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
                    partido.ListaJugadores.Add(jugador.Interesado);
                }
            }
        }

        public bool DebeCriticas(Usuario usuario)
        {
            return this.listaPartidos.Any(z => z.Finalizado 
                    && z.ListaJugadores.Contains(usuario.Interesado) 
                    && !usuario.Interesado.ListaPartidosCriticados.Contains(z));
        }

        public List<Partido> ObtenerPartidosDeInteresado(Interesado interesado)
        {
            return this.listaPartidos.Where(z => z.ListaJugadores.Contains(interesado)).ToList();
        }

    }
}
