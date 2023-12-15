using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromGruz
{
    public class Sort
    {
        // Универсальный метод дописка в DataGridView
        public void SearchInDataGridView(DataGridView dataGridView, DataTable dataTable, ComboBox comboBox, TextBox textBox)
        {
            if (comboBox.SelectedItem == null || string.IsNullOrEmpty(textBox.Text) || comboBox.SelectedItem.ToString() == "Без сортировки")
            {
                // Если не выбрана колонка, текстовое поле пустое, или выбрана опция "Без сортировки", показываем все записи
                dataGridView.DataSource = dataTable;
            }
            else
            {
                // Создаем новый DataTable для хранения результатов поиска
                DataTable searchResults = new DataTable();

                // Добавляем все столбцы из исходной таблицы
                foreach (DataColumn column in dataTable.Columns)
                {
                    searchResults.Columns.Add(column.ColumnName, column.DataType);
                }

                // Проходим по всем строкам
                foreach (DataRow row in dataTable.Rows)
                {
                    // Получаем значение выбранной колонки
                    object cellValue = row[comboBox.SelectedItem.ToString()];

                    // Преобразуем значение ячейки к строке для поиска
                    string stringValue = cellValue != null ? cellValue.ToString() : string.Empty;

                    // Ищем вхождение текста в строке
                    if (stringValue.IndexOf(textBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        searchResults.Rows.Add(row.ItemArray);
                    }
                }

                // Отображаем результаты поиска
                dataGridView.DataSource = searchResults;
            }
        }


        // Универсальный метод заполнения комбобокса колонками из дата грида
        public void FillComboBoxWithColumns(ComboBox comboBox, DataGridView dataGridView)
        {
            comboBox.Items.Clear();

            // Добавляем вариант "Без сортировки"
            comboBox.Items.Add("Без сортировки");

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                comboBox.Items.Add(column.HeaderText);
            }

            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }


    }

}
