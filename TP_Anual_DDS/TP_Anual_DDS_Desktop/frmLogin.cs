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


namespace TP_Anual_DDS_Desktop
{
    public partial class frmLogin : Form
    {
        public List<Interesado> ListaInteresados { get; set; }
        public Usuario Usuario { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtContraseña.Text))
            {
                if (txtUsuario.Text == "admin" && txtContraseña.Text == "admin")
                {
                    Properties.Settings.Default.EsAdmin = true;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    //sera PERSISTIDO
                    Usuario usuario = Administrador.ObtenerInstancia().ObtenerUsuario(txtUsuario.Text,txtContraseña.Text);
                    if (usuario != null)
                    {
                        Properties.Settings.Default.EsAdmin = false;
                        Properties.Settings.Default.IdUsuario = usuario.IdUsuario;
                        this.Usuario = usuario;
                        DialogResult = DialogResult.OK;
                    }
                    else
                        lblError.Visible = true;
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }
    }
}
