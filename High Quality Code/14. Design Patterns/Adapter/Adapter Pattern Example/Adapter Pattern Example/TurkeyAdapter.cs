namespace Adapter_Pattern_Example
{
    public class TurkeyAdapter : IDuck
    {
        private ITurkey turkey;

        public TurkeyAdapter(ITurkey turkey)
        {
            this.turkey = turkey;
        }

        public void Quack()
        {
            this.turkey.Gobble();
        }

        public void Fly()
        {
            this.turkey.Fly();
        }
    }
}
