namespace TP_Anual_DDS_E4
{
    partial class Critica
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCriticado = new System.Windows.Forms.Label();
            this.numPuntaje = new System.Windows.Forms.NumericUpDown();
            this.txtCritica = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblLugarPartido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCritico = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntaje)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCriticado
            // 
            this.lblCriticado.AutoSize = true;
            this.lblCriticado.Location = new System.Drawing.Point(35, 43);
            this.lblCriticado.Name = "lblCriticado";
            this.lblCriticado.Size = new System.Drawing.Size(44, 13);
            this.lblCriticado.TabIndex = 0;
            this.lblCriticado.Text = "Nombre";
            // 
            // numPuntaje
            // 
            this.numPuntaje.Location = new System.Drawing.Point(282, 7);
            this.numPuntaje.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPuntaje.Name = "numPuntaje";
            this.numPuntaje.Size = new System.Drawing.Size(44, 20);
            this.numPuntaje.TabIndex = 2;
            this.numPuntaje.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // txtCritica
            // 
            this.txtCritica.Location = new System.Drawing.Point(6, 59);
            this.txtCritica.Multiline = true;
            this.txtCritica.Name = "txtCritica";
            this.txtCritica.Size = new System.Drawing.Size(276, 45);
            this.txtCritica.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(288, 57);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(38, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblLugarPartido
            // 
            this.lblLugarPartido.AutoSize = true;
            this.lblLugarPartido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLugarPartido.Location = new System.Drawing.Point(3, 4);
            this.lblLugarPartido.Name = "lblLugarPartido";
            this.lblLugarPartido.Size = new System.Drawing.Size(47, 16);
            this.lblLugarPartido.TabIndex = 5;
            this.lblLugarPartido.Text = "Lugar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Por:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "A:";
            // 
            // lblCritico
            // 
            this.lblCritico.AutoSize = true;
            this.lblCritico.Location = new System.Drawing.Point(35, 26);
            this.lblCritico.Name = "lblCritico";
            this.lblCritico.Size = new System.Drawing.Size(44, 13);
            this.lblCritico.TabIndex = 8;
            this.lblCritico.Text = "Nombre";
            // 
            // Critica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.lblCritico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLugarPartido);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCritica);
            this.Controls.Add(this.numPuntaje);
            this.Controls.Add(this.lblCriticado);
            this.Name = "Critica";
            this.Size = new System.Drawing.Size(329, 107);
            this.Load += new System.EventHandler(this.Critica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPuntaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCriticado;
        private System.Windows.Forms.NumericUpDown numPuntaje;
        private System.Windows.Forms.TextBox txtCritica;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblLugarPartido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCritico;
    }
}
