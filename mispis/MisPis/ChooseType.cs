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
    public partial class ChooseType : Form
    {
        public ChooseType()
        {
            InitializeComponent();
        }

        private void button_fullness_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.Text = this.Text + " " + button_fullness.Text;
            test.Show();
            this.Hide();
            
        }

        private void button_integrity_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.Text = this.Text + " " + button_integrity.Text;
            test.Show();
            this.Hide();
        }

        private void button_skill_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.Text = this.Text + " " + button_skill.Text;
            test.Show();
            this.Hide();
        }
    }
}
