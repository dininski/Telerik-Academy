namespace Cooking
{
    using System.Collections.Generic;
    using System.Linq;

    public class Bowl
    {
        private readonly IList<Vegetable> contents;

        public Bowl()
        {
            this.contents = new List<Vegetable>();
        }

        public void Add(Vegetable veggie)
        {
            this.contents.Add(veggie);
        }

        public Vegetable[] GetContents()
        {
            return this.contents.ToArray();
        }
    }
}
