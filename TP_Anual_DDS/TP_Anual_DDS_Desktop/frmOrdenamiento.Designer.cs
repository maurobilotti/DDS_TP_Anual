namespace TP_Anual_DDS_E4
{
    partial class frmOrdenamiento
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
            this.chkCriterioOrdenamiento = new System.Windows.Forms.CheckedListBox();
            this.btnAplicarOrdenamiento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkCriterioOrdenamiento
            // 
            this.chkCriterioOrdenamiento.FormattingEnabled = true;
            this.chkCriterioOrdenamiento.Location = new System.Drawing.Point(12, 12);
            this.chkCriterioOrdenamiento.Name = "chkCriterioOrdenamiento";
            this.chkCriterioOrdenamiento.Size = new System.Drawing.Size(236, 124);
            this.chkCriterioOrdenamiento.TabIndex = 0;
            // 
            // btnAplicarOrdenamiento
            // 
            this.btnAplicarOrdenamiento.Location = new System.Drawing.Point(102, 149);
            this.btnAplicarOrdenamiento.Name = "btnAplicarOrdenamiento";
            this.btnAplicarOrdenamiento.Size = new System.Drawing.Size(61, 26);
            this.btnAplicarOrdenamiento.TabIndex = 1;
            this.btnAplicarOrdenamiento.Text = "Aplicar";
            this.btnAplicarOrdenamiento.UseVisualStyleBackColor = true;
            this.btnAplicarOrdenamiento.Click += new System.EventHandler(this.btnAplicarOrdenamiento_Click);
            // 
            // frmOrdenamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(260, 187);
            this.Controls.Add(this.btnAplicarOrdenamiento);
            this.Controls.Add(this.chkCriterioOrdenamiento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOrdenamiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenamiento";
            this.Load += new System.EventHandler(this.frmOrdenamiento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkCriterioOrdenamiento;
        private System.Windows.Forms.Button btnAplicarOrdenamiento;
    }
}