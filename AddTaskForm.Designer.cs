namespace WorkingTimeTracker
{
    partial class AddTaskForm
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
            this.panelTask = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.PrOnTaskcombo = new System.Windows.Forms.ComboBox();
            this.PersTaskButt = new System.Windows.Forms.Button();
            this.DeleteTaskButt = new System.Windows.Forms.Button();
            this.SaveTaskButt = new System.Windows.Forms.Button();
            this.TaskNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TaskReviewBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TaskAddButt = new System.Windows.Forms.Button();
            this.EndTaskDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartTaskDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panelTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTask
            // 
            this.panelTask.BackColor = System.Drawing.Color.Aquamarine;
            this.panelTask.Controls.Add(this.dataGridView2);
            this.panelTask.Controls.Add(this.PrOnTaskcombo);
            this.panelTask.Controls.Add(this.PersTaskButt);
            this.panelTask.Controls.Add(this.DeleteTaskButt);
            this.panelTask.Controls.Add(this.SaveTaskButt);
            this.panelTask.Controls.Add(this.TaskNameBox);
            this.panelTask.Controls.Add(this.label2);
            this.panelTask.Controls.Add(this.TaskReviewBox);
            this.panelTask.Controls.Add(this.label1);
            this.panelTask.Controls.Add(this.TaskAddButt);
            this.panelTask.Controls.Add(this.EndTaskDateTimePicker);
            this.panelTask.Controls.Add(this.StartTaskDateTimePicker);
            this.panelTask.Controls.Add(this.label17);
            this.panelTask.Controls.Add(this.label16);
            this.panelTask.Controls.Add(this.label15);
            this.panelTask.Location = new System.Drawing.Point(0, 2);
            this.panelTask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTask.Name = "panelTask";
            this.panelTask.Size = new System.Drawing.Size(1269, 670);
            this.panelTask.TabIndex = 8;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Turquoise;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(618, 22);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(593, 600);
            this.dataGridView2.TabIndex = 20;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // PrOnTaskcombo
            // 
            this.PrOnTaskcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrOnTaskcombo.FormattingEnabled = true;
            this.PrOnTaskcombo.Location = new System.Drawing.Point(260, 39);
            this.PrOnTaskcombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrOnTaskcombo.Name = "PrOnTaskcombo";
            this.PrOnTaskcombo.Size = new System.Drawing.Size(240, 33);
            this.PrOnTaskcombo.TabIndex = 51;
            this.PrOnTaskcombo.Click += new System.EventHandler(this.PrOnTaskcombo_Click);
            // 
            // PersTaskButt
            // 
            this.PersTaskButt.Location = new System.Drawing.Point(234, 561);
            this.PersTaskButt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PersTaskButt.Name = "PersTaskButt";
            this.PersTaskButt.Size = new System.Drawing.Size(171, 61);
            this.PersTaskButt.TabIndex = 27;
            this.PersTaskButt.Text = "Сотрудники задачи";
            this.PersTaskButt.UseVisualStyleBackColor = true;
            this.PersTaskButt.Click += new System.EventHandler(this.PersTaskButt_Click);
            // 
            // DeleteTaskButt
            // 
            this.DeleteTaskButt.Location = new System.Drawing.Point(440, 435);
            this.DeleteTaskButt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteTaskButt.Name = "DeleteTaskButt";
            this.DeleteTaskButt.Size = new System.Drawing.Size(171, 61);
            this.DeleteTaskButt.TabIndex = 26;
            this.DeleteTaskButt.Text = "Удалить задачу";
            this.DeleteTaskButt.UseVisualStyleBackColor = true;
            this.DeleteTaskButt.Click += new System.EventHandler(this.DeleteTaskButt_Click);
            // 
            // SaveTaskButt
            // 
            this.SaveTaskButt.Location = new System.Drawing.Point(36, 435);
            this.SaveTaskButt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveTaskButt.Name = "SaveTaskButt";
            this.SaveTaskButt.Size = new System.Drawing.Size(171, 61);
            this.SaveTaskButt.TabIndex = 25;
            this.SaveTaskButt.Text = "Сохранить изменения";
            this.SaveTaskButt.UseVisualStyleBackColor = true;
            this.SaveTaskButt.Click += new System.EventHandler(this.SaveTaskButt_Click);
            // 
            // TaskNameBox
            // 
            this.TaskNameBox.Location = new System.Drawing.Point(260, 105);
            this.TaskNameBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TaskNameBox.Name = "TaskNameBox";
            this.TaskNameBox.Size = new System.Drawing.Size(237, 31);
            this.TaskNameBox.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Название задачи";
            // 
            // TaskReviewBox
            // 
            this.TaskReviewBox.Location = new System.Drawing.Point(260, 168);
            this.TaskReviewBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TaskReviewBox.Name = "TaskReviewBox";
            this.TaskReviewBox.Size = new System.Drawing.Size(237, 31);
            this.TaskReviewBox.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Описание задачи";
            // 
            // TaskAddButt
            // 
            this.TaskAddButt.Location = new System.Drawing.Point(234, 435);
            this.TaskAddButt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TaskAddButt.Name = "TaskAddButt";
            this.TaskAddButt.Size = new System.Drawing.Size(171, 61);
            this.TaskAddButt.TabIndex = 14;
            this.TaskAddButt.Text = "Добавить";
            this.TaskAddButt.UseVisualStyleBackColor = true;
            this.TaskAddButt.Click += new System.EventHandler(this.PrAddButton_Click);
            // 
            // EndTaskDateTimePicker
            // 
            this.EndTaskDateTimePicker.Location = new System.Drawing.Point(260, 334);
            this.EndTaskDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EndTaskDateTimePicker.Name = "EndTaskDateTimePicker";
            this.EndTaskDateTimePicker.Size = new System.Drawing.Size(240, 31);
            this.EndTaskDateTimePicker.TabIndex = 19;
            // 
            // StartTaskDateTimePicker
            // 
            this.StartTaskDateTimePicker.Location = new System.Drawing.Point(260, 256);
            this.StartTaskDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StartTaskDateTimePicker.Name = "StartTaskDateTimePicker";
            this.StartTaskDateTimePicker.Size = new System.Drawing.Size(240, 31);
            this.StartTaskDateTimePicker.TabIndex = 18;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(31, 334);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(204, 25);
            this.label17.TabIndex = 17;
            this.label17.Text = "Дата окончания задачи";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(31, 256);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(171, 25);
            this.label16.TabIndex = 16;
            this.label16.Text = "Дата начала задачи";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(31, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(161, 25);
            this.label15.TabIndex = 15;
            this.label15.Text = "Название проекта";
            // 
            // AddTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 668);
            this.Controls.Add(this.panelTask);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddTaskForm";
            this.Text = "Добавление Задачи";
            this.panelTask.ResumeLayout(false);
            this.panelTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTask;
        private System.Windows.Forms.Button TaskAddButt;
        private System.Windows.Forms.DateTimePicker EndTaskDateTimePicker;
        private System.Windows.Forms.DateTimePicker StartTaskDateTimePicker;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button PersTaskButt;
        private System.Windows.Forms.Button DeleteTaskButt;
        private System.Windows.Forms.Button SaveTaskButt;
        private System.Windows.Forms.TextBox TaskNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TaskReviewBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox PrOnTaskcombo;
    }
}