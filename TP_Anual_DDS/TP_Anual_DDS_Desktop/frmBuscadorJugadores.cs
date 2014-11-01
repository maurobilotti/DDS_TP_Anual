using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Anual_DDS_E4
{
    public partial class frmBuscadorJugadores : Form
    {
        public frmBuscadorJugadores()
        {
            InitializeComponent();
        }

        private void frmBuscadorJugadores_Load(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("Descripcion", typeof(string));

            tabla.Rows.Add(-1, "TODOS");
            tabla.Rows.Add(0, "Sin infracciones");
            tabla.Rows.Add(1, "Con infracciones");

            cmbInfrantores.DataSource = tabla;
            cmbInfrantores.DisplayMember = "Descripcion";
            cmbInfrantores.ValueMember = "Id";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //if (validarDatos())
            //{
            //    var tabla = new DDSDataContext().Buscar_Jugadores_L(
            //        !string.IsNullOrEmpty(txtNombre.Text) ? txtNombre.Text : null,
            //        dtpFechaNacimiento.Value,
            //        numHandicapDesde.Value != -1 ? numHandicapDesde.Value : null,
            //        numHandicapHasta.Value != -1 ? numHandicapHasta.Value : null,
            //        txtPromDesde.Text,
            //        txtPromHasta.Text,
            //        cmbInfrantores.SelectedValue
            //        ).AsEnumerable().ToList();

            //    gridJugadoresBuscados.DataSource = null;
            //    gridJugadoresBuscados.DataSource = tabla;

            //}
        }

        private bool validarDatos()
        {
            if ((!string.IsNullOrEmpty(txtPromDesde.Text) && string.IsNullOrEmpty(txtPromHasta.Text)) ||
                string.IsNullOrEmpty(txtPromDesde.Text) && !string.IsNullOrEmpty(txtPromHasta.Text))
            {
                Console.WriteLine("Debe seleccionar promedio desde y hasta.");
                return false;
            }
          
            return true;
        }

        private void gridBuscadorJugadores_Click(object sender, EventArgs e)
        {
            if (gridJugadoresBuscados.SelectedRows.Count == 1)
            {
                var idSeleccionado = (int) gridJugadoresBuscados.SelectedCells[0].Value;
                Usuario usuario = Administrador.ObtenerInstancia().ObtenerUsuario(idSeleccionado);

                frmRegistrar frmRegistrar = new frmRegistrar(usuario);
                frmRegistrar.ShowDialog();
            }
        }
    }
}
