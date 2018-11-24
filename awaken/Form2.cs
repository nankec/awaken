using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awaken
{
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2(Form1 from)
        {
            InitializeComponent();
            this.form1 = from;
            timer1.Interval = ConfigModel.getMiniTimer() * 1000;            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            getWorld();
            label1.ForeColor = ConfigModel.getColor();
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            //这个区域包括任务栏，就是屏幕显示的物理范围
            //Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            int width1 = ScreenArea.Width; //屏幕宽度 
            int height1 = ScreenArea.Height; //屏幕高度
            this.Width = 300;
            this.Height = 250;
            this.label1.Font = ConfigModel.getFontMini();
            this.label1.Dock = DockStyle.Fill;
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            int x = width1 - this.Width;
            this.Location = new System.Drawing.Point(x, height1 - this.Height); //指定窗体显示在右下角
            label1.Padding = new Padding(20);
            this.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + "timg2.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Update();
        }

        void getWorld() {
            WordsModel words = LoadWordsService.getRandomWord();
            if (words == null) {
                return;
            }
            String s = words.Words;
            s = HelperUtil.replaceToRN(s);
            if (!s.EndsWith("\r\n") && !s.EndsWith("\r")) {
                s += "\r\n";
            }
            s += HelperUtil.fillSpace("--" + words.Author);
            this.TopMost = true;
            label1.Text = s;
            label1.Update();
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                form1.closeForm2();
                return;
            }
            getWorld();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getWorld();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            getWorld();
        }
    }
}
