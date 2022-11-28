using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Nelder_Mid
{
    public partial class Form1 : Form
    {
        
        int clicks = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            main_chart();
        }
        

        private void main_chart()
        {
            Dot dt1 = new Dot(2, 4);
            Dot dt2 = new Dot(5, 3);
            Dot dt3 = new Dot(7, 9);
            Triangle smp = new Triangle(dt1, dt2, dt3);


            //AddPoint(smp.GetDotMiddle());
            //AddPoint(smp.GetDotReflected());
            //AddPoint(smp.GetDotExpended());
            //AddPoint(smp.GetDotContracted());

            while (smp.isEnd() != true)
            {
                smp.Sort();
                DrawTriangle(smp);
                DrawPoint(smp.GetDotMiddle());
                DrawLine(smp.GetDotReflected(), smp.GetDotMiddle()); 
                if(smp.GetDotReflected().fun < smp.dots[0].fun)
                {
                    DrawLine(smp.GetDotReflected(), smp.GetDotExpended());
                    if(smp.GetDotExpended().fun < smp.dots[0].fun)
                    {
                        smp.dots[0] = smp.GetDotExpended();
                    }
                    else
                    {
                        smp.dots[2] = smp.GetDotReflected();
                    }
                }
                else
                {
                    if(smp.GetDotReflected().fun <= smp.dots[0].fun)
                    {
                        smp.dots[2] = smp.GetDotReflected();
                    }
                    else
                    {
                        if(smp.GetDotReflected().fun <= smp.dots[2].fun)
                        {
                            DrawLine(smp.GetDotContracted(), smp.GetDotMiddle());
                            smp.dots[2] = smp.GetDotContracted();
                        }
                        else
                        {
                            smp.Srink();
                        }
                    }
                }
            }
            richTextBox1.Text = smp.GetFullInfo();
        }

        private void DrawPoint(Dot dt)
        {
            chart1.Series[0].Points.AddXY(dt.X, dt.Y);
        }

        private void AddPointToSeires(Dot dt, System.Windows.Forms.DataVisualization.Charting.Series sr)
        {
            sr.Points.AddXY(dt.X, dt.Y);
        }

        private void DrawLine(Dot dt1, Dot dt2)
        {
            chart1.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            int i = chart1.Series.Count() - 1;
            chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[i].Color = Color.Orange;
            AddPointToSeires(dt1, chart1.Series[i]);
            AddPointToSeires(dt2, chart1.Series[i]);
        }

        private void DrawTriangle(Triangle smp)
        {
            chart1.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            int i = chart1.Series.Count() - 1;
            chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[i].Color = Color.Blue;
            for (int j = 0; j < 3; j++)
                chart1.Series[i].Points.AddXY(smp.dots[j].X, smp.dots[j].Y);

            chart1.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            i = chart1.Series.Count() - 1;
            chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[i].Color = chart1.Series[i - 1].Color;
            AddPointToSeires(minX(smp.dots), chart1.Series[i]);
            AddPointToSeires(maxX(smp.dots), chart1.Series[i]);
        }

        private Dot minX(Dot[] dots)
        {
            Dot minDot = dots[0];
            for(int i = 0; i < dots.Length; i++)
                if(dots[i].X < minDot.X)
                    minDot = dots[i];
            return minDot;
        }
        private Dot maxX(Dot[] dots)
        {
            Dot maxDot = dots[0];
            for (int i = 0; i < dots.Length; i++)
                if (dots[i].X > maxDot.X)
                    maxDot = dots[i];
            return maxDot;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            chart1.Series.RemoveAt(0);
            clicks++;
        }
    }
}
