using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS
{
    class Estandar : Interesado
    {
        public Estandar(string nombre, string apellido, int edad)
        {
            Prioridad = EnumPrioridad.Estandar;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
        }
    }
}
