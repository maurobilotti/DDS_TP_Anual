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

        #region Eventos
        private void btnAgregarPartido_Click(object sender, EventArgs e)
        {
            var frm = new frmNuevoPartido();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Administrador.ObtenerInstancia().CrearPartido(frm.ObtenerPartido());
                CargarPartidos();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            DeshablitarControles();
            EvaluarEstadoGrilla();
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (gridPartidos.SelectedRows.Count == 1)
            {
                int idSeleccionado = (int)gridPartidos.SelectedCells[0].Value;
                Partido partido = Administrador.ObtenerInstancia().ObtenerPartidos().Single(z => z.Id_Partido == idSeleccionado);

                //si no se cumplean las validaciones del partido, no se puede inscribir
                if (!ValidacionesPartido(partido))
                    return;

                Usuario usuario =
                    Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario);

                if (!partido.EstaInscripto(usuario.Interesado))
                {
                    DDSDataContext db = new DDSDataContext();
                    DBPartido_Interesado partidoInteresado = (from x in db.DBPartido_Interesado
                                                              where x.Id_Partido == partido.Id_Partido && x.Id_Interesado == usuario.Interesado.Id_Interesado
                                                              select x).SingleOrDefault();
                    if (partidoInteresado != null)
                    {
                        partidoInteresado.Baja = false;
                        partido.ListaJugadores.Add(usuario);
                        db.SubmitChanges();
                        EvaluarEstadoGrilla();
                        return;
                    }

                    var frmInscribirJugador = new frmInscribirseAPartido(Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario), partido);
                    if (frmInscribirJugador.ShowDialog() == DialogResult.OK)
                    {
                        if (!partido.AgregarJugador(frmInscribirJugador.Usuario, frmInscribirJugador.Id_TipoJugador,
                            frmInscribirJugador.Condiciones))
                        {
                            MessageBox.Show("No es posible incluir al jugador en el partido seleccionado.");
                            return;
                        }
                        gridInteresados.DataSource = null;
                        gridInteresados.DataSource = partido.ObtenerListaJugadoresInteresados();
                        lblCount.Text = gridInteresados.RowCount.ToString();
                        btnBaja.Enabled = true;
                        if (gridInteresados.Rows.Count >= 10 && EsAdministrador)
                        {
                            btnFinalizarPartido.Enabled = EsAdministrador;
                            btnCriterios.Enabled = true;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("El jugador está inscripto.");
                }
            }
        }

        private bool ValidacionesPartido(Partido partido)
        {
            if (partido.Confirmado)
            {
                MessageBox.Show("El partido ya fue confirmado, por lo que no es posible inscribirse");
                return false;
            }

            return true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DeshablitarControles();
            LimpiarGrillas();
            lblUsuario.Text = "";
            lblUsuario.Visible = false;
        }

        private void LimpiarGrillas()
        {
            gridPartidos.DataSource = gridEquipo1.DataSource = gridEquipo2.DataSource = gridInteresados.DataSource = null;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var frm = new frmLogin();
            frm.ListaInteresados = this.ListaUsuarios;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarPartidos();
                ResaltarPartidos();
                lblUsuario.Visible = true;
                this.EsAdministrador = Properties.Settings.Default.EsAdmin;
                EstaLogueado = true;
                HabilitarControles();
                if (!this.EsAdministrador)
                {
                    Usuario usuario = Administrador.ObtenerInstancia().ObtenerUsuario(Properties.Settings.Default.IdUsuario);
                    lblUsuario.Text = usuario._Usuario;
                    //btnRealizarCriticas.Visible = Administrador.ObtenerInstancia().DebeCriticas(usuario);
                    btnRealizarCriticas.Visible = true;
                }
                else
                {
                    btnRegistrarse.Enabled = true;
                    VerificarUsuariosPropuestos();
                    lblUsuario.Text = "Admin";
                    if (gridInteresados.Rows.Count >= 10)
                    {
                        btnCriterios.Visible = true;
                        EvaluarEstadoGrilla();
                    }

                }
            }
        }

        private void ResaltarPartidos()
        {
            foreach (DataGridViewRow row in gridPartidos.Rows)
            {
                if (row.Cells["Confirmado"].Value.Equals("True"))
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                if (row.Cells["Finalizado"].Value.Equals("True"))
                    row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }

        }

        private void gridEquipo1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void gridPartidos_Click(object sender, EventArgs e)
        {
            EvaluarEstadoGrilla();
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
                {
                    MessageBox.Show("Ya no es posible darse de baja del partido porque está confirmado");
                    return;
                }

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

                    gridEquipo1.DataSource = (from x in frm.Partido.ListaPrimerEquipo
                                              select new { x.Interesado.NombreYApellido, x.Interesado.FechaNacimiento, x.Interesado.Posicion, x.Interesado.Handicap }).ToList();
                    frm.Partido.RegistrarPrimerEquipo();
                    gridEquipo2.DataSource = (from x in frm.Partido.ListaSegundoEquipo
                                              select new { x.Interesado.NombreYApellido, x.Interesado.FechaNacimiento, x.Interesado.Posicion, x.Interesado.Handicap }).ToList();
                    frm.Partido.RegistrarSegundoEquipo();
                    //se habilita el botón confirmar si los equipos están completos y es el admin
                    EvaluarEstadoGrilla();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (gridInteresados.RowCount >= 10 && gridEquipo1.RowCount == 5 && gridEquipo2.RowCount == 5)
            {
                Partido partido = Administrador.ObtenerInstancia()
                    .ObtenerPartido((int)gridPartidos.SelectedCells[0].Value);
                partido.Confirmado = true;

                //confirma el partido en la base de datos
                partido.Confirmar();

                btnFinalizarPartido.Enabled = btnFinalizarPartido.Visible = true;
            }
        }

        private void btnFinalizarPartido_Click(object sender, EventArgs e)
        {
            if (gridEquipo1.RowCount >= 5 && gridEquipo2.RowCount >= 5 && gridPartidos.SelectedRows.Count == 1)
            {
                Partido partido = Administrador.ObtenerInstancia().ObtenerPartido((int)gridPartidos.SelectedCells[0].Value);
                //finaliza el partido en la base de datos
                partido.Finalizar();

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
            MarcarJugadoresExcluidos(gridEquipo1);
            MarcarJugadoresConAltoHandicap(gridEquipo1);
        }

        private void gridEquipo2_DataSourceChanged(object sender, EventArgs e)
        {
            MarcarJugadoresExcluidos(gridEquipo2);
            MarcarJugadoresConAltoHandicap(gridEquipo2);
        }

        private void btnVerCriticas_Click(object sender, EventArgs e)
        {
            frmCriticas frm = new frmCriticas(Administrador.ObtenerInstancia().ObtenerPartidos());
            frm.ShowDialog();
        }

        private void btnBuscarJugadores_Click(object sender, EventArgs e)
        {
            frmBuscadorJugadores frm = new frmBuscadorJugadores();
            frm.ShowDialog();
        }

        private void gridInteresados_DataSourceChanged(object sender, EventArgs e)
        {
            MarcarJugadoresConAltoHandicap(gridInteresados);
        }
        #endregion

        #region Metodos

        private void MarcarJugadoresExcluidos(DataGridView grid)
        {
            if (grid.RowCount >= 5)
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    if (i > 4)
                        grid.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void MarcarJugadoresConAltoHandicap(DataGridView grid)
        {
            try
            {
                if (grid.RowCount > 0)
                {
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if ((int)row.Cells["Handicap"].Value >= 8)
                        {
                            row.DefaultCellStyle.BackColor = Color.CadetBlue;
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void DeshablitarControles()
        {
            // se deshablitan todos los controles que no van al principio.
            btnProponerAmigo.Enabled =
            btnFinalizarPartido.Visible =
            btnNuevoPartido.Enabled =
            btnConfirmar.Enabled = btnConfirmar.Visible =
            btnCriterios.Visible = btnCriterios.Enabled =
            btnBaja.Enabled =
            btnInscribirse.Enabled = 
            btnRegistrarse.Enabled = false;
        }

        private void HabilitarControles()
        {
            btnNuevoPartido.Enabled = btnConfirmar.Enabled = EsAdministrador;
            btnInscribirse.Enabled = btnProponerAmigo.Enabled = !EsAdministrador;
        }

        public void CargarPartidos()
        {
            gridPartidos.DataSource = null;
            gridPartidos.DataSource = (from x in Administrador.ObtenerInstancia().ObtenerPartidos()
                                       select new
                                       {
                                           x.Id_Partido,
                                           x.Lugar,
                                           x.Fecha_Hora,
                                           Confirmado = x.Confirmado.ToString(),
                                           Finalizado = x.Finalizado.ToString()
                                       }).ToList();
        }

        private void EvaluarEstadoGrilla()
        {
            if (gridPartidos.SelectedRows.Count == 1)
            {
                btnCriterios.Enabled = btnConfirmar.Visible = btnFinalizarPartido.Visible = false;
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
                gridInteresados.DataSource = partido.ObtenerListaJugadoresInteresados();
                lblCount.Text = gridInteresados.RowCount.ToString();

                gridEquipo1.DataSource = partido.ArmadorPartido != null ? partido.ObtenerListaEquipo(1) : partido.ObtenerEquiposDesignados(1);
                gridEquipo2.DataSource = partido.ArmadorPartido != null ? partido.ObtenerListaEquipo(2) : partido.ObtenerEquiposDesignados(2);

                if (gridInteresados.RowCount == 10 && EsAdministrador)
                {
                    btnCriterios.Visible = btnCriterios.Enabled = btnOrdenamiento.Enabled = true;
                        
                    //si está confirmado, bloqueo el botón
                    if (gridEquipo1.RowCount == 5 && gridEquipo2.RowCount == 5)
                    {
                        btnConfirmar.Visible = btnFinalizarPartido.Visible = true;
                        btnConfirmar.Enabled = !partido.Confirmado;
                        btnFinalizarPartido.Enabled = !partido.Finalizado;
                    }
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
        #endregion

        private void btnOrdenamiento_Click(object sender, EventArgs e)
        {
            int idSeleccionado = (int)gridPartidos.SelectedCells[0].Value;
            Partido partido = Administrador.ObtenerInstancia().ObtenerPartidos().Single(z => z.Id_Partido == idSeleccionado);
            frmOrdenamiento frm = new frmOrdenamiento(partido);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //ordeno la lista aplicando el criterio especificado
                gridInteresados.DataSource = (from x in partido.ListaJugadores
                                              orderby x.Interesado.Criterio.AplicarCriterio()
                                              select new
                {
                    x.Interesado.Nombre,
                    x.Interesado.Apellido,
                    x.Interesado.FechaNacimiento,
                    x.Interesado.Posicion,
                    x.Interesado.Handicap,
                    TipoJugador = x.Interesado.ObtenerTipoJugadorPartido(partido.Id_Partido)
                }).ToList(); ;
            }
        }

    }
}
