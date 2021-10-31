namespace Nutrucion_App.Core
{
    partial class _0012_ABM_Dieta
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
            this.cmbTipoPlan = new System.Windows.Forms.ComboBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.txtComida = new System.Windows.Forms.TextBox();
            this.txtCaloria = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.btnArchivo = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // cmbTipoPlan
            // 
            this.cmbTipoPlan.BackColor = System.Drawing.Color.White;
            this.cmbTipoPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoPlan.FormattingEnabled = true;
            this.cmbTipoPlan.Location = new System.Drawing.Point(173, 161);
            this.cmbTipoPlan.Name = "cmbTipoPlan";
            this.cmbTipoPlan.Size = new System.Drawing.Size(204, 32);
            this.cmbTipoPlan.TabIndex = 0;
            // 
            // txtAltura
            // 
            this.txtAltura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltura.Location = new System.Drawing.Point(288, 251);
            this.txtAltura.Multiline = true;
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(236, 31);
            this.txtAltura.TabIndex = 2;
            this.txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // txtComida
            // 
            this.txtComida.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComida.Location = new System.Drawing.Point(288, 351);
            this.txtComida.Multiline = true;
            this.txtComida.Name = "txtComida";
            this.txtComida.Size = new System.Drawing.Size(236, 31);
            this.txtComida.TabIndex = 4;
            this.txtComida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtComida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // txtCaloria
            // 
            this.txtCaloria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaloria.Location = new System.Drawing.Point(10, 351);
            this.txtCaloria.Multiline = true;
            this.txtCaloria.Name = "txtCaloria";
            this.txtCaloria.Size = new System.Drawing.Size(238, 31);
            this.txtCaloria.TabIndex = 3;
            this.txtCaloria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCaloria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // txtPeso
            // 
            this.txtPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeso.Location = new System.Drawing.Point(12, 251);
            this.txtPeso.Multiline = true;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(236, 31);
            this.txtPeso.TabIndex = 1;
            this.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(378, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Altura";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(26, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "Calorias Consumidas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(93, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Peso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(340, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "N° de Comidas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(212, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tipo de Plan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Archivo Dieta";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(10, 462);
            this.txtDocumento.Multiline = true;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(433, 31);
            this.txtDocumento.TabIndex = 18;
            this.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnArchivo
            // 
            this.btnArchivo.Location = new System.Drawing.Point(449, 464);
            this.btnArchivo.Name = "btnArchivo";
            this.btnArchivo.Size = new System.Drawing.Size(75, 31);
            this.btnArchivo.TabIndex = 5;
            this.btnArchivo.Text = "...";
            this.btnArchivo.UseVisualStyleBackColor = true;
            this.btnArchivo.Click += new System.EventHandler(this.btnArchivo_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // _0012_ABM_Dieta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Nutrucion_App.Properties.Resources.fondo001rosa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(538, 550);
            this.Controls.Add(this.btnArchivo);
            this.Controls.Add(this.cmbTipoPlan);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.txtComida);
            this.Controls.Add(this.txtCaloria);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Name = "_0012_ABM_Dieta";
            this.Text = "_0012_ABM_Dieta";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtPeso, 0);
            this.Controls.SetChildIndex(this.txtCaloria, 0);
            this.Controls.SetChildIndex(this.txtComida, 0);
            this.Controls.SetChildIndex(this.txtDocumento, 0);
            this.Controls.SetChildIndex(this.txtAltura, 0);
            this.Controls.SetChildIndex(this.cmbTipoPlan, 0);
            this.Controls.SetChildIndex(this.btnArchivo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoPlan;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.TextBox txtComida;
        private System.Windows.Forms.TextBox txtCaloria;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Button btnArchivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}