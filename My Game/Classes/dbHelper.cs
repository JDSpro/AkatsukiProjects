using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    public class DBHelper : IDisposable
    {
        private static DBHelper instance;
        private SqlConnection connection;

        private DBHelper()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            Connection(connectionString);
        }

        private void Connection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public static DBHelper GetInstance()
        {
            if (instance is null)
                instance = new DBHelper();
            return instance;
        }

        public void Dispose()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public int InsertIntoAccQuery(string login, string password)
        {
            string query = "INSERT INTO Accounts(Login, Password) VALUES(@login, @password)";

            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter login_param = new SqlParameter("@login", login);
            command.Parameters.Add(login_param);

            SqlParameter pswd_param = new SqlParameter("@password", password);
            command.Parameters.Add(pswd_param);
            
            command.ExecuteNonQuery();
            //MessageBox.Show($"Количество изменненых строк: {command.ExecuteNonQuery()}");

            int id = GetAccId(login, password);

            if (id == -1)
            {
                return id;
            }

            return id;
        }

        public int GetAccId(string login, string password)
        {
            string query = $"SELECT Id FROM dbo.Account Where Login = @login and Password = @password";

            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter loginParam = new SqlParameter("@login",login);
            command.Parameters.Add(loginParam);

            SqlParameter passwordParam = new SqlParameter("@password", password);
            command.Parameters.Add(passwordParam);


            int id = -1;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    };
                }
            }
            return id;
        }


    }
}
