using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerTest
{
    public partial class Form1 : Form
    {
        int ms = 27*60*1000;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private string getTime(int ms)
        {

            string time = "";
            time += $"{(ms/1000)/60}:{(ms / 1000)%60}";
            return time;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ms -= timer1.Interval;
            label1.Text = getTime(ms);
            if (ms <= 0)
                label1.Text = "Время вышло";
        }
    }
}
