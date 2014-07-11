using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class PromUltimoPartido :ICriterio
    {
        private List<int> ListaCalificaciones;

        public PromUltimoPartido(List<int> listaCalificaciones)
        {
            this.ListaCalificaciones = new List<int>();
            this.ListaCalificaciones = listaCalificaciones;
        }
        
        public double AplicarCriterio()
        {
            return this.ListaCalificaciones.Sum() / this.ListaCalificaciones.Count; 
        }
    }
}
