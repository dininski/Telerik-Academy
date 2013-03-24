using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem2
{
    public abstract class MultimediaDocuments : BinaryDocument
    {
        public int Length { get; set; }
        //public MultimediaDocuments(string name, string content, long size, int length)
        //    : base(name, content, size)
        //{
        //    this.Length = length;
        //}

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "length")
            {
                this.Length = int.Parse(value);
            }
        }
    }
}
