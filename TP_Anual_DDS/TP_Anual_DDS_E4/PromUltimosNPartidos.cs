using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class PromUltimosNPartidos : ICriterio
    {
        public int partidos {get;set;}
        private List<int> ListaCalificaciones;

        public string Descripcion
        {
            get { return typeof(PromUltimosNPartidos).Name; }
        }

        public PromUltimosNPartidos(List<int> listaCalificaciones, int cantidadPartidos)
        {
            this.ListaCalificaciones = new List<int>();
            this.ListaCalificaciones = listaCalificaciones;
            this.partidos = cantidadPartidos;
        }

        public double AplicarCriterio()
        {
            return this.ListaCalificaciones.Sum() / this.partidos;
        }
    }
}
