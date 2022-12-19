using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MisPis
{
    internal class database
    {

<<<<<<< HEAD
        //SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-8AH9BLU;Initial Catalog=MisPis;Integrated Security=True");
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=MisPis;Integrated Security=True");
=======
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-8AH9BLU;Initial Catalog=MisPis;Integrated Security=True");
        //SqlConnection sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=MisPis;Integrated Security=True");
>>>>>>> 0308067dd707611fe8d83f3f267b9cd5e501a750
        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }   
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

    }
}
