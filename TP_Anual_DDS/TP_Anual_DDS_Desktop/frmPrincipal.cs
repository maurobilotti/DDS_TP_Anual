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

        private bool EstaLogueado = false;

        #endregion

        public frmPrincipal()
        {
            InitializeComponent();
            this.ListaUsuarios = new List<Interesado>();
            DeshablitarControles();
        }

        private void DeshablitarControles()
        {
            btnFinalizarPartido.Visible = btnNuevoPartido.Enabled = btnConfirmar.Enabled = btnCriterios.Enabled = btnBaja.Enabled = btnInscribirse.Enabled = false;
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
            Guid IdPartido = Administrador.ObtenerInstancia().CrearPartido(new Partido("Ciudad jardin", DateTime.Now));
            Administrador.ObtenerInstancia().CrearPartido(new Partido("Caballito", DateTime.Now));

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Ezequiel", "Barany", 22, "asdasd111@gmail.com", 6, 9, 0, new Estandar()),
                contrasena = "1234",
                usuario = "barany",
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Pablo", "Furst", 22, "asdasd111@gmail.com", 3, 9, 0, new Solidario()),
                contrasena = "1234",
                usuario = "furst"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Mauro", "Bilotti", 25, "asdasd111@gmail.com", 9, 9, 0, new Solidario()),
                contrasena = "1234",
                usuario = "bilotti"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Federico", "Beldevere", 23, "asdasd111@gmail.com", 5, 3, 0, new Estandar()),
                contrasena = "1234",
                usuario = "beldevere"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Augusto", "Bonabia", 22, "asdasd111@gmail.com", 1, 3, 0, new Estandar()),
                contrasena = "1234",
                usuario = "bonabia"
            });


            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Leo", "Messi", 26, "asdasd111@gmail.com", 10, 10, 0, new Estandar()),
                contrasena = "1234",
                usuario = "messi"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Cristiano", "Ronaldo", 29, "asdasd111@gmail.com", 7, 10, 0, new Solidario()),
                contrasena = "1234",
                usuario = "ronaldo"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Sergio", "Aguero", 25, "asdasd111@gmail.com", 9, 10, 0, new Estandar()),
                contrasena = "1234",
                usuario = "aguero"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Marcelo", "Barovero", 30, "asdasd111@gmail.com", 1, 5, 0, new Estandar()),
                contrasena = "1234",
                usuario = "barovero"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Javier", "Mascherano", 31, "asdasd111@gmail.com", 5, 8, 0, new Solidario()),
                contrasena = "1234",
                usuario = "mascherano"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Marcos", "Rojo", 22, "asdasd111@gmail.com", 3, 8, 0, new Estandar()),
                contrasena = "1234",
                usuario = "rojo"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Angel", "Di Maria", 26, "asdasd111@gmail.com", 7, 9, 0, new Estandar()),
                contrasena = "1234",
                usuario = "dimaria"
            });

            Administrador.ObtenerInstancia().CrearUsuario(new Usuario()
            {
                Interesado = new Interesado("Pablo", "Zabaleta", 32, "asdasd111@gmail.com", 4, 7, 0, new Solidario()),
                contrasena = "1234",
                usuario = "zabaleta"
            });

            Partido partido = Administrador.ObtenerInstancia().ObtenerPartido(IdPartido);
            Administrador.ObtenerInstancia().CompletarJugadoresPartido(partido);


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
                        if (gridInteresados.Rows.Count >= 10)
                            btnFinalizarPartido.Enabled = EsAdministrador;
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
                EstaLogueado = true;
                HabilitarControles();
                if (!this.EsAdministrador)
                {
                    Usuario usuario = Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario);
                    lblUsuario.Text = usuario.usuario;
                    lblUsuario.Visible = true;
                    btnRealizarCriticas.Visible = Administrador.ObtenerInstancia().DebeCriticas(usuario);
                }
                else
                {
                    VerificarUsuariosPropuestos();
                    if (gridInteresados.Rows.Count >= 10)
                        btnFinalizarPartido.Visible = true;
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
                if (!EsAdministrador && EstaLogueado)
                {
                    Interesado interesado =
                        Administrador.ObtenerInstancia()
                            .ObtenerUsuario(Properties.Settings.Default.IdUsuario)
                            .Interesado;
                    btnBaja.Enabled = partido.EstaInscripto(interesado);
                }
                gridInteresados.DataSource = partido.ListaJugadores;

                gridEquipo1.DataSource = partido.ArmadorPartido != null ? partido.ListaPrimerEquipo : null;
                gridEquipo2.DataSource = partido.ArmadorPartido != null ? partido.ListaSegundoEquipo : null;
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
                if (partido.Confirmado)
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

                    gridEquipo1.DataSource = frm.Partido.ListaPrimerEquipo;
                    gridEquipo2.DataSource = frm.Partido.ListaSegundoEquipo;
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

        private void btnFinalizarPartido_Click(object sender, EventArgs e)
        {
            if (gridEquipo1.RowCount >= 5 && gridEquipo2.RowCount >= 5 && gridPartidos.SelectedRows.Count == 1)
            {
                Partido partido = Administrador.ObtenerInstancia().ObtenerPartido(new Guid(gridPartidos.SelectedCells[0].Value.ToString()));
                
                if (!partido.Finalizado)
                {
                    partido.Finalizado = true;
                    partido.ListaJugadores.ForEach(z => z.ListaPartidosFinalizados.Add(partido));
                }

                MessageBox.Show(
                    "El partido se ha finalizado correctamente. Los jugadores realizarán las criticas al conectarse al sistema.",
                    "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los equipos no están completos. Revise los jugadores agregados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRealizarCriticas_Click(object sender, EventArgs e)
        {
            Usuario critico = Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario);
            frmCriticas frm = new frmCriticas(critico.Interesado.ListaPartidosFinalizados,critico.Interesado);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnRealizarCriticas.Visible = Administrador.ObtenerInstancia().DebeCriticas(critico);
            }
        }
    }
}
