using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Denegacion
    {
        public Interesado JugadorRechazado { get; set; }
        public string motivo { get; set; }
        public DateTime fechaDenegacion { get; set; }

        public Denegacion(Interesado principal, string motivo, DateTime fecha)
        {
            this.JugadorRechazado = principal;
            this.motivo = motivo;
            this.fechaDenegacion = fecha;
        }
    }
}
