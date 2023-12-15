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
    public partial class DriverForm : Form
    {

        private int driverId;
        private Sort sortHelper = new Sort();


        public DriverForm()
        {
            InitializeComponent();

            // Установить фиксированный минимальный и максимальный размер окна
            this.MinimumSize = new Size(1200, 650);
            this.MaximumSize = new Size(1200, 650);

            LoadDriverData();

        }

        // Конструктор с параметром для передачи идентификатора водителя
        public DriverForm(int driverId) : this()
        {
            // Инициализация формы с передачей идентификатора водителя
            this.driverId = driverId;
            LoadDriverData();
        }


        private void DriverForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            // Здесь не вызываем Application.Exit(), а показываем форму авторизации 
            AuthenticationForm.Instance.Show();

        }

        private void LoadDriverData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                {
                    connection.Open();

                    // Загружаем данные в DataGridView с учетом идентификатора водителя
                    string query = "SELECT * FROM Перевозки WHERE Номер_водителя = @DriverId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriverId", driverId);

                        DataTable dataTable = new DataTable();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        dataAdapter.Fill(dataTable);

                        // Привязываем данные к DataGridView
                        dataGridViewPerevozkiVoditelya.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных водителя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Проверка принадлежности перевозки водителю
        private bool CheckPerevozkaBelongsToDriver(int perevozkaId)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Перевозки WHERE Номер = @PerevozkaId AND Номер_водителя = @DriverId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PerevozkaId", perevozkaId);
                    command.Parameters.AddWithValue("@DriverId", driverId);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        // Получение статуса перевозки
        private string GetPerevozkaStatus(int perevozkaId)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT Статус_перевозки FROM Перевозки WHERE Номер = @PerevozkaId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PerevozkaId", perevozkaId);

                    object result = command.ExecuteScalar();

                    return result != null ? result.ToString() : string.Empty;
                }
            }
        }

        private void button_perevozkaEnd_Click_1(object sender, EventArgs e)
        {
            // Получаем значение из текстового поля
            if (!int.TryParse(textBox_perevozkaId.Text.Trim(), out int perevozkaId))
            {
                MessageBox.Show("Введите корректный номер перевозки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка наличия существующего номера перевозки у текущего водителя
            if (!CheckPerevozkaBelongsToDriver(perevozkaId))
            {
                MessageBox.Show("Эта перевозка не принадлежит вам или не существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка статуса перевозки
            string currentStatus = GetPerevozkaStatus(perevozkaId);
            if (currentStatus == "Завершена")
            {
                MessageBox.Show("Эта перевозка уже завершена.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Запрос подтверждения перед завершением
            DialogResult result = MessageBox.Show("Вы уверены, что хотите завершить эту перевозку?", "Подтверждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Обновляем запись в базе данных
                try
                {
                    using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                    {
                        connection.Open();

                        string query = "UPDATE Перевозки SET Статус_перевозки = 'Завершена', Дата_прибытия = GETDATE() WHERE Номер = @PerevozkaId";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PerevozkaId", perevozkaId);

                            command.ExecuteNonQuery();
                        }
                    }

                    // Очищаем текстовое поле после успешного завершения
                    textBox_perevozkaId.Clear();

                    // Обновляем информацию в DataGridView (если используется)
                    LoadDriverData();

                    MessageBox.Show("Перевозка успешно завершена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при завершении перевозки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (result == DialogResult.No)
            {
                // Пользователь отменил завершение перевозки
                MessageBox.Show("Операция завершения перевозки отменена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Пользователь отменил подтверждение
                MessageBox.Show("Вы не подтвердили завершение перевозки.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DriverForm_Load(object sender, EventArgs e)
        {

            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Транспортные_средства". При необходимости она может быть перемещена или удалена.
            this.транспортные_средстваTableAdapter.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Маршруты". При необходимости она может быть перемещена или удалена.
            this.маршрутыTableAdapter.Fill(this.грузоперевозкиDataSet1.Маршруты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Грузы". При необходимости она может быть перемещена или удалена.
            this.грузыTableAdapter.Fill(this.грузоперевозкиDataSet1.Грузы);

            // Вызываем метод FillComboBoxWithColumns, передавая ComboBox и DataGridView
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsPerevozki, dataGridViewPerevozkiVoditelya);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsGruz, dataGridView1);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsMarshrut, dataGridView2);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsTransport, dataGridView3);
        }

        private void button9_Click(object sender, EventArgs e)
        {

            // Очистка текстовых полей
            textBox_SearchPerevozka.Text = "";

            this.транспортные_средстваTableAdapter.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
         
            this.маршрутыTableAdapter.Fill(this.грузоперевозкиDataSet1.Маршруты);

            this.грузыTableAdapter.Fill(this.грузоперевозкиDataSet1.Грузы);

            // Очистка сортировки в DataGridView
            dataGridView1.DataSource = грузоперевозкиDataSet1.Грузы;
            dataGridView2.DataSource = грузоперевозкиDataSet1.Маршруты;
            dataGridView3.DataSource = грузоперевозкиDataSet1.Транспортные_средства;

            LoadDriverData();

            MessageBox.Show("Фильтры сортировки сброшены.");

        }

        private void textBox_SearchPerevozka_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridViewPerevozkiVoditelya, (DataTable)dataGridViewPerevozkiVoditelya.DataSource, comboBox_ColumnsPerevozki, textBox_SearchPerevozka);
        }

        private void textBox_SearchMarshrut_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView2, грузоперевозкиDataSet1.Маршруты, comboBox_ColumnsMarshrut, textBox_SearchMarshrut);
        }


        private void textBox_SearchTransport_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView3, грузоперевозкиDataSet1.Транспортные_средства, comboBox_ColumnsTransport, textBox_SearchTransport);
        }

        private void textBox_SearchGruz_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView1, грузоперевозкиDataSet1.Грузы, comboBox_ColumnsGruz, textBox_SearchGruz);
        }

    }
}
