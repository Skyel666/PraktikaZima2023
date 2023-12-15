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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PromGruz
{
    public partial class AuthenticationForm : Form
    {
        public static AuthenticationForm Instance { get; private set; }

        public AuthenticationForm(SqlConnection dbConnection)
        {
            InitializeComponent();

            // Запретить изменение размеров окна
            this.FormBorderStyle = FormBorderStyle.FixedDialog;


            // Запретить изменение размеров окна
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Установить фиксированный минимальный и максимальный размер окна
            this.MinimumSize = new Size(500, 300);
            this.MaximumSize = new Size(500, 300);

            userAuthentication = new UserAuthentication(dbConnection);

            Instance = this;  // сохраняем текущий экземпляр
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {

        }

        private UserAuthentication userAuthentication;

        private void button1_Click(object sender, EventArgs e)
        {
            DriverAuthenticationForm driverAuthenticationForm = new DriverAuthenticationForm();
            driverAuthenticationForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string login = textBox_login.Text.Trim();
                string password = textBox_password.Text.Trim();

                // Используем метод AuthenticateUser для получения информации о пользователе
                UserInfo userInfo = userAuthentication.AuthenticateUser(login, password);

                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Пожалуйста, введите логин и пароль.");
                    return;
                }

                // Добавим предопределенные значения логина и пароля для админа
                string ownerLogin = "skyel";
                string ownerPassword = "skyel666";

                // Если введены значения админа, открываем форму админа
                if (login == ownerLogin && password == ownerPassword)
                {
                    UserInfo adminInfo = new UserInfo("adminLogin", "adminPassword", "Администратор");
                    AdminForm aadminForm = new AdminForm(adminInfo);

                    aadminForm.Show();
                    this.Hide();
                    return; // Выходим из метода, чтобы не продолжать дальше

                }


                if (userInfo != null)
                {
                    MessageBox.Show("Авторизация успешна!");

                    // В зависимости от роли пользователя открываем соответствующую форму
                    switch (userInfo.Role)
                    {
                        case "Кладовщик":
                            StorekeeperForm storekeeperForm = new StorekeeperForm(userInfo);
                            storekeeperForm.Show();
                            this.Hide();
                            break;
                        case "Транспортный Менеджер":
                            TransportManagerForm transportManagerForm = new TransportManagerForm(userInfo);
                            transportManagerForm.Show();
                            this.Hide();
                            break;
                        case "Логист":
                            LogisticianForm logisticianForm = new LogisticianForm(userInfo);
                            logisticianForm.Show();
                            this.Hide();
                            break;
                        case "Администратор":
                            AdminForm adminForm = new AdminForm(userInfo);
                            adminForm.Show();
                            this.Hide();
                            break;
                        case "Директор":
                            DirectorForm directorForm = new DirectorForm(userInfo);
                            directorForm.Show();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("Неизвестная роль пользователя -  обратитесь в тех. поддержку.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                }
            }
             catch (Exception ex)
            {
                MessageBox.Show($"Ошибка аунтификации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
