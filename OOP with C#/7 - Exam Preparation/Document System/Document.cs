using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem2
{
    public abstract class Document : IDocument
    {
        protected string content;
        protected string name;
        IList<KeyValuePair<string, object>> properties;
        protected string documentType = "Document";

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
        }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.name = value;
            }
            if (key == "content")
            {
                this.content = value;
            }
        }

        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            IEnumerable<KeyValuePair<string, object>> sorted = output.OrderBy(kvp => kvp.Key);
            this.properties = sorted.ToList();
            
            foreach (var item in output)
            {
                this.LoadProperty(item.Key, item.Value.ToString());
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(documentType);
            sb.Append('[');
            foreach (var property in this.properties)
            {
                sb.Append(String.Format("{0}={1};", property.Key, property.Value));
            }
            sb.Remove(sb.Length-1,1);
            sb.Append(']');
            return sb.ToString();
        }
    }
}
