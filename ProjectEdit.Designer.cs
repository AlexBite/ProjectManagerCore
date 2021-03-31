
namespace ProjectManagerCore
{
    partial class ProjectEdit
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.projectEndDateDTP = new System.Windows.Forms.DateTimePicker();
            this.projectStartDateDTP = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(338, 33);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(118, 253);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(338, 33);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.Click += new System.EventHandler(this.comboBox2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(374, 298);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 50);
            this.label9.TabIndex = 47;
            this.label9.Text = "Выберите дату\r\nокончания проекта";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(174, 202);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(211, 25);
            this.label12.TabIndex = 46;
            this.label12.Text = "Выберите руководителя";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(44, 298);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(139, 50);
            this.label14.TabIndex = 45;
            this.label14.Text = "Выберите дату\r\nначала проекта";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(174, 19);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(242, 25);
            this.label15.TabIndex = 44;
            this.label15.Text = "Выберите название проекта";
            // 
            // projectEndDateDTP
            // 
            this.projectEndDateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.projectEndDateDTP.Location = new System.Drawing.Point(374, 391);
            this.projectEndDateDTP.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.projectEndDateDTP.Name = "projectEndDateDTP";
            this.projectEndDateDTP.Size = new System.Drawing.Size(153, 31);
            this.projectEndDateDTP.TabIndex = 49;
            // 
            // projectStartDateDTP
            // 
            this.projectStartDateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.projectStartDateDTP.Location = new System.Drawing.Point(44, 391);
            this.projectStartDateDTP.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.projectStartDateDTP.Name = "projectStartDateDTP";
            this.projectStartDateDTP.Size = new System.Drawing.Size(153, 31);
            this.projectStartDateDTP.TabIndex = 48;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 70);
            this.button1.TabIndex = 50;
            this.button1.Text = "ок";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 50);
            this.label1.TabIndex = 51;
            this.label1.Text = "Введите название проекта\r\n      (если необходимо)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 159);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 31);
            this.textBox1.TabIndex = 52;
            // 
            // ProjectEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(631, 496);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.projectEndDateDTP);
            this.Controls.Add(this.projectStartDateDTP);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "ProjectEdit";
            this.Text = "ProjectEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker projectEndDateDTP;
        private System.Windows.Forms.DateTimePicker projectStartDateDTP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}