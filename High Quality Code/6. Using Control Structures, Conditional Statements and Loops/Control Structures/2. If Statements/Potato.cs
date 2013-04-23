namespace If_Statements_part_1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Potato
    {
        public Potato(bool isPeeled = false, bool isGoodToEat = true, bool isCooked = false)
        {
            this.IsPeeled = isPeeled;
            this.IsGoodToEat = isGoodToEat;
            this.IsCooked = isCooked;
        }

        public bool IsPeeled { get; set; }

        public bool IsGoodToEat { get; set; }

        public bool IsCooked { get; set; }
    }
}
