using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace PromGruz
{
    public class Otchet
    {

        public static void ApplyVisibleTableBorders(Table table)
        {
            table.AppendChild(new TableProperties(
                new TableBorders(
                    new TopBorder() { Val = BorderValues.Single, Size = 2 },
                    new BottomBorder() { Val = BorderValues.Single, Size = 2 },
                    new LeftBorder() { Val = BorderValues.Single, Size = 2 },
                    new RightBorder() { Val = BorderValues.Single, Size = 2 },
                    new InsideHorizontalBorder() { Val = BorderValues.Single, Size = 2 },
                    new InsideVerticalBorder() { Val = BorderValues.Single, Size = 2 }
                )
            ));
        }

        //
        // Анализ веса грузов (Кладовщик)
        //

        public void GenerateWeightAnalysisToWord(string savePath)
        {

            try
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(savePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    // Добавляем заголовок документа
                    Paragraph titleParagraph = new Paragraph(new Run(new Text($"Отчет Анализ Веса грузов на {DateTime.Now:yyyy-MM-dd}")));
                    titleParagraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                    body.AppendChild(titleParagraph);

                    // Подключение к базе данных
                    using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                    {
                        connection.Open();

                        // Запрос для получения данных из таблицы "Грузы"
                        string query = "SELECT * FROM Грузы";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                        // Заполняем DataTable данными из базы данных
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Добавляем заголовок раздела для самого тяжелого груза
                        Paragraph heaviestTitleParagraph = new Paragraph(new Run(new Text("Самый тяжелый груз:")));
                        body.AppendChild(heaviestTitleParagraph);

                        // Добавляем информацию о самом тяжелом грузе
                        DataRow heaviestRow = dataTable.Select("Вес = MAX(Вес)")[0];
                        string heaviestCargoInfo = $"{heaviestRow["Наименование"]} - вес: {heaviestRow["Вес"]}";
                        Paragraph heaviestInfoParagraph = new Paragraph(new Run(new Text(heaviestCargoInfo)));
                        body.AppendChild(heaviestInfoParagraph);

                        // Добавляем таблицу с данными о самом тяжелом грузе
                        AddCargoInfoToDocument(body, heaviestRow);


                        // Добавляем заголовок раздела для самого легкого груза
                        Paragraph lightestTitleParagraph = new Paragraph(new Run(new Text("Самый легкий груз:")));
                        body.AppendChild(lightestTitleParagraph);

                        // Добавляем информацию о самом легком грузе
                        DataRow lightestRow = dataTable.Select("Вес = MIN(Вес)")[0];
                        string lightestCargoInfo = $"{lightestRow["Наименование"]} - вес: {lightestRow["Вес"]}";
                        Paragraph lightestInfoParagraph = new Paragraph(new Run(new Text(lightestCargoInfo)));
                        body.AppendChild(lightestInfoParagraph);

                        // Добавляем таблицу с данными о самом легком грузе
                        AddCargoInfoToDocument(body, lightestRow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчёта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void AddCargoInfoToDocument(Body body, DataRow cargoData)
        {
            // Создаем таблицу
            Table cargoTable = new Table();

            ApplyVisibleTableBorders(cargoTable);

            // Создаем строку для заголовков (названий столбцов)
            TableRow headerRow = new TableRow();

            // Добавляем ячейки с заголовками (названиями столбцов)
            foreach (DataColumn column in cargoData.Table.Columns)
            {
                TableCell headerCell = new TableCell(new Paragraph(new Run(new Text(column.ColumnName))));
                headerRow.AppendChild(headerCell);
            }

            // Добавляем строку заголовков к таблице
            cargoTable.AppendChild(headerRow);

            // Создаем строку для данных
            TableRow dataRow = new TableRow();

            // Добавляем ячейки с данными
            foreach (var item in cargoData.ItemArray)
            {
                TableCell cell = new TableCell(new Paragraph(new Run(new Text(item.ToString()))));
                dataRow.AppendChild(cell);
            }

            // Добавляем строку данных к таблице
            cargoTable.AppendChild(dataRow);

            // Добавляем таблицу к документу
            body.AppendChild(cargoTable);
        }



        //
        // Анализ грузоподъёмности (Менеджер)
        //

        public void GeneratePayloadAnalysisToWord(string savePath)
        {
            try
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(savePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    // Добавляем заголовок документа
                    Paragraph titleParagraph = new Paragraph(new Run(new Text($"Отчет Анализ Грузоподъемности на {DateTime.Now:yyyy-MM-dd}")));
                    titleParagraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                    body.AppendChild(titleParagraph);

                    // Подключение к базе данных
                    using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                    {
                        connection.Open();

                        // Запрос для получения данных из таблицы "Транспортные_средства"
                        string query = "SELECT * FROM Транспортные_средства";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                        // Заполняем DataTable данными из базы данных
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Добавляем заголовок раздела для транспортного средства с максимальной грузоподъемностью
                        Paragraph heaviestTitleParagraph = new Paragraph(new Run(new Text("Транспортное средство с максимальной грузоподъемностью:")));
                        body.AppendChild(heaviestTitleParagraph);

                        // Добавляем информацию о транспортном средстве с максимальной грузоподъемностью
                        DataRow heaviestRow = dataTable.Select("Грузоподъемность = MAX(Грузоподъемность)")[0];
                        string heaviestCargoInfo = $"{heaviestRow["Марка"]} - грузоподъемность: {heaviestRow["Грузоподъемность"]} кг";
                        Paragraph heaviestInfoParagraph = new Paragraph(new Run(new Text(heaviestCargoInfo)));
                        body.AppendChild(heaviestInfoParagraph);

                        // Добавляем таблицу с данными о транспортном средстве с максимальной грузоподъемностью
                        AddVehicleInfoToDocument(body, heaviestRow);

                        // Добавляем заголовок раздела для транспортного средства с минимальной грузоподъемностью
                        Paragraph lightestTitleParagraph = new Paragraph(new Run(new Text("Транспортное средство с минимальной грузоподъемностью:")));
                        body.AppendChild(lightestTitleParagraph);

                        // Добавляем информацию о транспортном средстве с минимальной грузоподъемностью
                        DataRow lightestRow = dataTable.Select("Грузоподъемность = MIN(Грузоподъемность)")[0];
                        string lightestCargoInfo = $"{lightestRow["Марка"]} - грузоподъемность: {lightestRow["Грузоподъемность"]} кг";
                        Paragraph lightestInfoParagraph = new Paragraph(new Run(new Text(lightestCargoInfo)));
                        body.AppendChild(lightestInfoParagraph);

                        // Добавляем таблицу с данными о транспортном средстве с минимальной грузоподъемностью
                        AddVehicleInfoToDocument(body, lightestRow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчёта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void AddVehicleInfoToDocument(Body body, DataRow vehicleData)
        {
            // Создаем таблицу
            Table vehicleTable = new Table();

            ApplyVisibleTableBorders(vehicleTable);

            // Создаем строку для заголовков (названий столбцов)
            TableRow headerRow = new TableRow();

            // Добавляем ячейки с заголовками (названиями столбцов)
            foreach (DataColumn column in vehicleData.Table.Columns)
            {
                TableCell headerCell = new TableCell(new Paragraph(new Run(new Text(column.ColumnName))));
                headerRow.AppendChild(headerCell);
            }

            // Добавляем строку заголовков к таблице
            vehicleTable.AppendChild(headerRow);

            // Создаем строку для данных
            TableRow dataRow = new TableRow();

            // Добавляем ячейки с данными
            foreach (var item in vehicleData.ItemArray)
            {
                TableCell cell = new TableCell(new Paragraph(new Run(new Text(item.ToString()))));
                dataRow.AppendChild(cell);
            }

            // Добавляем строку данных к таблице
            vehicleTable.AppendChild(dataRow);

            // Добавляем таблицу к документу
            body.AppendChild(vehicleTable);
        }

        //
        // Анализ марки (Менеджер)
        //

        public void GenerateBrandAnalysisToWord(string savePath)
        {
            try
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(savePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    // Добавляем заголовок документа
                    Paragraph titleParagraph = new Paragraph(new Run(new Text($"Отчет Анализ Марки на {DateTime.Now:yyyy-MM-dd}")));
                    titleParagraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                    body.AppendChild(titleParagraph);

                    // Подключение к базе данных
                    using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                    {
                        connection.Open();

                        // Запрос для получения самой популярной марки авто
                        string brandQuery = "SELECT TOP 1 Марка, COUNT(*) AS Количество FROM Транспортные_средства GROUP BY Марка ORDER BY Количество DESC";
                        SqlDataAdapter brandAdapter = new SqlDataAdapter(brandQuery, connection);
                        DataTable brandTable = new DataTable();
                        brandAdapter.Fill(brandTable);

                        // Проверяем, есть ли данные о марке
                        if (brandTable.Rows.Count > 0)
                        {
                            // Добавляем заголовок раздела для самой популярной марки
                            Paragraph brandTitleParagraph = new Paragraph(new Run(new Text("Самая популярная марка:")));
                            body.AppendChild(brandTitleParagraph);

                            // Добавляем информацию о самой популярной марке
                            string mostPopularBrand = brandTable.Rows[0]["Марка"].ToString();
                            Paragraph brandInfoParagraph = new Paragraph(new Run(new Text(mostPopularBrand)));
                            body.AppendChild(brandInfoParagraph);

                            // Добавляем заголовок раздела для таблицы с данными о транспортных средствах выбранной марки
                            Paragraph vehiclesTitleParagraph = new Paragraph(new Run(new Text("Данные о транспортных средствах выбранной марки:")));
                            body.AppendChild(vehiclesTitleParagraph);

                            // Добавляем таблицу с данными о транспортных средствах выбранной марки
                            AddBrandVehiclesInfoToDocument(body, mostPopularBrand, connection);
                        }
                        else
                        {
                            // Если нет данных о марке, выводим сообщение
                            Paragraph noDataParagraph = new Paragraph(new Run(new Text("Нет данных о марках транспортных средств.")));
                            body.AppendChild(noDataParagraph);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчёта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void AddBrandVehiclesInfoToDocument(Body body, string brand, SqlConnection connection)
        {
            // Запрос для получения данных о транспортных средствах выбранной марки
            string vehiclesQuery = $"SELECT * FROM Транспортные_средства WHERE Марка = '{brand}'";
            SqlDataAdapter vehiclesAdapter = new SqlDataAdapter(vehiclesQuery, connection);
            DataTable vehiclesTable = new DataTable();
            vehiclesAdapter.Fill(vehiclesTable);

            // Проверяем, есть ли данные о транспортных средствах выбранной марки
            if (vehiclesTable.Rows.Count > 0)
            {
                // Создаем таблицу
                Table vehiclesTableDoc = new Table();

                ApplyVisibleTableBorders(vehiclesTableDoc);

                // Создаем строку для заголовков
                TableRow headerRow = new TableRow();

                // Добавляем заголовки в ячейки
                foreach (DataColumn column in vehiclesTable.Columns)
                {
                    TableCell headerCell = new TableCell(new Paragraph(new Run(new Text(column.ColumnName))));
                    headerRow.AppendChild(headerCell);
                }

                // Добавляем строку заголовков к таблице
                vehiclesTableDoc.AppendChild(headerRow);

                // Добавляем строки с данными
                foreach (DataRow vehicleRow in vehiclesTable.Rows)
                {
                    TableRow dataRow = new TableRow();

                    // Добавляем ячейки с данными
                    foreach (var item in vehicleRow.ItemArray)
                    {
                        TableCell cell = new TableCell(new Paragraph(new Run(new Text(item.ToString()))));
                        dataRow.AppendChild(cell);
                    }

                    // Добавляем строку с данными к таблице
                    vehiclesTableDoc.AppendChild(dataRow);
                }

                // Добавляем таблицу с данными о транспортных средствах к документу
                body.AppendChild(vehiclesTableDoc);
            }
            else
            {
                // Если нет данных о транспортных средствах выбранной марки, выводим сообщение
                Paragraph noDataParagraph = new Paragraph(new Run(new Text($"Нет данных о транспортных средствах марки {brand}.")));
                body.AppendChild(noDataParagraph);
            }
        }

        //
        // Анализ стажа вождения (Менеджер)
        //

        public void GenerateDriverExperienceAnalysisToWord(string savePath)
        {
            try
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(savePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    // Добавляем заголовок документа
                    Paragraph titleParagraph = new Paragraph(new Run(new Text($"Отчет Анализ Стажа вождения на {DateTime.Now:yyyy-MM-dd}")));
                    titleParagraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                    body.AppendChild(titleParagraph);

                    // Подключение к базе данных
                    using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                    {
                        connection.Open();

                        // Запрос для получения данных из таблицы "Водители"
                        string query = "SELECT Номер, ФИО, Номер_телефона, CONVERT(VARCHAR(10), Дата_рождения, 120) AS Дата_рождения, Стаж_вождения, ИНН, Логин_водителя, Пароль_водителя FROM Водители";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                        // Заполняем DataTable данными из базы данных
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Добавляем заголовок раздела для водителя с максимальным стажем
                        Paragraph maxExperienceTitleParagraph = new Paragraph(new Run(new Text("Водитель с максимальным стажем:")));
                        body.AppendChild(maxExperienceTitleParagraph);

                        // Добавляем информацию о водителе с максимальным стажем
                        DataRow maxExperienceRow = dataTable.Select("Стаж_вождения = MAX(Стаж_вождения)")[0];
                        string maxExperienceDriverInfo = $"{maxExperienceRow["ФИО"]} - стаж: {maxExperienceRow["Стаж_вождения"]} лет";
                        Paragraph maxExperienceInfoParagraph = new Paragraph(new Run(new Text(maxExperienceDriverInfo)));
                        body.AppendChild(maxExperienceInfoParagraph);

                        // Добавляем таблицу с данными о водителе с максимальным стажем
                        AddDriverInfoToDocument(body, maxExperienceRow);

                        // Добавляем заголовок раздела для водителя с минимальным стажем
                        Paragraph minExperienceTitleParagraph = new Paragraph(new Run(new Text("Водитель с минимальным стажем:")));
                        body.AppendChild(minExperienceTitleParagraph);

                        // Добавляем информацию о водителе с минимальным стажем
                        DataRow minExperienceRow = dataTable.Select("Стаж_вождения = MIN(Стаж_вождения)")[0];
                        string minExperienceDriverInfo = $"{minExperienceRow["ФИО"]} - стаж: {minExperienceRow["Стаж_вождения"]} лет";
                        Paragraph minExperienceInfoParagraph = new Paragraph(new Run(new Text(minExperienceDriverInfo)));
                        body.AppendChild(minExperienceInfoParagraph);

                        // Добавляем таблицу с данными о водителе с минимальным стажем
                        AddDriverInfoToDocument(body, minExperienceRow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчёта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public static void AddDriverInfoToDocument(Body body, DataRow driverData)
        {
            // Создаем таблицу
            Table driverTable = new Table();

            ApplyVisibleTableBorders(driverTable);

            // Добавляем строку с заголовками
            TableRow headerRow = new TableRow();

            foreach (DataColumn column in driverData.Table.Columns)
            {
                TableCell cell = new TableCell(new Paragraph(new Run(new Text(column.ColumnName))));
                headerRow.AppendChild(cell);
            }

            driverTable.AppendChild(headerRow);

            // Создаем строку для данных
            TableRow dataRow = new TableRow();

            // Добавляем ячейки с данными
            foreach (var item in driverData.ItemArray)
            {
                TableCell cell = new TableCell(new Paragraph(new Run(new Text(item.ToString()))));
                dataRow.AppendChild(cell);
            }

            // Добавляем строку к таблице
            driverTable.AppendChild(dataRow);

            // Добавляем таблицу к документу
            body.AppendChild(driverTable);
        }

        //
        // Анализ длины маршрута (Логист)
        //

        public void GenerateRouteLengthAnalysisToWord(string savePath)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(savePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Добавляем заголовок документа
                Paragraph titleParagraph = new Paragraph(new Run(new Text($"Отчет Анализ Длины маршрута на {DateTime.Now:yyyy-MM-dd}")));
                titleParagraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                body.AppendChild(titleParagraph);

                // Подключение к базе данных
                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                {
                    connection.Open();

                    // Запрос для получения данных из таблицы "Маршруты"
                    string query = "SELECT * FROM Маршруты";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // Заполняем DataTable данными из базы данных
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Добавляем заголовок раздела для маршрута с максимальной длиной
                    Paragraph longestRouteTitleParagraph = new Paragraph(new Run(new Text("Маршрут с максимальной длиной:")));
                    body.AppendChild(longestRouteTitleParagraph);

                    // Добавляем информацию о маршруте с максимальной длиной
                    DataRow longestRouteRow = dataTable.Select("Длина_маршрута = MAX(Длина_маршрута)")[0];
                    string longestRouteInfo = $"{longestRouteRow["Начальная_точка"]} - {longestRouteRow["Конечная_точка"]} - длина: {longestRouteRow["Длина_маршрута"]} км";
                    Paragraph longestRouteInfoParagraph = new Paragraph(new Run(new Text(longestRouteInfo)));
                    body.AppendChild(longestRouteInfoParagraph);

                    // Добавляем таблицу с данными о маршруте с максимальной длиной
                    AddRouteInfoToDocument(body, longestRouteRow);

                    // Добавляем заголовок раздела для маршрута с минимальной длиной
                    Paragraph shortestRouteTitleParagraph = new Paragraph(new Run(new Text("Маршрут с минимальной длиной:")));
                    body.AppendChild(shortestRouteTitleParagraph);

                    // Добавляем информацию о маршруте с минимальной длиной
                    DataRow shortestRouteRow = dataTable.Select("Длина_маршрута = MIN(Длина_маршрута)")[0];
                    string shortestRouteInfo = $"{shortestRouteRow["Начальная_точка"]} - {shortestRouteRow["Конечная_точка"]} - длина: {shortestRouteRow["Длина_маршрута"]} км";
                    Paragraph shortestRouteInfoParagraph = new Paragraph(new Run(new Text(shortestRouteInfo)));
                    body.AppendChild(shortestRouteInfoParagraph);

                    // Добавляем таблицу с данными о маршруте с минимальной длиной
                    AddRouteInfoToDocument(body, shortestRouteRow);
                }
            }
        }

        public static void AddRouteInfoToDocument(Body body, DataRow routeData)
        {
            // Создаем таблицу
            Table routeTable = new Table();

            ApplyVisibleTableBorders(routeTable);

            // Создаем строку для заголовков
            TableRow headerRow = new TableRow();
            foreach (DataColumn column in routeData.Table.Columns)
            {
                TableCell headerCell = new TableCell(new Paragraph(new Run(new Text(column.ColumnName))));
                headerRow.AppendChild(headerCell);
            }
            routeTable.AppendChild(headerRow);

            // Создаем строку для данных
            TableRow dataRow = new TableRow();

            // Добавляем ячейки с данными
            foreach (var item in routeData.ItemArray)
            {
                TableCell cell = new TableCell(new Paragraph(new Run(new Text(item.ToString()))));
                dataRow.AppendChild(cell);
            }

            // Добавляем строку к таблице
            routeTable.AppendChild(dataRow);

            // Добавляем таблицу к документу
            body.AppendChild(routeTable);
        }

        //
        // Лучший водитель (Логист)
        //

        public void GenerateBestDriverToWord(string savePath)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(savePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Добавляем заголовок документа
                Paragraph titleParagraph = new Paragraph(new Run(new Text($"Отчет Лучший водитель на {DateTime.Now:yyyy-MM-dd}")));
                titleParagraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                body.AppendChild(titleParagraph);

                // Получаем данные о лучшем водителе
                DataRow bestDriverRow = GetBestDriverData();

                if (bestDriverRow != null)
                {
                    // Добавляем информацию о лучшем водителе
                    Paragraph bestDriverInfoParagraph = new Paragraph(new Run(new Text($"Лучший водитель: {bestDriverRow["ФИО"]}")));
                    body.AppendChild(bestDriverInfoParagraph);

                    // Добавляем количество завершенных заказов
                    int completedOrdersCount = GetCompletedOrdersCount(Convert.ToInt32(bestDriverRow["Номер"]));
                    body.AppendChild(new Paragraph(new Run(new Text($"Количество завершенных заказов: {completedOrdersCount}"))));

                    // Добавляем таблицу с данными о перевозках
                    DataTable transportData = GetTransportData(Convert.ToInt32(bestDriverRow["Номер"]));
                    AddTransportInfoToDocument(body, transportData);
                }
                else
                {
                    body.AppendChild(new Paragraph(new Run(new Text("Нет данных о завершенных заказах."))));
                }
            }
        }

        private DataRow GetBestDriverData()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 Водители.Номер, Водители.ФИО, Водители.Номер_телефона, COUNT(Перевозки.Номер) AS ЗавершенныеЗаказы " +
                               "FROM Водители " +
                               "LEFT JOIN Перевозки ON Водители.Номер = Перевозки.Номер_водителя AND Перевозки.Статус_перевозки = 'Завершена' " +
                               "GROUP BY Водители.Номер, Водители.ФИО, Водители.Номер_телефона " +
                               "ORDER BY ЗавершенныеЗаказы DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    return dataTable.Rows[0];
                }

                return null;
            }
        }



        private int GetCompletedOrdersCount(int driverNumber)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = $"SELECT COUNT(*) FROM Перевозки WHERE Номер_водителя = {driverNumber} AND Статус_перевозки = 'Завершена'";
                SqlCommand command = new SqlCommand(query, connection);

                return (int)command.ExecuteScalar();
            }
        }

        private DataTable GetTransportData(int driverNumber)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM Перевозки WHERE Номер_водителя = {driverNumber} AND Статус_перевозки = 'Завершена'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        private static void AddTransportInfoToDocument(Body body, DataTable transportData)
        {
            if (transportData.Rows.Count > 0)
            {
                // Создаем таблицу
                Table transportTable = new Table();

                ApplyVisibleTableBorders(transportTable);

                // Создаем строку для заголовков столбцов
                TableRow headerRow = new TableRow();

                // Добавляем ячейки с заголовками столбцов
                foreach (DataColumn column in transportData.Columns)
                {
                    TableCell headerCell = new TableCell(new Paragraph(new Run(new Text(column.ColumnName))));
                    headerRow.AppendChild(headerCell);
                }

                // Добавляем строку заголовков к таблице
                transportTable.AppendChild(headerRow);

                // Добавляем строки с данными
                foreach (DataRow row in transportData.Rows)
                {
                    TableRow dataRow = new TableRow();

                    foreach (var item in row.ItemArray)
                    {
                        TableCell cell = new TableCell(new Paragraph(new Run(new Text(item.ToString()))));
                        dataRow.AppendChild(cell);
                    }

                    // Добавляем строку данных к таблице
                    transportTable.AppendChild(dataRow);
                }

                // Добавляем таблицу к документу
                body.AppendChild(transportTable);
            }
            else
            {
                // Добавляем сообщение о отсутствии данных
                body.AppendChild(new Paragraph(new Run(new Text("Нет данных о завершенных заказах."))));
            }
        }



        //
        // Самый Популярный маршрут (Логист)
        //

        public void GeneratePopularRouteToWord(string savePath)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(savePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Добавляем заголовок документа
                Paragraph titleParagraph = new Paragraph(new Run(new Text($"Отчет Популярный маршрут грузоперевозок на {DateTime.Now:yyyy-MM-dd}")));
                titleParagraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                body.AppendChild(titleParagraph);

                // Получаем данные о популярном маршруте
                DataRow popularRouteRow = GetPopularRouteData();

                if (popularRouteRow != null)
                {
                    // Добавляем информацию о популярном маршруте
                    Paragraph popularRouteInfoParagraph = new Paragraph(new Run(new Text($"Популярный маршрут: №{popularRouteRow["Название"]}")));
                    body.AppendChild(popularRouteInfoParagraph);

                    // Добавляем таблицу с завершенными перевозками для популярного маршрута
                    AddTransportTableToDocument(body, "Завершенные перевозки", GetCompletedTransportData(popularRouteRow));

                    // Добавляем таблицу с незавершенными перевозками для популярного маршрута
                    AddTransportTableToDocument(body, "Незавершенные перевозки", GetInProgressTransportData(popularRouteRow));
                }
                else
                {
                    body.AppendChild(new Paragraph(new Run(new Text("Нет данных о популярных маршрутах."))));
                }
            }
        }

        // Метод для получения данных о завершенных перевозках для популярного маршрута
        private DataTable GetCompletedTransportData(DataRow popularRouteRow)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string routeName = popularRouteRow["Название"].ToString();

                string query = $"SELECT * FROM Перевозки WHERE Номер_маршрута = '{routeName}' AND Статус_перевозки = 'Завершена'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Метод для получения данных о незавершенных перевозках для популярного маршрута
        private DataTable GetInProgressTransportData(DataRow popularRouteRow)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string routeName = popularRouteRow["Название"].ToString();

                string query = $"SELECT * FROM Перевозки WHERE Номер_маршрута = '{routeName}' AND Статус_перевозки != 'Завершена'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Метод для добавления таблицы с данными о перевозках в документ
        private static void AddTransportTableToDocument(Body body, string tableTitle, DataTable transportData)
        {
            if (transportData.Rows.Count > 0)
            {
                // Создаем заголовок таблицы
                Paragraph tableTitleParagraph = new Paragraph(new Run(new Text(tableTitle)));
                body.AppendChild(tableTitleParagraph);

                // Создаем таблицу
                Table transportTable = new Table();

                ApplyVisibleTableBorders(transportTable);

                // Создаем строку для заголовков столбцов
                TableRow headerRow = new TableRow();

                // Добавляем ячейки с заголовками столбцов
                foreach (DataColumn column in transportData.Columns)
                {
                    TableCell headerCell = new TableCell(new Paragraph(new Run(new Text(column.ColumnName))));
                    headerRow.AppendChild(headerCell);
                }

                // Добавляем строку заголовков к таблице
                transportTable.AppendChild(headerRow);

                // Добавляем строки с данными
                foreach (DataRow row in transportData.Rows)
                {
                    TableRow dataRow = new TableRow();

                    foreach (var item in row.ItemArray)
                    {
                        TableCell cell = new TableCell(new Paragraph(new Run(new Text(item.ToString()))));
                        dataRow.AppendChild(cell);
                    }

                    // Добавляем строку данных к таблице
                    transportTable.AppendChild(dataRow);
                }

                // Добавляем таблицу к документу
                body.AppendChild(transportTable);
            }
            else
            {
                // Добавляем сообщение о отсутствии данных
                body.AppendChild(new Paragraph(new Run(new Text($"Нет данных о {tableTitle.ToLower()} для популярного маршрута."))));
            }
        }

        // Метод для получения данных о популярном маршруте
        private DataRow GetPopularRouteData()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 Номер_маршрута AS Название, COUNT(Перевозки.Номер) AS ЗавершенныеПеревозки " +
                 "FROM Маршруты " +
                 "JOIN Перевозки ON Маршруты.Номер = Перевозки.Номер_маршрута " +
                 "WHERE Перевозки.Статус_перевозки = 'Завершена' " +
                 "GROUP BY Номер_маршрута " +
                 "ORDER BY ЗавершенныеПеревозки DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    return dataTable.Rows[0];
                }

                return null;
            }
        }


        //
        // Завершённые перевозки (Логист)
        //

        public void ZaverwennieToWord(string savePath)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(savePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Добавляем заголовок документа
                Paragraph titleParagraph = new Paragraph(new Run(new Text($"Отчет о завершенных перевозках на {DateTime.Now:yyyy-MM-dd}")));
                titleParagraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                body.AppendChild(titleParagraph);

                // Добавляем информацию о количестве завершенных заказов
                int completedOrdersCount = GetCompletedOrdersCount();
                Paragraph completedOrdersCountParagraph = new Paragraph(new Run(new Text($"Количество завершенных заказов: {completedOrdersCount}")));
                body.AppendChild(completedOrdersCountParagraph);

                // Добавляем таблицу с завершенными перевозками
                DataTable completedTransportData = GetCompletedTransportData();
                AddTransportTableToDocument1(body, "Завершенные перевозки", completedTransportData);
            }
        }

        private int GetCompletedOrdersCount()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Перевозки WHERE Статус_перевозки = 'Завершена'";
                SqlCommand command = new SqlCommand(query, connection);

                return (int)command.ExecuteScalar();
            }
        }

        private DataTable GetCompletedTransportData()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Перевозки WHERE Статус_перевозки = 'Завершена'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        private static void AddTransportTableToDocument1(Body body, string tableTitle, DataTable transportData)
        {
            if (transportData.Rows.Count > 0)
            {
                // Создаем заголовок таблицы
                Paragraph tableTitleParagraph = new Paragraph(new Run(new Text(tableTitle)));
                body.AppendChild(tableTitleParagraph);

                // Создаем таблицу
                Table transportTable = new Table();

                ApplyVisibleTableBorders(transportTable);

                // Создаем строку для заголовков столбцов
                TableRow headerRow = new TableRow();

                // Добавляем ячейки с заголовками столбцов
                foreach (DataColumn column in transportData.Columns)
                {
                    TableCell headerCell = new TableCell(new Paragraph(new Run(new Text(column.ColumnName))));
                    headerRow.AppendChild(headerCell);
                }

                // Добавляем строку заголовков к таблице
                transportTable.AppendChild(headerRow);

                // Добавляем строки с данными
                foreach (DataRow row in transportData.Rows)
                {
                    TableRow dataRow = new TableRow();

                    foreach (var item in row.ItemArray)
                    {
                        TableCell cell = new TableCell(new Paragraph(new Run(new Text(item.ToString()))));
                        dataRow.AppendChild(cell);
                    }

                    // Добавляем строку данных к таблице
                    transportTable.AppendChild(dataRow);
                }

                // Добавляем таблицу к документу
                body.AppendChild(transportTable);
            }
            else
            {
                // Добавляем сообщение о отсутствии данных
                body.AppendChild(new Paragraph(new Run(new Text($"Нет данных о {tableTitle.ToLower()}."))));
            }
        }

        //
        // Незавершенные перевозки (Логист)
        //
        public void NezaverwennieToWord(string savePath)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(savePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Добавляем заголовок документа
                Paragraph titleParagraph = new Paragraph(new Run(new Text($"Отчет о незавершенных перевозках на {DateTime.Now:yyyy-MM-dd}")));
                titleParagraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                body.AppendChild(titleParagraph);

                // Добавляем информацию о количестве незавершенных заказов
                int inProgressOrdersCount = GetInProgressOrdersCount();
                Paragraph inProgressOrdersCountParagraph = new Paragraph(new Run(new Text($"Количество незавершенных заказов: {inProgressOrdersCount}")));
                body.AppendChild(inProgressOrdersCountParagraph);

                // Добавляем таблицу с незавершенными перевозками
                DataTable inProgressTransportData = GetInProgressTransportData();
                AddTransportTableToDocument(body, "Незавершенные перевозки", inProgressTransportData);
            }
        }

        private int GetInProgressOrdersCount()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Перевозки WHERE Статус_перевозки != 'Завершена'";
                SqlCommand command = new SqlCommand(query, connection);

                return (int)command.ExecuteScalar();
            }
        }

        private DataTable GetInProgressTransportData()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Перевозки WHERE Статус_перевозки != 'Завершена'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }



    }
}
