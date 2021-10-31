namespace Nutrucion_App.Core
{
    partial class _0016_Informe_Grafico
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerarGrafico = new System.Windows.Forms.Button();
            this.cmbFechaHasta = new System.Windows.Forms.ComboBox();
            this.cmbFechaDesde = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chartPeso = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chartPorcentaje = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeso)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPorcentaje)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.btnGenerarGrafico);
            this.panel1.Controls.Add(this.cmbFechaHasta);
            this.panel1.Controls.Add(this.cmbFechaDesde);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 107);
            this.panel1.TabIndex = 0;
            // 
            // btnGenerarGrafico
            // 
            this.btnGenerarGrafico.BackColor = System.Drawing.Color.DimGray;
            this.btnGenerarGrafico.BackgroundImage = global::Nutrucion_App.Properties.Resources.grafico;
            this.btnGenerarGrafico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerarGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarGrafico.ForeColor = System.Drawing.Color.White;
            this.btnGenerarGrafico.Location = new System.Drawing.Point(298, -3);
            this.btnGenerarGrafico.Name = "btnGenerarGrafico";
            this.btnGenerarGrafico.Size = new System.Drawing.Size(145, 107);
            this.btnGenerarGrafico.TabIndex = 8;
            this.btnGenerarGrafico.Text = "Generar Grafico";
            this.btnGenerarGrafico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerarGrafico.UseVisualStyleBackColor = false;
            this.btnGenerarGrafico.Click += new System.EventHandler(this.btnGenerarGrafico_Click);
            // 
            // cmbFechaHasta
            // 
            this.cmbFechaHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFechaHasta.FormattingEnabled = true;
            this.cmbFechaHasta.Location = new System.Drawing.Point(517, 47);
            this.cmbFechaHasta.Name = "cmbFechaHasta";
            this.cmbFechaHasta.Size = new System.Drawing.Size(200, 28);
            this.cmbFechaHasta.TabIndex = 1;
            // 
            // cmbFechaDesde
            // 
            this.cmbFechaDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFechaDesde.FormattingEnabled = true;
            this.cmbFechaDesde.Location = new System.Drawing.Point(8, 47);
            this.cmbFechaDesde.Name = "cmbFechaDesde";
            this.cmbFechaDesde.Size = new System.Drawing.Size(200, 28);
            this.cmbFechaDesde.TabIndex = 0;
            this.cmbFechaDesde.SelectedIndexChanged += new System.EventHandler(this.cmbFechaDesde_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(534, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "Fecha Hasta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(31, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 27);
            this.label8.TabIndex = 7;
            this.label8.Text = "Fecha desde";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightPink;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 542);
            this.panel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.chartPeso);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 299);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(720, 237);
            this.panel6.TabIndex = 4;
            // 
            // chartPeso
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPeso.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPeso.Legends.Add(legend1);
            this.chartPeso.Location = new System.Drawing.Point(0, 0);
            this.chartPeso.Name = "chartPeso";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.Legend = "Legend1";
            series1.MarkerSize = 7;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Valores";
            this.chartPeso.Series.Add(series1);
            this.chartPeso.Size = new System.Drawing.Size(717, 234);
            this.chartPeso.TabIndex = 0;
            this.chartPeso.Text = "chart1";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkGray;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 275);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(720, 24);
            this.panel5.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Peso";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chartPorcentaje);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 38);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(720, 237);
            this.panel4.TabIndex = 4;
            // 
            // chartPorcentaje
            // 
            chartArea2.Name = "ChartArea1";
            this.chartPorcentaje.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPorcentaje.Legends.Add(legend2);
            this.chartPorcentaje.Location = new System.Drawing.Point(0, 0);
            this.chartPorcentaje.Name = "chartPorcentaje";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series2.Legend = "Legend1";
            series2.MarkerSize = 7;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Musculo";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series3.Legend = "Legend1";
            series3.MarkerSize = 7;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "Grasa";
            this.chartPorcentaje.Series.Add(series2);
            this.chartPorcentaje.Series.Add(series3);
            this.chartPorcentaje.Size = new System.Drawing.Size(717, 231);
            this.chartPorcentaje.TabIndex = 0;
            this.chartPorcentaje.Text = "chart1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(720, 38);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Porcentaje de Musculo y Grasa";
            // 
            // _0016_Informe_Grafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 649);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "_0016_Informe_Grafico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Informes Graficos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPeso)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPorcentaje)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPeso;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPorcentaje;
        private System.Windows.Forms.ComboBox cmbFechaHasta;
        private System.Windows.Forms.ComboBox cmbFechaDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerarGrafico;
        private System.Windows.Forms.Label label3;
    }
}