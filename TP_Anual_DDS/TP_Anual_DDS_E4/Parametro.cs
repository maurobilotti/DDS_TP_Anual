using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Parametro
    {
        public SqlParameter pParametro { get; set; }
        public Parametro(string nombreParametro, SqlDbType tipo, object valor)
        {
            pParametro = new SqlParameter(nombreParametro,tipo);
            this.pParametro.Value = valor;
        }
    }
}
