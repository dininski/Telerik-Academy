namespace Cooking
{
    public abstract class Vegetable
    {
        public Vegetable()
        {
            this.IsCut = false;
            this.IsPeeled = false;
        }

        public Vegetable(bool isCut, bool isPeeled)
        {
            this.IsCut = isCut;
            this.IsPeeled = isPeeled;
        }
        
        public bool IsCut { get; set; }

        public bool IsPeeled { get; set; }
    }
}
