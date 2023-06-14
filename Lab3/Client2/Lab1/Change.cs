using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Change : Form
    {
        List<Exam>? RestorCopy = new List<Exam>();
        int index = 0;
        List<string> questions = new List<string>();
        public Change(Exam one_exam, int i)
        {
            index = i;
            InitializeComponent();
            Exam.Text = one_exam.Trial_name;
            Year.Text = Convert.ToString(one_exam.Year);
            Day.Text = Convert.ToString(one_exam.Day);
            Mounth.Text = Convert.ToString(one_exam.Mounth);
            Lastname.Text = one_exam.Lastname;
            Firstname.Text = one_exam.Firstname;
            Middlename.Text = one_exam.Middlename;
            Spec.Text = one_exam.Speciality;
            Number.Text = Convert.ToString(one_exam.Number);
            Grade.Text = Convert.ToString(one_exam.Grade);
            questions = one_exam.Questions;
            string json = File.ReadAllText(@"Exams.json");
            RestorCopy = JsonSerializer.Deserialize<List<Exam>?>(json);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Exam.Text == "" || Year.Text == "" || Day.Text == "" || Mounth.Text == ""
               || Lastname.Text == "" || Firstname.Text == "" || Middlename.Text == "" || Spec.Text == ""
               || Number.Text == "" || Grade.Text == "")
            {
                MessageBox.Show("Форма не заполнена полностью!");
            }
            else
            {
                Exam exam = new Exam
                {
                    Trial_name = Exam.Text,
                    Grade = Convert.ToInt16(Grade.Text),
                    Year = Convert.ToInt32(Year.Text),
                    Day = Convert.ToInt32(Day.Text),
                    Mounth = Convert.ToInt32(Mounth.Text),
                    Firstname = Firstname.Text,
                    Middlename = Middlename.Text,
                    Lastname = Lastname.Text,
                    Speciality = Spec.Text,
                    Number = Convert.ToInt32(Number.Text),
                    Questions = questions
                };
                RestorCopy[index] = exam;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                string json = JsonSerializer.Serialize<List<Exam>>(RestorCopy, options);
                var fileName = @"Exams.json";
                File.WriteAllText(fileName, json);
            }
        }

        private void Year_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void Day_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void Mouth_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void Mounth_TextChanged(object sender, EventArgs e)
        {
            int box_int = 0;
            Int32.TryParse(Mounth.Text, out box_int);
            if (box_int > 12) { Mounth.Text = "12"; }
        }

        private void Day_TextChanged(object sender, EventArgs e)
        {
            int box_int = 0;
            Int32.TryParse(Day.Text, out box_int);
            if (box_int > 31) { Day.Text = "30"; }
        }

        private void Grade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '1' && e.KeyChar <= '5' || e.KeyChar == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
