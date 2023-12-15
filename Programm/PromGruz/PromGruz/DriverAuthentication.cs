using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PromGruz
{
    public class DriverAuthentication
    {
        private SqlConnection connection;

        public DriverAuthentication(SqlConnection dbConnection)
        {
            connection = dbConnection;
        }

        public bool AuthenticateDriver(string login, string password)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Водители WHERE Логин_водителя = @Login AND Пароль_водителя = @Password", connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при авторизации водителя: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
