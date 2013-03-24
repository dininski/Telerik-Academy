using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem2
{
    public class PDF : BinaryDocument, IEncryptable
    {
        public int NumberOfPages { get; set; }
        private bool encrypted = false;
        private new string documentType = "PDFDocument";

        //public PDF(string name, string content, long size, int numberOfPages)
        //    : base(name, content, size)
        //{
        //    this.NumberOfPages = numberOfPages;
        //}

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "pages")
            {
                this.NumberOfPages = int.Parse(value);
            }
        }

        public bool IsEncrypted
        {
            get { return this.encrypted; }
        }

        public void Encrypt()
        {
            this.encrypted = true;
        }

        public void Decrypt()
        {
            this.encrypted = false;
        }

        public override string ToString()
        {
            if (IsEncrypted)
            {
                return String.Format("{0}[encrypted]", this.name);
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
