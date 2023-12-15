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
    public partial class InstactionZapolnenieForm : Form
    {
        public InstactionZapolnenieForm()
        {
            InitializeComponent();

            this.MinimumSize = new Size(1100, 450);
            this.MaximumSize = new Size(1100, 450);
        }

        private void button_addGruz_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Поздравляем! Теперь вы знаете куда нажимать, что бы добавить запись в базу данных!\n" +
                        "Убедитесь, что все ячейки заполнены правильно!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Поздравляем! Теперь вы знаете куда нажимать, что бы очистить поля для заполнения!\n" +
                        "Убедитесь, что вы не очистите лишнего!");
        }
    }
}
