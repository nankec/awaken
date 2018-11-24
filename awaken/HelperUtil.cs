using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awaken
{
    public class HelperUtil
    {
        /**
         * 字符串换行
         **/
        public static string replaceToRN(string s) {
            s = s.Replace("。", "。\r\n");
            s = s.Replace("？", "?\r\n");
            //s = s.Replace("?", "?\r\n");
            s = s.Replace("!", "!\r\n");
            s = s.Replace("！", "!\r\n");
            return s;
        }

        //替换所有换行
        public static string replaceAllRn(string s) {
            return s.Replace("<BR>","").Replace("\r","");
        }

        public static string BreakLongString(string SubjectString, int lineLength)
        {
            StringBuilder sb = new StringBuilder(SubjectString);
            int offset = 0;
            ArrayList indexList = buildInsertIndexList(SubjectString, lineLength);
            for (int i = 0; i < indexList.Count; i++)
            {
                sb.Insert((int)indexList[i] + offset, '\n');
                offset++;
            }
            return sb.ToString();
        }

        private static ArrayList buildInsertIndexList(string str, int maxLen)
        {
            int nowLen = 0;
            ArrayList list = new ArrayList();
            for (int i = 1; i < str.Length; i++)
            {
                if (IsChinese(str[i]))
                {
                    nowLen += 2;
                }
                else
                {
                    nowLen++;
                }
                if (nowLen > maxLen)
                {
                    nowLen = 0;
                    list.Add(i);
                }
            }
            return list;
        }
        public static bool IsChinese(char c)
        {
            return (int)c >= 0x4E00 && (int)c <= 0x9FA5;
        }

        /**
         **填充空格
         **/ 
        public  static string fillSpace(string str) {
            int left = ConfigModel.getRowNum() - str.Length;
            if (left <= 0) {
                return str;
            }
            string preS = string.Empty;
            for (int i = 0; i < left; i++) {
                preS += "　";
            }
            return preS+str;
        }
    }
}
