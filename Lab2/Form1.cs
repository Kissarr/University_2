using Lab1;
using System.Net.Sockets;

namespace laba2
{
    public partial class Form1 : Form
    {
        public List<Math_exam> List_Math_exam = new List<Math_exam>();
        public List<Prog_exam> List_Prog_exam = new List<Prog_exam>();
        public Thread math_thread;
        public Thread prog_thread;
        public string cur_thread;
        public int thread_pause = 100;
        public int N = 2;
        public bool isMathPause = false;
        public bool isProgPause = false;
        object locker1 = new();
        object locker2 = new();
        public DateTime dateTime;
        public Form1()
        {
            InitializeComponent();
        }
        public int getRandInRange(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }
        public void change_math_direction()
        {
            for (int i = 0; i < 5; i++)
            {
                List_Math_exam[i].change_direction(getRandInRange(1, 5));
            }
        }
        public void seeMath()
        {

            while (true)
            {
                lock (locker1)
                {
                    while (!isMathPause)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Label label1 = new Label(); //создаем новый label
                            label1.Location = new Point(List_Math_exam[i].x_cur, List_Math_exam[i].y_cur); //прописываем расположение)
                            label1.Text = List_Math_exam[i].letter_to_show.ToString(); //прописываем текст, который будет отображаться в label
                            Invoke(new Action(() =>
                            {
                                cur_thread = "Math";
                                Thread1TextBox.Text = cur_thread;
                                Controls.Add(label1);
                            }));
                            List_Math_exam[i].make_step();
                        }
                        Thread.Sleep(thread_pause);
                        DateTime localDate = DateTime.Now;
                        if ((localDate - dateTime).TotalSeconds >= N)
                        {
                            change_math_direction();
                        }
                        Invoke(new Action(() =>
                        {
                            foreach (Control c in Controls.OfType<Label>().ToList())
                            {
                                if (c.Text == List_Math_exam[0].letter_to_show.ToString())
                                    Controls.Remove(c);
                            }
                        }));
                        
                    }
                    Monitor.Wait(locker1);
                }

            }
        }
        public void seeProg()
        {
            while (true)
            {
                lock (locker2)
                {
                    while (!isProgPause)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Label label1 = new Label(); //создаем новый label
                            label1.Location = new Point(List_Prog_exam[i].x_cur, List_Prog_exam[i].y_cur); //прописываем расположение
                            label1.Text = List_Prog_exam[i].letter_to_show.ToString(); //прописываем текст, который будет отображаться в label
                            Invoke(new Action(() =>
                            {
                                cur_thread = "Prog";
                                Thread1TextBox.Text = cur_thread;
                                Controls.Add(label1);
                            }));
                            List_Prog_exam[i].make_step();
                        }
                        Thread.Sleep(thread_pause);
                        Invoke(new Action(() =>
                        {
                            foreach (Control c in Controls.OfType<Label>().ToList())
                            {
                                if (c.Text == List_Prog_exam[0].letter_to_show.ToString())
                                    Controls.Remove(c);
                            }
                        }));
                    }
                    Monitor.Wait(locker2);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int StartPosition_x = 20;
            int StartPosition_y = 120;
            for (int i = 0; i < 5; i++)
            {
                Math_exam math_Exam = new Math_exam(20, StartPosition_x, StartPosition_y, 20, 200, 200, 'm', 15, "down");
                Prog_exam prog_Exam = new Prog_exam(20, StartPosition_x, StartPosition_y + 120, 220, 200, 420, 'p', 15, "right");
                List_Math_exam.Add(math_Exam);
                List_Prog_exam.Add(prog_Exam);
                StartPosition_x += 15;
                StartPosition_y += 15;
            }
            change_math_direction();
            math_thread = new Thread(seeMath);
            math_thread.Start();
            dateTime = DateTime.Now;
            Thread1_pause.Enabled = false;
            Thread1_pause_Click(sender, e);
            prog_thread = new Thread(seeProg);
            prog_thread.Start();
            Thread2_pause_Click(sender, e);
        }

        private void Thread1_pause_Click(object sender, EventArgs e)//Math
        {
            isMathPause = !isMathPause;
            Thread1_pause.Enabled = false;
            Thread1_start.Enabled = true;
            if (Thread1_pause.Enabled == Thread2_pause.Enabled)
                Invoke(new Action(() => Thread1TextBox.Text = ""));
        }

        private void Thread2_pause_Click(object sender, EventArgs e)//Prog
        {
            isProgPause = !isProgPause;
            Thread2_pause.Enabled = false;
            Thread2_start.Enabled = true;
            if (Thread1_pause.Enabled == Thread2_pause.Enabled)
                Invoke(new Action(() => Thread1TextBox.Text = ""));
        }
        private void Thread1_start_Click(object sender, EventArgs e)//Math
        {
            lock (locker1)
            {
                isMathPause = !isMathPause;
                Monitor.Pulse(locker1);
                Thread1_pause.Enabled = true;
                Thread1_start.Enabled = false;
            }
        }
        private void Thread2_start_Click(object sender, EventArgs e)//Prog
        {
            lock(locker2)
            {
                isProgPause = !isProgPause;
                Monitor.Pulse(locker2);
                Thread2_pause.Enabled = true;
                Thread2_start.Enabled = false;
            }
        }
    }
}