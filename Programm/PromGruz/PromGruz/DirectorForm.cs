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
    public partial class DirectorForm : Form
    {

        private UserInfo userInfo;

        private Sort sortHelper = new Sort();

        public DirectorForm(UserInfo userInfo)
        {

            InitializeComponent();

            this.userInfo = userInfo;

            // Установить фиксированный минимальный и максимальный размер окна
            this.MinimumSize = new Size(1200, 650);
            this.MaximumSize = new Size(1200, 650);

        }

        private void DirectorForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            // Здесь не вызываем Application.Exit(), а показываем форму авторизации 
            AuthenticationForm.Instance.Show();

        }

        private void DirectorForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Роли". При необходимости она может быть перемещена или удалена.
            this.ролиTableAdapter.Fill(this.грузоперевозкиDataSet1.Роли);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Грузы". При необходимости она может быть перемещена или удалена.
            this.грузыTableAdapter.Fill(this.грузоперевозкиDataSet1.Грузы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Транспортные_средства". При необходимости она может быть перемещена или удалена.
            this.транспортные_средстваTableAdapter.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Маршруты". При необходимости она может быть перемещена или удалена.
            this.маршрутыTableAdapter.Fill(this.грузоперевозкиDataSet1.Маршруты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Перевозки". При необходимости она может быть перемещена или удалена.
            this.перевозкиTableAdapter.Fill(this.грузоперевозкиDataSet1.Перевозки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Водители". При необходимости она может быть перемещена или удалена.
            this.водителиTableAdapter.Fill(this.грузоперевозкиDataSet1.Водители);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.грузоперевозкиDataSet1.Пользователи);

            // Вызываем метод FillComboBoxWithColumns, передавая ComboBox и DataGridView
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsUser, dataGridView1);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsVoditel, dataGridView2);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsPerevozki, dataGridView3);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsMarshrut, dataGridView4);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsTransport, dataGridView5);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsGruz, dataGridView6);

        }

        //
        //  Добавить Водителя
        //

        private void button3_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            int driverId;
            if (!int.TryParse(textBox_driverId.Text.Trim(), out driverId))
            {
                MessageBox.Show("Введите корректный номер водителя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fio = textBox_driverName.Text.Trim();
            string phoneNumber = textBox_driverFone.Text.Trim();
            string birthDateStr = textBox_driverRozh.Text.Trim();
            string experienceStr = textBox_driverStazh.Text.Trim();
            string inn = textBox_driverInn.Text.Trim();
            string login = textBox_driverLogin.Text.Trim();
            string password = textBox_driverPassword.Text.Trim();

            // Проверка на заполненность обязательных полей
            if (string.IsNullOrEmpty(fio) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(birthDateStr) ||
                string.IsNullOrEmpty(experienceStr) || string.IsNullOrEmpty(inn) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все обязательные поля.\nПроверьте инструкцию!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка правильного формата данных
            if (!DateTime.TryParse(birthDateStr, out DateTime birthDate) || !int.TryParse(experienceStr, out int experience))
            {
                MessageBox.Show("Проверьте правильность ввода данных.\nПроверьте инструкцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка на размер вводимых данных
            if (fio.Length > 255 || phoneNumber.Length > 20 || inn.Length > 12 || login.Length > 50 || password.Length > 50)
            {
                MessageBox.Show("Превышен допустимый размер данных.\nПроверьте инструкцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка наличия существующего номера водителя
            if (CheckDriverIdExists(driverId))
            {
                MessageBox.Show("Водитель с таким номером уже существует. Пожалуйста, выберите другой номер.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на возрастающую последовательность номера водителя
            if (CheckDriverIdSequence(driverId))
            {
                MessageBox.Show("Пожалуйста, введите следующий по порядку номер водителя.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Добавляем запись в базу данных
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Водители (Номер, ФИО, Номер_телефона, Дата_рождения, Стаж_вождения, ИНН, Логин_водителя, Пароль_водителя) " +
                                    "VALUES (@DriverId, @FIO, @PhoneNumber, @BirthDate, @Experience, @INN, @Login, @Password)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriverId", driverId);
                        command.Parameters.AddWithValue("@FIO", fio);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@BirthDate", birthDate);
                        command.Parameters.AddWithValue("@Experience", experience);
                        command.Parameters.AddWithValue("@INN", inn);
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@Password", password);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Водитель успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.водителиTableAdapter.Fill(this.грузоперевозкиDataSet1.Водители);

                // Очищаем текстовые поля после успешного добавления
                ClearDriverTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении водителя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private bool CheckDriverIdExists(int driverId)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Водители WHERE Номер = @DriverId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverId", driverId);
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private bool CheckDriverIdSequence(int driverId)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT MAX(Номер) FROM Водители";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int maxDriverId = Convert.ToInt32(result);
                        return driverId != maxDriverId + 1;
                    }

                    // Если база данных пуста, возвращаем false
                    return false;
                }
            }
        }


        private void ClearDriverTextBoxes()
        {
            // Очищаем текстовые поля для водителей
            textBox_driverId.Clear();
            textBox_driverName.Clear();
            textBox_driverFone.Clear();
            textBox_driverRozh.Clear();
            textBox_driverStazh.Clear();
            textBox_driverInn.Clear();
            textBox_driverLogin.Clear();
            textBox_driverPassword.Clear();
        }

        //
        //  Отчёты
        //

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Otchet otchet = new Otchet();

            // Показываем диалоговое окно для выбора пути сохранения
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.Title = "Выберите место для сохранения отчета";
            saveFileDialog.FileName = "Отчёт_'Завершённые_перевозки'_" + DateTime.Now.ToString("yyyy-MM-dd");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Вызываем метод для генерации отчета с выбранным пользователем путем
                otchet.ZaverwennieToWord(saveFileDialog.FileName);
            }
        }

        private void wordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Otchet otchet = new Otchet();

            // Показываем диалоговое окно для выбора пути сохранения
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.Title = "Выберите место для сохранения отчета";
            saveFileDialog.FileName = "Отчёт_'Незавершённые_перевозки'_" + DateTime.Now.ToString("yyyy-MM-dd");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Вызываем метод для генерации отчета с выбранным пользователем путем
                otchet.NezaverwennieToWord(saveFileDialog.FileName);
            }
        }

        private void wordToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Otchet otchet = new Otchet();

            // Показываем диалоговое окно для выбора пути сохранения
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.Title = "Выберите место для сохранения отчета";
            saveFileDialog.FileName = "Отчёт_'Популярный_маршрут'_" + DateTime.Now.ToString("yyyy-MM-dd");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Вызываем метод для генерации отчета с выбранным пользователем путем
                otchet.GeneratePopularRouteToWord(saveFileDialog.FileName);
            }
        }

        private void wordToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Otchet otchet = new Otchet();

            // Показываем диалоговое окно для выбора пути сохранения
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.Title = "Выберите место для сохранения отчета";
            saveFileDialog.FileName = "Отчёт_'Лучший_водитель'_" + DateTime.Now.ToString("yyyy-MM-dd");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Вызываем метод для генерации отчета с выбранным пользователем путем
                otchet.GenerateBestDriverToWord(saveFileDialog.FileName);
            }
        }

        private void wordToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Otchet otchet = new Otchet();

            // Показываем диалоговое окно для выбора пути сохранения
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.Title = "Выберите место для сохранения отчета";
            saveFileDialog.FileName = "Отчёт_'Анализ_длинны_маршрутов'_" + DateTime.Now.ToString("yyyy-MM-dd");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Вызываем метод для генерации отчета с выбранным пользователем путем
                otchet.GenerateRouteLengthAnalysisToWord(saveFileDialog.FileName);
            }
        }

        private void wordToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Otchet otchet = new Otchet();

            // Показываем диалоговое окно для выбора пути сохранения
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.Title = "Выберите место для сохранения отчета";
            saveFileDialog.FileName = "Отчёт_'Анализ веса груза'_" + DateTime.Now.ToString("yyyy-MM-dd");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Вызываем метод для генерации отчета с выбранным пользователем путем
                otchet.GenerateWeightAnalysisToWord(saveFileDialog.FileName);
            }
        }

        private void wordToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Otchet otchet = new Otchet();

            // Показываем диалоговое окно для выбора пути сохранения
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.Title = "Выберите место для сохранения отчета";
            saveFileDialog.FileName = "Отчёт_'Анализ_грузопъёмности'_" + DateTime.Now.ToString("yyyy-MM-dd");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Вызываем метод для генерации отчета с выбранным пользователем путем
                otchet.GeneratePayloadAnalysisToWord(saveFileDialog.FileName);
            }
        }

        private void wordToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Otchet otchet = new Otchet();

            // Показываем диалоговое окно для выбора пути сохранения
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.Title = "Выберите место для сохранения отчета";
            saveFileDialog.FileName = "Отчёт_'Анализ_марки'_" + DateTime.Now.ToString("yyyy-MM-dd");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Вызываем метод для генерации отчета с выбранным пользователем путем
                otchet.GenerateBrandAnalysisToWord(saveFileDialog.FileName);
            }
        }

        private void wordToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Otchet otchet = new Otchet();

            // Показываем диалоговое окно для выбора пути сохранения
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.Title = "Выберите место для сохранения отчета";
            saveFileDialog.FileName = "Отчёт_'Анализ_стажа'_" + DateTime.Now.ToString("yyyy-MM-dd");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Вызываем метод для генерации отчета с выбранным пользователем путем
                otchet.GenerateDriverExperienceAnalysisToWord(saveFileDialog.FileName);

            }
        }


        //
        // Добавить пользователя
        //

        private void button_addPol_Click(object sender, EventArgs e)
        {
            int userId;
            if (int.TryParse(textBox_polNum.Text, out userId))
            {
                if (!UserExists(userId) && IsNextNumber(userId))
                {
                    // Номер пользователя не существует и следующий, можно добавлять
                    string login = textBox_polLogin.Text;
                    string password = textBox_polPassword.Text;
                    int roleId = int.Parse(textBox_polRole.Text);

                    string insertQuery = $"INSERT INTO Пользователи (Номер, Логин, Пароль, Номер_Роли) VALUES ({userId}, '{login}', '{password}', {roleId})";

                    if (ExecuteQuery(insertQuery))
                    {

                        this.пользователиTableAdapter.Fill(this.грузоперевозкиDataSet1.Пользователи);

                        MessageBox.Show("Пользователь успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearTextBoxes();

                    }
                }
                else
                {
                    MessageBox.Show("Некорректный номер пользователя или пользователь с таким номером уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите корректный номер пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsNextNumber(int userId)
        {
            string query = "SELECT MAX(Номер) FROM Пользователи";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    int maxNumber = Convert.ToInt32(result);
                    return userId == maxNumber + 1;
                }

                // Если таблица пуста, новый номер должен быть равен 1
                return userId == 0;
            }
        }

        private bool ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private bool UserExists(int userId)
        {
            string query = $"SELECT COUNT(*) FROM Пользователи WHERE Номер = {userId}";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void ClearTextBoxes()
        {
            // Очистка текстовых полей
            textBox_polNum.Text = "";
            textBox_polLogin.Text = "";
            textBox_polPassword.Text = "";
            textBox_polRole.Text = "";
        }





        //  Открыть инструкцию по Заполнению
        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstactionZapolnenieForm instactionZapolnenieForm = new InstactionZapolnenieForm();
            instactionZapolnenieForm.Show();
        }
        //  Открыть инструкцию по Созданию отчётов
        private void созданиеОтчётовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstractionOtchetiForm instractionOtchetiForm = new InstractionOtchetiForm();   
            instractionOtchetiForm.Show();
        }
        //  Открыть инструкцию по Поиску
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstractionPoiskForm instractionPoiskForm = new InstractionPoiskForm();
            instractionPoiskForm.Show();
        }


        //
        //  Очистить сортировку
        //



        private void button9_Click(object sender, EventArgs e)
        {
            // Очистка текстовых полей
            textBox_SearchPerevozka.Text = "";
            textBox_SearchMarshrut.Text = "";
            textBox_SearchTransport.Text = "";
            textBox_SearchVoditel.Text = "";
            textBox_SearchGruz.Text = "";
            textBox_SearchUser.Text = "";

            // Загрузка данных из базы в таблицы DataSet
            this.грузыTableAdapter.Fill(this.грузоперевозкиDataSet1.Грузы);
            this.транспортные_средстваTableAdapter.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
            this.маршрутыTableAdapter.Fill(this.грузоперевозкиDataSet1.Маршруты);
            this.перевозкиTableAdapter.Fill(this.грузоперевозкиDataSet1.Перевозки);
            this.пользователиTableAdapter.Fill(this.грузоперевозкиDataSet1.Пользователи);
            this.водителиTableAdapter.Fill(this.грузоперевозкиDataSet1.Водители);

            // Очистка сортировки в DataGridView
            dataGridView1.DataSource = грузоперевозкиDataSet1.Пользователи;
            dataGridView2.DataSource = грузоперевозкиDataSet1.Водители;
            dataGridView3.DataSource = грузоперевозкиDataSet1.Перевозки;
            dataGridView4.DataSource = грузоперевозкиDataSet1.Маршруты;
            dataGridView5.DataSource = грузоперевозкиDataSet1.Транспортные_средства;
            dataGridView6.DataSource = грузоперевозкиDataSet1.Грузы;

            MessageBox.Show("Фильтры сортировки сброшены.");
        }




        private void textBox_SearchPerevozka_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView3, грузоперевозкиDataSet1.Перевозки, comboBox_ColumnsPerevozki, textBox_SearchPerevozka);
        }

        private void textBox_SearchMarshrut_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView4, грузоперевозкиDataSet1.Маршруты, comboBox_ColumnsMarshrut, textBox_SearchMarshrut);
        }

        private void textBox_SearchVoditel_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView2, грузоперевозкиDataSet1.Водители, comboBox_ColumnsVoditel, textBox_SearchVoditel);
        }


        private void textBox_SearchTransport_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView5, грузоперевозкиDataSet1.Транспортные_средства, comboBox_ColumnsTransport, textBox_SearchTransport);
        }

        private void textBox_SearchGruz_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView6, грузоперевозкиDataSet1.Грузы, comboBox_ColumnsGruz, textBox_SearchGruz);
        }

        private void textBox_SearchUser_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView1, грузоперевозкиDataSet1.Пользователи, comboBox_ColumnsUser, textBox_SearchUser);
        }
    }
}
