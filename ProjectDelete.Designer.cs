namespace Курсовая
{
    partial class ProjectDelete
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
            this.deleteBtn = new System.Windows.Forms.Button();
            this.projectsCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(150, 174);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(212, 69);
            this.deleteBtn.TabIndex = 0;
            this.deleteBtn.Text = "Удалить проект";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // projectsCB
            // 
            this.projectsCB.FormattingEnabled = true;
            this.projectsCB.Location = new System.Drawing.Point(50, 109);
            this.projectsCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.projectsCB.Name = "projectsCB";
            this.projectsCB.Size = new System.Drawing.Size(460, 33);
            this.projectsCB.TabIndex = 1;
            this.projectsCB.SelectedIndexChanged += new System.EventHandler(this.projectsCB_SelectedIndexChanged);
            this.projectsCB.Click += new System.EventHandler(this.projectsCB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите проект";
            // 
            // ProjectDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(550, 365);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectsCB);
            this.Controls.Add(this.deleteBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProjectDelete";
            this.Text = "ProjectDelete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.ComboBox projectsCB;
        private System.Windows.Forms.Label label1;
    }
}