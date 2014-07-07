using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS
{
    public class Condicional : Interesado
    {
        private List<ICondiciones> Condiciones { get; set; }

        public Condicional(string nombre, string apellido, int edad)
        {
            this.Condiciones = new List<ICondiciones>();
            this.Prioridad = EnumPrioridad.Condicional;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
        }

        public void AgregarCondicion(ICondiciones condicion)
        {
            Condiciones.Add(condicion);
        }

        public override bool PuedoJugarEn(Partido partido)
        {
            //si cumple con todas las condiciones y puede jugar el partido porque hay menos de 10, entonces se añade.
            bool resultado = Condiciones.All(z => z.EvaluarCondicion(partido)) && base.PuedoJugarEn(partido);
            if(!resultado)
                Console.WriteLine("No se cumplen las condiciones para que {0} {1} juegue el partido", this.Nombre, this.Apellido);
            return resultado;
        }

    }
}
