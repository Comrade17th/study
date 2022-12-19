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
    public partial class Test : Form
    {
        int ms = 60*1000;
        List<string> answers = new List<string>();
        List<int> goals = new List<int>();
        List<string> userAnswers = new List<string>();
        List<string> questions = new List<string>();
        int total_goal;
        string[] names;
        database db = new database();
        public Test()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ms -= timer1.Interval;
            label_timer.Text = getTime(ms);
        }

        private string getTime(int ms)
        {
            return ($"Оствашееся время {(ms/1000)/60}:{(ms/1000)%60}");
        }

        private void fillFields()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            names = this.Text.Split();

            string querystring = $"select * from questions where type_math = '{names[1]}' and type_question = '{names[3]}'";
            SqlCommand command = new SqlCommand(querystring, db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                int timer_add_time = 0;
                for(int i = 0; i < table.Rows.Count; i++)
                {
                    //booksTable.Rows[0][2] = 300; //третьей ячейке первой строки присваивается значение 300
                    questions.Add(table.Rows[i][1].ToString());
                    answers.Add(table.Rows[i][2].ToString());
                    goals.Add(int.Parse(table.Rows[i][3].ToString()));
                    timer_add_time += int.Parse(table.Rows[i][3].ToString());
                    total_goal = int.Parse(table.Rows[i][4].ToString());
                }
                ms *= timer_add_time * 3;
                
                richTextBox1.Text = questions[0];
                richTextBox2.Text = questions[1];
                richTextBox3.Text = questions[2];
            }
            else
            {
                MessageBox.Show("Вопросов для этого теста нет");
            }
        }

        private void testEnded()
        {
            
            int result = 0;
            if (textBox1.Text == answers[0])
                result += 1;
            if (textBox2.Text == answers[1])
                result += 3;
            if (textBox3.Text == answers[2])
                result += 5;


            string querystring = 
                $"insert into report (result, total_goal, type_math, type_question, login_)" +
                $"Values({result}, {total_goal}, '{names[1]}', '{names[2]}', '{names[0]}')";
            SqlCommand cmd = new SqlCommand(querystring, db.GetConnection());
            db.openConnection();

            int mark = getMark(result, total_goal);
            if (cmd.ExecuteNonQuery() == 1)
                MessageBox.Show($"Ваш ответ сохранен\nВаш результат: {result}/{total_goal}\nВаша оценка {mark}");
            else
                MessageBox.Show("Ваш не удалось сохранить");
            db.closeConnection();

            Main main = new Main();
            this.Hide();
            main.Show();
            //main.Main_Load();
            this.Close();
        }

        private int getMark(int result, int total_goal)
        {
            int mark = 2;
            double res = (double)result / (double)total_goal;
            if (res * 100 < 60)
                mark = 2;
            else
            if (res * 100 >= 60 && res * 100 < 72)
                mark = 3;
            else
            if (res * 100 >= 72 && res * 100 <= 93)
                mark = 4;
            else
                mark = 5;
            return mark;
        }
        private void button_start_Click(object sender, EventArgs e)
        {
            button_start.Enabled = false;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            fillFields();

            button_end.Enabled = true;
        }

        private void button_end_Click(object sender, EventArgs e)
        {
            testEnded();
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }
    }
}
