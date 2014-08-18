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
    public partial class frmRegistrar : Form
    {
        public frmRegistrar()
        {
            InitializeComponent();
        }

        public Usuario Usuario { get; set; }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.Usuario = new Usuario()
                {
                    contrasena = txtContrasena.Text,
                    usuario = txtUsuario.Text,
                    Interesado =
                        new Interesado(txtNombre.Text, txtApellido.Text, (int)numEdad.Value, txtMail.Text,
                            (int)numPosicion.Value, (int)numHandicap.Value, 0)

                };

                DialogResult = DialogResult.OK;
            }
        }

        private bool Validar()
        {
            return !string.IsNullOrEmpty(txtNombre.Text) &&
                   !string.IsNullOrEmpty(txtApellido.Text) &&
                   !string.IsNullOrEmpty(txtMail.Text);
        }
    }
}
