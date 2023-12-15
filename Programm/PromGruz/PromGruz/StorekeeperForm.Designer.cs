namespace PromGruz
{
    partial class StorekeeperForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorekeeperForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.анализВесаГрузовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.инструкцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заполнениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.созданиеОтчётовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.номерDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименованиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.весDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.типгрузаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.грузыBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.грузоперевозкиDataSet1 = new PromGruz.ГрузоперевозкиDataSet1();
            this.грузыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.грузоперевозкиDataSet = new PromGruz.ГрузоперевозкиDataSet();
            this.грузыTableAdapter = new PromGruz.ГрузоперевозкиDataSetTableAdapters.ГрузыTableAdapter();
            this.грузыTableAdapter1 = new PromGruz.ГрузоперевозкиDataSet1TableAdapters.ГрузыTableAdapter();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_addGruz = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_gruzType = new System.Windows.Forms.TextBox();
            this.textBox_gruzVes = new System.Windows.Forms.TextBox();
            this.textBox_gruzName = new System.Windows.Forms.TextBox();
            this.textBox_gruzNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.comboBox_ColumnsGruz = new System.Windows.Forms.ComboBox();
            this.textBox_SearchGruz = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузыBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузоперевозкиDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузоперевозкиDataSet)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчётыToolStripMenuItem,
            this.инструкцияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(493, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.анализВесаГрузовToolStripMenuItem});
            this.отчётыToolStripMenuItem.Image = global::PromGruz.Properties.Resources.otchetsaicon;
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // анализВесаГрузовToolStripMenuItem
            // 
            this.анализВесаГрузовToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.анализВесаГрузовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordToolStripMenuItem1});
            this.анализВесаГрузовToolStripMenuItem.Name = "анализВесаГрузовToolStripMenuItem";
            this.анализВесаГрузовToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.анализВесаГрузовToolStripMenuItem.Text = "Анализ Веса грузов";
            // 
            // wordToolStripMenuItem1
            // 
            this.wordToolStripMenuItem1.BackColor = System.Drawing.Color.Lime;
            this.wordToolStripMenuItem1.Name = "wordToolStripMenuItem1";
            this.wordToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.wordToolStripMenuItem1.Text = "Word";
            this.wordToolStripMenuItem1.Click += new System.EventHandler(this.wordToolStripMenuItem1_Click);
            // 
            // инструкцияToolStripMenuItem
            // 
            this.инструкцияToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.инструкцияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заполнениеToolStripMenuItem,
            this.созданиеОтчётовToolStripMenuItem,
            this.поискToolStripMenuItem});
            this.инструкцияToolStripMenuItem.Image = global::PromGruz.Properties.Resources.dada;
            this.инструкцияToolStripMenuItem.Name = "инструкцияToolStripMenuItem";
            this.инструкцияToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.инструкцияToolStripMenuItem.Text = "Инструкция";
            // 
            // заполнениеToolStripMenuItem
            // 
            this.заполнениеToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.заполнениеToolStripMenuItem.Name = "заполнениеToolStripMenuItem";
            this.заполнениеToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.заполнениеToolStripMenuItem.Text = "Заполнение";
            this.заполнениеToolStripMenuItem.Click += new System.EventHandler(this.заполнениеToolStripMenuItem_Click);
            // 
            // созданиеОтчётовToolStripMenuItem
            // 
            this.созданиеОтчётовToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.созданиеОтчётовToolStripMenuItem.Name = "созданиеОтчётовToolStripMenuItem";
            this.созданиеОтчётовToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.созданиеОтчётовToolStripMenuItem.Text = "Создание отчётов";
            this.созданиеОтчётовToolStripMenuItem.Click += new System.EventHandler(this.созданиеОтчётовToolStripMenuItem_Click);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
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
            this.dataGridView1.DataSource = this.грузыBindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(493, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(691, 611);
            this.dataGridView1.TabIndex = 1;
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
            // грузыBindingSource1
            // 
            this.грузыBindingSource1.DataMember = "Грузы";
            this.грузыBindingSource1.DataSource = this.грузоперевозкиDataSet1;
            // 
            // грузоперевозкиDataSet1
            // 
            this.грузоперевозкиDataSet1.DataSetName = "ГрузоперевозкиDataSet1";
            this.грузоперевозкиDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // грузыBindingSource
            // 
            this.грузыBindingSource.DataMember = "Грузы";
            this.грузыBindingSource.DataSource = this.грузоперевозкиDataSet;
            // 
            // грузоперевозкиDataSet
            // 
            this.грузоперевозкиDataSet.DataSetName = "ГрузоперевозкиDataSet";
            this.грузоперевозкиDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // грузыTableAdapter
            // 
            this.грузыTableAdapter.ClearBeforeFill = true;
            // 
            // грузыTableAdapter1
            // 
            this.грузыTableAdapter1.ClearBeforeFill = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::PromGruz.Properties.Resources.fonAunt1;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.comboBox_ColumnsGruz);
            this.tabPage1.Controls.Add(this.textBox_SearchGruz);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.button_addGruz);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox_gruzType);
            this.tabPage1.Controls.Add(this.textBox_gruzVes);
            this.tabPage1.Controls.Add(this.textBox_gruzName);
            this.tabPage1.Controls.Add(this.textBox_gruzNum);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(483, 561);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Управление";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Gray;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 21.75F);
            this.button9.ForeColor = System.Drawing.Color.Red;
            this.button9.Location = new System.Drawing.Point(8, 495);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(469, 60);
            this.button9.TabIndex = 88;
            this.button9.Text = "Сбросить сортировку";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(4, 304);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(133, 39);
            this.label26.TabIndex = 81;
            this.label26.Text = "Поиск:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 42);
            this.label1.TabIndex = 24;
            this.label1.Text = "Груз:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(276, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 45);
            this.button2.TabIndex = 34;
            this.button2.Text = "Очистить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 32);
            this.label2.TabIndex = 25;
            this.label2.Text = "Номер груза:";
            // 
            // button_addGruz
            // 
            this.button_addGruz.BackColor = System.Drawing.Color.Gray;
            this.button_addGruz.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button_addGruz.ForeColor = System.Drawing.Color.Lime;
            this.button_addGruz.Location = new System.Drawing.Point(4, 233);
            this.button_addGruz.Name = "button_addGruz";
            this.button_addGruz.Size = new System.Drawing.Size(200, 45);
            this.button_addGruz.TabIndex = 33;
            this.button_addGruz.Text = "Добавить";
            this.button_addGruz.UseVisualStyleBackColor = false;
            this.button_addGruz.Click += new System.EventHandler(this.button_addGruz_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 32);
            this.label3.TabIndex = 26;
            this.label3.Text = "Наименование:";
            // 
            // textBox_gruzType
            // 
            this.textBox_gruzType.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.textBox_gruzType.Location = new System.Drawing.Point(195, 192);
            this.textBox_gruzType.Name = "textBox_gruzType";
            this.textBox_gruzType.Size = new System.Drawing.Size(280, 35);
            this.textBox_gruzType.TabIndex = 32;
            // 
            // textBox_gruzVes
            // 
            this.textBox_gruzVes.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.textBox_gruzVes.Location = new System.Drawing.Point(195, 151);
            this.textBox_gruzVes.Name = "textBox_gruzVes";
            this.textBox_gruzVes.Size = new System.Drawing.Size(280, 35);
            this.textBox_gruzVes.TabIndex = 31;
            // 
            // textBox_gruzName
            // 
            this.textBox_gruzName.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.textBox_gruzName.Location = new System.Drawing.Point(195, 110);
            this.textBox_gruzName.Name = "textBox_gruzName";
            this.textBox_gruzName.Size = new System.Drawing.Size(280, 35);
            this.textBox_gruzName.TabIndex = 30;
            // 
            // textBox_gruzNum
            // 
            this.textBox_gruzNum.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.textBox_gruzNum.Location = new System.Drawing.Point(195, 69);
            this.textBox_gruzNum.Name = "textBox_gruzNum";
            this.textBox_gruzNum.Size = new System.Drawing.Size(280, 35);
            this.textBox_gruzNum.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(6, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 32);
            this.label4.TabIndex = 27;
            this.label4.Text = "Вес груза(кг):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(6, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 32);
            this.label5.TabIndex = 28;
            this.label5.Text = "Тип груза:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(491, 587);
            this.tabControl1.TabIndex = 35;
            // 
            // comboBox_ColumnsGruz
            // 
            this.comboBox_ColumnsGruz.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.comboBox_ColumnsGruz.FormattingEnabled = true;
            this.comboBox_ColumnsGruz.Location = new System.Drawing.Point(8, 346);
            this.comboBox_ColumnsGruz.Name = "comboBox_ColumnsGruz";
            this.comboBox_ColumnsGruz.Size = new System.Drawing.Size(181, 31);
            this.comboBox_ColumnsGruz.TabIndex = 91;
            // 
            // textBox_SearchGruz
            // 
            this.textBox_SearchGruz.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_SearchGruz.Location = new System.Drawing.Point(195, 345);
            this.textBox_SearchGruz.Name = "textBox_SearchGruz";
            this.textBox_SearchGruz.Size = new System.Drawing.Size(280, 32);
            this.textBox_SearchGruz.TabIndex = 90;
            this.textBox_SearchGruz.TextChanged += new System.EventHandler(this.textBox_SearchGruz_TextChanged);
            // 
            // StorekeeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PromGruz.Properties.Resources.fonAunt1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "StorekeeperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кладовщик";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StorekeeperForm_FormClosed);
            this.Load += new System.EventHandler(this.StorekeeperForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузыBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузоперевозкиDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.грузоперевозкиDataSet)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инструкцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заполнениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem созданиеОтчётовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem анализВесаГрузовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordToolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ГрузоперевозкиDataSet грузоперевозкиDataSet;
        private System.Windows.Forms.BindingSource грузыBindingSource;
        private ГрузоперевозкиDataSetTableAdapters.ГрузыTableAdapter грузыTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименованиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn весDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn типгрузаDataGridViewTextBoxColumn;
        private ГрузоперевозкиDataSet1 грузоперевозкиDataSet1;
        private System.Windows.Forms.BindingSource грузыBindingSource1;
        private ГрузоперевозкиDataSet1TableAdapters.ГрузыTableAdapter грузыTableAdapter1;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_addGruz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_gruzType;
        private System.Windows.Forms.TextBox textBox_gruzVes;
        private System.Windows.Forms.TextBox textBox_gruzName;
        private System.Windows.Forms.TextBox textBox_gruzNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox comboBox_ColumnsGruz;
        private System.Windows.Forms.TextBox textBox_SearchGruz;
    }
}