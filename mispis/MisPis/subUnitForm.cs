using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisPis
{
    public partial class subUnitForm : Form
    {
        public subUnitForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseType chooseFrm = new ChooseType();
            chooseFrm.Text = this.Text + " " + 1;
            this.Close();
            chooseFrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChooseType chooseFrm = new ChooseType();
            chooseFrm.Text = this.Text + " "+ 2;
            this.Close();
            chooseFrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChooseType chooseFrm = new ChooseType();
            chooseFrm.Text = this.Text + " " + 3;
            this.Close();
            chooseFrm.Show();
        }
    }
}
