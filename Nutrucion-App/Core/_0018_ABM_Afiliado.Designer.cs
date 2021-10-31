namespace Nutrucion_App.Core
{
    partial class _0018_ABM_Afiliado
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
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.txtAfiliado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(94, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "Paciente";
            // 
            // txtPaciente
            // 
            this.txtPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaciente.Location = new System.Drawing.Point(249, 105);
            this.txtPaciente.Multiline = true;
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(254, 31);
            this.txtPaciente.TabIndex = 12;
            this.txtPaciente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAfiliado
            // 
            this.txtAfiliado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAfiliado.Location = new System.Drawing.Point(249, 182);
            this.txtAfiliado.Multiline = true;
            this.txtAfiliado.Name = "txtAfiliado";
            this.txtAfiliado.Size = new System.Drawing.Size(305, 31);
            this.txtAfiliado.TabIndex = 12;
            this.txtAfiliado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(73, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "N° Afiliado";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(509, 105);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(45, 31);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // _0018_ABM_Afiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Nutrucion_App.Properties.Resources.fondo001rosa;
            this.ClientSize = new System.Drawing.Size(716, 265);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAfiliado);
            this.Controls.Add(this.txtPaciente);
            this.Name = "_0018_ABM_Afiliado";
            this.Text = "_0018_ABM_Afiliado";
            this.Controls.SetChildIndex(this.txtPaciente, 0);
            this.Controls.SetChildIndex(this.txtAfiliado, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.TextBox txtAfiliado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
    }
}