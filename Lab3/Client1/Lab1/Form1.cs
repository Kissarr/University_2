using Lab1;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab1;

public partial class Form1 : Form
{

    public List<string> questions = new List<string>();
    public List<Exam> ExamsTable = new List<Exam>();
    public string server = "127.0.0.1";
    public TcpClient tcpClient;
    public int port = 2001;
    public Form1()
    {
        InitializeComponent();
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        string json = File.ReadAllText(@"Exams.json");
        ExamsTable = JsonSerializer.Deserialize<List<Exam>?>(json);
    }



    private void Show_Click(object sender, EventArgs e)
    {
        string json = File.ReadAllText(@"Exams.json");
        ExamsTable = JsonSerializer.Deserialize<List<Exam>?>(json);
        Form2 settingsForm = new Form2(ExamsTable);
        settingsForm.Show();
    }

    private async void Add_Click(object sender, EventArgs e)
    {
        if (Exam.Text == "" || Year.Text == "" || Day.Text == "" || Mounth.Text == ""
            || Lastname.Text == "" || Firstname.Text == "" || Middlename.Text == "" || Spec.Text == ""
            || Number.Text == "" || Grade.Text == "" || questions == null)
        {
            MessageBox.Show("Форма не заполнена полностью!");
        }
        else
        {
            string json = File.ReadAllText(@"Exams.json");
            ExamsTable = JsonSerializer.Deserialize<List<Exam>?>(json);
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
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            json = JsonSerializer.Serialize<Exam>(exam, options);
            var endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            tcpClient = new TcpClient(endPoint);
            await tcpClient.ConnectAsync(server, 1234);
            NetworkStream stream = tcpClient.GetStream();
            var requestData = Encoding.UTF8.GetBytes(json);
            await stream.WriteAsync(requestData);
            var response = new List<byte>();
            int bytesRead = 10; // для считывания байтов из потока
                                // считываем данные до конечного символа
            while ((bytesRead = stream.ReadByte()) != '}')
            {
                // добавляем в буфер
                response.Add((byte)bytesRead);
            }
            var responsStr = Encoding.UTF8.GetString(response.ToArray());
            response.Clear();
            responsStr = responsStr + "}\n";
            MessageBox.Show(responsStr);
            await Task.Delay(2000);
            await stream.WriteAsync(Encoding.UTF8.GetBytes("END\n"));
            port += 2;
            Exam exam_get = new Exam();
            if (responsStr != "21}")
                exam_get = JsonSerializer.Deserialize<Exam>(responsStr);
            ExamsTable.Add(exam_get);
            json = JsonSerializer.Serialize<List<Exam>>(ExamsTable, options);
            var fileName = @"Exams.json";
            File.WriteAllText(fileName, json);
            questions = new List<string>();
            MessageBox.Show("Студент добавлен в список");
        }
    }

    private void Add_question_Click(object sender, EventArgs e)
    {
        if (Question.Text == "")
        {
            MessageBox.Show("Вопрос пуст!");
        }
        else
        {
            string question = Convert.ToString(Question.Text);
            questions.Add(question);
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
