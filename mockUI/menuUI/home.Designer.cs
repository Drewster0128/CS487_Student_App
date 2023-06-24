
namespace menuUI
{
    partial class home
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
            this.Notes = new System.Windows.Forms.Button();
            this.Calendar = new System.Windows.Forms.Button();
            this.Marketplace = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Notes
            // 
            this.Notes.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notes.Location = new System.Drawing.Point(94, 271);
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(200, 100);
            this.Notes.TabIndex = 0;
            this.Notes.Text = "Notes";
            this.Notes.UseVisualStyleBackColor = true;
            this.Notes.Click += new System.EventHandler(this.button1_Click);
            // 
            // Calendar
            // 
            this.Calendar.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendar.Location = new System.Drawing.Point(506, 271);
            this.Calendar.Name = "Calendar";
            this.Calendar.Size = new System.Drawing.Size(200, 100);
            this.Calendar.TabIndex = 1;
            this.Calendar.Text = "Calendar";
            this.Calendar.UseVisualStyleBackColor = true;
            this.Calendar.Click += new System.EventHandler(this.Calendar_Click);
            // 
            // Marketplace
            // 
            this.Marketplace.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Marketplace.Location = new System.Drawing.Point(506, 136);
            this.Marketplace.Name = "Marketplace";
            this.Marketplace.Size = new System.Drawing.Size(200, 100);
            this.Marketplace.TabIndex = 2;
            this.Marketplace.Text = "Marketplace";
            this.Marketplace.UseVisualStyleBackColor = true;
            this.Marketplace.Click += new System.EventHandler(this.Marketplace_Click);
            // 
            // Timer
            // 
            this.Timer.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer.Location = new System.Drawing.Point(94, 136);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(200, 100);
            this.Timer.TabIndex = 3;
            this.Timer.Text = "Timer";
            this.Timer.UseVisualStyleBackColor = true;
            this.Timer.Click += new System.EventHandler(this.Timer_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(300, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 44);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Student App";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(626, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Quit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.Marketplace);
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.Notes);
            this.Name = "home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Notes;
        private System.Windows.Forms.Button Calendar;
        private System.Windows.Forms.Button Marketplace;
        private System.Windows.Forms.Button Timer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

