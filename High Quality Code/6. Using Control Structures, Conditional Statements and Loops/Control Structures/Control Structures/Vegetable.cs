namespace Cooking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Vegetable
    {
        public Vegetable(bool isCut = false, bool isPeeled = false)
        {
            this.IsCut = isCut;
            this.IsPeeled = isPeeled;
        }
        
        public bool IsCut { get; set; }

        public bool IsPeeled { get; set; }
    }
}
