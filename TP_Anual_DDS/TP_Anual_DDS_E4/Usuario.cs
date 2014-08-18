using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Usuario
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public Interesado Interesado { get; set; }
        public Guid IdUsuario { get; set; }

        public Usuario()
        {
            this.IdUsuario = Guid.NewGuid();
        }
    }
}
