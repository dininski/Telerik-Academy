using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem2
{
    public class Excel : OfficeDocuments
    {
        public int NumberOfRows { get; set; }
        public int NumberOfCols { get; set; }

        public Excel()
        {
            base.documentType = "ExcelDocument";
        }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "rows")
            {
                this.NumberOfRows = int.Parse(value);
            }
            if (key == "cols")
            {
                this.NumberOfCols = int.Parse(value);
            }
        }
    }
}
