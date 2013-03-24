using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem2
{
    public class Audio : MultimediaDocuments
    {
        public int SampleRate { get; set; }

        public Audio()
        {
            base.documentType = "AudioDocument";
        }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "samplerate")
            {
                this.SampleRate = int.Parse(value);
            }
        }
    }
}
