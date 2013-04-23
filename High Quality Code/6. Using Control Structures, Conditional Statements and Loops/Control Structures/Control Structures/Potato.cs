namespace Cooking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Potato : Vegetable
    {
        public Potato(bool isCut = false, bool isPeeled = false)
            : base(isCut, isPeeled)
        {
        }
    }
}
