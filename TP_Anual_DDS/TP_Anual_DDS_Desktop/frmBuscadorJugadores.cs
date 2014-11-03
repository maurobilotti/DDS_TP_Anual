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

            //se ejecuta la primera búsqueda
            FiltrarJugadores();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarJugadores();
        }

        private void FiltrarJugadores()
        {
            DDSDataContext db = new DDSDataContext();
            var tabla = (from x in db.Buscar_Jugadores_L(
                             txtNombre.Text,
                             dtpFechaNacimiento.Value.Date,
                             chkHandicapDesde.Checked ? (int?)numHandicapDesde.Value : null,
                             chkHandicapHasta.Checked ? (int?)numHandicapHasta.Value : null,
                             chkPromedioDesde.Checked ? (int?)numPromedioDesde.Value : null,
                             chkPromedioHasta.Checked ? (int?)numPromedioHasta.Value : null,
                             (int?)cmbInfrantores.SelectedValue).AsEnumerable()
                         select new
                         {
                             x.Nombre,
                             x.Apellido,
                             x.FechaNacimiento,
                             x.Handicap,
                             Promedio = db.PromUltimoPartido(x.Id_Interesado)
                         }).ToList();

            gridJugadoresBuscados.DataSource = null;
            gridJugadoresBuscados.DataSource = tabla;
        }

        private void gridJugadoresBuscados_DoubleClick(object sender, EventArgs e)
        {
            if (gridJugadoresBuscados.SelectedRows.Count == 1)
            {
                var idSeleccionado = (int)gridJugadoresBuscados.SelectedCells[0].Value;
                Usuario usuario = Administrador.ObtenerInstancia().ObtenerUsuario(idSeleccionado);

                frmRegistrar frmRegistrar = new frmRegistrar(usuario);
                frmRegistrar.ShowDialog();
            }
        }

        private void gridJugadoresBuscados_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridJugadoresBuscados.RowCount > 0)
                {
                    foreach (DataGridViewRow row in gridJugadoresBuscados.Rows)
                    {
                        if ((int)row.Cells["Handicap"].Value >= 8)
                        {
                            row.DefaultCellStyle.BackColor = Color.CadetBlue;
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void chkHandicapDesde_CheckedChanged(object sender, EventArgs e)
        {
            numHandicapDesde.Enabled = chkHandicapDesde.Checked;
        }

        private void chkHandicapHasta_CheckedChanged(object sender, EventArgs e)
        {
            numHandicapHasta.Enabled = chkHandicapHasta.Checked;
        }

        private void chkPromedioHasta_CheckedChanged(object sender, EventArgs e)
        {
            numPromedioHasta.Enabled = chkPromedioHasta.Checked;
        }

        private void chkPromedioDesde_CheckedChanged(object sender, EventArgs e)
        {
            numPromedioDesde.Enabled = chkPromedioDesde.Checked;
        }

    }
}
