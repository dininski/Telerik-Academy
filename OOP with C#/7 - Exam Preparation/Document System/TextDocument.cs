using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem2
{
    public class TextDocument : Document, IEditable
    {
        public string Charset { get; set; }

        public TextDocument()
        {
            base.documentType = "TextDocument";
        }

        public void ChangeContent(string newContent)
        {
            this.content = newContent;
            this.LoadProperty("content", newContent);
        }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);

            if (key == "charset")
            {
                this.Charset = value;
            }
        }
    }
}
