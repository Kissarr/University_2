using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1
{
    public partial class Form2 : Form
    {
        List<Exam> Exams = new List<Exam>();
        public Form2(List<Exam> ExamsTable)
        {
            InitializeComponent();
            int i = 1;
            Exams = ExamsTable;
            foreach (Exam exam in ExamsTable)
            {
                DataGridViewCell id = new DataGridViewTextBoxCell();
                DataGridViewCell name = new DataGridViewTextBoxCell();
                DataGridViewCell group = new DataGridViewTextBoxCell();
                DataGridViewCell date = new DataGridViewTextBoxCell();
                DataGridViewCell exam_name = new DataGridViewTextBoxCell();
                DataGridViewCell grade = new DataGridViewTextBoxCell();
                DataGridViewCell questions = new DataGridViewTextBoxCell();
                id.Value = i;
                name.Value = exam.Lastname + " " + exam.Firstname + " " + exam.Middlename;
                group.Value = exam.Speciality + "-" + Convert.ToString(exam.Number);
                date.Value = exam.Year + "-" + exam.Day + "-" + exam.Mounth;
                exam_name.Value = exam.Trial_name;
                grade.Value = Convert.ToString(exam.Grade);
                string[] s = exam.Questions.ToArray();
                string result = "";
                foreach (string str in exam.Questions.ToArray())
                    result = result + str + '\n';
                questions.Value = result;
                DataGridViewRow row = new DataGridViewRow();
                
                row.Cells.AddRange(id, name, group, date, exam_name, grade, questions);
                dataGridView1.Rows.Add(row);
                i++;
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void IDForChange_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void Change_Click(object sender, EventArgs e)
        {
            if (IDForChange.Text != "")
            {
                int i = Convert.ToInt32(IDForChange.Text);
                Change FormChange = new Change(Exams[i-1], i-1);

                FormChange.Show();
            }
            else
                MessageBox.Show("Введите ID!");
        }
    }
}
