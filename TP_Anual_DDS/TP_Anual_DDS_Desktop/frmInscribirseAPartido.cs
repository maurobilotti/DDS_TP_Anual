using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_E4
{
    public partial class frmInscribirseAPartido : Form
    {
        public frmInscribirseAPartido(Usuario usuario, Partido partido)
        {
            InitializeComponent();
            this.Usuario = usuario;
            this.Partido = partido;
        }

        private enum EnumTipo_Jugador
        {
            Condicional = 1, Estandar = 2, Solidario = 3
        }

        public Usuario Usuario { get; set; }
        public Partido Partido { get; set; }

        private void frmInscribirseAPartido_Load(object sender, EventArgs e)
        {
            cmbTipoJugador.DataSource = Interesado.ObtenerTipoJugadores();
            cmbTipoJugador.DisplayMember = "Descripcion";
            cmbTipoJugador.ValueMember = "Id";

            chkCondiciones.DataSource = Condicional.ObtenerCondiciones();
            chkCondiciones.DisplayMember = "Descripcion";
            chkCondiciones.ValueMember = "Id";
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                DDSDataContext db = new DDSDataContext();
                try
                {
                    string descripcionTipo = string.Empty;
                    int idTipo = 0;
                    switch ((int)cmbTipoJugador.SelectedValue)
                    {
                        case 0:
                            idTipo = (int) EnumTipo_Jugador.Condicional;
                            foreach (DataRowView condicion in chkCondiciones.CheckedItems)
                            {
                                int idCondicion = (int)condicion[0];
                                db.Partido_Interesado_Condicional_UI(Partido.Id_Partido, this.Usuario.Interesado.Id_Interesado,
                                    idCondicion, false);
                            }
                            break;
                        case 1:
                            idTipo = (int)EnumTipo_Jugador.Solidario;
                            break;
                        case 2:
                            idTipo = (int)EnumTipo_Jugador.Estandar;
                            break;
                        default:
                            throw new Exception("Tipo jugador incorrecto");
                    }
                    //se inserta la persona para el partido en cuestion
                    db.Partido_Interesado_UI(Partido.Id_Partido, this.Usuario.Interesado.Id_Interesado, idTipo, false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("Los datos ingresados no son correctos.");
            }
        }

        private bool Validar()
        {
            return (Interesado.EnumPrioridad)cmbTipoJugador.SelectedValue != Interesado.EnumPrioridad.Condicional || chkCondiciones.CheckedItems.Count > 0;
        }

        private void cmbTipoJugador_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chkCondiciones.Enabled = (Interesado.EnumPrioridad)cmbTipoJugador.SelectedValue == Interesado.EnumPrioridad.Condicional;
        }


    }
}
