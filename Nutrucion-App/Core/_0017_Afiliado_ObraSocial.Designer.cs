namespace Nutrucion_App.Core
{
    partial class _0017_Afiliado_ObraSocial
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
            this.cmbObraSocial = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbObraSocial
            // 
            this.cmbObraSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObraSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbObraSocial.FormattingEnabled = true;
            this.cmbObraSocial.Location = new System.Drawing.Point(171, 126);
            this.cmbObraSocial.Name = "cmbObraSocial";
            this.cmbObraSocial.Size = new System.Drawing.Size(228, 33);
            this.cmbObraSocial.TabIndex = 4;
            this.cmbObraSocial.SelectedIndexChanged += new System.EventHandler(this.cmbObraSocial_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(-1, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 27);
            this.label8.TabIndex = 8;
            this.label8.Text = "Obra Social :";
            // 
            // _0017_Afiliado_ObraSocial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 574);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbObraSocial);
            this.Name = "_0017_Afiliado_ObraSocial";
            this.Text = "Afiliados - Obra Social";
            this.Controls.SetChildIndex(this.cmbObraSocial, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbObraSocial;
        private System.Windows.Forms.Label label8;
    }
}