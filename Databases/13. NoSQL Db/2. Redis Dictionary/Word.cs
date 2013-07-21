namespace RedisDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Word
    {
        private string word;
        private string explanation;

        public Word(byte[] word, byte[] explanation)
        {
            this.word = word.StringFromByteArray();
            this.explanation = explanation.StringFromByteArray();
        }

        public string Text
        {
            get
            {
                return this.word;
            }
        }

        public string Explanation
        {
            get
            {
                return this.explanation;
            }
        }
    }
}
