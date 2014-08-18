using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Mail :IMail
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Cuerpo { get; set; }

        public bool EnviarMail() 
        {
            return true;
        }
    }
}
