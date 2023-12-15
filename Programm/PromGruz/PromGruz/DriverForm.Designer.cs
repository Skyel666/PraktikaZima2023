namespace PromGruz
{
    partial class DriverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverForm));
            this.dataGridViewPerevozkiVoditelya = new System.Windows.Forms.DataGridView();
            this.button_perevozkaEnd = new System.Windows.Forms.Button();
            this.textBox_perevozkaId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabePage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.номерDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименованиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.весDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.типгрузаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.грузыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.грузоперевозкиDataSet1 = new PromGruz.ГрузоперевозкиDataSet1();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.номерDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.начальнаяточкаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.конечнаяточкаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.длинамаршрутаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.маршрутыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.номерDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.маркаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.цветкорпусаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.грузоподъемностьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.годвыпускаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.госНомерDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.транспортныесредстваBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.грузыTableAdapter = new PromGruz.ГрузоперевозкиDataSet1TableAdapters.ГрузыTableAdapter();
            this.маршрутыTableAdapter = new PromGruz.ГрузоперевозкиDataSet1TableAdapters.МаршрутыTableAdapter();
            this.транспортные_средстваTableAdapter = new PromGruz.ГрузоперевозкиDataSet1TableAdapters.Транспортные_средстваTableAdapter();
            this.comboBox_ColumnsPerevozki = new System.Windows.Forms.ComboBox();
            this.textBox_SearchPerevozka = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox_ColumnsGruz = new System.Windows.Forms.ComboBox();
            this.comboBox_ColumnsTransport = new System.Windows.Forms.ComboBox();
            this.textBox_SearchGruz = new System.Windows.Forms.TextBox();
            this.textBox_SearchTransport = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_ColumnsMarshrut = new System.Windows.Forms.ComboBox();
            this.textBox_SearchMarshrut = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerevozkiVoditelya)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabePage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузоперевозкиDataSet1)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.маршрутыBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.транспортныесредстваBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPerevozkiVoditelya
            // 
            this.dataGridViewPerevozkiVoditelya.AllowUserToAddRows = false;
            this.dataGridViewPerevozkiVoditelya.AllowUserToDeleteRows = false;
            this.dataGridViewPerevozkiVoditelya.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPerevozkiVoditelya.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPerevozkiVoditelya.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPerevozkiVoditelya.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewPerevozkiVoditelya.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewPerevozkiVoditelya.Name = "dataGridViewPerevozkiVoditelya";
            this.dataGridViewPerevozkiVoditelya.ReadOnly = true;
            this.dataGridViewPerevozkiVoditelya.Size = new System.Drawing.Size(741, 579);
            this.dataGridViewPerevozkiVoditelya.TabIndex = 1;
            // 
            // button_perevozkaEnd
            // 
            this.button_perevozkaEnd.BackColor = System.Drawing.Color.Gray;
            this.button_perevozkaEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_perevozkaEnd.ForeColor = System.Drawing.Color.Lime;
            this.button_perevozkaEnd.Location = new System.Drawing.Point(4, 92);
            this.button_perevozkaEnd.Name = "button_perevozkaEnd";
            this.button_perevozkaEnd.Size = new System.Drawing.Size(419, 60);
            this.button_perevozkaEnd.TabIndex = 2;
            this.button_perevozkaEnd.Text = "Завершить перевозку";
            this.button_perevozkaEnd.UseVisualStyleBackColor = false;
            this.button_perevozkaEnd.Click += new System.EventHandler(this.button_perevozkaEnd_Click_1);
            // 
            // textBox_perevozkaId
            // 
            this.textBox_perevozkaId.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_perevozkaId.Location = new System.Drawing.Point(6, 54);
            this.textBox_perevozkaId.Name = "textBox_perevozkaId";
            this.textBox_perevozkaId.Size = new System.Drawing.Size(417, 32);
            this.textBox_perevozkaId.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 42);
            this.label1.TabIndex = 4;
            this.label1.Text = "Укажите номер перевозки";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabePage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(429, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(755, 611);
            this.tabControl1.TabIndex = 5;
            // 
            // tabePage1
            // 
            this.tabePage1.Controls.Add(this.dataGridViewPerevozkiVoditelya);
            this.tabePage1.Location = new System.Drawing.Point(4, 22);
            this.tabePage1.Name = "tabePage1";
            this.tabePage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabePage1.Size = new System.Drawing.Size(747, 585);
            this.tabePage1.TabIndex = 0;
            this.tabePage1.Text = "Перевозки";
            this.tabePage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(747, 585);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Грузы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерDataGridViewTextBoxColumn,
            this.наименованиеDataGridViewTextBoxColumn,
            this.весDataGridViewTextBoxColumn,
            this.типгрузаDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.грузыBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(741, 579);
            this.dataGridView1.TabIndex = 0;
            // 
            // номерDataGridViewTextBoxColumn
            // 
            this.номерDataGridViewTextBoxColumn.DataPropertyName = "Номер";
            this.номерDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.номерDataGridViewTextBoxColumn.Name = "номерDataGridViewTextBoxColumn";
            this.номерDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // наименованиеDataGridViewTextBoxColumn
            // 
            this.наименованиеDataGridViewTextBoxColumn.DataPropertyName = "Наименование";
            this.наименованиеDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.наименованиеDataGridViewTextBoxColumn.Name = "наименованиеDataGridViewTextBoxColumn";
            this.наименованиеDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // весDataGridViewTextBoxColumn
            // 
            this.весDataGridViewTextBoxColumn.DataPropertyName = "Вес";
            this.весDataGridViewTextBoxColumn.HeaderText = "Вес";
            this.весDataGridViewTextBoxColumn.Name = "весDataGridViewTextBoxColumn";
            this.весDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // типгрузаDataGridViewTextBoxColumn
            // 
            this.типгрузаDataGridViewTextBoxColumn.DataPropertyName = "Тип_груза";
            this.типгрузаDataGridViewTextBoxColumn.HeaderText = "Тип_груза";
            this.типгрузаDataGridViewTextBoxColumn.Name = "типгрузаDataGridViewTextBoxColumn";
            this.типгрузаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // грузыBindingSource
            // 
            this.грузыBindingSource.DataMember = "Грузы";
            this.грузыBindingSource.DataSource = this.грузоперевозкиDataSet1;
            // 
            // грузоперевозкиDataSet1
            // 
            this.грузоперевозкиDataSet1.DataSetName = "ГрузоперевозкиDataSet1";
            this.грузоперевозкиDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(747, 585);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Маршруты";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерDataGridViewTextBoxColumn1,
            this.начальнаяточкаDataGridViewTextBoxColumn,
            this.конечнаяточкаDataGridViewTextBoxColumn,
            this.длинамаршрутаDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.маршрутыBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(741, 579);
            this.dataGridView2.TabIndex = 0;
            // 
            // номерDataGridViewTextBoxColumn1
            // 
            this.номерDataGridViewTextBoxColumn1.DataPropertyName = "Номер";
            this.номерDataGridViewTextBoxColumn1.HeaderText = "Номер";
            this.номерDataGridViewTextBoxColumn1.Name = "номерDataGridViewTextBoxColumn1";
            this.номерDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // начальнаяточкаDataGridViewTextBoxColumn
            // 
            this.начальнаяточкаDataGridViewTextBoxColumn.DataPropertyName = "Начальная_точка";
            this.начальнаяточкаDataGridViewTextBoxColumn.HeaderText = "Начальная_точка";
            this.начальнаяточкаDataGridViewTextBoxColumn.Name = "начальнаяточкаDataGridViewTextBoxColumn";
            this.начальнаяточкаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // конечнаяточкаDataGridViewTextBoxColumn
            // 
            this.конечнаяточкаDataGridViewTextBoxColumn.DataPropertyName = "Конечная_точка";
            this.конечнаяточкаDataGridViewTextBoxColumn.HeaderText = "Конечная_точка";
            this.конечнаяточкаDataGridViewTextBoxColumn.Name = "конечнаяточкаDataGridViewTextBoxColumn";
            this.конечнаяточкаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // длинамаршрутаDataGridViewTextBoxColumn
            // 
            this.длинамаршрутаDataGridViewTextBoxColumn.DataPropertyName = "Длина_маршрута";
            this.длинамаршрутаDataGridViewTextBoxColumn.HeaderText = "Длина_маршрута";
            this.длинамаршрутаDataGridViewTextBoxColumn.Name = "длинамаршрутаDataGridViewTextBoxColumn";
            this.длинамаршрутаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // маршрутыBindingSource
            // 
            this.маршрутыBindingSource.DataMember = "Маршруты";
            this.маршрутыBindingSource.DataSource = this.грузоперевозкиDataSet1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(747, 585);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Транспорт";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерDataGridViewTextBoxColumn2,
            this.маркаDataGridViewTextBoxColumn,
            this.цветкорпусаDataGridViewTextBoxColumn,
            this.грузоподъемностьDataGridViewTextBoxColumn,
            this.годвыпускаDataGridViewTextBoxColumn,
            this.госНомерDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.транспортныесредстваBindingSource;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(741, 579);
            this.dataGridView3.TabIndex = 1;
            // 
            // номерDataGridViewTextBoxColumn2
            // 
            this.номерDataGridViewTextBoxColumn2.DataPropertyName = "Номер";
            this.номерDataGridViewTextBoxColumn2.HeaderText = "Номер";
            this.номерDataGridViewTextBoxColumn2.Name = "номерDataGridViewTextBoxColumn2";
            this.номерDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // маркаDataGridViewTextBoxColumn
            // 
            this.маркаDataGridViewTextBoxColumn.DataPropertyName = "Марка";
            this.маркаDataGridViewTextBoxColumn.HeaderText = "Марка";
            this.маркаDataGridViewTextBoxColumn.Name = "маркаDataGridViewTextBoxColumn";
            this.маркаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // цветкорпусаDataGridViewTextBoxColumn
            // 
            this.цветкорпусаDataGridViewTextBoxColumn.DataPropertyName = "Цвет_корпуса";
            this.цветкорпусаDataGridViewTextBoxColumn.HeaderText = "Цвет_корпуса";
            this.цветкорпусаDataGridViewTextBoxColumn.Name = "цветкорпусаDataGridViewTextBoxColumn";
            this.цветкорпусаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // грузоподъемностьDataGridViewTextBoxColumn
            // 
            this.грузоподъемностьDataGridViewTextBoxColumn.DataPropertyName = "Грузоподъемность";
            this.грузоподъемностьDataGridViewTextBoxColumn.HeaderText = "Грузоподъемность";
            this.грузоподъемностьDataGridViewTextBoxColumn.Name = "грузоподъемностьDataGridViewTextBoxColumn";
            this.грузоподъемностьDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // годвыпускаDataGridViewTextBoxColumn
            // 
            this.годвыпускаDataGridViewTextBoxColumn.DataPropertyName = "Год_выпуска";
            this.годвыпускаDataGridViewTextBoxColumn.HeaderText = "Год_выпуска";
            this.годвыпускаDataGridViewTextBoxColumn.Name = "годвыпускаDataGridViewTextBoxColumn";
            this.годвыпускаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // госНомерDataGridViewTextBoxColumn
            // 
            this.госНомерDataGridViewTextBoxColumn.DataPropertyName = "Гос_Номер";
            this.госНомерDataGridViewTextBoxColumn.HeaderText = "Гос_Номер";
            this.госНомерDataGridViewTextBoxColumn.Name = "госНомерDataGridViewTextBoxColumn";
            this.госНомерDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // транспортныесредстваBindingSource
            // 
            this.транспортныесредстваBindingSource.DataMember = "Транспортные_средства";
            this.транспортныесредстваBindingSource.DataSource = this.грузоперевозкиDataSet1;
            // 
            // грузыTableAdapter
            // 
            this.грузыTableAdapter.ClearBeforeFill = true;
            // 
            // маршрутыTableAdapter
            // 
            this.маршрутыTableAdapter.ClearBeforeFill = true;
            // 
            // транспортные_средстваTableAdapter
            // 
            this.транспортные_средстваTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox_ColumnsPerevozki
            // 
            this.comboBox_ColumnsPerevozki.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.comboBox_ColumnsPerevozki.FormattingEnabled = true;
            this.comboBox_ColumnsPerevozki.Location = new System.Drawing.Point(6, 236);
            this.comboBox_ColumnsPerevozki.Name = "comboBox_ColumnsPerevozki";
            this.comboBox_ColumnsPerevozki.Size = new System.Drawing.Size(180, 31);
            this.comboBox_ColumnsPerevozki.TabIndex = 119;
            // 
            // textBox_SearchPerevozka
            // 
            this.textBox_SearchPerevozka.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_SearchPerevozka.Location = new System.Drawing.Point(192, 236);
            this.textBox_SearchPerevozka.Name = "textBox_SearchPerevozka";
            this.textBox_SearchPerevozka.Size = new System.Drawing.Size(231, 32);
            this.textBox_SearchPerevozka.TabIndex = 118;
            this.textBox_SearchPerevozka.TextChanged += new System.EventHandler(this.textBox_SearchPerevozka_TextChanged);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Gray;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 21.75F);
            this.button9.ForeColor = System.Drawing.Color.Red;
            this.button9.Location = new System.Drawing.Point(6, 539);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(417, 60);
            this.button9.TabIndex = 117;
            this.button9.Text = "Сбросить сортировку";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(-1, 155);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 39);
            this.label15.TabIndex = 116;
            this.label15.Text = "Поиск:";
            // 
            // comboBox_ColumnsGruz
            // 
            this.comboBox_ColumnsGruz.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.comboBox_ColumnsGruz.FormattingEnabled = true;
            this.comboBox_ColumnsGruz.Location = new System.Drawing.Point(8, 387);
            this.comboBox_ColumnsGruz.Name = "comboBox_ColumnsGruz";
            this.comboBox_ColumnsGruz.Size = new System.Drawing.Size(180, 31);
            this.comboBox_ColumnsGruz.TabIndex = 126;
            // 
            // comboBox_ColumnsTransport
            // 
            this.comboBox_ColumnsTransport.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.comboBox_ColumnsTransport.FormattingEnabled = true;
            this.comboBox_ColumnsTransport.Location = new System.Drawing.Point(8, 313);
            this.comboBox_ColumnsTransport.Name = "comboBox_ColumnsTransport";
            this.comboBox_ColumnsTransport.Size = new System.Drawing.Size(180, 31);
            this.comboBox_ColumnsTransport.TabIndex = 125;
            // 
            // textBox_SearchGruz
            // 
            this.textBox_SearchGruz.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_SearchGruz.Location = new System.Drawing.Point(194, 386);
            this.textBox_SearchGruz.Name = "textBox_SearchGruz";
            this.textBox_SearchGruz.Size = new System.Drawing.Size(229, 32);
            this.textBox_SearchGruz.TabIndex = 124;
            this.textBox_SearchGruz.TextChanged += new System.EventHandler(this.textBox_SearchGruz_TextChanged);
            // 
            // textBox_SearchTransport
            // 
            this.textBox_SearchTransport.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_SearchTransport.Location = new System.Drawing.Point(194, 313);
            this.textBox_SearchTransport.Name = "textBox_SearchTransport";
            this.textBox_SearchTransport.Size = new System.Drawing.Size(229, 32);
            this.textBox_SearchTransport.TabIndex = 123;
            this.textBox_SearchTransport.TextChanged += new System.EventHandler(this.textBox_SearchTransport_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(1, 345);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(107, 39);
            this.label26.TabIndex = 122;
            this.label26.Text = "Груз:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(-1, 271);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(206, 39);
            this.label23.TabIndex = 121;
            this.label23.Text = "Транспорт:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-1, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 39);
            this.label2.TabIndex = 120;
            this.label2.Text = "Перевозки:";
            // 
            // comboBox_ColumnsMarshrut
            // 
            this.comboBox_ColumnsMarshrut.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.comboBox_ColumnsMarshrut.FormattingEnabled = true;
            this.comboBox_ColumnsMarshrut.Location = new System.Drawing.Point(8, 463);
            this.comboBox_ColumnsMarshrut.Name = "comboBox_ColumnsMarshrut";
            this.comboBox_ColumnsMarshrut.Size = new System.Drawing.Size(180, 31);
            this.comboBox_ColumnsMarshrut.TabIndex = 129;
            // 
            // textBox_SearchMarshrut
            // 
            this.textBox_SearchMarshrut.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_SearchMarshrut.Location = new System.Drawing.Point(192, 462);
            this.textBox_SearchMarshrut.Name = "textBox_SearchMarshrut";
            this.textBox_SearchMarshrut.Size = new System.Drawing.Size(231, 32);
            this.textBox_SearchMarshrut.TabIndex = 128;
            this.textBox_SearchMarshrut.TextChanged += new System.EventHandler(this.textBox_SearchMarshrut_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(-3, 421);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(183, 39);
            this.label20.TabIndex = 127;
            this.label20.Text = "Маршрут:";
            // 
            // DriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PromGruz.Properties.Resources.ada;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.comboBox_ColumnsMarshrut);
            this.Controls.Add(this.textBox_SearchMarshrut);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comboBox_ColumnsGruz);
            this.Controls.Add(this.comboBox_ColumnsTransport);
            this.Controls.Add(this.textBox_SearchGruz);
            this.Controls.Add(this.textBox_SearchTransport);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_ColumnsPerevozki);
            this.Controls.Add(this.textBox_SearchPerevozka);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_perevozkaId);
            this.Controls.Add(this.button_perevozkaEnd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DriverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Водитель";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DriverForm_FormClosed);
            this.Load += new System.EventHandler(this.DriverForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerevozkiVoditelya)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabePage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузоперевозкиDataSet1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.маршрутыBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.транспортныесредстваBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewPerevozkiVoditelya;
        private System.Windows.Forms.Button button_perevozkaEnd;
        private System.Windows.Forms.TextBox textBox_perevozkaId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabePage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ГрузоперевозкиDataSet1 грузоперевозкиDataSet1;
        private System.Windows.Forms.BindingSource грузыBindingSource;
        private ГрузоперевозкиDataSet1TableAdapters.ГрузыTableAdapter грузыTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименованиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn весDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn типгрузаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource маршрутыBindingSource;
        private ГрузоперевозкиDataSet1TableAdapters.МаршрутыTableAdapter маршрутыTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn начальнаяточкаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn конечнаяточкаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn длинамаршрутаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.BindingSource транспортныесредстваBindingSource;
        private ГрузоперевозкиDataSet1TableAdapters.Транспортные_средстваTableAdapter транспортные_средстваTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn маркаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn цветкорпусаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn грузоподъемностьDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn годвыпускаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn госНомерDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox_ColumnsPerevozki;
        private System.Windows.Forms.TextBox textBox_SearchPerevozka;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox_ColumnsGruz;
        private System.Windows.Forms.ComboBox comboBox_ColumnsTransport;
        private System.Windows.Forms.TextBox textBox_SearchGruz;
        private System.Windows.Forms.TextBox textBox_SearchTransport;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_ColumnsMarshrut;
        private System.Windows.Forms.TextBox textBox_SearchMarshrut;
        private System.Windows.Forms.Label label20;
    }
}