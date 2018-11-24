namespace awaken
{
    partial class Sets
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
            this.label1 = new System.Windows.Forms.Label();
            this.lab_font = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_color = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_timer = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.com_file = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.com_style = new System.Windows.Forms.ComboBox();
            this.lab_font_mini = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "字体:";
            // 
            // lab_font
            // 
            this.lab_font.AutoSize = true;
            this.lab_font.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lab_font.Location = new System.Drawing.Point(99, 13);
            this.lab_font.Name = "lab_font";
            this.lab_font.Size = new System.Drawing.Size(41, 12);
            this.lab_font.TabIndex = 1;
            this.lab_font.Text = "label2";
            this.lab_font.Click += new System.EventHandler(this.lab_font_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
            // 
            // colorDialog1
            // 
            this.colorDialog1.SolidColorOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "颜色:";
            // 
            // lab_color
            // 
            this.lab_color.AutoSize = true;
            this.lab_color.Location = new System.Drawing.Point(98, 63);
            this.lab_color.Name = "lab_color";
            this.lab_color.Size = new System.Drawing.Size(35, 12);
            this.lab_color.TabIndex = 3;
            this.lab_color.Text = "color";
            this.lab_color.Click += new System.EventHandler(this.lab_color_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "间隔周期(s):";
            // 
            // txt_timer
            // 
            this.txt_timer.Location = new System.Drawing.Point(100, 117);
            this.txt_timer.Name = "txt_timer";
            this.txt_timer.Size = new System.Drawing.Size(100, 21);
            this.txt_timer.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "名言文件:";
            // 
            // com_file
            // 
            this.com_file.FormattingEnabled = true;
            this.com_file.Location = new System.Drawing.Point(102, 89);
            this.com_file.Name = "com_file";
            this.com_file.Size = new System.Drawing.Size(121, 20);
            this.com_file.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "展现:";
            // 
            // com_style
            // 
            this.com_style.FormattingEnabled = true;
            this.com_style.Items.AddRange(new object[] {
            "底部显示",
            "右边小窗"});
            this.com_style.Location = new System.Drawing.Point(192, 59);
            this.com_style.Name = "com_style";
            this.com_style.Size = new System.Drawing.Size(70, 20);
            this.com_style.TabIndex = 10;
            // 
            // lab_font_mini
            // 
            this.lab_font_mini.AutoSize = true;
            this.lab_font_mini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lab_font_mini.Location = new System.Drawing.Point(100, 37);
            this.lab_font_mini.Name = "lab_font_mini";
            this.lab_font_mini.Size = new System.Drawing.Size(41, 12);
            this.lab_font_mini.TabIndex = 12;
            this.lab_font_mini.Text = "label2";
            this.lab_font_mini.Click += new System.EventHandler(this.lab_font_mini_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "小窗口:";
            // 
            // Sets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 204);
            this.Controls.Add(this.lab_font_mini);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.com_style);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.com_file);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_timer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lab_color);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lab_font);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Sets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_font;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_color;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_timer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox com_file;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox com_style;
        private System.Windows.Forms.Label lab_font_mini;
        private System.Windows.Forms.Label label7;
    }
}