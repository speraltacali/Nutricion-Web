namespace Nutrucion_App.Core
{
    partial class _0015_ABM_ObraSocial
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtObraSocial = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(37, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "Obra Social";
            // 
            // txtObraSocial
            // 
            this.txtObraSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObraSocial.Location = new System.Drawing.Point(213, 160);
            this.txtObraSocial.Multiline = true;
            this.txtObraSocial.Name = "txtObraSocial";
            this.txtObraSocial.Size = new System.Drawing.Size(305, 31);
            this.txtObraSocial.TabIndex = 10;
            this.txtObraSocial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _0015_ABM_ObraSocial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Nutrucion_App.Properties.Resources.fondo001rosa;
            this.ClientSize = new System.Drawing.Size(575, 309);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtObraSocial);
            this.Name = "_0015_ABM_ObraSocial";
            this.Text = "_0015_ABM_ObraSocial";
            this.Controls.SetChildIndex(this.txtObraSocial, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObraSocial;
    }
}