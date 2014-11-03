using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public enum EnumFiltrosInfracciones
        {
            Todos,
            ConInfracciones,
            SinInfracciones
        }

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
            return listaUsuarios = (from x in new DDSDataContext().Usuario_L()
                                    select new Usuario(x.Nombre_Usuario, x.Password_Usuario,
                                        new Interesado(x.Nombre, x.Apellido, (DateTime)x.FechaNacimiento, x.Mail, (int)x.Posicion, (int)x.Handicap, x.CantPartidosJugados))).ToList();
        }

        public void CrearPartido(Partido partido)
        {
            this.listaPartidos.Add(partido);
        }

        public List<Partido> ObtenerPartidos()
        {
            this.listaPartidos = (from x in new DDSDataContext().Partido_L()
                                  select new Partido(x.Lugar, (DateTime)x.Fecha_Hora, x.Confirmado.Value, x.Finalizado.Value)).ToList();

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
            return this.listaUsuarios.SingleOrDefault(x => x.Id_Usuario == id);
        }

        public Usuario ObtenerUsuario(string usuario, string contrasena)
        {
            return listaUsuarios.SingleOrDefault(z => z.Password.Equals(contrasena) && z._Usuario.Equals(usuario));
        }

        public Partido ObtenerPartido(int id)
        {
            return this.listaPartidos.SingleOrDefault(x => x.Id_Partido == id);
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

        public DataTable ObtenerListaJugadores(string cadena, DateTime fechaNacimientoMaxima,
                                double promedioDesde, double promedioHasta, EnumFiltrosInfracciones filtroInfraccion, int handicapDesde = -1, int handicapHasta = -1)
        {
            DataTable dt = new DataTable();

            DDSDataContext db = new DDSDataContext();
            var lista = (from x in db.DBInteresado select new
            {
                Nombre = string.Format("{0} {1}",x.Nombre,x.Apellido),
                x.Handicap,
                Promedio = (from y in db.DBCalificacion where y.Id_Jugador_Criticado == x.Id_Interesado select y.Calificacion).ToList().Average()
            }).ToList();

           
            
            return dt;
        }

        private DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

    }
}
