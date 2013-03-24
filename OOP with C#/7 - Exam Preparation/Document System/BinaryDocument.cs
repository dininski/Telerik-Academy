using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem2
{
    public abstract class BinaryDocument : Document
    {
        public long Size { get; set; }

        //public BinaryDocument(string name, string content, long size)
        //    : base(name, content)
        //{
        //    this.Size = size;
        //}

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "size")
            {
                this.Size = int.Parse(value);
            }
        }
    }
}
