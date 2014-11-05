using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Anual_DDS_E4
{
    public partial class frmOrdenamiento : Form
    {
        public frmOrdenamiento(Partido partido)
        {
            InitializeComponent();
            this.Partido = partido;
        }

        public Partido Partido { get; set; }

        private void frmOrdenamiento_Load(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Tipo", typeof(char));
            tabla.Columns.Add("Descripcion", typeof(string));

            var nombreClasePadre = typeof(ICriterio);
            List<Type> tiposDerivados = (AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => nombreClasePadre.IsAssignableFrom(p) && p != nombreClasePadre)).ToList();

            foreach (Type tipo in tiposDerivados)
            {
                tabla.Rows.Add((char)tipo.Name[0], tipo.Name);
            }

            chkCriterioOrdenamiento.DataSource = tabla;
            chkCriterioOrdenamiento.DisplayMember = "Descripcion";
            chkCriterioOrdenamiento.ValueMember = "Tipo";
        }

        private void btnAplicarOrdenamiento_Click(object sender, EventArgs e)
        {
            if (chkCriterioOrdenamiento.SelectedItems.Count == 1)
            {
                Partido.AgregarCriterio((char)chkCriterioOrdenamiento.SelectedValue);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Debe seleccionar solo un item de la colección.");
            }
        }
    }
}
