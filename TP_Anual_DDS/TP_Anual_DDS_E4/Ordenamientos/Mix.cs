using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Mix : ICriterio
    {
        private List<ICriterio> ListaCriterios;

        public string Descripcion
        {
            get { return typeof(Mix).Name; }
        }

        public Mix(List<ICriterio> listaCriterios)
        {
            this.ListaCriterios = new List<ICriterio>();
            this.ListaCriterios = listaCriterios;
        }

        public double AplicarCriterio()
        {
            return this.ListaCriterios.Count != 0 ? this.ListaCriterios.Sum(x => x.AplicarCriterio()) / this.ListaCriterios.Count : 0;
        }
    }
}
