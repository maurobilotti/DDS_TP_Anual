using System;using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TP_Anual_DDS_E3;

namespace TP_Anual_DDS_E4
{
    public class Partido
    {
        #region Propiedades

        public Guid IdPartido { get; set; }
        public DateTime FechaHora { get; set; }
        public string Lugar { get; set; }
        private List<Denegacion> ListaDenegaciones { get; set; }
        public List<Interesado> ListaJugadores { get; set; }
        private List<Interesado> ListaInfractores { get; set; }
        public List<Calificacion> ListaCalificaciones { get; set; }
        public ArmadorPartido ArmadorPartido { get; set; }
        public bool Confirmado { get; set; }

        #endregion

        #region Constructores

        public Partido() { }
        public Partido(string lugar, DateTime fechaHora)
        {
            this.ListaJugadores = new List<Interesado>();
            this.ListaInfractores = new List<Interesado>();
            this.ListaDenegaciones = new List<Denegacion>();
            this.ListaCalificaciones = new List<Calificacion>();
            this.FechaHora = fechaHora;
            this.Lugar = lugar;
            this.IdPartido = Guid.NewGuid();
        }
        #endregion

        #region Métodos públicos

        internal void AgregarCalificaciones()
        {
            foreach (Interesado jugadorCritico in this.ListaJugadores)
            {
                foreach (Interesado jugadorCriticado in this.ListaJugadores)
                {
                    if (jugadorCritico != jugadorCriticado)
                    {
                        //se inicia la critica al primer jugador
                        Console.WriteLine(string.Format("El jugador {0} {1} le realiza la critica al jugador {2} {3}",
                                jugadorCritico.Nombre, jugadorCritico.Apellido, jugadorCriticado.Nombre, jugadorCriticado.Apellido));

                        Console.WriteLine("Escriba la critica y luego presione 'enter'.");
                        string critica = Console.ReadLine();

                        //valido que la calificacion sea correcta
                        bool esValido = false;
                        int calificacion = 0;
                        while (!esValido)
                        {
                            Console.WriteLine("Ingrese un puntaje numérico y luego presione 'enter' (0 a 5).");
                            esValido = int.TryParse(Console.ReadLine(), out calificacion);
                            if (calificacion > 5 || calificacion < 0)
                            {
                                Console.WriteLine("Los valores de calificacion deben estar entre 0 y 5.");
                                esValido = false;
                            }
                        }
                        this.AgregarCalificacion(new Calificacion(jugadorCritico, jugadorCriticado, critica, calificacion));
                    }
                }
            }
        }

        internal void AgregarSugeridos()
        {
            if (this.ListaJugadores.Count > 0)
            {
                for (int i = this.ListaJugadores.Count - 1; i >= 0; i--)
                {
                    string nombrePrincipal = this.ListaJugadores[i].Nombre;
                    string apellidoPrincipal = this.ListaJugadores[i].Apellido;
                    Console.WriteLine(string.Format("{0} {1} ha propuesto un jugador." +
                        " ¿Desea agregarlo al partido? (S/N)", nombrePrincipal, apellidoPrincipal));
                    char resp = (char)Console.Read();

                    if (resp == 'S' || resp == 's')
                    {
                        Console.WriteLine("////Se ingresan los datos del nuevo jugador: ");
                        Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre y presione 'enter':");
                        string nombreAmigo = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido y presione 'enter':");
                        string apellidoAmigo = Console.ReadLine();
                        int edadAmigo = 0;
                        bool esValido = false;
                        while (!esValido)
                        {
                            Console.WriteLine("Ingrese la edad y presione 'enter':");
                            esValido = int.TryParse(Console.ReadLine(), out edadAmigo);
                        }
                        Console.WriteLine("Ingrese el mail y presione 'enter',:");
                        string mailAmigo = Console.ReadLine();

                        int posicion = 0;
                        esValido = false;
                        while (!esValido)
                        {
                            Console.WriteLine("Ingrese la posición en la que juega el jugador sugerido: ");
                            esValido = int.TryParse(Console.ReadLine(), out posicion);
                        }

                        int handicap = 0;
                        esValido = false;
                        while (!esValido)
                        {
                            Console.WriteLine("Ingrese el handicap del jugador: ");
                            esValido = int.TryParse(Console.ReadLine(), out handicap);
                            esValido = handicap >= 0 && handicap <= 10;
                        }

                        this.ListaJugadores[i].AgregarAmigo(new Interesado(nombreAmigo, apellidoAmigo, edadAmigo, mailAmigo, posicion, handicap, 1));
                        //valida que la tecla apretada sea correcta
                        esValido = false;
                        char tipo = 'E';
                        while (!esValido)
                        {
                            Console.WriteLine(string.Format("El jugador {0} {1} se incluirá a la lista para el partido," +
                                                "escoja el tipo de jugador que será (C = CONDICIONAL, E = ESTANDAR, S = SOLIDARIO)", nombreAmigo, apellidoAmigo));
                            tipo = (char)Console.Read();
                            if (tipo == 'c' || tipo == 'C' || tipo == 'e' || tipo == 'E' || tipo == 's' || tipo == 'S')
                                break;
                        }
                        switch (tipo)
                        {
                            case 'C':
                            case 'c':
                                {
                                    this.ListaJugadores[i].listaAmigos[0].Tipo = new Condicional();
                                }
                                break;
                            case 'E':
                            case 'e':
                                {
                                    this.ListaJugadores[i].listaAmigos[0].Tipo = new Estandar();
                                }
                                break;
                            case 'S':
                            case 's':
                                {
                                    this.ListaJugadores[i].listaAmigos[0].Tipo = new Solidario();
                                }
                                break;
                            default:
                                //si se equivoca la tecla, se crea estandar
                                this.ListaJugadores[i].listaAmigos[0].Tipo = new Estandar();
                                break;
                        }
                        //se agrega el jugador al partido
                        this.AgregarInteresado(this.ListaJugadores[i].listaAmigos[0]);

                    }
                    else if (resp == 'N' || resp == 'n')
                    {
                        //limpia el buffer de entrada
                        Console.ReadLine();
                        Console.WriteLine("Ingrese el motivo de la denegación del jugador");
                        string motivo = Console.ReadLine();
                        //se añade el jugador que sugiere, el motivo y la fecha de la denegación
                        this.AgregarDenegacion(new Denegacion(this.ListaJugadores[i], motivo, DateTime.Now));
                    }

                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadLine();
                }
            }
            else
            {
                //si el partido no tiene jugadores, se sale.
                Console.WriteLine("El partido no cuenta con jugadores. Se sale del programa.");
                Console.ReadKey();
                return;
            }
        }

        public bool AgregarInteresado(Interesado interesado)
        {
            if (interesado.Tipo.PuedoJugarEn(this))
            {
                if (ListaJugadores.Count < 10)
                {
                    ListaJugadores.Add(interesado);
                    interesado.EstasIncriptoEn(this);
                    if (ListaJugadores.Count == 10)
                        Console.WriteLine("La lista está completa.");
                }
                else
                {
                    if (interesado.Tipo.Prioridad == Interesado.EnumPrioridad.Solidario)//Si quiere ingresar un solidario
                    {
                        BuscarYEliminar(interesado, Interesado.EnumPrioridad.Condicional);//Busca si hay condicional y los cambia.
                    }
                    if (interesado.Tipo.Prioridad == Interesado.EnumPrioridad.Estandar)//Si quiere ingresar un estandar
                    {
                        //Si hay un condicional, lo saca. Si no, busca si hay un solidario para sacarlo.
                        if (!BuscarYEliminar(interesado, Interesado.EnumPrioridad.Condicional))//Busca si hay condicional.
                            BuscarYEliminar(interesado, Interesado.EnumPrioridad.Solidario);//Busca si hay solidario.
                    }
                }
                ChequearCondicionales();
            }
            return true;
        }

        public void DarBaja(Interesado interesadoBaja)
        {
            this.ListaJugadores.Remove(interesadoBaja);
            this.ListaInfractores.Add(interesadoBaja);//Se agrega a una lista de infractores.
        }

        public void DarBaja(Interesado interesadoBaja, Interesado interesadoAlta)
        {
            this.ListaJugadores.Remove(interesadoBaja);
            this.ListaJugadores.Add(interesadoAlta);
        }

        public void AgregarDenegacion(Denegacion denegacion)
        {
            this.ListaDenegaciones.Add(denegacion);
        }

        #endregion

        #region Métodos privados

        private void ChequearCondicionales()
        {
            foreach (Interesado interes in this.ListaJugadores)
            {
                if (!interes.Tipo.PuedoJugarEn(this))
                {
                    this.ListaJugadores.Remove(interes);
                    Console.WriteLine("Fue sacado de la lista: " + interes.Nombre + " por dejar de cumplir sus condiciones.");
                }
            }
        }
        /// <summary>
        /// Busca en la lista de interesados inscriptos los que tienen menor prioridad y los vuela.
        /// </summary>
        /// <param name="interesadoAIngresar"></param>
        /// <param name="prioridadDeIngresanteAVolar">Busca interesados segun esto</param>
        private bool BuscarYEliminar(Interesado interesadoAIngresar, Interesado.EnumPrioridad prioridadDeIngresanteAVolar)
        {
            foreach (Interesado interes in this.ListaJugadores)
            {
                if (interes.Tipo.Prioridad == prioridadDeIngresanteAVolar)
                {
                    ListaJugadores.Remove(interes);
                    ListaJugadores.Add(interesadoAIngresar);
                    interesadoAIngresar.EstasIncriptoEn(this);
                    if (ListaJugadores.Count == 10)
                        Console.WriteLine("La lista está completa.");
                    return true;
                }
            }
            return false;
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
                    ListaJugadores.ForEach(z => z.Criterio = new Handicap(z.Handicap));
                    break;
                case 'P':
                    ListaJugadores.ForEach(z => z.Criterio = new PromUltimoPartido(z.ListaCalificaciones));
                    break;
                case 'N':
                    ListaJugadores.ForEach(z => z.Criterio = new PromUltimosNPartidos(z.ListaCalificaciones, z.CantPartidosJugados));
                    break;
                case 'M':
                    //incluye los tres criterios
                    ListaJugadores.ForEach(z => z.Criterio = new Mix(new List<ICriterio>()
                    {
                        new Handicap(z.Handicap),
                        new PromUltimoPartido(z.ListaCalificaciones),
                        new PromUltimosNPartidos(z.ListaCalificaciones,z.CantPartidosJugados)
                    }));
                    break;
            }
            //ordeno la lista por posición y aplicando el criterio especificado
            this.ListaJugadores = (from x in ListaJugadores orderby x.Posicion, x.Criterio.AplicarCriterio() select x).ToList();
        }
        #endregion

        public void ArmarEquipos()
        {
            Console.WriteLine("Primer equipo: " + Environment.NewLine);
            this.ArmadorPartido.ArmarPrimerEquipo().ForEach(z => Console.WriteLine(string.Format("{0} {1} Posicion: {2}, ", z.Nombre, z.Apellido, z.Posicion)));
            Console.WriteLine("Segundo equipo: " + Environment.NewLine);
            this.ArmadorPartido.ArmarSegundoEquipo().ForEach(z => Console.WriteLine(string.Format("{0} {1} Posicion: {2}, ", z.Nombre, z.Apellido, z.Posicion)));
        }
    }
}
