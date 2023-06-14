namespace Lab1
{
    partial class Form2
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
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ФИО = new DataGridViewTextBoxColumn();
            Group = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Exam = new DataGridViewTextBoxColumn();
            Grade = new DataGridViewTextBoxColumn();
            Qustions = new DataGridViewTextBoxColumn();
            Change = new Button();
            IDForChange = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AccessibleRole = AccessibleRole.None;
            dataGridView1.BackgroundColor = SystemColors.ControlLight;
            dataGridView1.CausesValidation = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, ФИО, Group, Date, Exam, Grade, Qustions });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.Size = new Size(1156, 451);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 40;
            // 
            // ФИО
            // 
            ФИО.HeaderText = "Name";
            ФИО.MinimumWidth = 6;
            ФИО.Name = "ФИО";
            ФИО.ReadOnly = true;
            ФИО.Width = 200;
            // 
            // Group
            // 
            Group.HeaderText = "Group";
            Group.MinimumWidth = 6;
            Group.Name = "Group";
            Group.ReadOnly = true;
            Group.Width = 70;
            // 
            // Date
            // 
            Date.HeaderText = "Date";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Width = 125;
            // 
            // Exam
            // 
            Exam.HeaderText = "Exam";
            Exam.MinimumWidth = 6;
            Exam.Name = "Exam";
            Exam.ReadOnly = true;
            Exam.Width = 200;
            // 
            // Grade
            // 
            Grade.HeaderText = "Grade";
            Grade.MinimumWidth = 6;
            Grade.Name = "Grade";
            Grade.ReadOnly = true;
            Grade.Width = 125;
            // 
            // Qustions
            // 
            Qustions.HeaderText = "Qustions";
            Qustions.MinimumWidth = 6;
            Qustions.Name = "Qustions";
            Qustions.ReadOnly = true;
            Qustions.Width = 400;
            // 
            // Change
            // 
            Change.Location = new Point(1009, 475);
            Change.Name = "Change";
            Change.Size = new Size(159, 34);
            Change.TabIndex = 1;
            Change.Text = "Изменить";
            Change.UseVisualStyleBackColor = true;
            Change.Click += Change_Click;
            // 
            // IDForChange
            // 
            IDForChange.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            IDForChange.Location = new Point(812, 477);
            IDForChange.Name = "IDForChange";
            IDForChange.Size = new Size(182, 34);
            IDForChange.TabIndex = 2;
            IDForChange.TabStop = false;
            IDForChange.KeyPress += IDForChange_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(601, 477);
            label1.Name = "label1";
            label1.Size = new Size(205, 31);
            label1.TabIndex = 3;
            label1.Text = "ID для изменения ";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 521);
            Controls.Add(label1);
            Controls.Add(IDForChange);
            Controls.Add(Change);
            Controls.Add(dataGridView1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ФИО;
        private DataGridViewTextBoxColumn Group;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Exam;
        private DataGridViewTextBoxColumn Grade;
        private DataGridViewTextBoxColumn Qustions;
        private Button Change;
        private TextBox IDForChange;
        private Label label1;
    }
}