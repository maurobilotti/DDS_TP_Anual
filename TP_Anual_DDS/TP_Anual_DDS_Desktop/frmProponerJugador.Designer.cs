namespace TP_Anual_DDS_E4
{
    partial class frmProponerJugador
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
            this.cmbJugadorPropuesto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProponer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbJugadorPropuesto
            // 
            this.cmbJugadorPropuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJugadorPropuesto.FormattingEnabled = true;
            this.cmbJugadorPropuesto.Location = new System.Drawing.Point(113, 12);
            this.cmbJugadorPropuesto.Name = "cmbJugadorPropuesto";
            this.cmbJugadorPropuesto.Size = new System.Drawing.Size(225, 21);
            this.cmbJugadorPropuesto.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Jugador propuesto";
            // 
            // btnProponer
            // 
            this.btnProponer.Location = new System.Drawing.Point(136, 61);
            this.btnProponer.Name = "btnProponer";
            this.btnProponer.Size = new System.Drawing.Size(75, 23);
            this.btnProponer.TabIndex = 2;
            this.btnProponer.Text = "Proponer";
            this.btnProponer.UseVisualStyleBackColor = true;
            this.btnProponer.Click += new System.EventHandler(this.btnProponer_Click);
            // 
            // frmProponerJugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(351, 96);
            this.Controls.Add(this.btnProponer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbJugadorPropuesto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmProponerJugador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proponer Jugador";
            this.Load += new System.EventHandler(this.frmProponerJugador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbJugadorPropuesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProponer;
    }
}