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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button_approximation_Click(object sender, EventArgs e)
        {
            ChooseType chooseFrm = new ChooseType();
            chooseFrm.Text = this.Text+ " "+ "Аппроксимация";
            this.Close();
            chooseFrm.Show();
        }

        private void button_interpolation_Click(object sender, EventArgs e)
        {
            ChooseType chooseFrm = new ChooseType();
            chooseFrm.Text = this.Text + " " + "Интерполяция";
            this.Close();
            chooseFrm.Show();
        }

        private void button_poly_Click(object sender, EventArgs e)
        {
            ChooseType chooseFrm = new ChooseType();
            chooseFrm.Text = this.Text + " " + "Полиномы";
            this.Close();
            chooseFrm.Show();
        }
    }
}
