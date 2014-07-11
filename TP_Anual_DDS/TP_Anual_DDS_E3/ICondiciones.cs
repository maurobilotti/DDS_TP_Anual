using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E3
{
    public interface ICondiciones
    {
        /// <summary>
        /// establece el valor de la condicion a evaluar
        /// </summary>
        void EstablecerCondicion();

        /// <summary>
        /// evalua la condición deseada sobre el partido
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        bool EvaluarCondicion(Partido partido);
    }
}
