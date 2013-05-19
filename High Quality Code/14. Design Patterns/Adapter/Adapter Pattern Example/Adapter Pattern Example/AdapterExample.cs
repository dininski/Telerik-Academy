namespace Adapter_Pattern_Example
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class AdapterExample
    {
        static void Main(string[] args)
        {
            ITurkey aTurkey = new WildTurkey();
            IDuck anAdaptedTurkey = new TurkeyAdapter(aTurkey);

            // now Quack actually invokes WildTurkey's Gobble
            // method - even though the aTurkey is not a duck
            // it has been "adapted" to the IDuck interface
            anAdaptedTurkey.Quack();
            anAdaptedTurkey.Fly();
        }
    }
}
