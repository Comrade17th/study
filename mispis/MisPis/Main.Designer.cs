namespace MisPis
{
    partial class Main
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_approximation = new System.Windows.Forms.Button();
            this.button_interpolation = new System.Windows.Forms.Button();
            this.button_poly = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_reload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // button_approximation
            // 
            this.button_approximation.Location = new System.Drawing.Point(12, 163);
            this.button_approximation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_approximation.Name = "button_approximation";
            this.button_approximation.Size = new System.Drawing.Size(239, 28);
            this.button_approximation.TabIndex = 0;
            this.button_approximation.Text = "Апроксимация";
            this.button_approximation.UseVisualStyleBackColor = true;
            this.button_approximation.Click += new System.EventHandler(this.button_approximation_Click);
            // 
            // button_interpolation
            // 
            this.button_interpolation.Location = new System.Drawing.Point(371, 163);
            this.button_interpolation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_interpolation.Name = "button_interpolation";
            this.button_interpolation.Size = new System.Drawing.Size(153, 28);
            this.button_interpolation.TabIndex = 1;
            this.button_interpolation.Text = "Интерполяция";
            this.button_interpolation.UseVisualStyleBackColor = true;
            this.button_interpolation.Click += new System.EventHandler(this.button_interpolation_Click);
            // 
            // button_poly
            // 
            this.button_poly.Location = new System.Drawing.Point(690, 163);
            this.button_poly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_poly.Name = "button_poly";
            this.button_poly.Size = new System.Drawing.Size(153, 28);
            this.button_poly.TabIndex = 2;
            this.button_poly.Text = "Полиномы";
            this.button_poly.UseVisualStyleBackColor = true;
            this.button_poly.Click += new System.EventHandler(this.button_poly_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 195);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Решение алгебраических и трансцендентных урванений";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 195);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Интерполяционные полиномы";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 218);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(239, 180);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(331, 218);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(239, 180);
            this.chart2.TabIndex = 6;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(649, 215);
            this.chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(239, 180);
            this.chart3.TabIndex = 7;
            this.chart3.Text = "chart3";
            // 
            // button_reload
            // 
            this.button_reload.Location = new System.Drawing.Point(760, 506);
            this.button_reload.Name = "button_reload";
            this.button_reload.Size = new System.Drawing.Size(174, 23);
            this.button_reload.TabIndex = 8;
            this.button_reload.Text = "Обновить графики";
            this.button_reload.UseVisualStyleBackColor = true;
            this.button_reload.Click += new System.EventHandler(this.button_reload_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 565);
            this.Controls.Add(this.button_reload);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_poly);
            this.Controls.Add(this.button_interpolation);
            this.Controls.Add(this.button_approximation);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_approximation;
        private System.Windows.Forms.Button button_interpolation;
        private System.Windows.Forms.Button button_poly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Button button_reload;
    }
}