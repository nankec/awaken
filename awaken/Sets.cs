using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awaken
{
    public partial class Sets : Form
    {
        public Sets()
        {
            InitializeComponent();
        }

        private void Sets_Load(object sender, EventArgs e)
        {
            lab_color.BackColor = ConfigModel.getColor();
            lab_color.Text = ConfigModel.getColorStr();
            lab_font.Text = ConfigModel.getFont().FontFamily.Name + "/" + ConfigModel.getFont().Size;
            txt_timer.Text = ConfigModel.getTimer().ToString();
            londFile();
            lab_font_mini.Text= ConfigModel.getFontMini().FontFamily.Name + "/" + ConfigModel.getFontMini().Size;
            com_style.SelectedIndex=ConfigModel.getStyle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigModel.setColor(lab_color.Text);
            ConfigModel.setFont(lab_font.Text);
            int timer = 0;
            if (String.IsNullOrEmpty(txt_timer.Text)){
                MessageBox.Show("请输入间隔周期");
                return;
            }
            if (!int.TryParse(txt_timer.Text, out timer)) {
                MessageBox.Show("请输入数字");
                return;
            }
            if (timer < 0) {
                MessageBox.Show("请输入大于0的数字");
                return;
            }
            if (com_file.SelectedIndex==-1) {
                MessageBox.Show("请选择名言文件");
                return;
            }
            LoadWordsService.SetFilePath(ConfigModel.getDataPath() + com_file.SelectedItem);
            ConfigModel.setFile(com_file.SelectedItem.ToString());
            ConfigModel.setTimer(timer);

            ConfigModel.setFontMini(lab_font_mini.Text);
            ConfigModel.setStyle(com_style.SelectedIndex);
            DialogResult result= MessageBox.Show("保存成功");
            if (result.Equals(DialogResult.OK)) {
                this.Close();
            }
        }

        private void lab_font_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = ConfigModel.getFont();
            fontDialog1.Tag = "0";
            DialogResult result = fontDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String font = fontDialog1.Font.FontFamily.Name + "/" + fontDialog1.Font.Size;
                lab_font.Text = font;
            }
        }

        private void lab_font_mini_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = ConfigModel.getFontMini();
            fontDialog1.Tag = "1";
            DialogResult result = fontDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String font = fontDialog1.Font.FontFamily.Name + "/" + fontDialog1.Font.Size;
                lab_font_mini.Text = font;
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            String font = fontDialog1.Font.FontFamily.Name + "/" + fontDialog1.Font.Size;
            if (fontDialog1.Tag.Equals("0"))
            {
                lab_font.Text = font;
            }
            else {
                lab_font_mini.Text = font;
            }
            
        }

        private void lab_color_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = ConfigModel.getColor();
            DialogResult result= colorDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK)) {
                String name= colorDialog1.Color.Name;
                lab_color.BackColor = colorDialog1.Color;
                lab_color.Text = colorDialog1.Color.R + "/" + colorDialog1.Color.G + "/" + colorDialog1.Color.B;
                lab_color.Update();
            }
        }

        void londFile() {
            string dataPath = ConfigModel.getDataPath();
            String[] files=Directory.GetFiles(dataPath);
            //com_file.DisplayMember = "Name";
            //com_file.ValueMember = "Name";
            for (int i =0;i<files.Length;i++) {
                string fileName = Path.GetFileName(files[i]);
                com_file.Items.Add(fileName);
            }
            for (int i = 0; i < com_file.Items.Count; i++) {
                string temp = com_file.Items[i].ToString();
                if (ConfigModel.getFile().Equals(temp))
                {
                    com_file.SelectedIndex = i;
                }
            }
        }

        
    }
}
