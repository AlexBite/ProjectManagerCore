namespace Курсовая
{
    partial class AddDepartmentForm
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
			this.nameTb = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.addBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// nameTb
			// 
			this.nameTb.Location = new System.Drawing.Point(27, 146);
			this.nameTb.Name = "nameTb";
			this.nameTb.Size = new System.Drawing.Size(342, 27);
			this.nameTb.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(76, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(237, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Введите название департамента";
			// 
			// addBtn
			// 
			this.addBtn.Location = new System.Drawing.Point(123, 230);
			this.addBtn.Name = "addBtn";
			this.addBtn.Size = new System.Drawing.Size(116, 40);
			this.addBtn.TabIndex = 2;
			this.addBtn.Text = "Добавить";
			this.addBtn.UseVisualStyleBackColor = true;
			this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
			// 
			// AddDepartmentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Aquamarine;
			this.ClientSize = new System.Drawing.Size(398, 336);
			this.Controls.Add(this.addBtn);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nameTb);
			this.Name = "AddDepartmentForm";
			this.Text = "AddDepartmentForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addBtn;
    }
}