using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem2
{
    public class Video : MultimediaDocuments
    {
        public int FrameRate { get; set; }
        private new string documentType = "VideoDocument";

        public Video()
        {
            base.documentType = "VideoDocument";
        }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);

            if (key == "framerate".ToLower())
            {
                this.FrameRate = int.Parse(value);
            }
        }
    }
}
