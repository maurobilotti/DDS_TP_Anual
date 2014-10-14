using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Anual_DDS_E4;

namespace TP_Anual_DDS_E4
{
    public partial class frmPrincipal : Form
    {
        #region Propiedades
        public bool EsAdministrador { get; set; }
        public List<Interesado> ListaUsuarios { get; set; }
        public Interesado Usuario { get; set; }

        private bool EstaLogueado = false;

        #endregion

        #region Constructor
        public frmPrincipal()
        {
            InitializeComponent();
            this.ListaUsuarios = Administrador.ObtenerInstancia().CargarUsuariosIniciales().Select(x => x.Interesado).ToList();
            DeshablitarControles();
        }
        #endregion

        private void DeshablitarControles()
        {
            // se deshablitan todos los controles que no van al principio.
            btnProponerAmigo.Enabled =
            btnFinalizarPartido.Visible =
            btnNuevoPartido.Enabled =
            btnConfirmar.Enabled =
            btnCriterios.Enabled =
            btnBaja.Enabled =
            btnInscribirse.Enabled = false;
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
            //Guid IdPartido1 = Administrador.ObtenerInstancia().CrearPartido(new Partido("Ciudad Jardin", DateTime.Now));
            //Guid IdPartido2 = Administrador.ObtenerInstancia().CrearPartido(new Partido("Caballito", DateTime.Now));
            //Administrador.ObtenerInstancia().CrearPartido(new Partido("Flores", DateTime.Now));
            //Administrador.ObtenerInstancia().CrearPartido(new Partido("Parque Avellaneda", DateTime.Now));

            //Administrador.ObtenerInstancia().CargarUsuariosIniciales();

            //Partido partido1 = Administrador.ObtenerInstancia().ObtenerPartido(IdPartido1);
            //Administrador.ObtenerInstancia().CompletarJugadoresPartido(partido1);
            //Partido partido2 = Administrador.ObtenerInstancia().ObtenerPartido(IdPartido2);
            //Administrador.ObtenerInstancia().CompletarJugadoresPartido(partido2);

            Actualizar();
        }

        private void HabilitarControles()
        {
            btnNuevoPartido.Enabled = btnCriterios.Enabled = btnConfirmar.Enabled = EsAdministrador;
            btnInscribirse.Enabled = btnProponerAmigo.Enabled = !EsAdministrador;
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
                int idSeleccionado = (int)gridPartidos.SelectedCells[0].Value;
                Partido partido = Administrador.ObtenerInstancia().ObtenerPartidos().Single(z => z.Id_Partido == idSeleccionado);
                if (partido.Confirmado)
                    return;

                if (!partido.EstaInscripto(Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario).Interesado))
                {
                    var frmJugador = new frmInscribirseAPartido(Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario));
                    if (frmJugador.ShowDialog() == DialogResult.OK)
                    {
                        partido.AgregarJugador(frmJugador.Usuario);
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
                lblUsuario.Visible = true;
                this.EsAdministrador = Properties.Settings.Default.EsAdmin;
                EstaLogueado = true;
                HabilitarControles();
                if (!this.EsAdministrador)
                {
                    Usuario usuario = Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario);
                    lblUsuario.Text = usuario._Usuario;
                    btnRealizarCriticas.Visible = Administrador.ObtenerInstancia().DebeCriticas(usuario);
                }
                else
                {
                    VerificarUsuariosPropuestos();
                    lblUsuario.Text = "Admin";
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
                var idSeleccionado = (int)gridPartidos.SelectedCells[0].Value;
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
                Partido partido = Administrador.ObtenerInstancia().ObtenerPartido((int)gridPartidos.SelectedCells[0].Value);
                if (partido.Confirmado)
                    return;

                DialogResult resp = MessageBox.Show("Va a ser dado de baja al partido. ¿Desea proponer un reemplazo?", "Advertencia",
                    MessageBoxButtons.YesNoCancel);

                if (resp == DialogResult.No)
                {
                    partido.DarBaja(Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario));
                }
                if (resp == DialogResult.Yes)
                {
                    frmProponerJugador frmProponer = new frmProponerJugador(partido);
                    if (frmProponer.ShowDialog() == DialogResult.OK)
                    {
                        Usuario jugBaja =
                            Administrador.ObtenerInstancia()
                                .ObtenerUsuario(Properties.Settings.Default.IdUsuario);

                        Usuario jugAlta = frmProponer.JugadorPropuesto;
                        jugAlta.Interesado.Tipo = jugBaja.Interesado.Tipo;
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
                Partido partido = Administrador.ObtenerInstancia().ObtenerPartido((int)gridPartidos.SelectedCells[0].Value);
                frmCriterios frm = new frmCriterios(partido);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    gridEquipo1.DataSource = gridEquipo2.DataSource = null;

                    gridEquipo1.DataSource = frm.Partido.ListaPrimerEquipo;
                    gridEquipo2.DataSource = frm.Partido.ListaSegundoEquipo;
                    btnFinalizarPartido.Visible = gridEquipo1.RowCount >= 5 && gridEquipo2.RowCount >= 5;
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (gridInteresados.RowCount >= 10 && gridEquipo1.RowCount > 0 && gridEquipo2.RowCount > 0)
            {
                Administrador.ObtenerInstancia()
                    .ObtenerPartido((int)gridPartidos.SelectedCells[0].Value)
                    .Confirmado = true;
            }
        }

        private void btnFinalizarPartido_Click(object sender, EventArgs e)
        {
            if (gridEquipo1.RowCount >= 5 && gridEquipo2.RowCount >= 5 && gridPartidos.SelectedRows.Count == 1)
            {
                Partido partido = Administrador.ObtenerInstancia().ObtenerPartido((int)gridPartidos.SelectedCells[0].Value);

                if (!partido.Finalizado)
                {
                    partido.Finalizado = true;
                    partido.ListaJugadores.ForEach(z => z.Interesado.ListaPartidosFinalizados.Add(partido));
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
            frmCriticas frm = new frmCriticas(critico.Interesado.ListaPartidosFinalizados, critico.Interesado);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnRealizarCriticas.Visible = Administrador.ObtenerInstancia().DebeCriticas(critico);
            }
        }

        private void gridEquipo1_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridEquipo1.RowCount >= 5)
            {
                for (int i = 0; i < 5 && i <= gridEquipo1.RowCount; i++)
                {
                    gridEquipo1.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                }
            }
        }

        private void gridEquipo2_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridEquipo2.RowCount >= 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    gridEquipo2.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                }
            }
        }

        private void btnVerCriticas_Click(object sender, EventArgs e)
        {
            frmCriticas frm = new frmCriticas(Administrador.ObtenerInstancia().ObtenerPartidos());
            frm.ShowDialog();
        }
    }
}
