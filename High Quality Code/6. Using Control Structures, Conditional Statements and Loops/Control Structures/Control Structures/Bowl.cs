namespace Cooking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bowl
    {
        private IList<Vegetable> contents;

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
