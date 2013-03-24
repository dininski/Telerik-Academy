using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem2
{
    public class Word : OfficeDocuments, IEditable
    {
        public ulong NumberOfCharacters { get; set; }

        public Word()
        {
            base.documentType = "WordDocument";
        }
        public void ChangeContent(string newContent)
        {
            this.content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "chars")
            {
                this.NumberOfCharacters = ulong.Parse(value);
            }
        }
    }
}
