using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Example
{
    class FactoryMethodExample
    {
        static void Main(string[] args)
        {
            // the pizza factory method hides the creation of the pizza
            // and it can hold complex initialization or some other type of
            // calculation. Also changing from one type of pizza to another
            // can be done in the entire program by simply changing a couple
            // of lines of code in the factory method, without changing any
            // of the functionality in the rest of the code.
            IPizza cheesePizza = PizzaFactory.MakePizza("cheese");
            cheesePizza.Ingridients();
            cheesePizza.Bake();
        }
    }
}
