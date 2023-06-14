namespace laba2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Thread1_pause = new System.Windows.Forms.Button();
            this.Thread2_pause = new System.Windows.Forms.Button();
            this.Thread1TextBox = new System.Windows.Forms.TextBox();
            this.Thread1_start = new System.Windows.Forms.Button();
            this.Thread2_start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Thread1_pause
            // 
            this.Thread1_pause.Location = new System.Drawing.Point(451, 225);
            this.Thread1_pause.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Thread1_pause.Name = "Thread1_pause";
            this.Thread1_pause.Size = new System.Drawing.Size(107, 52);
            this.Thread1_pause.TabIndex = 0;
            this.Thread1_pause.Text = "Thread1 pause";
            this.Thread1_pause.UseVisualStyleBackColor = true;
            this.Thread1_pause.Click += new System.EventHandler(this.Thread1_pause_Click);
            // 
            // Thread2_pause
            // 
            this.Thread2_pause.Location = new System.Drawing.Point(594, 225);
            this.Thread2_pause.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Thread2_pause.Name = "Thread2_pause";
            this.Thread2_pause.Size = new System.Drawing.Size(107, 52);
            this.Thread2_pause.TabIndex = 1;
            this.Thread2_pause.Text = "Thread2 pause";
            this.Thread2_pause.UseVisualStyleBackColor = true;
            this.Thread2_pause.Click += new System.EventHandler(this.Thread2_pause_Click);
            // 
            // Thread1TextBox
            // 
            this.Thread1TextBox.Location = new System.Drawing.Point(529, 66);
            this.Thread1TextBox.Multiline = true;
            this.Thread1TextBox.Name = "Thread1TextBox";
            this.Thread1TextBox.Size = new System.Drawing.Size(96, 39);
            this.Thread1TextBox.TabIndex = 2;
            // 
            // Thread1_start
            // 
            this.Thread1_start.Location = new System.Drawing.Point(451, 139);
            this.Thread1_start.Name = "Thread1_start";
            this.Thread1_start.Size = new System.Drawing.Size(107, 52);
            this.Thread1_start.TabIndex = 3;
            this.Thread1_start.Text = "Tread1 start";
            this.Thread1_start.UseVisualStyleBackColor = true;
            this.Thread1_start.Click += new System.EventHandler(this.Thread1_start_Click);
            // 
            // Thread2_start
            // 
            this.Thread2_start.Location = new System.Drawing.Point(594, 139);
            this.Thread2_start.Name = "Thread2_start";
            this.Thread2_start.Size = new System.Drawing.Size(107, 52);
            this.Thread2_start.TabIndex = 4;
            this.Thread2_start.Text = "Tread2 start";
            this.Thread2_start.UseVisualStyleBackColor = true;
            this.Thread2_start.Click += new System.EventHandler(this.Thread2_start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.Thread2_start);
            this.Controls.Add(this.Thread1_start);
            this.Controls.Add(this.Thread1TextBox);
            this.Controls.Add(this.Thread2_pause);
            this.Controls.Add(this.Thread1_pause);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Thread1_pause;
        private Button Thread2_pause;
        private Button button1;
        private Button Thread2_button;
        private TextBox Thread1TextBox;
        private Button Thread1_start;
        private Button Thread2_start;
    }
}