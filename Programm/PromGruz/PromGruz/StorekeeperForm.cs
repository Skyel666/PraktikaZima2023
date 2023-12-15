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
    public partial class StorekeeperForm : Form
    {

        private UserInfo userInfo;
        private Sort sortHelper = new Sort();

        public StorekeeperForm(UserInfo userInfo)
        {
            InitializeComponent();

            this.userInfo = userInfo;

            // Установить фиксированный минимальный и максимальный размер окна
            this.MinimumSize = new Size(1200, 650);
            this.MaximumSize = new Size(1200, 650);

        }

        private void StorekeeperForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Здесь не вызываем Application.Exit(), а показываем форму авторизации или другую форму
            AuthenticationForm.Instance.Show();
        }

        private void StorekeeperForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Грузы". При необходимости она может быть перемещена или удалена.
            this.грузыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Грузы);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsGruz, dataGridView1);
        }

        //
        // ypravlenie gruzami
        //

        private void button_addGruz_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            int gruzNum;
            if (!int.TryParse(textBox_gruzNum.Text.Trim(), out gruzNum))
            {
                MessageBox.Show("Введите корректный номер груза.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string gruzName = textBox_gruzName.Text.Trim();
            string gruzVesStr = textBox_gruzVes.Text.Trim();
            string gruzType = textBox_gruzType.Text.Trim();

            // Проверка на заполненность обязательных полей
            if (string.IsNullOrEmpty(gruzName) || string.IsNullOrEmpty(gruzVesStr) || string.IsNullOrEmpty(gruzType))
            {
                MessageBox.Show("Заполните все обязательные поля.\nПроверьте инструкцию!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка правильного формата данных
            if (!decimal.TryParse(gruzVesStr, out decimal gruzVes))
            {
                MessageBox.Show("Проверьте правильность ввода данных.\nПроверьте инструкцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка на размер вводимых данных
            if (gruzName.Length > 255 || gruzType.Length > 100)
            {
                MessageBox.Show("Превышен допустимый размер данных.\nПроверьте инструкцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка наличия существующего номера груза
            if (CheckGruzNumExists(gruzNum))
            {
                MessageBox.Show("Груз с таким номером уже существует. Пожалуйста, выберите другой номер.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на возрастающую последовательность номера груза
            if (CheckGruzNumSequence(gruzNum))
            {
                MessageBox.Show("Пожалуйста, введите следующий по порядку номер груза.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Добавляем запись в базу данных
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Грузы (Номер, Наименование, Вес, Тип_груза) " +
                                    "VALUES (@GruzNum, @GruzName, @GruzVes, @GruzType)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GruzNum", gruzNum);
                        command.Parameters.AddWithValue("@GruzName", gruzName);
                        command.Parameters.AddWithValue("@GruzVes", gruzVes);
                        command.Parameters.AddWithValue("@GruzType", gruzType);

                        command.ExecuteNonQuery();
                    }
                }

                // Очищаем текстовые поля после успешного добавления
                ClearGruzTextBoxes();

                this.грузыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Грузы);

                MessageBox.Show("Груз успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении груза: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckGruzNumExists(int gruzNum)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Грузы WHERE Номер = @GruzNum";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GruzNum", gruzNum);
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private bool CheckGruzNumSequence(int gruzNum)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT MAX(Номер) FROM Грузы";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int maxGruzNum = Convert.ToInt32(result);
                        return gruzNum != maxGruzNum + 1;
                    }

                    // Если база данных пуста, возвращаем false
                    return false;
                }
            }
        }

        private void ClearGruzTextBoxes()
        {
            textBox_gruzNum.Clear();
            textBox_gruzName.Clear();
            textBox_gruzVes.Clear();
            textBox_gruzType.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearGruzTextBoxes();
        }

        private void wordToolStripMenuItem1_Click(object sender, EventArgs e)
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


        //  Открыть инструкцию по Заполнени.
        private void заполнениеToolStripMenuItem_Click(object sender, EventArgs e)
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
        //  Открыть инструкцию по Сортировке
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstractionPoiskForm instractionPoiskForm = new InstractionPoiskForm();
            instractionPoiskForm.Show();
        }



        //
        //  Очистить сортировку

        private void button9_Click(object sender, EventArgs e)
        {
            textBox_SearchGruz.Text = "";

            this.грузыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Грузы);

            dataGridView1.DataSource = грузоперевозкиDataSet1.Грузы;

            MessageBox.Show("Фильтры сортировки сброшены.");
        }

        private void textBox_SearchGruz_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView1, грузоперевозкиDataSet1.Грузы, comboBox_ColumnsGruz, textBox_SearchGruz);
        }
    }
}
