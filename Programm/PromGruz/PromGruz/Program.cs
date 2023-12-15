using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromGruz
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        // Статическая строка подключения
        public static string ConnectionString { get; } = "Data Source=MS-SQL\\SQLEXPRESS;Initial Catalog=Грузоперевозки;Integrated Security=True;";

        [STAThread]
        static void Main()
        {
            // Создаем подключение к базе данных
            SqlConnection dbConnection = new SqlConnection(ConnectionString);

            try
            {
                // Открываем подключение
                dbConnection.Open();
                MessageBox.Show("Успешное подключение к базе данных!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение и закрываем приложение
                MessageBox.Show($"Приложению не удалось подключиться к базе данных!\nОбратитесь в тех. поддержку.\nПриложение будет закрыто.\nОшибка: {ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Завершаем приложение
            }
            finally
            {
                // Всегда закрываем подключение, чтобы избежать утечек ресурсов
                if (dbConnection.State == System.Data.ConnectionState.Open)
                    dbConnection.Close();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Запускаем приложение и передаем подключение в AuthenticationForm
            Application.Run(new AuthenticationForm(dbConnection));
        }


    }
}
