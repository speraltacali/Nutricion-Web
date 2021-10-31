namespace Nutrucion_App.Core
{
    partial class _0002_ABM
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_0002_ABM));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pixCancelar = new System.Windows.Forms.PictureBox();
            this.pixLimpiar = new System.Windows.Forms.PictureBox();
            this.pixEjecutar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.TimerOpen = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixEjecutar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.pixCancelar);
            this.panel1.Controls.Add(this.pixLimpiar);
            this.panel1.Controls.Add(this.pixEjecutar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 52);
            this.panel1.TabIndex = 0;
            // 
            // pixCancelar
            // 
            this.pixCancelar.BackgroundImage = global::Nutrucion_App.Properties.Resources.calcelar01;
            this.pixCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pixCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pixCancelar.Location = new System.Drawing.Point(773, 0);
            this.pixCancelar.Name = "pixCancelar";
            this.pixCancelar.Size = new System.Drawing.Size(65, 52);
            this.pixCancelar.TabIndex = 1;
            this.pixCancelar.TabStop = false;
            this.pixCancelar.Click += new System.EventHandler(this.pixCancelar_Click);
            this.pixCancelar.MouseLeave += new System.EventHandler(this.pixCancelar_MouseLeave);
            this.pixCancelar.MouseHover += new System.EventHandler(this.pixCancelar_MouseHover);
            // 
            // pixLimpiar
            // 
            this.pixLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.pixLimpiar.BackgroundImage = global::Nutrucion_App.Properties.Resources.escoba;
            this.pixLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pixLimpiar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pixLimpiar.Location = new System.Drawing.Point(65, 0);
            this.pixLimpiar.Name = "pixLimpiar";
            this.pixLimpiar.Size = new System.Drawing.Size(65, 52);
            this.pixLimpiar.TabIndex = 1;
            this.pixLimpiar.TabStop = false;
            this.pixLimpiar.Click += new System.EventHandler(this.pixLimpiar_Click);
            this.pixLimpiar.MouseLeave += new System.EventHandler(this.pixLimpiar_MouseLeave);
            this.pixLimpiar.MouseHover += new System.EventHandler(this.pixLimpiar_MouseHover);
            // 
            // pixEjecutar
            // 
            this.pixEjecutar.BackgroundImage = global::Nutrucion_App.Properties.Resources.ejecutar01;
            this.pixEjecutar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pixEjecutar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pixEjecutar.Location = new System.Drawing.Point(0, 0);
            this.pixEjecutar.Name = "pixEjecutar";
            this.pixEjecutar.Size = new System.Drawing.Size(65, 52);
            this.pixEjecutar.TabIndex = 1;
            this.pixEjecutar.TabStop = false;
            this.pixEjecutar.Click += new System.EventHandler(this.pixEjecutar_Click);
            this.pixEjecutar.MouseLeave += new System.EventHandler(this.pixEjecutar_MouseLeave);
            this.pixEjecutar.MouseHover += new System.EventHandler(this.pixEjecutar_MouseHover);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(838, 10);
            this.panel2.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Cooper Black", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTitulo.Location = new System.Drawing.Point(3, 65);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 42);
            this.lblTitulo.TabIndex = 3;
            // 
            // TimerOpen
            // 
            this.TimerOpen.Interval = 10;
            this.TimerOpen.Tick += new System.EventHandler(this.TimerOpen_Tick);
            // 
            // _0002_ABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Nutrucion_App.Properties.Resources.fondo001rosa;
            this.ClientSize = new System.Drawing.Size(838, 551);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "_0002_ABM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Paciente";
            this.Load += new System.EventHandler(this._0002_ABM_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pixCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixEjecutar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pixEjecutar;
        private System.Windows.Forms.PictureBox pixCancelar;
        private System.Windows.Forms.PictureBox pixLimpiar;
        private System.Windows.Forms.Timer TimerOpen;
    }
}