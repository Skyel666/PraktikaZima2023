using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromGruz
{
    public partial class InstractionAdminForm : Form
    {
        public InstractionAdminForm()
        {
            InitializeComponent();

            this.MinimumSize = new Size(1100, 450);
            this.MaximumSize = new Size(1100, 450);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlScript = @"
            -- Выполнять запросы по порядку!

            -- Создание базы данных
            CREATE DATABASE Грузоперевозки;

            -- Использование созданной базы данных
            USE Грузоперевозки;

            -- Создание таблицы 'Транспортные_средства'
            CREATE TABLE Транспортные_средства (
                Номер INT PRIMARY KEY,
                Марка NVARCHAR(255),
                Цвет_корпуса NVARCHAR(75),
                Грузоподъемность DECIMAL(10,2),
                Год_выпуска INT,
                Гос_Номер NVARCHAR(10));
            
            -- Создание таблицы 'Грузы'
            CREATE TABLE Грузы (
                Номер INT PRIMARY KEY,
                Наименование NVARCHAR(255),
                Вес DECIMAL(10,2),
                Тип_груза NVARCHAR(100),);
            
            -- Создание таблицы 'Маршруты'
            CREATE TABLE Маршруты (
                Номер INT PRIMARY KEY,
                Начальная_точка NVARCHAR(255),
                Конечная_точка NVARCHAR(255),
                Длина_маршрута DECIMAL(10,2));
            
            -- Создание таблицы 'Водители'
            CREATE TABLE Водители (
                Номер INT PRIMARY KEY,
                ФИО NVARCHAR(255),
                Номер_телефона NVARCHAR(20),
                Дата_рождения DATE,
                Стаж_вождения INT,
                ИНН NVARCHAR(12),
            	Логин_водителя NVARCHAR(50),
            	Пароль_водителя NVARCHAR(50));
            
            -- Создание таблицы 'Перевозки'
            CREATE TABLE Перевозки (
                Номер INT PRIMARY KEY,
                Заказчик NVARCHAR(255),
                Номер_транспортного_средства INT,
                Номер_груза INT,
                Номер_маршрута INT,
                Номер_водителя INT,
                Дата_отправки DATE,
                Ожидаемая_дата_прибытия DATE,
                Статус_перевозки NVARCHAR(50),
                Дата_прибытия DATE,
                FOREIGN KEY (Номер_транспортного_средства) REFERENCES Транспортные_средства (Номер),
                FOREIGN KEY (Номер_груза) REFERENCES Грузы (Номер),
                FOREIGN KEY (Номер_маршрута) REFERENCES Маршруты (Номер),
                FOREIGN KEY (Номер_водителя) REFERENCES Водители (Номер));
            
            -- Создание таблицы 'Роли'
            CREATE TABLE Роли (
                Номер INT PRIMARY KEY,
                Роль NVARCHAR(100));
            
            CREATE TABLE Пользователи (
                Номер INT PRIMARY KEY,
                Логин NVARCHAR(50),
                Пароль NVARCHAR(50),
                Номер_Роли INT,
                FOREIGN KEY (Номер_Роли) REFERENCES Роли (Номер)); ";

            // Копирование текста в буфер обмена
             Clipboard.SetText(sqlScript);

            // Вывод сообщения об успешном копировании
            MessageBox.Show("SQL-скрипт скопирован в буфер обмена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
