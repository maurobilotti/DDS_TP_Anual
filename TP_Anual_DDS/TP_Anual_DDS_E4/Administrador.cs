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

        public void CargarUsuariosIniciales()
        {
            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Ezequiel", "Barany", 22, "asdasd111@gmail.com", 6, 9, 0, new Estandar()),
                contrasena = "1234",
                usuario = "barany",
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Pablo", "Furst", 22, "asdasd111@gmail.com", 3, 9, 0, new Solidario()),
                contrasena = "1234",
                usuario = "furst"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Mauro", "Bilotti", 25, "asdasd111@gmail.com", 9, 9, 0, new Solidario()),
                contrasena = "1234",
                usuario = "bilotti"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Federico", "Beldevere", 23, "asdasd111@gmail.com", 5, 3, 0, new Estandar()),
                contrasena = "1234",
                usuario = "beldevere"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Augusto", "Bonabia", 22, "asdasd111@gmail.com", 1, 3, 0, new Estandar()),
                contrasena = "1234",
                usuario = "bonabia"
            });


            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Leo", "Messi", 26, "asdasd111@gmail.com", 10, 10, 0, new Estandar()),
                contrasena = "1234",
                usuario = "messi"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Cristiano", "Ronaldo", 29, "asdasd111@gmail.com", 7, 10, 0, new Solidario()),
                contrasena = "1234",
                usuario = "ronaldo"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Sergio", "Aguero", 25, "asdasd111@gmail.com", 9, 10, 0, new Estandar()),
                contrasena = "1234",
                usuario = "aguero"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Marcelo", "Barovero", 30, "asdasd111@gmail.com", 1, 5, 0, new Estandar()),
                contrasena = "1234",
                usuario = "barovero"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Javier", "Mascherano", 31, "asdasd111@gmail.com", 5, 8, 0, new Solidario()),
                contrasena = "1234",
                usuario = "mascherano"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Marcos", "Rojo", 22, "asdasd111@gmail.com", 3, 8, 0, new Estandar()),
                contrasena = "1234",
                usuario = "rojo"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Angel", "Di Maria", 26, "asdasd111@gmail.com", 7, 9, 0, new Estandar()),
                contrasena = "1234",
                usuario = "dimaria"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Pablo", "Zabaleta", 32, "asdasd111@gmail.com", 4, 7, 0, new Solidario()),
                contrasena = "1234",
                usuario = "zabaleta"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Pablo", "Zabaleta", 32, "asdasd111@gmail.com", 4, 7, 0, new Solidario()),
                contrasena = "1234",
                usuario = "zabaleta"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Lucas", "Biglia", 27, "asdasd111@gmail.com", 5, 6, 0, new Solidario()),
                contrasena = "1234",
                usuario = "biblia"
            });

            this.CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Enzo", "Perez", 32, "asdasd111@gmail.com", 4, 7, 0, new Solidario()),
                contrasena = "1234",
                usuario = "perez"
            });
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
