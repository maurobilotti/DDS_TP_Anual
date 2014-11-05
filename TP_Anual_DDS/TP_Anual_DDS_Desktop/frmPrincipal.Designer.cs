namespace TP_Anual_DDS_E4
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridPartidos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOrdenamiento = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnFinalizarPartido = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridEquipo1 = new System.Windows.Forms.DataGridView();
            this.gridEquipo2 = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCriterios = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gridInteresados = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnNuevoPartido = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnInscribirse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBaja = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnProponerAmigo = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBuscarJugadores = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnVerCriticas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRealizarCriticas = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPartidos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInteresados)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.gridPartidos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 445);
            this.panel1.TabIndex = 2;
            // 
            // gridPartidos
            // 
            this.gridPartidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPartidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPartidos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.gridPartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPartidos.GridColor = System.Drawing.Color.White;
            this.gridPartidos.Location = new System.Drawing.Point(0, 30);
            this.gridPartidos.MultiSelect = false;
            this.gridPartidos.Name = "gridPartidos";
            this.gridPartidos.ReadOnly = true;
            this.gridPartidos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridPartidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPartidos.Size = new System.Drawing.Size(463, 415);
            this.gridPartidos.TabIndex = 1;
            this.gridPartidos.Click += new System.EventHandler(this.gridPartidos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Partidos";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.btnOrdenamiento);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblCount);
            this.panel2.Controls.Add(this.btnFinalizarPartido);
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Controls.Add(this.btnConfirmar);
            this.panel2.Controls.Add(this.btnCriterios);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.gridInteresados);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(469, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 445);
            this.panel2.TabIndex = 3;
            // 
            // btnOrdenamiento
            // 
            this.btnOrdenamiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrdenamiento.Enabled = false;
            this.btnOrdenamiento.Location = new System.Drawing.Point(676, 4);
            this.btnOrdenamiento.Name = "btnOrdenamiento";
            this.btnOrdenamiento.Size = new System.Drawing.Size(86, 23);
            this.btnOrdenamiento.TabIndex = 13;
            this.btnOrdenamiento.Text = "Ordenamiento";
            this.btnOrdenamiento.UseVisualStyleBackColor = true;
            this.btnOrdenamiento.Click += new System.EventHandler(this.btnOrdenamiento_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(639, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "CANTIDAD:";
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.ForeColor = System.Drawing.Color.Black;
            this.lblCount.Location = new System.Drawing.Point(709, 232);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = "0";
            // 
            // btnFinalizarPartido
            // 
            this.btnFinalizarPartido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizarPartido.Location = new System.Drawing.Point(312, 419);
            this.btnFinalizarPartido.Name = "btnFinalizarPartido";
            this.btnFinalizarPartido.Size = new System.Drawing.Size(125, 23);
            this.btnFinalizarPartido.TabIndex = 10;
            this.btnFinalizarPartido.Text = "Partido Finalizado";
            this.btnFinalizarPartido.UseVisualStyleBackColor = true;
            this.btnFinalizarPartido.Click += new System.EventHandler(this.btnFinalizarPartido_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 280);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridEquipo1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridEquipo2);
            this.splitContainer1.Size = new System.Drawing.Size(759, 133);
            this.splitContainer1.SplitterDistance = 382;
            this.splitContainer1.TabIndex = 9;
            // 
            // gridEquipo1
            // 
            this.gridEquipo1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEquipo1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEquipo1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEquipo1.Location = new System.Drawing.Point(0, 0);
            this.gridEquipo1.Name = "gridEquipo1";
            this.gridEquipo1.ReadOnly = true;
            this.gridEquipo1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEquipo1.Size = new System.Drawing.Size(382, 133);
            this.gridEquipo1.TabIndex = 2;
            this.gridEquipo1.DataSourceChanged += new System.EventHandler(this.gridEquipo1_DataSourceChanged);
            this.gridEquipo1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridEquipo1_MouseClick);
            // 
            // gridEquipo2
            // 
            this.gridEquipo2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEquipo2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEquipo2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEquipo2.Location = new System.Drawing.Point(0, 0);
            this.gridEquipo2.Name = "gridEquipo2";
            this.gridEquipo2.ReadOnly = true;
            this.gridEquipo2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEquipo2.Size = new System.Drawing.Size(373, 133);
            this.gridEquipo2.TabIndex = 3;
            this.gridEquipo2.DataSourceChanged += new System.EventHandler(this.gridEquipo2_DataSourceChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.Location = new System.Drawing.Point(676, 419);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(86, 23);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCriterios
            // 
            this.btnCriterios.Location = new System.Drawing.Point(3, 234);
            this.btnCriterios.Name = "btnCriterios";
            this.btnCriterios.Size = new System.Drawing.Size(86, 23);
            this.btnCriterios.TabIndex = 7;
            this.btnCriterios.Text = "Elegir criterios";
            this.btnCriterios.UseVisualStyleBackColor = true;
            this.btnCriterios.Click += new System.EventHandler(this.btnCriterios_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(396, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Equipo 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(2, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Equipo 1";
            // 
            // gridInteresados
            // 
            this.gridInteresados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInteresados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInteresados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInteresados.Location = new System.Drawing.Point(3, 30);
            this.gridInteresados.Name = "gridInteresados";
            this.gridInteresados.ReadOnly = true;
            this.gridInteresados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInteresados.Size = new System.Drawing.Size(759, 198);
            this.gridInteresados.TabIndex = 1;
            this.gridInteresados.DataSourceChanged += new System.EventHandler(this.gridInteresados_DataSourceChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Interesados";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(1159, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.Location = new System.Drawing.Point(1080, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarse.Location = new System.Drawing.Point(999, 2);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrarse.TabIndex = 8;
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.UseVisualStyleBackColor = true;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUsuario.Location = new System.Drawing.Point(874, 3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(57, 20);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "label3";
            this.lblUsuario.Visible = false;
            // 
            // btnNuevoPartido
            // 
            this.btnNuevoPartido.Name = "btnNuevoPartido";
            this.btnNuevoPartido.Size = new System.Drawing.Size(75, 22);
            this.btnNuevoPartido.Text = "Nuevo Partido";
            this.btnNuevoPartido.Click += new System.EventHandler(this.btnAgregarPartido_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnInscribirse
            // 
            this.btnInscribirse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnInscribirse.Image = ((System.Drawing.Image)(resources.GetObject("btnInscribirse.Image")));
            this.btnInscribirse.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnInscribirse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInscribirse.Name = "btnInscribirse";
            this.btnInscribirse.Size = new System.Drawing.Size(101, 22);
            this.btnInscribirse.Text = "Incribirse a partido";
            this.btnInscribirse.Click += new System.EventHandler(this.btnInscribirse_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBaja
            // 
            this.btnBaja.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBaja.Image = ((System.Drawing.Image)(resources.GetObject("btnBaja.Image")));
            this.btnBaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(78, 22);
            this.btnBaja.Text = "Darse de baja";
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnProponerAmigo
            // 
            this.btnProponerAmigo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProponerAmigo.Image = ((System.Drawing.Image)(resources.GetObject("btnProponerAmigo.Image")));
            this.btnProponerAmigo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProponerAmigo.Name = "btnProponerAmigo";
            this.btnProponerAmigo.Size = new System.Drawing.Size(86, 22);
            this.btnProponerAmigo.Text = "Proponer amigo";
            this.btnProponerAmigo.Click += new System.EventHandler(this.btnProponerAmigo_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBuscarJugadores,
            this.toolStripSeparator6,
            this.btnNuevoPartido,
            this.toolStripSeparator1,
            this.btnInscribirse,
            this.toolStripSeparator2,
            this.btnBaja,
            this.toolStripSeparator3,
            this.btnProponerAmigo,
            this.toolStripSeparator4,
            this.btnVerCriticas,
            this.toolStripSeparator5,
            this.btnRealizarCriticas});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1234, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnBuscarJugadores
            // 
            this.btnBuscarJugadores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBuscarJugadores.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarJugadores.Image")));
            this.btnBuscarJugadores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscarJugadores.Name = "btnBuscarJugadores";
            this.btnBuscarJugadores.Size = new System.Drawing.Size(23, 22);
            this.btnBuscarJugadores.Click += new System.EventHandler(this.btnBuscarJugadores_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnVerCriticas
            // 
            this.btnVerCriticas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnVerCriticas.Image = ((System.Drawing.Image)(resources.GetObject("btnVerCriticas.Image")));
            this.btnVerCriticas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerCriticas.Name = "btnVerCriticas";
            this.btnVerCriticas.Size = new System.Drawing.Size(65, 22);
            this.btnVerCriticas.Text = "Ver Criticas";
            this.btnVerCriticas.Click += new System.EventHandler(this.btnVerCriticas_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRealizarCriticas
            // 
            this.btnRealizarCriticas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRealizarCriticas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRealizarCriticas.Image = ((System.Drawing.Image)(resources.GetObject("btnRealizarCriticas.Image")));
            this.btnRealizarCriticas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRealizarCriticas.Name = "btnRealizarCriticas";
            this.btnRealizarCriticas.Size = new System.Drawing.Size(87, 22);
            this.btnRealizarCriticas.Text = "Realizar Criticas";
            this.btnRealizarCriticas.Visible = false;
            this.btnRealizarCriticas.Click += new System.EventHandler(this.btnRealizarCriticas_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Location = new System.Drawing.Point(280, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 17);
            this.panel3.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Confirmado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(406, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Finalizado";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Aqua;
            this.panel4.Location = new System.Drawing.Point(381, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(18, 17);
            this.panel4.TabIndex = 4;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1234, 470);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnRegistrarse);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPartidos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInteresados)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridPartidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridInteresados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gridEquipo2;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCriterios;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridEquipo1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnFinalizarPartido;
        private System.Windows.Forms.ToolStripLabel btnNuevoPartido;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnInscribirse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnBaja;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnProponerAmigo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnRealizarCriticas;
        private System.Windows.Forms.ToolStripButton btnVerCriticas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnBuscarJugadores;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnOrdenamiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}

