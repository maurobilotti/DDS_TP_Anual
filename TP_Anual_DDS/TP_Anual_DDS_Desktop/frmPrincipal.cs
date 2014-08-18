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
    public partial class frmPrincipal : Form
    {
        #region Propiedades
        public bool EsAdministrador { get; set; }
        public List<Interesado> ListaUsuarios { get; set; }
        public Interesado Usuario { get; set; }

        #endregion

        public frmPrincipal()
        {
            InitializeComponent();
            this.ListaUsuarios = new List<Interesado>();
            DeshablitarControles();
        }

        private void DeshablitarControles()
        {
            btnNuevoPartido.Enabled = btnConfirmar.Enabled = btnCriterios.Enabled = btnBaja.Enabled = btnInscribirse.Enabled = false;
        }

        private void btnAgregarPartido_Click(object sender, EventArgs e)
        {
            var frm = new frmNuevoPartido();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Administrador.ObtenerInstancia().CrearPartido(frm.ObtenerPartido());
                Actualizar();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            DeshablitarControles();
            //-------------------
            Administrador.ObtenerInstancia().CrearPartido(new Partido("Ciudad jardin", DateTime.Now));
            Administrador.ObtenerInstancia().CrearPartido(new Partido("Caballito", DateTime.Now));

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("ezequiel", "Barany", 22, "asdasd111@gmail.com", 6, 9, 0),
                contrasena = "1234",
                usuario = "barany"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("pablo", "furst", 22, "asdasd111@gmail.com", 3, 9, 0),
                contrasena = "1234",
                usuario = "furst"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("mauro", "bilotti", 25, "asdasd111@gmail.com", 9, 9, 0),
                contrasena = "1234",
                usuario = "bilotti"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("federico", "beldevere", 23, "asdasd111@gmail.com", 5, 3, 0),
                contrasena = "1234",
                usuario = "beldevere"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("augusto", "bonabia", 22, "asdasd111@gmail.com", 1, 3, 0),
                contrasena = "1234",
                usuario = "bonabia"
            });

            Actualizar();



        }

        private void HabilitarControles()
        {
            btnNuevoPartido.Enabled = btnCriterios.Enabled = btnConfirmar.Enabled = EsAdministrador;
            btnInscribirse.Enabled = !EsAdministrador;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Actualizar()
        {
            gridPartidos.DataSource = null;
            gridPartidos.DataSource = Administrador.ObtenerInstancia().ObtenerPartidos();
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (gridPartidos.SelectedRows.Count == 1)
            {
                var idSeleccionado = new Guid(gridPartidos.SelectedCells[0].Value.ToString());
                Partido partido = Administrador.ObtenerInstancia().ObtenerPartidos().Single(z => z.IdPartido == idSeleccionado);
                if (partido.Confirmado)
                    return;

                if (!partido.EstaInscripto(Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario).Interesado))
                {
                    var frmJugador = new frmInscribirseAPartido(Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario));
                    if (frmJugador.ShowDialog() == DialogResult.OK)
                    {
                        partido.AgregarInteresado(frmJugador.Usuario.Interesado);
                        gridInteresados.DataSource = null;
                        gridInteresados.DataSource = partido.ListaJugadores;
                        btnBaja.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("El jugador está inscripto.");
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DeshablitarControles();
            lblUsuario.Text = "";
            lblUsuario.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var frm = new frmLogin();
            frm.ListaInteresados = this.ListaUsuarios;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.EsAdministrador = Properties.Settings.Default.EsAdmin;
                HabilitarControles();
                if (!this.EsAdministrador)
                {
                    lblUsuario.Text = Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario).usuario;
                    lblUsuario.Visible = true;
                }
                else
                {
                    VerificarUsuariosPropuestos();
                }
            }
        }

        private void VerificarUsuariosPropuestos()
        {
            if (this.EsAdministrador)
            {
                for (int i = Administrador.ObtenerInstancia().ObtenerUsuariosPropuestos().Count - 1; i >= 0; i--)
                {
                    Usuario usuarioProp = Administrador.ObtenerInstancia().ObtenerUsuariosPropuestos()[i];

                    DialogResult resp =
                        MessageBox.Show(
                            string.Format("Desea aceptar al usuario {0} {1} ?", usuarioProp.Interesado.Nombre,
                                usuarioProp.Interesado.Apellido), "Advertencia", MessageBoxButtons.YesNo);

                    if (resp == DialogResult.Yes)
                    {
                        Administrador.ObtenerInstancia().CrearUsuario(usuarioProp);

                    }
                    else
                    {
                        frmDenegacion frm = new frmDenegacion();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            Administrador.ObtenerInstancia().RegistrarMotivoRechazo(usuarioProp, frm.MotivoRechazo);
                        }
                    }

                    Administrador.ObtenerInstancia().QuitarUsuarioPropuesto(usuarioProp);
                }
            }
        }

        private void gridEquipo1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void gridPartidos_Click(object sender, EventArgs e)
        {
            EvaluarEstadoGrilla();
        }

        private void EvaluarEstadoGrilla()
        {
            if (gridPartidos.SelectedRows.Count == 1)
            {
                var idSeleccionado = new Guid(gridPartidos.SelectedCells[0].Value.ToString());
                Partido partido = Administrador.ObtenerInstancia().ObtenerPartido(idSeleccionado);
                btnBaja.Enabled =
                    partido.EstaInscripto(
                        Administrador.ObtenerInstancia()
                            .ObtenerUsuario(Properties.Settings.Default.IdUsuario)
                            .Interesado);
                gridInteresados.DataSource = partido.ListaJugadores;
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            frmRegistrar frm = new frmRegistrar();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Administrador.ObtenerInstancia().CrearUsuario(frm.Usuario);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (gridPartidos.SelectedRows.Count == 1)
            {
                Partido partido = Administrador.ObtenerInstancia().ObtenerPartido(new Guid(gridPartidos.SelectedCells[0].Value.ToString()));
                if(partido.Confirmado)
                    return;

                DialogResult resp = MessageBox.Show("Va a ser dado de baja al partido. ¿Desea proponer un reemplazo?", "Advertencia",
                    MessageBoxButtons.YesNoCancel);

                if (resp == DialogResult.No)
                {
                    partido.DarBaja(Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario).Interesado);
                }
                if (resp == DialogResult.Yes)
                {
                    frmProponerJugador frmProponer = new frmProponerJugador(partido);
                    if (frmProponer.ShowDialog() == DialogResult.OK)
                    {
                        Interesado jugBaja =
                            Administrador.ObtenerInstancia()
                                .ObtenerUsuario(Properties.Settings.Default.IdUsuario)
                                .Interesado;

                        Interesado jugAlta = frmProponer.JugadorPropuesto;
                        jugAlta.Tipo = jugBaja.Tipo;
                        partido.DarBaja(jugBaja, jugAlta);
                    }
                }
                gridInteresados.DataSource = null;
                gridInteresados.DataSource = partido.ListaJugadores;
                EvaluarEstadoGrilla();
            }
        }

        private void btnProponerAmigo_Click(object sender, EventArgs e)
        {
            frmRegistrar frm = new frmRegistrar();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Administrador.ObtenerInstancia().CrearUsuarioPropuesto(frm.Usuario);
            }
        }

        private void btnCriterios_Click(object sender, EventArgs e)
        {
            if (gridInteresados.RowCount >= 10)
            {
                Partido partido = Administrador.ObtenerInstancia().ObtenerPartido(new Guid(gridPartidos.SelectedCells[0].Value.ToString()));
                frmCriterios frm = new frmCriterios(partido);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    gridEquipo1.DataSource = gridEquipo2.DataSource = null;
                    gridEquipo1.DataSource = frm.Partido.ArmadorPartido.ArmarPrimerEquipo();
                    gridEquipo2.DataSource = frm.Partido.ArmadorPartido.ArmarSegundoEquipo();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (gridInteresados.RowCount >= 10 && gridEquipo1.RowCount > 0 && gridEquipo2.RowCount > 0)
            {
                Administrador.ObtenerInstancia()
                    .ObtenerPartido(new Guid(gridPartidos.SelectedCells[0].Value.ToString()))
                    .Confirmado = true;
            }
        }
    }
}
