using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Personeel dep;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dep = new Personeel(listBox1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                int salary;
                double coef;
                int p;
                bool check1 = int.TryParse(textBox2.Text, out salary);
                bool check2 = double.TryParse(textBox3.Text, out coef);
                bool check3 = int.TryParse(textBox4.Text, out p);

                if (check1 == false || check2 == false || check3 == false)
                {
                    MessageBox.Show("Информация не была добавлена. Проверьте введенную информацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dep.Name = textBox1.Text;
                    dep.BaseSalary = salary;
                    dep.Coefficient = coef;
                    dep.P = p;

                    dep.AddDepartment();
                    listBox1.Items.Clear();
                    dep.FillList();

                    MessageBox.Show("Информация была успешно добавлена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }        
            }

            else  MessageBox.Show("Информация не была добавлена. Проверьте введенную информацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);               
                dep.RemoveDepartment(textBox1.Text);
               

                MessageBox.Show("Информация была успешно удалена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Пожалуйста введите название отдела для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
