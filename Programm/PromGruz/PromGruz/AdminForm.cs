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
using System.Diagnostics;

namespace PromGruz
{
    public partial class AdminForm : Form
    {

        private UserInfo userInfo;
        private Sort sortHelper = new Sort();

        public AdminForm(UserInfo userInfo)
        {
            InitializeComponent();

            this.userInfo = userInfo;

            // Установить фиксированный минимальный и максимальный размер окна
            this.MinimumSize = new Size(1200, 650);
            this.MaximumSize = new Size(1200, 650);


        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            SaveChanges();

            // Здесь не вызываем Application.Exit(), а показываем форму авторизации 
            AuthenticationForm.Instance.Show();

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Транспортные_средства". При необходимости она может быть перемещена или удалена.
            this.транспортные_средстваTableAdapter1.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Грузы". При необходимости она может быть перемещена или удалена.
            this.грузыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Грузы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Маршруты". При необходимости она может быть перемещена или удалена.
            this.маршрутыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Маршруты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Перевозки". При необходимости она может быть перемещена или удалена.
            this.перевозкиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Перевозки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Водители". При необходимости она может быть перемещена или удалена.
            this.водителиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Водители);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Роли". При необходимости она может быть перемещена или удалена.
            this.ролиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Роли);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "грузоперевозкиDataSet1.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Пользователи);

            dataGridView1.DataError += DataGridView_DataError;
            dataGridView2.DataError += DataGridView_DataError;
            dataGridView3.DataError += DataGridView_DataError;
            dataGridView4.DataError += DataGridView_DataError;
            dataGridView5.DataError += DataGridView_DataError;
            dataGridView6.DataError += DataGridView_DataError;
            dataGridView7.DataError += DataGridView_DataError;

            // Вызываем метод FillComboBoxWithColumns, передавая ComboBox и DataGridView
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsUser, dataGridView1);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsVoditel, dataGridView3);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsPerevozki, dataGridView4);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsMarshrut, dataGridView5);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsGruz, dataGridView6);
            sortHelper.FillComboBoxWithColumns(comboBox_ColumnsTransport, dataGridView7);

        }


        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Получаем информацию об ошибке
            Exception ex = e.Exception;

            // Показываем более информативное сообщение
            MessageBox.Show($"Произошла ошибка при редактировании ячейки ({e.RowIndex}, {e.ColumnIndex}): {ex.Message}" + "\nПроверьте инструкцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Отмечаем событие как обработанное
            e.ThrowException = false;
        }

        private void сохранитьИзмененияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                this.Validate();

                this.транспортные_средстваTableAdapter1.Update(this.грузоперевозкиDataSet1.Транспортные_средства);
                this.грузыTableAdapter1.Update(this.грузоперевозкиDataSet1.Грузы);
                this.маршрутыTableAdapter1.Update(this.грузоперевозкиDataSet1.Маршруты);
                this.перевозкиTableAdapter1.Update(this.грузоперевозкиDataSet1.Перевозки);
                this.водителиTableAdapter1.Update(this.грузоперевозкиDataSet1.Водители);
                this.пользователиTableAdapter1.Update(this.грузоперевозкиDataSet1.Пользователи);
                this.ролиTableAdapter1.Update(this.грузоперевозкиDataSet1.Роли);

                MessageBox.Show("Изменения сохранены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + "\nПроверьте инструкцию!");
            }
        }

        private void нАПИСАТЬСОЗДАТЕЛЮToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Открываем ссылку в браузере
                Process.Start("https://vk.com/skyel666");
                Process.Start("https://github.com/Skyel666");
            }
            catch (Exception ex)
            {

                // Обрабатываем возможные ошибки
                MessageBox.Show("Ошибка при открытии ссылок.\n" +
                    "Вам поможет только молитва:\n" +
                    "«Отче наш, Иже еси на небесех! Да святится имя Твое, да приидет Царствие Твое, да будет воля Твоя, яко на небеси и на земли. Хлеб наш насущный даждь нам днесь; и остави нам долги наша, якоже и мы оставляем должником нашим; и не введи нас во искушение, но избави нас от лукаваго. Ибо Твое есть Царство и сила и слава во веки. Аминь.»");

            }
        }



        //Открыть форму с инструкцией Как редактировать Бд
        private void какДолжныВыглядитьРабочиеРолиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstractionAdminForm instractionAdminForm = new InstractionAdminForm();
            instractionAdminForm.Show();
        }

        //Открыть форму с инструкцией поиска
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstractionPoiskForm instractionPoiskForm = new InstractionPoiskForm();
            instractionPoiskForm.Show();
        }


        private void button9_Click(object sender, EventArgs e)
        {

            // Очистка текстовых полей
            textBox_SearchPerevozka.Text = "";
            textBox_SearchMarshrut.Text = "";
            textBox_SearchTransport.Text = "";
            textBox_SearchVoditel.Text = "";
            textBox_SearchGruz.Text = "";
            textBox_SearchUser.Text = "";

            this.транспортные_средстваTableAdapter1.Fill(this.грузоперевозкиDataSet1.Транспортные_средства);
            this.грузыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Грузы);
            this.маршрутыTableAdapter1.Fill(this.грузоперевозкиDataSet1.Маршруты);
            this.перевозкиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Перевозки);
            this.водителиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Водители);
            this.ролиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Роли);
            this.пользователиTableAdapter1.Fill(this.грузоперевозкиDataSet1.Пользователи);

            // Очистка сортировки в DataGridView
            dataGridView1.DataSource = грузоперевозкиDataSet1.Пользователи;
            dataGridView3.DataSource = грузоперевозкиDataSet1.Водители;
            dataGridView4.DataSource = грузоперевозкиDataSet1.Перевозки;
            dataGridView5.DataSource = грузоперевозкиDataSet1.Маршруты;
            dataGridView6.DataSource = грузоперевозкиDataSet1.Грузы;
            dataGridView7.DataSource = грузоперевозкиDataSet1.Транспортные_средства;

            MessageBox.Show("Фильтры сортировки сброшены.");

        }

        private void textBox_SearchPerevozka_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView4, грузоперевозкиDataSet1.Перевозки, comboBox_ColumnsPerevozki, textBox_SearchPerevozka);
        }

        private void textBox_SearchMarshrut_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView5, грузоперевозкиDataSet1.Маршруты, comboBox_ColumnsMarshrut, textBox_SearchMarshrut);
        }

        private void textBox_SearchVoditel_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView3, грузоперевозкиDataSet1.Водители, comboBox_ColumnsVoditel, textBox_SearchVoditel);
        }


        private void textBox_SearchTransport_TextChanged(object sender, EventArgs e)
        {
            sortHelper.SearchInDataGridView(dataGridView7, грузоперевозкиDataSet1.Транспортные_средства, comboBox_ColumnsTransport, textBox_SearchTransport);
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

