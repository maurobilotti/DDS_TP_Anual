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
        #region Constructor
        public frmInscribirseAPartido(Usuario usuario, Partido partido)
        {
            InitializeComponent();
            this.Usuario = usuario;
            this.Partido = partido;
        } 
        #endregion

        #region Miembros
        private enum EnumTipo_Jugador
        {
            Condicional = 1, Estandar = 3, Solidario = 2
        }

        public Usuario Usuario { get; set; }
        public Partido Partido { get; set; }
        public int Id_TipoJugador { get; set; }
        public List<int> Condiciones { get; set; } 
        #endregion

        #region Eventos
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
                switch ((int)cmbTipoJugador.SelectedValue)
                {
                    case 1: //Condicional
                        this.Id_TipoJugador = (int)EnumTipo_Jugador.Condicional;
                        Condiciones = new List<int>();
                        foreach (DataRowView condicion in chkCondiciones.CheckedItems)
                            Condiciones.Add((int)condicion[0]);

                        break;
                    case 2: //Solidario
                        this.Id_TipoJugador = (int)EnumTipo_Jugador.Solidario;
                        break;
                    case 3: //Estandar
                        this.Id_TipoJugador = (int)EnumTipo_Jugador.Estandar;
                        break;
                }

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Los datos ingresados no son correctos.");
            }
        }

        private void cmbTipoJugador_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chkCondiciones.Enabled = (Interesado.EnumPrioridad)cmbTipoJugador.SelectedValue == Interesado.EnumPrioridad.Condicional;
        }
        
        #endregion

        #region Metodos
        private bool Validar()
        {
            return (Interesado.EnumPrioridad)cmbTipoJugador.SelectedValue != Interesado.EnumPrioridad.Condicional || chkCondiciones.CheckedItems.Count > 0;
        } 
        #endregion
    }
}
