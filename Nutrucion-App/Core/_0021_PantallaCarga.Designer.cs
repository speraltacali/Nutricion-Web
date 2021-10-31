namespace Nutrucion_App.Core
{
    partial class _0021_PantallaCarga
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
            this.CargaBar = new CircularProgressBar.CircularProgressBar();
            this.timerOpen = new System.Windows.Forms.Timer(this.components);
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.picture03 = new System.Windows.Forms.PictureBox();
            this.picture02 = new System.Windows.Forms.PictureBox();
            this.picture01 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture01)).BeginInit();
            this.SuspendLayout();
            // 
            // CargaBar
            // 
            this.CargaBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.CargaBar.AnimationSpeed = 500;
            this.CargaBar.BackColor = System.Drawing.Color.Transparent;
            this.CargaBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.CargaBar.ForeColor = System.Drawing.Color.White;
            this.CargaBar.InnerColor = System.Drawing.Color.DimGray;
            this.CargaBar.InnerMargin = 2;
            this.CargaBar.InnerWidth = -1;
            this.CargaBar.Location = new System.Drawing.Point(297, 235);
            this.CargaBar.MarqueeAnimationSpeed = 2000;
            this.CargaBar.Name = "CargaBar";
            this.CargaBar.OuterColor = System.Drawing.Color.Gray;
            this.CargaBar.OuterMargin = -25;
            this.CargaBar.OuterWidth = 26;
            this.CargaBar.ProgressColor = System.Drawing.SystemColors.Highlight;
            this.CargaBar.ProgressWidth = 25;
            this.CargaBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.CargaBar.Size = new System.Drawing.Size(199, 183);
            this.CargaBar.StartAngle = 270;
            this.CargaBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.CargaBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.CargaBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.CargaBar.SubscriptText = "";
            this.CargaBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.CargaBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.CargaBar.SuperscriptText = "%";
            this.CargaBar.TabIndex = 1;
            this.CargaBar.Text = "0";
            this.CargaBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.CargaBar.Value = 68;
            // 
            // timerOpen
            // 
            this.timerOpen.Interval = 50;
            this.timerOpen.Tick += new System.EventHandler(this.timerOpen_Tick);
            // 
            // timerClose
            // 
            this.timerClose.Interval = 50;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // picture03
            // 
            this.picture03.BackColor = System.Drawing.Color.Transparent;
            this.picture03.BackgroundImage = global::Nutrucion_App.Properties.Resources.correr02;
            this.picture03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture03.Location = new System.Drawing.Point(615, 12);
            this.picture03.Name = "picture03";
            this.picture03.Size = new System.Drawing.Size(128, 172);
            this.picture03.TabIndex = 2;
            this.picture03.TabStop = false;
            // 
            // picture02
            // 
            this.picture02.BackColor = System.Drawing.Color.Transparent;
            this.picture02.BackgroundImage = global::Nutrucion_App.Properties.Resources.correr01;
            this.picture02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture02.Location = new System.Drawing.Point(327, 12);
            this.picture02.Name = "picture02";
            this.picture02.Size = new System.Drawing.Size(128, 172);
            this.picture02.TabIndex = 2;
            this.picture02.TabStop = false;
            // 
            // picture01
            // 
            this.picture01.BackColor = System.Drawing.Color.Transparent;
            this.picture01.BackgroundImage = global::Nutrucion_App.Properties.Resources.corrert;
            this.picture01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture01.Location = new System.Drawing.Point(25, 12);
            this.picture01.Name = "picture01";
            this.picture01.Size = new System.Drawing.Size(128, 172);
            this.picture01.TabIndex = 2;
            this.picture01.TabStop = false;
            // 
            // _0021_PantallaCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.BackgroundImage = global::Nutrucion_App.Properties.Resources.fondo001rosa;
            this.ClientSize = new System.Drawing.Size(805, 439);
            this.ControlBox = false;
            this.Controls.Add(this.picture03);
            this.Controls.Add(this.picture02);
            this.Controls.Add(this.picture01);
            this.Controls.Add(this.CargaBar);
            this.Name = "_0021_PantallaCarga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this._0021_PantallaCarga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CircularProgressBar.CircularProgressBar CargaBar;
        private System.Windows.Forms.PictureBox picture01;
        private System.Windows.Forms.Timer timerOpen;
        private System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.PictureBox picture03;
        private System.Windows.Forms.PictureBox picture02;
    }
}