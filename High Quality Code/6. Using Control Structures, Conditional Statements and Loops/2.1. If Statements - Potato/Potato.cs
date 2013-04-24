namespace IfStatementsPart1
{
    public class Potato
    {
        public Potato()
        {
            this.IsPeeled = false;
            this.IsGoodToEat = true;
            this.IsCooked = false;
        }

        public Potato(bool isPeeled, bool isGoodToEat, bool isCooked)
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
