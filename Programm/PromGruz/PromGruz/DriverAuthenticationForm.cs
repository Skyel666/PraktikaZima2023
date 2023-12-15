using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromGruz
{
    public partial class DriverAuthenticationForm : Form
    {



        public DriverAuthenticationForm()
        {
            InitializeComponent();

            // Запретить изменение размеров окна
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Установить фиксированный минимальный и максимальный размер окна
            this.MinimumSize = new Size(500, 300);
            this.MaximumSize = new Size(500, 300);

        }

        private void DriverAuthenticationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Здесь не вызываем Application.Exit(), а показываем форму авторизации или другую форму
            AuthenticationForm.Instance.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AuthenticationForm.Instance.Show();
        }

        // Vhod voditelya


        // Объявление переменной currentUserId в классе формы
        private int currentUserId = -1;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем введенные логин и пароль
                string enteredLogin = textBox_login.Text.Trim();
                string enteredPassword = textBox_password.Text.Trim();

                // Проводим аутентификацию
                int authenticatedUserId = AuthenticateDriver(enteredLogin, enteredPassword);

                // Проверяем результат аутентификации
                if (authenticatedUserId != -1)
                {
                    // Аутентификация прошла успешно, открываем форму для водителя
                    DriverForm driverForm = new DriverForm(authenticatedUserId);
                    driverForm.Show();
                    this.Hide(); // Скрываем текущую форму (если это необходимо)
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль. Попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка аунтификации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int AuthenticateDriver(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT Номер FROM Водители WHERE Логин_водителя = @Login AND Пароль_водителя = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }

                    return -1; // В случае неудачной аутентификации
                }
            }
        }

    }
}
