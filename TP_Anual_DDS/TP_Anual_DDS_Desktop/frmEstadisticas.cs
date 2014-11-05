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
    public partial class frmEstadisticas : Form
    {
        public frmEstadisticas()
        {
            InitializeComponent();
        }

        private void frmEstadisticas_Load(object sender, EventArgs e)
        {
            DDSDataContext db = new DDSDataContext();
            gridConFuturo.DataSource = (from x in db.ObtenerJugadoresConFuturo() select new {x.Nombre,x.Apellido,x.FechaNacimiento,x.Mail,x.Handicap,x.Posicion,x.CantPartidosJugados}).ToList();
            gridMalos.DataSource = (from x in db.ObtenerJugadoresMalos() select new { x.Nombre, x.Apellido, x.FechaNacimiento, x.Mail, x.Handicap, x.Posicion, x.CantPartidosJugados }).ToList();
            gridTraicioneros.DataSource = (from x in db.ObtenerJugadoresTraicioneros() select new { x.Nombre, x.Apellido, x.FechaNacimiento, x.Mail, x.Handicap, x.Posicion, x.CantPartidosJugados }).ToList();
        }
    }
}
