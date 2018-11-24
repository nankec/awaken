using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awaken
{
    public class WordsModel
    {
        private string author;


        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }
        private String words;

        public string Words
        {
            get
            {
                return words;
            }

            set
            {
                words = value;
            }
        }
    }
}