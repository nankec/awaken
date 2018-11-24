using Newtonsoft.Json;
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
    public partial class sumWords : Form
    {
        Form1 form1;
        public sumWords(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        List<CheckBox> controlList = new List<CheckBox>();
        void addCheckBox(int i,string text) {
            CheckBox checkBox=  new System.Windows.Forms.CheckBox();
            checkBox.AutoSize = true;
            int width = 10+(i % 3) * 140;
            int height = 30 + (i / 3) * 25;

            checkBox.Location = new Point(width, height);
            checkBox.Name = "checkBox_"+ i;
            checkBox.Size = new System.Drawing.Size(78, 16);
            checkBox.Text = text;
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
            //this.groupBox1.Controls.Add(checkBox);
            controlList.Add(checkBox);
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            eachCheckBox();
            label1.Text = "总文件数量为:"+ controlList.Count+",选中数量:"+ files.Count;
        }

        void addCheckBox2(int i, string text) {
            int width = 10 + (i % 3) * 40;
            int height = 30 + (i / 3) * 25;
            checkBoxVModel m = new checkBoxVModel();
            m.x = width;
            m.y = height;
            m.text = text;
            //list.Add(m);
        }


        private void sumWords_Load(object sender, EventArgs e)
        {
            string dataPath = ConfigModel.getDataPath();
            String[] files = Directory.GetFiles(dataPath);
            for (int i = 0; i < files.Length; i++)
            {
                string fileName = Path.GetFileName(files[i]);
                addCheckBox(i,fileName);
                //addCheckBox2(i,fileName);
            }
            for (int i = controlList.Count-1; i >=0; i--) {
                groupBox1.Controls.Add(controlList[i]);
            }
            label1.Text = "总文件数量为:" + controlList.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (files.Count == 0) {
                MessageBox.Show("请勾选要合成的文件");
                return;
            }
            string dataPath = ConfigModel.getDataPath();
            foreach (string s in files) {
                loadFile(dataPath + s);
            }

            String filePath = ConfigModel.getDataPath() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

            FileStream fs = new FileStream(filePath, FileMode.Create);
            string str = JsonConvert.SerializeObject(listWorlds);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();

            MessageBox.Show("合并成功，条数:" + listWorlds.Count);

        }

        List<String> files = new List<string>();
        void eachCheckBox() {
            files = new List<string>();
            foreach (Control c in this.groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    if (((CheckBox)c).Checked)
                    {
                        files.Add(c.Text);
                    }
                }
            }
        }

        List<WordsModel> listWorlds = new List<WordsModel>();
        void loadFile(String FilePath) {
            StreamReader sr = new StreamReader(FilePath, Encoding.GetEncoding("UTF-8"));
            string txt = sr.ReadToEnd();
            if (txt == "" || txt == null)
            {
                return;
            }
            try
            {
                List<WordsModel> wordsModel = JsonConvert.DeserializeObject<List<WordsModel>>(txt);
                if (wordsModel != null)
                {
                    listWorlds.AddRange(wordsModel);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void sumWords_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.closeSumForm();
        }
    }

    public class checkBoxVModel {
        public int x;
        public int y;
        public string text;
    }
}
