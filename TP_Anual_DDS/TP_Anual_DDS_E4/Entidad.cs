using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_E4
{
    public abstract class Entidad
    {
        protected virtual void Guardar(string nombreSP, List<Parametro> parametros )
        {
            Ejecutar(nombreSP, parametros);
        }

        protected virtual void Actualizar(string nombreSP, List<Parametro> parametros)
        {
            Ejecutar(nombreSP,parametros);
        }

        private void Ejecutar(string nombreSP, List<Parametro> parametros)
        {
            BaseDatos bd = new BaseDatos(nombreSP);
            bd.pTipoComando = CommandType.StoredProcedure;
            parametros.ForEach(z => bd.pParametros.Add(z.pParametro));
            bd.Ejecutar();
        }

        public DataTable Obtener(string nombreSP, List<Parametro> parametros)
        {
            BaseDatos bd = new BaseDatos(nombreSP);
            bd.pTipoComando = CommandType.StoredProcedure;
            parametros.ForEach(z => bd.pParametros.Add(z.pParametro));
            return bd.ObtenerDataTable();
        }
    }
}
