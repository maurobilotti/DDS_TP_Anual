namespace TP_Anual_DDS_Desktop
{
    partial class frmDenegacion
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
            this.btnRegistrarDenegacion = new System.Windows.Forms.Button();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRegistrarDenegacion
            // 
            this.btnRegistrarDenegacion.Location = new System.Drawing.Point(142, 112);
            this.btnRegistrarDenegacion.Name = "btnRegistrarDenegacion";
            this.btnRegistrarDenegacion.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrarDenegacion.TabIndex = 0;
            this.btnRegistrarDenegacion.Text = "Registrar";
            this.btnRegistrarDenegacion.UseVisualStyleBackColor = true;
            this.btnRegistrarDenegacion.Click += new System.EventHandler(this.btnRegistrarDenegacion_Click);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(12, 12);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(339, 89);
            this.txtMotivo.TabIndex = 1;
            // 
            // frmDenegacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 147);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.btnRegistrarDenegacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDenegacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Denegacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrarDenegacion;
        private System.Windows.Forms.TextBox txtMotivo;
    }
}