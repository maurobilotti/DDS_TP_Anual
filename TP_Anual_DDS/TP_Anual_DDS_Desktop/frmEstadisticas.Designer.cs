namespace TP_Anual_DDS_E4
{
    partial class frmEstadisticas
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
            this.tabEstadisticas = new System.Windows.Forms.TabControl();
            this.tabMalos = new System.Windows.Forms.TabPage();
            this.tabConFuturo = new System.Windows.Forms.TabPage();
            this.tabTraicioneros = new System.Windows.Forms.TabPage();
            this.gridMalos = new System.Windows.Forms.DataGridView();
            this.gridConFuturo = new System.Windows.Forms.DataGridView();
            this.gridTraicioneros = new System.Windows.Forms.DataGridView();
            this.tabEstadisticas.SuspendLayout();
            this.tabMalos.SuspendLayout();
            this.tabConFuturo.SuspendLayout();
            this.tabTraicioneros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMalos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridConFuturo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTraicioneros)).BeginInit();
            this.SuspendLayout();
            // 
            // tabEstadisticas
            // 
            this.tabEstadisticas.Controls.Add(this.tabMalos);
            this.tabEstadisticas.Controls.Add(this.tabConFuturo);
            this.tabEstadisticas.Controls.Add(this.tabTraicioneros);
            this.tabEstadisticas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEstadisticas.Location = new System.Drawing.Point(0, 0);
            this.tabEstadisticas.Name = "tabEstadisticas";
            this.tabEstadisticas.SelectedIndex = 0;
            this.tabEstadisticas.Size = new System.Drawing.Size(840, 360);
            this.tabEstadisticas.TabIndex = 0;
            // 
            // tabMalos
            // 
            this.tabMalos.Controls.Add(this.gridMalos);
            this.tabMalos.Location = new System.Drawing.Point(4, 22);
            this.tabMalos.Name = "tabMalos";
            this.tabMalos.Padding = new System.Windows.Forms.Padding(3);
            this.tabMalos.Size = new System.Drawing.Size(832, 334);
            this.tabMalos.TabIndex = 0;
            this.tabMalos.Text = "Jugadores malos";
            this.tabMalos.UseVisualStyleBackColor = true;
            // 
            // tabConFuturo
            // 
            this.tabConFuturo.Controls.Add(this.gridConFuturo);
            this.tabConFuturo.Location = new System.Drawing.Point(4, 22);
            this.tabConFuturo.Name = "tabConFuturo";
            this.tabConFuturo.Padding = new System.Windows.Forms.Padding(3);
            this.tabConFuturo.Size = new System.Drawing.Size(832, 334);
            this.tabConFuturo.TabIndex = 1;
            this.tabConFuturo.Text = "Jugadores con futuro";
            this.tabConFuturo.UseVisualStyleBackColor = true;
            // 
            // tabTraicioneros
            // 
            this.tabTraicioneros.Controls.Add(this.gridTraicioneros);
            this.tabTraicioneros.Location = new System.Drawing.Point(4, 22);
            this.tabTraicioneros.Name = "tabTraicioneros";
            this.tabTraicioneros.Padding = new System.Windows.Forms.Padding(3);
            this.tabTraicioneros.Size = new System.Drawing.Size(832, 334);
            this.tabTraicioneros.TabIndex = 2;
            this.tabTraicioneros.Text = "Jugadores traicioneros";
            this.tabTraicioneros.UseVisualStyleBackColor = true;
            // 
            // gridMalos
            // 
            this.gridMalos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMalos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMalos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMalos.Location = new System.Drawing.Point(3, 3);
            this.gridMalos.Name = "gridMalos";
            this.gridMalos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMalos.Size = new System.Drawing.Size(826, 328);
            this.gridMalos.TabIndex = 0;
            // 
            // gridConFuturo
            // 
            this.gridConFuturo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridConFuturo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConFuturo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridConFuturo.Location = new System.Drawing.Point(3, 3);
            this.gridConFuturo.Name = "gridConFuturo";
            this.gridConFuturo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridConFuturo.Size = new System.Drawing.Size(826, 328);
            this.gridConFuturo.TabIndex = 0;
            // 
            // gridTraicioneros
            // 
            this.gridTraicioneros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTraicioneros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTraicioneros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTraicioneros.Location = new System.Drawing.Point(3, 3);
            this.gridTraicioneros.Name = "gridTraicioneros";
            this.gridTraicioneros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTraicioneros.Size = new System.Drawing.Size(826, 328);
            this.gridTraicioneros.TabIndex = 0;
            // 
            // frmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(840, 360);
            this.Controls.Add(this.tabEstadisticas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEstadisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadisticas";
            this.Load += new System.EventHandler(this.frmEstadisticas_Load);
            this.tabEstadisticas.ResumeLayout(false);
            this.tabMalos.ResumeLayout(false);
            this.tabConFuturo.ResumeLayout(false);
            this.tabTraicioneros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMalos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridConFuturo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTraicioneros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabEstadisticas;
        private System.Windows.Forms.TabPage tabMalos;
        private System.Windows.Forms.TabPage tabConFuturo;
        private System.Windows.Forms.TabPage tabTraicioneros;
        private System.Windows.Forms.DataGridView gridMalos;
        private System.Windows.Forms.DataGridView gridConFuturo;
        private System.Windows.Forms.DataGridView gridTraicioneros;
    }
}