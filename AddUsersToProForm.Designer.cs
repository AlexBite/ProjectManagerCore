namespace Курсовая
{
    partial class AddUsersPro
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
			this.addBtn = new System.Windows.Forms.Button();
			this.projectCb = new System.Windows.Forms.ComboBox();
			this.employeeCb = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rateTb = new System.Windows.Forms.TextBox();
			this.employeeProjectDgv = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.employeeProjectDgv)).BeginInit();
			this.SuspendLayout();
			// 
			// addBtn
			// 
			this.addBtn.Location = new System.Drawing.Point(80, 357);
			this.addBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.addBtn.Name = "addBtn";
			this.addBtn.Size = new System.Drawing.Size(166, 58);
			this.addBtn.TabIndex = 0;
			this.addBtn.Text = "Добавить";
			this.addBtn.UseVisualStyleBackColor = true;
			this.addBtn.Click += new System.EventHandler(this.button1_Click);
			// 
			// projectCb
			// 
			this.projectCb.FormattingEnabled = true;
			this.projectCb.Location = new System.Drawing.Point(38, 94);
			this.projectCb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.projectCb.Name = "projectCb";
			this.projectCb.Size = new System.Drawing.Size(274, 28);
			this.projectCb.TabIndex = 1;
			this.projectCb.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			this.projectCb.Click += new System.EventHandler(this.comboBox1_Click);
			// 
			// employeeCb
			// 
			this.employeeCb.FormattingEnabled = true;
			this.employeeCb.Location = new System.Drawing.Point(38, 199);
			this.employeeCb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.employeeCb.Name = "employeeCb";
			this.employeeCb.Size = new System.Drawing.Size(274, 28);
			this.employeeCb.TabIndex = 2;
			this.employeeCb.Click += new System.EventHandler(this.comboBox2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(103, 46);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(130, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Выберите проект";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(94, 149);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(161, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Выберите сотрудника";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(103, 249);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Введите ставку";
			// 
			// rateTb
			// 
			this.rateTb.Location = new System.Drawing.Point(38, 296);
			this.rateTb.Margin = new System.Windows.Forms.Padding(2);
			this.rateTb.Name = "rateTb";
			this.rateTb.Size = new System.Drawing.Size(274, 27);
			this.rateTb.TabIndex = 8;
			// 
			// employeeProjectDgv
			// 
			this.employeeProjectDgv.BackgroundColor = System.Drawing.Color.Turquoise;
			this.employeeProjectDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.employeeProjectDgv.Location = new System.Drawing.Point(389, 62);
			this.employeeProjectDgv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.employeeProjectDgv.Name = "employeeProjectDgv";
			this.employeeProjectDgv.RowHeadersWidth = 62;
			this.employeeProjectDgv.Size = new System.Drawing.Size(565, 384);
			this.employeeProjectDgv.TabIndex = 5;
			// 
			// AddUsersPro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Aquamarine;
			this.ClientSize = new System.Drawing.Size(974, 466);
			this.Controls.Add(this.rateTb);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.employeeProjectDgv);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.employeeCb);
			this.Controls.Add(this.projectCb);
			this.Controls.Add(this.addBtn);
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "AddUsersPro";
			this.Text = "AddUsersPro";
			((System.ComponentModel.ISupportInitialize)(this.employeeProjectDgv)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ComboBox projectCb;
        private System.Windows.Forms.ComboBox employeeCb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView employeeProjectDgv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rateTb;
    }
}