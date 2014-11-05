namespace TP_Anual_DDS_E4
{
    partial class frmNuevoPartido
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
            this.btnGuardarPartido = new System.Windows.Forms.Button();
            this.txtLugar = new System.Windows.Forms.TextBox();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGuardarPartido
            // 
            this.btnGuardarPartido.Location = new System.Drawing.Point(223, 87);
            this.btnGuardarPartido.Name = "btnGuardarPartido";
            this.btnGuardarPartido.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarPartido.TabIndex = 0;
            this.btnGuardarPartido.Text = "Guardar";
            this.btnGuardarPartido.UseVisualStyleBackColor = true;
            this.btnGuardarPartido.Click += new System.EventHandler(this.btnGuardarPartido_Click);
            // 
            // txtLugar
            // 
            this.txtLugar.Location = new System.Drawing.Point(24, 42);
            this.txtLugar.Name = "txtLugar";
            this.txtLugar.Size = new System.Drawing.Size(196, 20);
            this.txtLugar.TabIndex = 1;
            // 
            // dateFecha
            // 
            this.dateFecha.CustomFormat = "dd/MM/yyyy hh:mm";
            this.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFecha.Location = new System.Drawing.Point(302, 41);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(200, 20);
            this.dateFecha.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lugar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha";
            // 
            // frmNuevoPartido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(524, 122);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFecha);
            this.Controls.Add(this.txtLugar);
            this.Controls.Add(this.btnGuardarPartido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNuevoPartido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Partido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardarPartido;
        private System.Windows.Forms.TextBox txtLugar;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}