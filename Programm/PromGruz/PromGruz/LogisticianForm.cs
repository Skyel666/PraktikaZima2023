using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class LogisticianForm : Form
    {

        private UserInfo userInfo;
        private Sort sortHelper = new Sort();


        public LogisticianForm(UserInfo userInfo)
        {
            InitializeComponent();

            this.userInfo = userInfo;

            // Установить фиксированный минимальный и максимальный размер окна
            this.MinimumSize = new Size(1200, 660);
            this.MaximumSize = new Size(1200, 660);

        }


        private void LogisticianForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Грузы". При необходимости она может быть перемещена или удалена.
            this.грузыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Грузы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Транспортные_средства". При необходимости она может быть перемещена или удалена.
            this.транспортные_средстваTableAdapter1.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Водители". При необходимости она может быть перемещена или удалена.
            this.водителиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Водители);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Маршруты". При необходимости она может быть перемещена или удалена.
            this.маршрутыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Маршруты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Перевозки". При необходимости она может быть перемещена или удалена.
            this.перевозкиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Перевозки);

            // Вызываем метод FillComboBoxWithColumns, передавая ComboBox и DataGridView
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsPerevozki, dataGridView1);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsMarshrut, dataGridView2);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsVoditel, dataGridView3);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsTransport, dataGridView4);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsGruz, dataGridView5); 



        }

        private void LogisticianForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Здесь не вызываем Application.Exit(), а показываем форму авторизации или другую форму
            AuthenticationForm.Instance.Show();
        }



        //
        // Перевозки
        //

        private void button_addPerevozka_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            int perevozkaId;

            if (!int.TryParse(textBox_perevozkaId.Text.Trim(), out perevozkaId))
            {
                MessageBox.Show("Введите корректный номер перевозки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string zakazchik = textBox_perevozkaZakazchik.Text.Trim();
            int autoId;
            if (!int.TryParse(textBox_perevozkaAutoId.Text.Trim(), out autoId))
            {
                MessageBox.Show("Введите корректный номер транспортного средства.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int gruzId;
            if (!int.TryParse(textBox_perevozkaGruzId.Text.Trim(), out gruzId))
            {
                MessageBox.Show("Введите корректный номер груза.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int marshrutId;
            if (!int.TryParse(textBox_perevozkaMarshrutId.Text.Trim(), out marshrutId))
            {
                MessageBox.Show("Введите корректный номер маршрута.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int voditelId;
            if (!int.TryParse(textBox_perevozkaVoditelId.Text.Trim(), out voditelId))
            {
                MessageBox.Show("Введите корректный номер водителя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime otpravkaData;
            if (!DateTime.TryParse(textBox_perevozkaOtpravkaData.Text.Trim(), out otpravkaData))
            {
                MessageBox.Show("Введите корректную дату отправки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ozhidaemayaData;
            if (!DateTime.TryParse(textBox_perevozkaOzhidaemayaData.Text.Trim(), out ozhidaemayaData))
            {
                MessageBox.Show("Введите корректную ожидаемую дату прибытия.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка на заполненность обязательных полей
            if (string.IsNullOrEmpty(zakazchik))
            {
                MessageBox.Show("Заполните все обязательные поля.\nПроверьте инструкцию!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на корректность дат
            if (otpravkaData > ozhidaemayaData)
            {
                MessageBox.Show("Дата отправки не может быть позже ожидаемой даты прибытия.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка наличия существующего номера перевозки
            if (CheckPerevozkaIdExists(perevozkaId))
            {
                MessageBox.Show("Перевозка с таким номером уже существует. Пожалуйста, выберите другой номер.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Добавляем запись в базу данных
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Перевозки (Номер, Заказчик, Номер_транспортного_средства, Номер_груза, Номер_маршрута, Номер_водителя, Дата_отправки, Ожидаемая_дата_прибытия, Статус_перевозки) " +
                                    "VALUES (@PerevozkaId, @Zakazchik, @AutoId, @GruzId, @MarshrutId, @VoditelId, @OtpravkaData, @OzhidaemayaData, @Status)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PerevozkaId", perevozkaId);
                        command.Parameters.AddWithValue("@Zakazchik", zakazchik);
                        command.Parameters.AddWithValue("@AutoId", autoId);
                        command.Parameters.AddWithValue("@GruzId", gruzId);
                        command.Parameters.AddWithValue("@MarshrutId", marshrutId);
                        command.Parameters.AddWithValue("@VoditelId", voditelId);
                        command.Parameters.AddWithValue("@OtpravkaData", otpravkaData);
                        command.Parameters.AddWithValue("@OzhidaemayaData", ozhidaemayaData);
                        command.Parameters.AddWithValue("@Status", "Не завершена"); // Устанавливаем статус по умолчанию

                        command.ExecuteNonQuery();
                    }
                }

                // Очищаем текстовые поля после успешного добавления
                ClearPerevozkaTextBoxes();

                // Обновляем информацию в DataGridView (если используется)
                this.перевозкиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Перевозки);


                MessageBox.Show("Перевозка успешно добавлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении перевозки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearPerevozkaTextBoxes()
        {
            textBox_perevozkaId.Clear();
            textBox_perevozkaZakazchik.Clear();
            textBox_perevozkaAutoId.Clear();
            textBox_perevozkaGruzId.Clear();
            textBox_perevozkaMarshrutId.Clear();
            textBox_perevozkaVoditelId.Clear();
            textBox_perevozkaOtpravkaData.Clear();
            textBox_perevozkaOzhidaemayaData.Clear();
        }

        private bool CheckPerevozkaIdExists(int perevozkaId)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Перевозки WHERE Номер = @PerevozkaId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PerevozkaId", perevozkaId);
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearPerevozkaTextBoxes();
        }


        //
        // Маршруты
        //

        private void button_addMarshrut_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            int marshrutId;
            if (!int.TryParse(textBox_marshrutId.Text.Trim(), out marshrutId))
            {
                MessageBox.Show("Введите корректный номер маршрута.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nachalnayaMark = textBox_nachalnayaMark.Text.Trim();
            string konechnayaMark = textBox_konechnayaMark.Text.Trim();
            string dlinaMarshrutaStr = textBox_dlinaMarshruta.Text.Trim();

            // Проверка на заполненность обязательных полей
            if (string.IsNullOrEmpty(nachalnayaMark) || string.IsNullOrEmpty(konechnayaMark) || string.IsNullOrEmpty(dlinaMarshrutaStr))
            {
                MessageBox.Show("Заполните все обязательные поля.\nПроверьте инструкцию!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка правильного формата данных
            if (!decimal.TryParse(dlinaMarshrutaStr, out decimal dlinaMarshruta))
            {
                MessageBox.Show("Проверьте правильность ввода данных.\nПроверьте инструкцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка на размер вводимых данных
            if (nachalnayaMark.Length > 255 || konechnayaMark.Length > 255)
            {
                MessageBox.Show("Превышен допустимый размер данных.\nПроверьте инструкцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка наличия существующего номера маршрута
            if (CheckMarshrutIdExists(marshrutId))
            {
                MessageBox.Show("Маршрут с таким номером уже существует. Пожалуйста, выберите другой номер.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на возрастающую последовательность номера маршрута
            if (CheckMarshrutIdSequence(marshrutId))
            {
                MessageBox.Show("Пожалуйста, введите следующий по порядку номер маршрута.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Добавляем запись в базу данных
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Маршруты (Номер, Начальная_точка, Конечная_точка, Длина_маршрута) " +
                                    "VALUES (@MarshrutId, @NachalnayaMark, @KonechnayaMark, @DlinaMarshruta)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MarshrutId", marshrutId);
                        command.Parameters.AddWithValue("@NachalnayaMark", nachalnayaMark);
                        command.Parameters.AddWithValue("@KonechnayaMark", konechnayaMark);
                        command.Parameters.AddWithValue("@DlinaMarshruta", dlinaMarshruta);

                        command.ExecuteNonQuery();
                    }
                }

                // Очищаем текстовые поля после успешного добавления
                ClearMarshrutTextBoxes();


                this.маршрутыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Маршруты);

                MessageBox.Show("Маршрут успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении маршрута: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private bool CheckMarshrutIdExists(int marshrutId)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Маршруты WHERE Номер = @MarshrutId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MarshrutId", marshrutId);
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private bool CheckMarshrutIdSequence(int marshrutId)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT MAX(Номер) FROM Маршруты";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int maxMarshrutId = Convert.ToInt32(result);
                        return marshrutId != maxMarshrutId + 1;
                    }

                    // Если база данных пуста, возвращаем false
                    return false;
                }
            }
        }

        private void ClearMarshrutTextBoxes()
        {
            textBox_marshrutId.Clear();
            textBox_nachalnayaMark.Clear();
            textBox_konechnayaMark.Clear();
            textBox_dlinaMarshruta.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearMarshrutTextBoxes();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
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

        // Лучший водила
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
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

        //
        // МАРШРУТЫ ИЗ ЭКСЕЛЯ
        //  

        private void button1_Click(object sender, EventArgs e)
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
                            string startPoint = GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(1));
                            string endPoint = GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(2));
                            decimal routeLength = Convert.ToDecimal(GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(3)));

                            if (id == idCounter)
                            {
                                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                                {
                                    connection.Open();

                                    SqlCommand command = new SqlCommand("INSERT INTO Маршруты (Номер, Начальная_точка, Конечная_точка, Длина_маршрута) VALUES (@Id, @StartPoint, @EndPoint, @RouteLength)", connection);
                                    command.Parameters.AddWithValue("@Id", id);
                                    command.Parameters.AddWithValue("@StartPoint", startPoint);
                                    command.Parameters.AddWithValue("@EndPoint", endPoint);
                                    command.Parameters.AddWithValue("@RouteLength", routeLength);

                                    command.ExecuteNonQuery();
                                }

                                idCounter++;
                            }
                            else
                            {
                                MessageBox.Show("Номера (Айди) должны идти по порядку и быть уникальными.");
                                this.маршрутыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Маршруты);
                                break;
                            }
                        }
                    }

                    this.маршрутыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Маршруты);

                    MessageBox.Show("Маршрут успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Ошибка при обработке Excel файла: {ex.Message}");
                    this.маршрутыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Маршруты);
                }
            }
        }

        private int GetMaxIdFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT MAX(Номер) FROM Маршруты", connection);
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


        //  Открыть инструкцию по Заполнению
        private void заполнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstactionZapolnenieForm instactionZapolnenieForm = new InstactionZapolnenieForm();
            instactionZapolnenieForm.Show();
        }
        //  Открыть инструкцию по Импорту из экселя
        private void импортИзExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstractionExcelMarshrutiForm instractionExcelMarshrutiForm = new InstractionExcelMarshrutiForm();
            instractionExcelMarshrutiForm.Show();
        }
        //  Открыть инструкцию по Созданию отчётов
        private void созданиеОтчётовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstractionOtchetiForm instractionOtchetiForm = new InstractionOtchetiForm();
            instractionOtchetiForm.Show();
        }
        //  Открыть инструкцию по Сортировке
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


            // Загрузка данных из базы в таблицы DataSet

            this.грузыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Грузы);
      
            this.транспортные_средстваTableAdapter1.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
         
            this.водителиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Водители);
          
            this.маршрутыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Маршруты);
          
            this.перевозкиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Перевозки);

            // Очистка сортировки в DataGridView
            dataGridView1.DataSource = грузоперевозкиDataSet1.Перевозки;
            dataGridView2.DataSource = грузоперевозкиDataSet1.Маршруты;
            dataGridView3.DataSource = грузоперевозкиDataSet1.Водители;
            dataGridView4.DataSource = грузоперевозкиDataSet1.Транспортные_средства;
            dataGridView5.DataSource = грузоперевозкиDataSet1.Грузы;

            MessageBox.Show("Фильтры сортировки сброшены.");

        }

        private void textBox_SearchPerevozka_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView1, грузоперевозкиDataSet1.Перевозки, comboBox_ColumnsPerevozki, textBox_SearchPerevozka);
        }

        private void textBox_SearchMarshrut_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView2, грузоперевозкиDataSet1.Маршруты, comboBox_ColumnsMarshrut, textBox_SearchMarshrut);
        }

        private void textBox_SearchVoditel_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView3, грузоперевозкиDataSet1.Водители, comboBox_ColumnsVoditel, textBox_SearchVoditel);
        }


        private void textBox_SearchTransport_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView4, грузоперевозкиDataSet1.Транспортные_средства, comboBox_ColumnsTransport, textBox_SearchTransport);
        }

        private void textBox_SearchGruz_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView5, грузоперевозкиDataSet1.Грузы, comboBox_ColumnsGruz, textBox_SearchGruz);
        }


    }
}
