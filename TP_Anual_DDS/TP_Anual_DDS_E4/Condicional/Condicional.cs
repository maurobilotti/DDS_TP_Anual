using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual_DDS_E4;
using System.Data;

namespace TP_Anual_DDS_E4
{
    public class Condicional : TipoJugador
    {
        public List<ICondiciones> Condiciones { get; set; }

        public string  Descripcion { get { return typeof (Condicional).Name; }}
       
        public Condicional()
        {
            this.Id_TipoJugador = 1;
            this.Condiciones = new List<ICondiciones>();
            this.Prioridad =  Interesado.EnumPrioridad.Condicional;
        }

        public override void AgregarCondicion(ICondiciones condicion)
        {
            Condiciones.Add(condicion);
        }

        public override bool PuedoJugarEn(Partido partido)
        {
            //return Condiciones.All(z => z.EvaluarCondicion(partido));
            return true; //no está aplicandose la lógica
        }

        public static DataTable ObtenerCondiciones()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("Descripcion", typeof(string));

            var nombreInterfaz = typeof(ICondiciones);
            List<Type> tiposDerivados = (AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => nombreInterfaz.IsAssignableFrom(p) && p != nombreInterfaz)).ToList();

            int i = 1;
            foreach (Type tipo in tiposDerivados)
            {
                tabla.Rows.Add(i, tipo.Name);
                i++;
            }

            return tabla;
        }

    }
}
