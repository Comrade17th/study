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
    public partial class Login : Form
    {
        database database_ = new database();
        
        public Login()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            if(login != "")
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                string querystring = $"select id, login_ from users where login_ = '{login}'";
                SqlCommand command = new SqlCommand(querystring, database_.GetConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);
                if(table.Rows.Count > 0)
                {
                    Main main = new Main();
                    main.Text = login;
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Такого пользователя нет");
                }
                // Заходим
            }
            else
            {
                MessageBox.Show("Поле пустое");
            }
        }
    }
}
