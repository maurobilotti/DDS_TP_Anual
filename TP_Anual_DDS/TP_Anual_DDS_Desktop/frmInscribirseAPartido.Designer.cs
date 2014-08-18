namespace TP_Anual_DDS_Desktop
{
    partial class frmInscribirseAPartido
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
            this.chkCondiciones = new System.Windows.Forms.CheckedListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoJugador = new System.Windows.Forms.ComboBox();
            this.btnInscribir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkCondiciones
            // 
            this.chkCondiciones.FormattingEnabled = true;
            this.chkCondiciones.Location = new System.Drawing.Point(72, 89);
            this.chkCondiciones.Name = "chkCondiciones";
            this.chkCondiciones.Size = new System.Drawing.Size(149, 79);
            this.chkCondiciones.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Condicion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tipo";
            // 
            // cmbTipoJugador
            // 
            this.cmbTipoJugador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoJugador.FormattingEnabled = true;
            this.cmbTipoJugador.Location = new System.Drawing.Point(72, 41);
            this.cmbTipoJugador.Name = "cmbTipoJugador";
            this.cmbTipoJugador.Size = new System.Drawing.Size(149, 21);
            this.cmbTipoJugador.TabIndex = 18;
            this.cmbTipoJugador.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoJugador_SelectionChangeCommitted);
            // 
            // btnInscribir
            // 
            this.btnInscribir.Location = new System.Drawing.Point(85, 193);
            this.btnInscribir.Name = "btnInscribir";
            this.btnInscribir.Size = new System.Drawing.Size(74, 24);
            this.btnInscribir.TabIndex = 22;
            this.btnInscribir.Text = "Inscribir";
            this.btnInscribir.UseVisualStyleBackColor = true;
            this.btnInscribir.Click += new System.EventHandler(this.btnInscribir_Click);
            // 
            // frmInscribirseAPartido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 231);
            this.Controls.Add(this.btnInscribir);
            this.Controls.Add(this.chkCondiciones);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbTipoJugador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInscribirseAPartido";
            this.Text = "Modalidad de insripción";
            this.Load += new System.EventHandler(this.frmInscribirseAPartido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkCondiciones;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTipoJugador;
        private System.Windows.Forms.Button btnInscribir;
    }
}