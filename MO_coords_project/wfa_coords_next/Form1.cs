using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace wfa_coords_next
{
    public partial class Form1 : Form
    {
        int i_ = 0;
        Dot dt1 = new Dot(-2, -2);
        Dot dt2 = new Dot(-2, 2);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private System.Windows.Forms.DataVisualization.Charting.Series newLine(Dot dt1, Dot dt2)
        {
            System.Windows.Forms.DataVisualization.Charting.Series sr = new System.Windows.Forms.DataVisualization.Charting.Series();
            sr.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            sr.Points.AddXY(dt1.X, dt1.Y);
            sr.Points.AddXY(dt2.X, dt2.Y);
            return sr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = 10, b = -10;
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[0].Points.AddXY(a, b);
            int i = 0;
            while(i < 1)
            {
                a += 0.1;
                b += 0.1;
                this.chart1.Series[0].Points.AddXY(a, b);
                i++;
            }
            this.chart1.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            this.chart1.Series[1].Points.AddXY(10, 10);
            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            this.chart1.Series[1].BorderColor = System.Drawing.Color.Red;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.chart1.Series.Add(newLine(dt1, dt2));
            dt1.X += 2;
            dt2.X += 2;
        }
    }
}
