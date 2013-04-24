namespace Cooking
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            this.Peel(potato);
            this.Peel(carrot);
            this.Cut(potato);
            this.Cut(carrot);
            Bowl bowl = this.GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private void Cut(Vegetable veggie)
        {
            veggie.IsCut = true;
        }

        private void Peel(Vegetable veggie)
        {
            veggie.IsPeeled = true;
        }
    }
}
