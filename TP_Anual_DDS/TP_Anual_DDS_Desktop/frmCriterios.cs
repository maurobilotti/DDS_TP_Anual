using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_E4
{
    public partial class frmCriterios : Form
    {
        public frmCriterios(Partido partido)
        {
            InitializeComponent();
            this.Partido = partido;
        }

        public Partido Partido { get; set; }

        private void frmCriterios_Load(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Tipo", typeof(ArmadorPartido));
            tabla.Columns.Add("Descripcion", typeof(string));

            var nombreClasePadre = typeof(ArmadorPartido);
            List<Type> tiposDerivados = (AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => nombreClasePadre.IsAssignableFrom(p) && p != nombreClasePadre)).ToList();

            foreach (Type tipo in tiposDerivados)
            {
                //le da al armador de partidos la lista segun el ordenamiento especificad

                ArmadorPartido instancia = Activator.CreateInstance(tipo, new object[] { this.Partido.ListaJugadores.OrderBy(z => z.Interesado.Criterio.AplicarCriterio()).ToList() }) as ArmadorPartido;
                tabla.Rows.Add(instancia, tipo.Name);
            }

            cmbCriterio.DataSource = tabla;
            cmbCriterio.DisplayMember = "Descripcion";
            cmbCriterio.ValueMember = "Tipo";
        }

        private void btnAplicarCriterio_Click(object sender, EventArgs e)
        {
            Partido.ArmadorPartido = (ArmadorPartido)cmbCriterio.SelectedValue;
            DialogResult = DialogResult.OK;
        }
    }
}
