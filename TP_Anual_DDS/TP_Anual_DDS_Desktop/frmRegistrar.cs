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

namespace TP_Anual_DDS_E4
{
    public partial class frmRegistrar : Form
    {
        #region Constructores
        /// <summary>
        /// constructor para Usuario nuevo.
        /// </summary>
        public frmRegistrar()
        {
            InitializeComponent();
            this.ModoApertura = EnumModoApertura.Nuevo;
        }

        /// <summary>
        /// Se pasa por parámetro el usuario del cual se quieren mostrar los datos
        /// </summary>
        /// <param name="usuario"></param>
        public frmRegistrar(Usuario usuario)
        {
            InitializeComponent();
            this.Usuario = usuario;
            this.ModoApertura = EnumModoApertura.Consulta;
        } 
        #endregion

        #region Variables y miembros
        private enum EnumModoApertura
        {
            Nuevo, Consulta
        }

        public Usuario Usuario { get; set; }
        private EnumModoApertura ModoApertura { get; set; } 
        #endregion

        #region Eventos
        private void frmRegistrar_Load(object sender, EventArgs e)
        {
            if (ModoApertura == EnumModoApertura.Consulta)
            {
                DeshabilitarControles();
                CargarDatosUsuario();
            }
        }
        /// <summary>
        /// evento ejecutado para crear un usuario nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.Usuario = new Usuario(txtUsuario.Text, txtContrasena.Text,
                    new Interesado(txtNombre.Text, txtApellido.Text, (DateTime)dpFechaNacimiento.Value, txtMail.Text,
                        (int)numPosicion.Value, (int)numHandicap.Value, 0));

                this.Usuario.Guardar();

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Los datos ingresados no son correctos.");
            }
        } 
        #endregion

        #region Metodos
        private void CargarDatosUsuario()
        {
            //carga los datos del usuario que se pasa por parametro al formulario
            txtApellido.Text = this.Usuario.Interesado.Apellido;
            txtNombre.Text = this.Usuario.Interesado.Nombre;
            txtMail.Text = this.Usuario.Interesado.Mail;
            txtUsuario.Text = this.Usuario._Usuario;
            numHandicap.Value = (int)this.Usuario.Interesado.Handicap;
            numPosicion.Value = (int)this.Usuario.Interesado.Posicion;
            dpFechaNacimiento.Value = this.Usuario.Interesado.FechaNacimiento;
        }

        private void DeshabilitarControles()
        {
            //deshabilita los controles por estar en modo lectura
            txtApellido.Enabled = txtContrasena.Enabled = txtMail.Enabled
                = txtNombre.Enabled = txtUsuario.Enabled = numHandicap.Enabled =
                numPosicion.Enabled = dpFechaNacimiento.Enabled = btnConfirmar.Enabled = false;
        }

        private bool Validar()
        {
            return !string.IsNullOrEmpty(txtNombre.Text) &&
                   !string.IsNullOrEmpty(txtApellido.Text) &&
                   !string.IsNullOrEmpty(txtMail.Text) &&
                   new DDSDataContext().DBInteresado.All(z => z.Apellido != txtApellido.Text &&
                   z.Nombre != txtNombre.Text) &&
                   new DDSDataContext().DBUsuario.All(z => z.Nombre_Usuario != txtUsuario.Text);
        } 
        #endregion
    }
}
