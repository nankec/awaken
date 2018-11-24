using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awaken
{
    public static class LoadWordsService
    {
        private static string FilePath;
        private static List<WordsModel> listWorlds;
        static LoadWordsService() {
            listWorlds = new List<WordsModel>();
        }
        /**
         * 设置路径
         * */
        public static void SetFilePath(string filePath) {
            FilePath = filePath;
            loadWorls();
        }

        //加载经典名言
        private static void loadWorls() {
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
        public static WordsModel getRandomWord() {
            object ojb = new object();
            lock (ojb) {
                if (listWorlds.Count == 0)
                {
                    return null;
                }
                Random r = new Random();
                int next = r.Next(listWorlds.Count);
                WordsModel w = listWorlds[next];
                if (w.Words.Length > 144)
                {
                    return getRandomWord(next + 1);
                }
                return w;
            }
        }

        public static WordsModel getRandomWord(int index)
        {
            if (listWorlds.Count == 0)
            {
                return null;
            }
            if (index >= listWorlds.Count) {
                index = 0;
            }
            WordsModel w = listWorlds[index];
            if (w.Words.Length > 144)
            {
                LogHelper.Log("字数超过144，继续遍历下一个,index:"+index);
                return getRandomWord(index+1);
            }
            return w;
        }
    }
}
