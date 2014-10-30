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
                switch ((int)cmbTipoJugador.SelectedValue)
                {
                    case 0:
                        //Usuario.Interesado.Tipo = new Condicional();

                        //foreach (DataRowView condicion in chkCondiciones.CheckedItems)
                        //{
                        //    Usuario.Interesado.Tipo.AgregarCondicion((ICondiciones)condicion[0]);
                        //}
                        db.Partido_Interesado_UI(Partido.Id_Partido, Usuario.Interesado.Id_Interesado,
                            typeof(Condicional).Name, false);
                        break;
                    case 1:
                        db.Partido_Interesado_UI(Partido.Id_Partido, Usuario.Interesado.Id_Interesado,
                            typeof (Solidario).Name, false);
                        break;
                    default:
                        db.Partido_Interesado_UI(Partido.Id_Partido, Usuario.Interesado.Id_Interesado,
                            typeof(Estandar).Name, false);
                        break;
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
