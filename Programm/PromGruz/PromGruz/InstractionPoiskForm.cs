﻿using System;
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
    public partial class InstractionPoiskForm : Form
    {
        public InstractionPoiskForm()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1100, 450);
            this.MaximumSize = new Size(1100, 450);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Поздравляем! Теперь вы знаете куда нажимать, что бы вернуть изначальный вид таблице!\n" +
                      "Убедитесь, что вам уже не нужна сортировка!");
        }
    }
}
