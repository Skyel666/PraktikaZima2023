using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;

namespace PromGruz
{
    public partial class TransportManagerForm : Form
    {

        private UserInfo userInfo;
        BindingSource транспортныеСредстваBindingSource = new BindingSource();
        private Sort sortHelper = new Sort();


        public TransportManagerForm(UserInfo userInfo)
        {
            InitializeComponent();

            this.userInfo = userInfo;

            // Установить фиксированный минимальный и максимальный размер окна
            this.MinimumSize = new Size(1200, 650);
            this.MaximumSize = new Size(1200, 650);
        }

        private void TransportManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Здесь не вызываем Application.Exit(), а показываем форму авторизации или другую форму
            AuthenticationForm.Instance.Show();
        }

        private void TransportManagerForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Водители". При необходимости она может быть перемещена или удалена.
            this.водителиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Водители);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Транспортные_средства". При необходимости она может быть перемещена или удалена.
            this.транспортные_средстваTableAdapter1.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);

            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsTransport, dataGridView1);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsVoditel, dataGridView2);


        }

        //
        // Добавить авто
        //

        private void button_addAuto_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            string autoId = textBox_autoId.Text.Trim();
            string mark = textBox_mark.Text.Trim();
            string color = textBox_color.Text.Trim();

            // Проверка на заполненность текстовых полей
            if (string.IsNullOrEmpty(autoId) || string.IsNullOrEmpty(mark) || string.IsNullOrEmpty(color))
            {
                MessageBox.Show("Заполните все обязательные поля.\n" +
                    "Проверьте инструкцию!\n", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на правильный формат данных
            if (!decimal.TryParse(textBox_ves.Text, out decimal ves) ||
                !int.TryParse(textBox_vozrast.Text, out int vozrast))
            {
                MessageBox.Show("Проверьте правильность ввода данных.\n" +
                    "Проверьте инструкцию!\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string gosId = textBox_gosId.Text.Trim();

            // Проверка на размер вводимых данных
            if (mark.Length > 255 || color.Length > 75 || gosId.Length > 10)
            {
                MessageBox.Show("Превышен допустимый размер данных.\n" +
                    "Проверьте инструкцию!\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка наличия существующего autoId
            if (CheckAutoIdExists(autoId))
            {
                MessageBox.Show("Автомобиль с таким ID уже существует. Пожалуйста, выберите другой ID.\n" +
                    "Проверьте инструкцию!\n", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на возрастающую последовательность autoId
            if (CheckAutoIdSequence(autoId))
            {
                MessageBox.Show("Пожалуйста, введите следующий по порядку ID.\n" +
                    "Проверьте инструкцию!\n", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Добавляем запись в базу данных
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Транспортные_средства (Номер, Марка, Цвет_корпуса, Грузоподъемность, Год_выпуска, Гос_Номер) " +
                                   "VALUES (@AutoId, @Mark, @Color, @Ves, @Vozrast, @GosId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AutoId", autoId);
                        command.Parameters.AddWithValue("@Mark", mark);
                        command.Parameters.AddWithValue("@Color", color);
                        command.Parameters.AddWithValue("@Ves", ves);
                        command.Parameters.AddWithValue("@Vozrast", vozrast);
                        command.Parameters.AddWithValue("@GosId", gosId);

                        command.ExecuteNonQuery();
                    }
                }

                // Очищаем текстовые поля после успешного добавления
                ClearTextBoxes();

                // Обновляем информацию в DataGridView
                LoadDataIntoDataGridView1();

                MessageBox.Show("Автомобиль успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении автомобиля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataIntoDataGridView1()
        {
            // Например, если у вас есть TableAdapter, можете использовать его:
            this.транспортные_средстваTableAdapter1.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
        }




        private bool CheckAutoIdExists(string autoId)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Транспортные_средства WHERE Номер = @AutoId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AutoId", autoId);
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private bool CheckAutoIdSequence(string autoId)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT MAX(Номер) FROM Транспортные_средства";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int maxAutoId = Convert.ToInt32(result);
                        return Convert.ToInt32(autoId) != maxAutoId + 1;
                    }

                    // Если база данных пуста, возвращаем false
                    return false;
                }
            }
        }

        private void ClearTextBoxes()
        {
            // Очистка всех текстовых полей
            textBox_autoId.Clear();
            textBox_mark.Clear();
            textBox_color.Clear();
            textBox_ves.Clear();
            textBox_vozrast.Clear();
            textBox_gosId.Clear();
        }

        private void button_clear_1_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }



        //
        // Добавить водителя
        //

        private void button_addDriver_Click(object sender, EventArgs e)
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

                // Очищаем текстовые поля после успешного добавления
                ClearDriverTextBoxes();

                // Обновляем информацию в DataGridView
                LoadDataIntoDataGridView2(); // Замените это на ваш метод получения данных для DataGridView

                MessageBox.Show("Водитель успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении водителя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataIntoDataGridView2()
        {
            // Например, если у вас есть TableAdapter, можете использовать его:
            this.водителиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Водители);
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

        private void button5_Click(object sender, EventArgs e)
        {
            ClearDriverTextBoxes();
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
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
        // ТРАНСПОРТ ЕКСЕЛь
        //

        private void button_excelAuto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xlsm",
                Title = "Выберите Excel файл"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    int idCounter = GetMaxIdFromDatabase();

                    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filePath, false))
                    {
                        WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();

                        SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                        foreach (Row row in sheetData.Elements<Row>())
                        {
                            int id = Convert.ToInt32(GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(0)));
                            string mark = GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(1));
                            string color = GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(2));
                            decimal ves = Convert.ToDecimal(GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(3)));
                            int vipusk = Convert.ToInt32(GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(4)));
                            string gosNum = GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(5));

                            if (id == idCounter)
                            {
                                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                                {
                                    connection.Open();

                                    SqlCommand command = new SqlCommand("INSERT INTO Транспортные_средства (Номер , Марка , Цвет_корпуса, Грузоподъемность, Год_выпуска, Гос_Номер) VALUES (@Id, @Mark, @Color, @Ves, @Vipusk, @GosNum)", connection);
                                    command.Parameters.AddWithValue("@Id", id);
                                    command.Parameters.AddWithValue("@Mark", mark);
                                    command.Parameters.AddWithValue("@Color", color);
                                    command.Parameters.AddWithValue("@Ves", ves);
                                    command.Parameters.AddWithValue("@Vipusk", vipusk);
                                    command.Parameters.AddWithValue("@GosNum", gosNum);

                                    command.ExecuteNonQuery();
                                }

                                idCounter++;
                                MessageBox.Show("Транспорт успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.транспортные_средстваTableAdapter1.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
                            }
                            else
                            {
                                MessageBox.Show("Номера (Айди) должны идти по порядку и быть уникальными.");
                                this.транспортные_средстваTableAdapter1.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.транспортные_средстваTableAdapter1.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
                    // ХЗ КАК НО РАБОТАЕТ ¯_(ツ)_/¯
                }
            }
        }

        private int GetMaxIdFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT MAX(Номер) FROM Транспортные_средства", connection);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    return Convert.ToInt32(result) + 1;
                }
                else
                {
                    return 1; // Если база данных пуста
                }
            }
        }

        private string GetCellValue(WorkbookPart workbookPart, Cell cell)
        {
            SharedStringTablePart stringTablePart = workbookPart.SharedStringTablePart;
            string value = cell.InnerText;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(value)).InnerText;
            }
            else
            {
                return value;
            }
        }

        //
        //  Очистить сортировку
        //


        private void button9_Click(object sender, EventArgs e)
        {
            textBox_SearchTransport.Text = "";
            textBox_SearchVoditel.Text = "";

            this.транспортные_средстваTableAdapter1.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
            this.водителиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Водители);

            dataGridView1.DataSource = грузоперевозкиDataSet1.Транспортные_средства;
            dataGridView2.DataSource = грузоперевозкиDataSet1.Водители;
            MessageBox.Show("Фильтры сортировки сброшены.");
        }







        //  Открыть инструкцию по заполнению БД
        private void заполнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstactionZapolnenieForm instactionZapolnenieForm = new InstactionZapolnenieForm();
            instactionZapolnenieForm.Show();
        }
        //  Открыть инструкию по импорту из экселя
        private void импортИзExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstractionExcelTransportForm instractionExcelTransportForm = new InstractionExcelTransportForm();
            instractionExcelTransportForm.Show();
        }
        //  Открыть инструкцию по созданию отчётов
        private void созданиеОтчётовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstractionOtchetiForm instractionOtchetiForm = new InstractionOtchetiForm();   
            instractionOtchetiForm.Show();
        }
        //  Открыть инструкцию по сортировке
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstractionPoiskForm instractionPoiskForm = new InstractionPoiskForm();
            instractionPoiskForm.Show();
        }

        private void textBox_SearchVoditel_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView2, грузоперевозкиDataSet1.Водители, comboBox_ColumnsVoditel, textBox_SearchVoditel);
        }


        private void textBox_SearchTransport_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView1, грузоперевозкиDataSet1.Транспортные_средства, comboBox_ColumnsTransport, textBox_SearchTransport);
        }

    }
}

 