using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem2
{
    public abstract class OfficeDocuments : BinaryDocument, IEncryptable
    {
        public string Version { get; set; }
        protected bool encrypted = false;

        //public OfficeDocuments(string name, string content, long size, string version)
        //    : base(name, content, size)
        //{
        //    this.Version = version;
        //}

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "version")
            {
                this.Version = value;
            }
        }

        public bool IsEncrypted
        {
            get
            {
                return this.encrypted;
            }
        }

        public void Encrypt()
        {
            this.encrypted = true;
        }

        public void Decrypt()
        {
            this.encrypted = false;
        }
    }
}
