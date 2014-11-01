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
        public frmRegistrar()
        {
            InitializeComponent();
        }

        public Usuario Usuario { get; set; }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.Usuario = new Usuario(txtUsuario.Text,txtContrasena.Text,
                    new Interesado(txtNombre.Text, txtApellido.Text, (DateTime) dpFechaNacimiento.Value, txtMail.Text,
                        (int) numPosicion.Value, (int) numHandicap.Value, 0));
                
                this.Usuario.Guardar();

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Los datos ingresados no son correctos.");
            }
        }

        private bool Validar()
        {
            return !string.IsNullOrEmpty(txtNombre.Text) &&
                   !string.IsNullOrEmpty(txtApellido.Text) &&
                   !string.IsNullOrEmpty(txtMail.Text) &&
                   new DDSDataContext().DBInteresado.All(z => z.Apellido != txtApellido.Text &&
                   z.Nombre != txtNombre.Text) && 
                   new DDSDataContext().DBUsuario.All(z=> z.Nombre_Usuario != txtUsuario.Text);
        }
    }
}
