using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class NUltimosPartidosPromedio : ICriterio
    {
        public int partidos { get; set; }
        private List<int> ListaCalificaciones;

        public string Descripcion
        {
            get { return typeof(NUltimosPartidosPromedio).Name; }
        }

        public NUltimosPartidosPromedio(List<int> listaCalificaciones, int cantidadPartidos)
        {
            this.ListaCalificaciones = new List<int>();
            this.ListaCalificaciones = listaCalificaciones;
            this.partidos = cantidadPartidos;
        }

        public double AplicarCriterio()
        {
            return this.partidos != 0 ? this.ListaCalificaciones.Sum() / this.partidos : 0;
        }
    }
}
