namespace TP_Anual_DDS_E4
{
    partial class frmBuscadorJugadores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridJugadoresBuscados = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbInfrantores = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numHandicapDesde = new System.Windows.Forms.NumericUpDown();
            this.numHandicapHasta = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.numPromedioDesde = new System.Windows.Forms.NumericUpDown();
            this.numPromedioHasta = new System.Windows.Forms.NumericUpDown();
            this.chkHandicapDesde = new System.Windows.Forms.CheckBox();
            this.chkHandicapHasta = new System.Windows.Forms.CheckBox();
            this.chkPromedioHasta = new System.Windows.Forms.CheckBox();
            this.chkPromedioDesde = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridJugadoresBuscados)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHandicapDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHandicapHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPromedioDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPromedioHasta)).BeginInit();
            this.SuspendLayout();
            // 
            // gridJugadoresBuscados
            // 
            this.gridJugadoresBuscados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridJugadoresBuscados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridJugadoresBuscados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridJugadoresBuscados.Location = new System.Drawing.Point(0, 107);
            this.gridJugadoresBuscados.MultiSelect = false;
            this.gridJugadoresBuscados.Name = "gridJugadoresBuscados";
            this.gridJugadoresBuscados.ReadOnly = true;
            this.gridJugadoresBuscados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridJugadoresBuscados.Size = new System.Drawing.Size(626, 351);
            this.gridJugadoresBuscados.TabIndex = 0;
            this.gridJugadoresBuscados.DataSourceChanged += new System.EventHandler(this.gridJugadoresBuscados_DataSourceChanged);
            this.gridJugadoresBuscados.DoubleClick += new System.EventHandler(this.gridJugadoresBuscados_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.chkPromedioDesde);
            this.panel1.Controls.Add(this.chkPromedioHasta);
            this.panel1.Controls.Add(this.chkHandicapHasta);
            this.panel1.Controls.Add(this.chkHandicapDesde);
            this.panel1.Controls.Add(this.numPromedioHasta);
            this.panel1.Controls.Add(this.numPromedioDesde);
            this.panel1.Controls.Add(this.cmbInfrantores);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numHandicapDesde);
            this.panel1.Controls.Add(this.numHandicapHasta);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFechaNacimiento);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 107);
            this.panel1.TabIndex = 1;
            // 
            // cmbInfrantores
            // 
            this.cmbInfrantores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInfrantores.FormattingEnabled = true;
            this.cmbInfrantores.Location = new System.Drawing.Point(311, 71);
            this.cmbInfrantores.Name = "cmbInfrantores";
            this.cmbInfrantores.Size = new System.Drawing.Size(163, 21);
            this.cmbInfrantores.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Por infracciones";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Promedio desde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Promedio hasta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Handicap hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Handicap desde";
            // 
            // numHandicapDesde
            // 
            this.numHandicapDesde.Location = new System.Drawing.Point(333, 26);
            this.numHandicapDesde.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHandicapDesde.Name = "numHandicapDesde";
            this.numHandicapDesde.Size = new System.Drawing.Size(55, 20);
            this.numHandicapDesde.TabIndex = 5;
            // 
            // numHandicapHasta
            // 
            this.numHandicapHasta.Location = new System.Drawing.Point(435, 27);
            this.numHandicapHasta.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHandicapHasta.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHandicapHasta.Name = "numHandicapHasta";
            this.numHandicapHasta.Size = new System.Drawing.Size(55, 20);
            this.numHandicapHasta.TabIndex = 4;
            this.numHandicapHasta.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha nacimiento (menor a)";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.CustomFormat = "yyyy-MM-dd";
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(131, 26);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(135, 20);
            this.dtpFechaNacimiento.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(10, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(517, 33);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 46);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // numPromedioDesde
            // 
            this.numPromedioDesde.DecimalPlaces = 2;
            this.numPromedioDesde.Location = new System.Drawing.Point(30, 71);
            this.numPromedioDesde.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPromedioDesde.Name = "numPromedioDesde";
            this.numPromedioDesde.Size = new System.Drawing.Size(65, 20);
            this.numPromedioDesde.TabIndex = 15;
            // 
            // numPromedioHasta
            // 
            this.numPromedioHasta.DecimalPlaces = 2;
            this.numPromedioHasta.Location = new System.Drawing.Point(156, 71);
            this.numPromedioHasta.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPromedioHasta.Name = "numPromedioHasta";
            this.numPromedioHasta.Size = new System.Drawing.Size(64, 20);
            this.numPromedioHasta.TabIndex = 16;
            this.numPromedioHasta.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chkHandicapDesde
            // 
            this.chkHandicapDesde.AutoSize = true;
            this.chkHandicapDesde.Checked = true;
            this.chkHandicapDesde.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHandicapDesde.Location = new System.Drawing.Point(311, 29);
            this.chkHandicapDesde.Name = "chkHandicapDesde";
            this.chkHandicapDesde.Size = new System.Drawing.Size(15, 14);
            this.chkHandicapDesde.TabIndex = 17;
            this.chkHandicapDesde.UseVisualStyleBackColor = true;
            this.chkHandicapDesde.CheckedChanged += new System.EventHandler(this.chkHandicapDesde_CheckedChanged);
            // 
            // chkHandicapHasta
            // 
            this.chkHandicapHasta.AutoSize = true;
            this.chkHandicapHasta.Checked = true;
            this.chkHandicapHasta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHandicapHasta.Location = new System.Drawing.Point(414, 29);
            this.chkHandicapHasta.Name = "chkHandicapHasta";
            this.chkHandicapHasta.Size = new System.Drawing.Size(15, 14);
            this.chkHandicapHasta.TabIndex = 18;
            this.chkHandicapHasta.UseVisualStyleBackColor = true;
            this.chkHandicapHasta.CheckedChanged += new System.EventHandler(this.chkHandicapHasta_CheckedChanged);
            // 
            // chkPromedioHasta
            // 
            this.chkPromedioHasta.AutoSize = true;
            this.chkPromedioHasta.Checked = true;
            this.chkPromedioHasta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPromedioHasta.Location = new System.Drawing.Point(135, 74);
            this.chkPromedioHasta.Name = "chkPromedioHasta";
            this.chkPromedioHasta.Size = new System.Drawing.Size(15, 14);
            this.chkPromedioHasta.TabIndex = 19;
            this.chkPromedioHasta.UseVisualStyleBackColor = true;
            this.chkPromedioHasta.CheckedChanged += new System.EventHandler(this.chkPromedioHasta_CheckedChanged);
            // 
            // chkPromedioDesde
            // 
            this.chkPromedioDesde.AutoSize = true;
            this.chkPromedioDesde.Checked = true;
            this.chkPromedioDesde.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPromedioDesde.Location = new System.Drawing.Point(12, 74);
            this.chkPromedioDesde.Name = "chkPromedioDesde";
            this.chkPromedioDesde.Size = new System.Drawing.Size(15, 14);
            this.chkPromedioDesde.TabIndex = 20;
            this.chkPromedioDesde.UseVisualStyleBackColor = true;
            this.chkPromedioDesde.CheckedChanged += new System.EventHandler(this.chkPromedioDesde_CheckedChanged);
            // 
            // frmBuscadorJugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 458);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridJugadoresBuscados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBuscadorJugadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBuscadorJugadores";
            this.Load += new System.EventHandler(this.frmBuscadorJugadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridJugadoresBuscados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHandicapDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHandicapHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPromedioDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPromedioHasta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridJugadoresBuscados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numHandicapDesde;
        private System.Windows.Forms.NumericUpDown numHandicapHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbInfrantores;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NumericUpDown numPromedioHasta;
        private System.Windows.Forms.NumericUpDown numPromedioDesde;
        private System.Windows.Forms.CheckBox chkPromedioDesde;
        private System.Windows.Forms.CheckBox chkPromedioHasta;
        private System.Windows.Forms.CheckBox chkHandicapHasta;
        private System.Windows.Forms.CheckBox chkHandicapDesde;
    }
}