namespace TP_Anual_DDS_Desktop
{
    partial class frmCriterios
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.btnAplicarCriterio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Criterio";
            // 
            // cmbCriterio
            // 
            this.cmbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriterio.FormattingEnabled = true;
            this.cmbCriterio.Location = new System.Drawing.Point(90, 45);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(205, 21);
            this.cmbCriterio.TabIndex = 1;
            // 
            // btnAplicarCriterio
            // 
            this.btnAplicarCriterio.Location = new System.Drawing.Point(124, 104);
            this.btnAplicarCriterio.Name = "btnAplicarCriterio";
            this.btnAplicarCriterio.Size = new System.Drawing.Size(75, 23);
            this.btnAplicarCriterio.TabIndex = 2;
            this.btnAplicarCriterio.Text = "Aplicar";
            this.btnAplicarCriterio.UseVisualStyleBackColor = true;
            this.btnAplicarCriterio.Click += new System.EventHandler(this.btnAplicarCriterio_Click);
            // 
            // frmCriterios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 139);
            this.Controls.Add(this.btnAplicarCriterio);
            this.Controls.Add(this.cmbCriterio);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmCriterios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Criterios de Armado de Equipos";
            this.Load += new System.EventHandler(this.frmCriterios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.Button btnAplicarCriterio;
    }
}