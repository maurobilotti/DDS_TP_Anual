using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_Desktop
{
    public partial class frmNuevoJugador : Form
    {
        public frmNuevoJugador()
        {
            InitializeComponent();
        }

        public Interesado Jugador { get; set; }

        private void frmNuevoJugador_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Jugador = new Interesado(txtNombre.Text, txtApellido.Text, (int) numEdad.Value, txtMail.Text,
                    (int) numPosicion.Value, (int)numHandicap.Value, 0);

                //using (var db = new Model2Container())
                //{
                //    var interesado = new DbInteresado()
                //    {
                //        IdInteresado = Jugador.IdInteresado,
                //        Nombre = Jugador.Nombre,
                //        Apellido = Jugador.Apellido,
                //        Edad = Jugador.Edad,
                //        Email = Jugador.Mail,
                //        Posicion = Jugador.Posicion,
                //        Handicap = Jugador.Handicap
                //    };

                //    db.DbInteresadoSet.Add(interesado);
                //    db.SaveChanges();
                //}
            }
        }

        private bool Validar()
        {
            return !string.IsNullOrEmpty(txtNombre.Text) &&
                   !string.IsNullOrEmpty(txtApellido.Text) &&
                   !string.IsNullOrEmpty(txtMail.Text);

        }

        public Interesado ObtenerJugador()
        {
            return this.Jugador;
        }

    }
}
