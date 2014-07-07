using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS
{
    public abstract class Interesado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public enum EnumPrioridad
        {
            Condicional, Solidario, Estandar
        }
        public EnumPrioridad Prioridad { get; set; }

        /// <summary>
        /// Evalua si un jugador puede estar en un partido, siempre y cuando la lista no tenga 10 jugadores Estandar.
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        public virtual bool PuedoJugarEn(Partido partido)
        {
            if (partido.Jugadores.Count(z => z.Prioridad == EnumPrioridad.Estandar) < 10)
            {
                return EvaluarPrioridad(partido.Jugadores);
            }
            Console.WriteLine("La lista de jugadores se encuentra completa. Debe esperar otro partido.");
            return false;
        }
        /// <summary>
        /// Método que sirve para Estandar y para Solidario, ya que en orden de prioridad
        /// Estandar > Solidario > Condicional
        /// </summary>
        /// <param name="jugadores"></param>
        /// <returns></returns>
        public virtual bool EvaluarPrioridad(List<Interesado> jugadores)
        {
            //si la lista está vacía, incluyo uno
            if (jugadores.Count < 10)
                return true;

            //si la prioridad es mayor, elimina al jugador y se mete en la lista
            foreach (Interesado jugador in jugadores)
            {
                if ((int)this.Prioridad > (int)jugador.Prioridad)
                {
                    Console.WriteLine("Se elimina al jugador {0} {1} y se agrega el jugador {2} {3}", jugador.Nombre,jugador.Apellido,this.Nombre,this.Apellido);
                    jugadores.Remove(jugador);
                    //se agrega en un nivel arriba
                    return true;
                }
            }

            Console.WriteLine("Los jugadores en la lista tiene mayor prioridad que {0} {1} por ser de tipo {2}",this.Nombre,this.Apellido,this.Prioridad.ToString());
            return false;
        }

    }
}
