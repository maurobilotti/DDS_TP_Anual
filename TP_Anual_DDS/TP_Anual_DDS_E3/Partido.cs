using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Partido
    {
        #region Propiedades
        public DateTime fechaHora { get; set; }
        public string lugar { get; set; }
        private List<Denegacion> listaDenegaciones { get; set; }
        public List<Interesado> listaJugadores {get;set;}
        private List<Interesado> listaInfractores { get; set; }
        public List<Calificacion> listaCalificaciones { get; set; }
        public Interesado Interesado
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        #endregion     

        #region Constructores

        public Partido() { }
        public Partido(string lugar, DateTime fechaHora) 
        {
            this.listaJugadores = new List<Interesado>();
            this.listaInfractores = new List<Interesado>();
            this.listaDenegaciones = new List<Denegacion>();
            this.listaCalificaciones = new List<Calificacion>();
            this.fechaHora = fechaHora;
            this.lugar = lugar;
        }
        #endregion

        #region Métodos públicos

        internal void AgregarCalificaciones()
        {
            foreach (Interesado jugadorCritico in this.listaJugadores)
            {
                foreach (Interesado jugadorCriticado in this.listaJugadores)
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
                            esValido = int.TryParse(Console.Read().ToString(), out calificacion);
                            if (calificacion > 5 && calificacion < 0)
                            {
                                Console.WriteLine("Los valores de calificacion deben estar entre 0 y 5.");
                                esValido = false;
                            }
                        }
                        this.AgregarCalificacion(new Calificacion(jugadorCritico, jugadorCriticado, critica, calificacion));
                        Console.WriteLine("--->Presione una tecla para continuar");
                        Console.ReadKey();
                    }
                }
            }
        }

        internal void AgregarSugeridos()
        {
            if (this.listaJugadores.Count > 0)
            {
                for (int i = this.listaJugadores.Count - 1; i >= 0; i--)
                {
                    string nombrePrincipal = this.listaJugadores[i].Nombre;
                    string apellidoPrincipal = this.listaJugadores[i].Apellido;
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
                            esValido = int.TryParse(Console.ReadLine().ToString(), out edadAmigo);
                        }
                        Console.WriteLine("Ingrese el mail y presione 'enter',:");
                        string mailAmigo = Console.ReadLine();

                        this.listaJugadores[i].AgregarAmigo(new Interesado(nombreAmigo, apellidoAmigo, edadAmigo, mailAmigo));
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
                                    this.listaJugadores[i].listaAmigos[0].Tipo = new Condicional();
                                }
                                break;
                            case 'E':
                            case 'e':
                                {
                                    this.listaJugadores[i].listaAmigos[0].Tipo = new Estandar();
                                }
                                break;
                            case 'S':
                            case 's':
                                {
                                    this.listaJugadores[i].listaAmigos[0].Tipo = new Solidario();
                                }
                                break;
                            default:
                                //si se equivoca la tecla, se crea estandar
                                this.listaJugadores[i].listaAmigos[0].Tipo = new Estandar();
                                break;
                        }
                        //se agrega el jugador al partido
                        this.AgregarInteresado(this.listaJugadores[i].listaAmigos[0]);

                    }
                    else if (resp == 'N' || resp == 'n')
                    {
                        //limpia el buffer de entrada
                        Console.ReadLine();
                        Console.WriteLine("Ingrese el motivo de la denegación del jugador");
                        string motivo = Console.ReadLine();
                        //se añade el jugador que sugiere, el motivo y la fecha de la denegación
                        this.AgregarDenegacion(new Denegacion(this.listaJugadores[i], motivo, DateTime.Now));
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
                if (listaJugadores.Count < 10)
                {
                    listaJugadores.Add(interesado);
                    interesado.EstasIncriptoEn(this);
                    if (listaJugadores.Count == 10)
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
                        if(!BuscarYEliminar(interesado, Interesado.EnumPrioridad.Condicional))//Busca si hay condicional.
                            BuscarYEliminar(interesado, Interesado.EnumPrioridad.Solidario);//Busca si hay solidario.
                    }
                }
                ChequearCondicionales();
            }
            return true;
        }

        public void DarBaja(Interesado interesadoBaja) 
        {
            this.listaJugadores.Remove(interesadoBaja);
            this.listaInfractores.Add(interesadoBaja);//Se agrega a una lista de infractores.
        }

        public void DarBaja(Interesado interesadoBaja, Interesado interesadoAlta)
        {
            this.listaJugadores.Remove(interesadoBaja);
            this.listaJugadores.Add(interesadoAlta);
        }

        public void AgregarDenegacion(Denegacion denegacion)
        {
            this.listaDenegaciones.Add(denegacion);
        }

        #endregion

        #region Métodos privados

        private void ChequearCondicionales() 
        {
            foreach (Interesado interes in this.listaJugadores)
            {
                if (!interes.Tipo.PuedoJugarEn(this))
                {
                    this.listaJugadores.Remove(interes);
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
            foreach (Interesado interes in this.listaJugadores)
            {
                if (interes.Tipo.Prioridad == prioridadDeIngresanteAVolar)
                {
                    listaJugadores.Remove(interes);
                    listaJugadores.Add(interesadoAIngresar);
                    interesadoAIngresar.EstasIncriptoEn(this);
                    if (listaJugadores.Count == 10)
                        Console.WriteLine("La lista está completa.");
                    return true;
                }
            }
            return false;
        }


        private void AgregarCalificacion(Calificacion calificacion)
        {
            listaCalificaciones.Add(calificacion);
        }
        #endregion        
    }
}
