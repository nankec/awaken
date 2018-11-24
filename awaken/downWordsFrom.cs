using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awaken
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]//COM+组件可见
    public partial class downWordsFrom : Form
    {
        private List<WordsModel> list = new List<WordsModel>();
        public downWordsFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text)) {
                MessageBox.Show("请输入句子迷地址");
                return;
            }
            webBrowser1.Url =new Uri(textBox1.Text);
            LogHelper.Log("[begin]"+textBox1.Text);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            LogHelper.Log("------字节数:"+ webBrowser1.Document.ToString().Length);
            LogHelper.Log("[end]" + webBrowser1.Url.AbsoluteUri);
            getWorlds();
            if (chk_autoPage.Checked) {
                autoPage();
            }
            HtmlDocument doc = webBrowser1.Document;
            int height = webBrowser1.Document.Body.ScrollRectangle.Height;

            doc.Window.ScrollTo(new Point(0, height-800));
        }


        void getWorlds() {
            String script2 = @"
function getList(){
var list='[';
$('.views-field-phpcode').each(function(){
    var words=$(this).find('.xlistju').html();
     var author=$(this).find('.views-field-field-oriwriter-value').html();
     if($(this).find('.views-field-field-oriwriter-value').length>0){
        author=$(this).find('.views-field-field-oriwriter-value')[0].innerText;
     }
    var obj2='{ words:\''+words+'\',author:\''+author+'\'}';
    list +=obj2+',';
});
//alert(obj);
list=list.substring(0,list.length-1);
list+=']';
window.external.CallBack(list);
}";
            addScript(script2);
            //addScript("function alert1(){alert('a');window.external.CallBack('a123')}");
            //webBrowser1.Document.InvokeScript("getList", new object[] { "CShareFunction" });
            //webBrowser1.Document.InvokeScript("alert1");
            webBrowser1.Document.InvokeScript("getList");
        }

        void addScript(String srcipt) {
            HtmlElement he = this.webBrowser1.Document.CreateElement("script");
            he.SetAttribute("type", "text/javascript");
            
            he.SetAttribute("text", srcipt);
            this.webBrowser1.Document.Body.AppendChild(he);
            //LogHelper.Log(webBrowser1.DocumentText);
            //LogHelper.Log(webBrowser1.Document.Body.OuterHtml);
        }

        

        public void CallBack(String str) {
            str = str.Replace("<BR>","\r\n").Replace("null","");
            //MessageBox.Show(str);
            List<WordsModel> wordsModel = JsonConvert.DeserializeObject<List<WordsModel>>(str);
            list.AddRange(wordsModel);
        }

        private void downWordsFrom_Load(object sender, EventArgs e)
        {
            webBrowser1.ObjectForScripting = this;
        }
        

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (list.Count == 0) {
                MessageBox.Show("没有分析到语句");
                return;
            }
            
            String filePath = ConfigModel.getDataPath() +DateTime.Now.ToString("yyyyMMddHHmmss")+".txt";

            FileStream fs = new FileStream(filePath, FileMode.Create);
            //获得字节数组
            removeRepeat();
            string str= JsonConvert.SerializeObject(list);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();

            MessageBox.Show("写入成功，数量:"+list.Count);
        }

        private void btn_clean_Click(object sender, EventArgs e)
        {
            list.Clear();
        }

        void autoPage() {
            String script = @"
function autoPage(){
  if($('.pager - item').length==0){
    return;
  }
  var next= $('.pager .pager-current').next();
  if(!next.hasClass('pager-item')){
    alert('执行完毕');
    return;
  }
  window.location.href= next.find('a').attr('href');
}
";

            addScript(script);
            webBrowser1.Document.InvokeScript("autoPage");
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.AbsoluteUri;
        }

        void getWords2() {
         //   webBrowser1.Document.get
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            webBrowser1.Width = this.Width-40;
            webBrowser1.Height = this.Height - 100;
        }

        void removeRepeat() {
            //var list2= list.GroupBy(s => s.Words).Select(group => new {

            //}).ToList();
            //list = new List<WordsModel>();
            //foreach (var l in list2) {
            //  list.Add(new WordsModel {  Author=l.Author,});
            //}
            LogHelper.Log("开始去重，原list数量:"+list.Count);
            Dictionary<String, WordsModel> dict = new Dictionary<string, WordsModel>();
            foreach (WordsModel w in list) {
                if (!dict.ContainsKey(w.Words)) {
                    dict.Add(w.Words, w);
                }
            }
            list = new List<WordsModel>();
            foreach (string key in dict.Keys) {
                list.Add(dict[key]);
            }
            LogHelper.Log("去重后数量:"+list.Count);
        }
    }
}
