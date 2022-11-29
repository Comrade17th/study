using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;


namespace wfa_coords_next
{
    public partial class Form1 : Form
    {
        int i_ = 0;
        Dot dt1 = new Dot(-2, -2);
        Dot dt2 = new Dot(-2, 2);
        static int[,] arr = new int[,] {
            {7, 2, 0, 0, 0, 0},
            { 0, 27, 33, 0, 0, 0},
            { 0, 0, 32, 49, 7, 0 },
            { 0, 0, 10, 11, 2, 6},
            { 0, 0, 0, 9, 7, 3 }
        };
        //Matrix matrix = new Matrix(6);
        Matrix matrix = new Matrix();
        double Xstart = 60; // 60-65 65-70 ...
        double Ystart = 160; // 160-170, 170-180 ...
        double Xdt = 5;
        double Ydt = 10;
        public class Matrix
        {
            public int size;
            public int height;
            public int width;
            public int[,] arr;
            public Matrix(int size)
            {
                this.size = size;
                arr = new int[size, size];
                for(int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        arr[i, j] = i + j * (-1 * j%2);
                        if (arr[i, j] <= 0)
                            arr[i, j] = i + j + 1;
                    }
                }

            }

            public Matrix()
            {
                this.arr = new int[,] {
                    {7, 2, 0, 0, 0, 0},
                    { 0, 27, 33, 0, 0, 0},
                    { 0, 0, 32, 49, 7, 0 },
                    { 0, 0, 10, 11, 2, 6},
                    { 0, 0, 0, 9, 7, 3 },
                    { 0, 0, 0, 0, 5, 6 }
                };
                height = 6;
                size = 6;
                width = 6;
            }



            public string GetInfo(string separator)
            {
                string result = "";
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        result += arr[i, j] + separator;
                    }
                    result += "\n";
                }
                return result;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = 
                "7 2 0 0 0 0\n" +
                "0 27 33 0 0 0\n" +
                "0 0 32 49 7 0\n" +
                "0 0 10 11 2 6\n" +
                "0 0 0 9 7 3\n";

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
            this.chart1.Series[1].BorderColor = System.Drawing.Color.Blue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.chart1.Series.Add(newLine(dt1, dt2));
            dt1.X += 2;
            dt2.X += 2;
        }

        public double GetRandomNumberInRange(Random random, double minNumber, double maxNumber)
        {
            return random.NextDouble() * (maxNumber - minNumber) + minNumber;
        }

        private Dot randomDot(Random random, Dot dt)
        {
            double borderDt = 1;
            Dot result = dt;
            Random r = random;
            result.X += GetRandomNumberInRange(r, borderDt, Xdt - borderDt);
            result.Y += GetRandomNumberInRange(r, borderDt, Ydt - borderDt);

            result.X = Round(result.X, 2);
            result.Y = Round(result.Y, 2);
            return result;
        }

        private void FillField()
        {
            double Ymain;
            double Xmain;
            int dtCount = 0;
            Random random = new Random();
            //this.chart1.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            for (int i = 0; i < matrix.size; i++ ) // идем по Y
            {
                Ymain = Ystart + i * Ydt;
                for (int j = 0; j < matrix.size; j++) // идем по X
                {
                    // проходим по всем ячейкам матрицы
                    Xmain = Xstart + j * Xdt;
                    for ( int n = 0; n < matrix.arr[i, j]; n++) // Добавляем точки ячейки
                    {
                        //Dot newDot = new Dot(Xmain, Ymain);
                        richTextBox2.Text += ($"{Xmain} {Ymain}\t");
                        Dot newDot = randomDot(random, new Dot(Xmain, Ymain));

                        
                        this.chart1.Series[dtCount].Points.AddXY(newDot.X, newDot.Y);
                        this.chart1.Series[dtCount].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                        this.chart1.Series[dtCount].BorderColor = System.Drawing.Color.Blue;
                        //dtCount++;
                        richTextBox2.Text += ($"{newDot.X} {newDot.Y}\n");
                    }
                }
            }
        }

        private void ChangeChartSize()
        {
            //this.chart1.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            int extraSq = 0;
            double minX = Xstart - extraSq * Xdt;
            double minY = Ystart - extraSq * Ydt;
            richTextBox2.Text += ($"{minX} {minY}\n");
            chart1.ChartAreas[0].AxisX.Minimum = minX;// - 3 * Xdt;
            chart1.ChartAreas[0].AxisY.Minimum = minY;// - 3 * Ydt;

            //AddDotToChart(chart1, new Dot(minX + Xdt/2, minY + Ydt/2));

            double maxX = minX + (matrix.size + extraSq) * Xdt;
            double maxY = minY + (matrix.size + extraSq)* Ydt;
            richTextBox2.Text += ($"{maxX} {maxY}\n");
            //chart1.ChartAreas[0].AxisX.Maximum = maxX;
           // chart1.ChartAreas[0].AxisX.Maximum = maxY;

            //AddDotToChart(chart1, new Dot(maxX - Xdt / 2, maxY - Ydt / 2));

            chart1.ChartAreas[0].AxisX.Interval = Xdt;
            chart1.ChartAreas[0].AxisY.Interval = Ydt;

        }

        private void AddDotToChart(System.Windows.Forms.DataVisualization.Charting.Chart chart, Dot dt)
        {
            chart.Series[0].Points.AddXY(dt.X, dt.Y);
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart.Series[0].BorderColor = System.Drawing.Color.Blue;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            ChangeChartSize();
            richTextBox1.Text = matrix.GetInfo(" ");
            
            
            FillField();
        }
    }
}
