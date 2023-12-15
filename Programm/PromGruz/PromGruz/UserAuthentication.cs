using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms; // Добавлено пространство имен

namespace PromGruz
{
    public class UserAuthentication
    {
        private SqlConnection connection;

        public UserAuthentication(SqlConnection dbConnection)
        {
            connection = dbConnection;
        }

        public UserInfo AuthenticateUser(string login, string password)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Пользователи.Логин, Пользователи.Пароль, Роли.Роль " +
                                                    "FROM Пользователи " +
                                                    "JOIN Роли ON Пользователи.Номер_Роли = Роли.Номер " +
                                                    "WHERE Пользователи.Логин = @Login AND Пользователи.Пароль = @Password", connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string userLogin = reader["Логин"].ToString();
                    string userPassword = reader["Пароль"].ToString();
                    string userRole = reader["Роль"].ToString();

                    return new UserInfo(userLogin, userPassword, userRole);
                }
                else
                {
                    return null; // Если не найдено совпадений, возвращаем null
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при аутентификации пользователя: " + ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }



    }
}
