namespace Курсовая
{
    partial class AddTypeOfActivity
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
            this.label13 = new System.Windows.Forms.Label();
            this.ActivityNameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Aquamarine;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(195, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(259, 20);
            this.label13.TabIndex = 41;
            this.label13.Text = "Добавление вида деятельности";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // ActivityNameBox
            // 
            this.ActivityNameBox.Location = new System.Drawing.Point(373, 109);
            this.ActivityNameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ActivityNameBox.Name = "ActivityNameBox";
            this.ActivityNameBox.Size = new System.Drawing.Size(214, 26);
            this.ActivityNameBox.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Название вида деятельности";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 32);
            this.button1.TabIndex = 42;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddUsersToProject
            // 
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(673, 245);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ActivityNameBox);
            this.Controls.Add(this.label7);
            this.Name = "AddUsersToProject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox ActivityNameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}