using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MisPis
{
    public partial class Main : Form
    {
        database db = new database();
        List<string> names = new List<string>();
        List<string> types = new List<string>();
        
        public Main()
        {
            
            InitializeComponent();
            
        }

        private void button_approximation_Click(object sender, EventArgs e)
        {
            subUnitForm subUnit = new subUnitForm();
            subUnit.Text = this.Text+ " "+ "Аппроксимация";
            this.Close();
            subUnit.Show();
        }

        private void button_interpolation_Click(object sender, EventArgs e)
        {
            subUnitForm subUnit = new subUnitForm();
            subUnit.Text = this.Text + " " + "Интерполяция";
            this.Close();
            subUnit.Show();
        }

        private void button_poly_Click(object sender, EventArgs e)
        {
            subUnitForm subUnit = new subUnitForm();
            subUnit.Text = this.Text + " " + "Полиномы";
            this.Close();
            subUnit.Show();
        }

        private void LoadChart(string type1, string login, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            types.Add("Полнота");
            types.Add("Целостность");
            types.Add("Умение");
            db.openConnection();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            SqlDataAdapter adapter3 = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select * from report where type_math = '{type1}' and login_ = '{login}' and type_question = '{types[0]}'";
            SqlCommand command = new SqlCommand(querystring, db.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if(table.Rows.Count > 0)
                chart.Series[0].Points.Add((double) int.Parse(table.Rows[0][1].ToString()) / (double) int.Parse(table.Rows[0][2].ToString()));

            DataTable table2 = new DataTable();
            querystring = $"select * from report where type_math = '{type1}' and login_ = '{login}' and type_question = '{types[1]}'";
            SqlCommand command2 = new SqlCommand(querystring, db.GetConnection());
            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);
            if (table2.Rows.Count > 0)
                chart.Series[0].Points.Add((double)int.Parse(table2.Rows[0][1].ToString()) / (double)int.Parse(table2.Rows[0][2].ToString()));

            DataTable table3 = new DataTable();
            querystring = $"select * from report where type_math = '{type1}' and login_ = '{login}' and type_question = '{types[2]}'";
            SqlCommand command3 = new SqlCommand(querystring, db.GetConnection());
            adapter3.SelectCommand = command3;
            adapter3.Fill(table3);
            if (table3.Rows.Count > 0)
                chart.Series[0].Points.Add((double)int.Parse(table3.Rows[0][1].ToString()) / (double)int.Parse(table3.Rows[0][2].ToString()));

            db.closeConnection();
        }

        private void updateChart(List<double> stats, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas[0].AxisY.Maximum = 1;
            List<string> seriesNames = new List<string>() { "Полнота","Целостность","Умение"};
            for(int i = 0; i < 3; i++)
            {
                var color = Color.White;
                if (i == 0)
                    color = Color.Red;
                if (i == 1)
                    color = Color.Yellow;
                if (i == 2)
                    color = Color.Blue;
                chart.Series.Add(seriesNames[i]);
                chart.Series[i].LegendText = seriesNames[i];
                loadToSeries(stats[i], color, chart.Series[i]);
            }
            chart.Series.Add("");
            chart.Series[3].LegendText = "";
            loadToSeries(1.0, Color.White, chart.Series[3]);
        }

        private void loadToSeries(double stat, Color clr, System.Windows.Forms.DataVisualization.Charting.Series series)
        {
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series.Points.Add(stat);
            series.Color = clr;
        }

        void Main_Load(object sender, EventArgs e)
        {
            /*
            string[] splitted = Text.Split();
            string login = splitted[0];
            LoadChart("Аппроксимация", login, chart1);
            LoadChart("Интерполяция", login, chart2);
            LoadChart("Полиномы", login, chart3);
            */
        }

        private void button_reload_Click(object sender, EventArgs e)
        {
            string[] splitted = Text.Split();
            string login = splitted[0];
            LoadChart("Аппроксимация", login, chart1);
            LoadChart("Интерполяция", login, chart2);
            LoadChart("Полиномы", login, chart3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> nums = new List<double>() {0.3, 0.8, 0.7 };
            updateChart(nums, chart1);
        }

        private void LoadChart(string type1, string login, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            types.Add("Полнота");
            types.Add("Целостность");
            types.Add("Умение");
            db.openConnection();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            SqlDataAdapter adapter3 = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select * from report where type_math = '{type1}' and login_ = '{login}' and type_question = '{types[0]}'";
            SqlCommand command = new SqlCommand(querystring, db.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if(table.Rows.Count > 0)
                chart.Series[0].Points.Add((double) int.Parse(table.Rows[0][1].ToString()) / (double) int.Parse(table.Rows[0][2].ToString()));

            DataTable table2 = new DataTable();
            querystring = $"select * from report where type_math = '{type1}' and login_ = '{login}' and type_question = '{types[1]}'";
            SqlCommand command2 = new SqlCommand(querystring, db.GetConnection());
            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);
            if (table2.Rows.Count > 0)
                chart.Series[0].Points.Add((double)int.Parse(table2.Rows[0][1].ToString()) / (double)int.Parse(table2.Rows[0][2].ToString()));

            DataTable table3 = new DataTable();
            querystring = $"select * from report where type_math = '{type1}' and login_ = '{login}' and type_question = '{types[2]}'";
            SqlCommand command3 = new SqlCommand(querystring, db.GetConnection());
            adapter3.SelectCommand = command3;
            adapter3.Fill(table3);
            if (table3.Rows.Count > 0)
                chart.Series[0].Points.Add((double)int.Parse(table3.Rows[0][1].ToString()) / (double)int.Parse(table3.Rows[0][2].ToString()));

            db.closeConnection();
        }

        void Main_Load(object sender, EventArgs e)
        {
            /*
            string[] splitted = Text.Split();
            string login = splitted[0];
            LoadChart("Аппроксимация", login, chart1);
            LoadChart("Интерполяция", login, chart2);
            LoadChart("Полиномы", login, chart3);
            */
        }

        private void button_reload_Click(object sender, EventArgs e)
        {
            string[] splitted = Text.Split();
            string login = splitted[0];
            LoadChart("Аппроксимация", login, chart1);
            LoadChart("Интерполяция", login, chart2);
            LoadChart("Полиномы", login, chart3);
        }
    }
}
