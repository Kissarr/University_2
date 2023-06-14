namespace Lab1
{
    partial class Change
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
            Lastname = new TextBox();
            Firstname = new TextBox();
            Year = new TextBox();
            Day = new TextBox();
            Mounth = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Middlename = new TextBox();
            label4 = new Label();
            Exam = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            Spec = new TextBox();
            label8 = new Label();
            Number = new TextBox();
            label9 = new Label();
            Grade = new TextBox();
            label10 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // Lastname
            // 
            Lastname.Location = new Point(116, 117);
            Lastname.MaxLength = 50;
            Lastname.Name = "Lastname";
            Lastname.Size = new Size(667, 27);
            Lastname.TabIndex = 0;
            // 
            // Firstname
            // 
            Firstname.Location = new Point(116, 168);
            Firstname.MaxLength = 50;
            Firstname.Name = "Firstname";
            Firstname.Size = new Size(667, 27);
            Firstname.TabIndex = 1;
            // 
            // Year
            // 
            Year.Location = new Point(443, 54);
            Year.MaxLength = 4;
            Year.Name = "Year";
            Year.Size = new Size(77, 27);
            Year.TabIndex = 2;
            Year.KeyPress += Year_TextChanged;
            // 
            // Day
            // 
            Day.Location = new Point(551, 55);
            Day.MaxLength = 3;
            Day.Name = "Day";
            Day.Size = new Size(38, 27);
            Day.TabIndex = 3;
            Day.TextChanged += Day_TextChanged;
            Day.KeyPress += Day_TextChanged;
            // 
            // Mounth
            // 
            Mounth.Location = new Point(620, 55);
            Mounth.MaxLength = 3;
            Mounth.Name = "Mounth";
            Mounth.Size = new Size(38, 27);
            Mounth.TabIndex = 4;
            Mounth.TextChanged += Mounth_TextChanged;
            Mounth.KeyPress += Mouth_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 116);
            label1.Name = "label1";
            label1.Size = new Size(85, 25);
            label1.TabIndex = 5;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(16, 167);
            label2.Name = "label2";
            label2.Size = new Size(47, 25);
            label2.TabIndex = 6;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 212);
            label3.Name = "label3";
            label3.Size = new Size(88, 25);
            label3.TabIndex = 7;
            label3.Text = "Отчество";
            // 
            // Middlename
            // 
            Middlename.Location = new Point(116, 212);
            Middlename.MaxLength = 50;
            Middlename.Name = "Middlename";
            Middlename.Size = new Size(667, 27);
            Middlename.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(16, 56);
            label4.Name = "label4";
            label4.Size = new Size(81, 25);
            label4.TabIndex = 9;
            label4.Text = "Экзамен";
            // 
            // Exam
            // 
            Exam.Location = new Point(116, 56);
            Exam.MaxLength = 25;
            Exam.Name = "Exam";
            Exam.Size = new Size(253, 27);
            Exam.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(388, 55);
            label5.Name = "label5";
            label5.Size = new Size(49, 25);
            label5.TabIndex = 11;
            label5.Text = "Дата";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(526, 56);
            label6.Name = "label6";
            label6.Size = new Size(19, 25);
            label6.TabIndex = 12;
            label6.Text = "-";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(595, 58);
            label7.Name = "label7";
            label7.Size = new Size(19, 25);
            label7.TabIndex = 13;
            label7.Text = "-";
            // 
            // Spec
            // 
            Spec.Location = new Point(116, 260);
            Spec.MaxLength = 4;
            Spec.Name = "Spec";
            Spec.Size = new Size(77, 27);
            Spec.TabIndex = 14;
            Spec.KeyPress += Spec_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(199, 260);
            label8.Name = "label8";
            label8.Size = new Size(19, 25);
            label8.TabIndex = 15;
            label8.Text = "-";
            // 
            // Number
            // 
            Number.Location = new Point(224, 261);
            Number.MaxLength = 3;
            Number.Name = "Number";
            Number.Size = new Size(38, 27);
            Number.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(16, 260);
            label9.Name = "label9";
            label9.Size = new Size(69, 25);
            label9.TabIndex = 17;
            label9.Text = "Группа";
            // 
            // Grade
            // 
            Grade.Location = new Point(388, 262);
            Grade.MaxLength = 1;
            Grade.Name = "Grade";
            Grade.Size = new Size(63, 27);
            Grade.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(295, 261);
            label10.Name = "label10";
            label10.Size = new Size(74, 25);
            label10.TabIndex = 19;
            label10.Text = "Оценка";
            // 
            // button1
            // 
            button1.Location = new Point(637, 253);
            button1.Name = "button1";
            button1.Size = new Size(146, 40);
            button1.TabIndex = 25;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Change
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 306);
            Controls.Add(button1);
            Controls.Add(label10);
            Controls.Add(Grade);
            Controls.Add(label9);
            Controls.Add(Number);
            Controls.Add(label8);
            Controls.Add(Spec);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(Exam);
            Controls.Add(label4);
            Controls.Add(Middlename);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Mounth);
            Controls.Add(Day);
            Controls.Add(Year);
            Controls.Add(Firstname);
            Controls.Add(Lastname);
            Name = "Change";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private void Mounth_KeyPress(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Day_KeyPress(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Spec_KeyPress(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox Lastname;
        private TextBox Firstname;
        private TextBox Year;
        private TextBox Day;
        private TextBox Mounth;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox Middlename;
        private Label label4;
        private TextBox Exam;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox Spec;
        private Label label8;
        private TextBox Number;
        private Label label9;
        private TextBox Grade;
        private Label label10;
        private Button button1;


    }
}