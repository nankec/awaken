using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awaken
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
            initSet();
            this.TransparencyKey = Color.Thistle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread mythread = new Thread(loadWords);
            mythread.IsBackground = true;
            mythread.Start();   
        }
        private void loadWords() {
            String filePath= ConfigModel.getFullFilePath();
            LoadWordsService.SetFilePath(filePath);
        }

        private void showWords() {
            while (true) {
                setShowStyle();
                WordsModel words= LoadWordsService.getRandomWord();
                String s= words.Words;
                if (ConfigModel.getStyle().Equals(0))
                {
                    s = s.Replace("。", "。\r\n");
                    s = s.TrimEnd('\n').TrimEnd('\r');
                    s += "        --" + words.Author;
                }
                else {
                    s = HelperUtil.replaceToRN(s);
                    if (!s.EndsWith("\r\n") && !s.EndsWith("\r"))
                    {
                        s += "\r\n";
                    }
                    s += HelperUtil.fillSpace("--" + words.Author);
                }
                label1.Text = s;
                this.Update();
                Thread.Sleep(1000*ConfigModel.getTimer());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void initSet() {
            setShowStyle();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sets sets = new Sets();
            sets.ShowDialog();
        }

        private void 下载迷句ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            downWordsFrom down = new downWordsFrom();
            down.ShowDialog();
        }
        void setShowStyle() {
            label1.ForeColor = ConfigModel.getColor();
            this.TopMost = true;
            //这个区域不包括任务栏的
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            //这个区域包括任务栏，就是屏幕显示的物理范围
            //Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            int width1 = ScreenArea.Width; //屏幕宽度 
            int height1 = ScreenArea.Height; //屏幕高度
            this.Visible = true;
            if (ConfigModel.getStyle().Equals(0)){
                label1.Font = ConfigModel.getFont();
                //最大化显示
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                this.Width = width1;
                //this.Location = new System.Drawing.Point(0 , height1 -this.Height+10); //指定窗体显示在右下角
                label1.Width = this.Width;
                label1.Height = height1 - 10;
                this.label1.TextAlign = ContentAlignment.BottomCenter;
                this.BackgroundImage = null;
                this.TransparencyKey = Color.White;
                label1.BackColor= Color.White;
                this.Update();
                return;
            }
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
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
            label1.BackColor = Color.Transparent;
            //this.BackColor = Color.Thistle;
            this.Update();
            Thread t2 = new Thread(hideForm);
            t2.IsBackground = true;
            t2.Start();
        }

        void hideForm()
        {
            Thread.Sleep(7000);
            hideFormNow();
        }

        void hideFormNow() {
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_HIDE | AW_BLEND);
        }

        public const Int32 AW_HOR_POSITIVE = 0x00000001;    // 从左到右打开窗口
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;    // 从右到左打开窗口
        public const Int32 AW_VER_POSITIVE = 0x00000004;    // 从上到下打开窗口
        public const Int32 AW_VER_NEGATIVE = 0x00000008;    // 从下到上打开窗口
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_HIDE = 0x00010000;        // 在窗体卸载时若想使用本函数就得加上此常量
        public const Int32 AW_ACTIVATE = 0x00020000;    //在窗体通过本函数打开后，默认情况下会失去焦点，除非加上本常量
        public const Int32 AW_SLIDE = 0x00040000;
        public const Int32 AW_BLEND = 0x00080000;       // 淡入淡出效果
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool AnimateWindow(
        IntPtr hwnd, // handle to window   
        int dwTime, // duration of animation   
        int dwFlags // animation type   
        );

        // Win32.AnimateWindow(this.Handle, 2000, Win32.AW_BLEND); 淡入

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            if (ConfigModel.getStyle().Equals(0)) return;
            //hideFormNow();
            showForm2();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ConfigModel.getStyle().Equals(1))
            {
                this.timer1.Interval = ConfigModel.getTimer() * 1000;
            }
            else {
                this.timer1.Interval = 60 * 1000;
            }
            
            setShowStyle();
            WordsModel words = LoadWordsService.getRandomWord();
            if (words == null) {
                label1.Text = "当我们开始听从内心\r\n就已开始前往天堂";
                return;
            }
            String s = words.Words;
            s = s.Replace("。", "。\r\n");
            s = s.TrimEnd('\n').TrimEnd('\r');
            s += "        --" + words.Author;
            label1.Text = s;
        }

        Form2 form2 = null;

        void showForm2() {
            if (form2 == null) {
                form2 = new Form2(this);
                form2.Show();
                return;
            }
            form2.TopMost = true;
        }
        private void 显示小窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm2();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            showForm2();
        }

        public void closeForm2() {
            form2.Close();
            form2 = null;
        }

        sumWords sumWords = null;
        private void 合成名言ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sumWords == null) {
                sumWords = new sumWords(this);
                sumWords.Show();
            }
            sumWords.TopMost = true;
        }

        public void closeSumForm() {
            sumWords = null;
        }
    }
}
