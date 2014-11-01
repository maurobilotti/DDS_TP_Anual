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
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numHandicapDesde = new System.Windows.Forms.NumericUpDown();
            this.numHandicapHasta = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtPromDesde = new System.Windows.Forms.TextBox();
            this.txtPromHasta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbInfrantores = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gridJugadoresBuscados)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHandicapDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHandicapHasta)).BeginInit();
            this.SuspendLayout();
            // 
            // gridJugadoresBuscados
            // 
            this.gridJugadoresBuscados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridJugadoresBuscados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridJugadoresBuscados.Location = new System.Drawing.Point(0, 107);
            this.gridJugadoresBuscados.MultiSelect = false;
            this.gridJugadoresBuscados.Name = "gridJugadoresBuscados";
            this.gridJugadoresBuscados.ReadOnly = true;
            this.gridJugadoresBuscados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridJugadoresBuscados.Size = new System.Drawing.Size(674, 351);
            this.gridJugadoresBuscados.TabIndex = 0;
            this.gridJugadoresBuscados.Click += new System.EventHandler(this.gridBuscadorJugadores_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.cmbInfrantores);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPromHasta);
            this.panel1.Controls.Add(this.txtPromDesde);
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
            this.panel1.Size = new System.Drawing.Size(674, 107);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Handicap hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Handicap desde";
            // 
            // numHandicapDesde
            // 
            this.numHandicapDesde.Location = new System.Drawing.Point(315, 29);
            this.numHandicapDesde.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHandicapDesde.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numHandicapDesde.Name = "numHandicapDesde";
            this.numHandicapDesde.Size = new System.Drawing.Size(55, 20);
            this.numHandicapDesde.TabIndex = 5;
            this.numHandicapDesde.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // numHandicapHasta
            // 
            this.numHandicapHasta.Location = new System.Drawing.Point(419, 29);
            this.numHandicapHasta.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHandicapHasta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numHandicapHasta.Name = "numHandicapHasta";
            this.numHandicapHasta.Size = new System.Drawing.Size(55, 20);
            this.numHandicapHasta.TabIndex = 4;
            this.numHandicapHasta.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha nacimiento (menor a)";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.CustomFormat = "yyyy-MM-dd";
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(131, 29);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(135, 20);
            this.dtpFechaNacimiento.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(10, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(553, 33);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 46);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtPromDesde
            // 
            this.txtPromDesde.Location = new System.Drawing.Point(12, 81);
            this.txtPromDesde.Name = "txtPromDesde";
            this.txtPromDesde.Size = new System.Drawing.Size(100, 20);
            this.txtPromDesde.TabIndex = 9;
            // 
            // txtPromHasta
            // 
            this.txtPromHasta.Location = new System.Drawing.Point(131, 81);
            this.txtPromHasta.Name = "txtPromHasta";
            this.txtPromHasta.Size = new System.Drawing.Size(100, 20);
            this.txtPromHasta.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Promedio hasta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Promedio desde";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Por infracciones";
            // 
            // cmbInfrantores
            // 
            this.cmbInfrantores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInfrantores.FormattingEnabled = true;
            this.cmbInfrantores.Location = new System.Drawing.Point(311, 80);
            this.cmbInfrantores.Name = "cmbInfrantores";
            this.cmbInfrantores.Size = new System.Drawing.Size(163, 21);
            this.cmbInfrantores.TabIndex = 14;
            // 
            // frmBuscadorJugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 458);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridJugadoresBuscados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBuscadorJugadores";
            this.Text = "frmBuscadorJugadores";
            this.Load += new System.EventHandler(this.frmBuscadorJugadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridJugadoresBuscados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHandicapDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHandicapHasta)).EndInit();
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
        private System.Windows.Forms.TextBox txtPromHasta;
        private System.Windows.Forms.TextBox txtPromDesde;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}