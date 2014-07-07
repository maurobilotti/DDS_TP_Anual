using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS
{
    public class Solidario: Interesado
    {

        /// <summary>
        /// costructor de un jugador Solidario
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="edad"></param>
        /// <param name="documento"></param>
        public Solidario(string nombre, string apellido, int edad)
        {
            this.Prioridad = EnumPrioridad.Solidario;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
        }
    }
}
