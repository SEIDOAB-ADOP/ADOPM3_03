using System;

namespace ADOPM3_03_02
{
    class Program
    {
        static Func<int> Iterator1()
        {
            int seed = 0;
            return () => seed++;     // returns a LE that is a closure
        }
        static void Main(string[] args)
        {
            // A lambda expression can reference the local variables and parameters of the method
            // in which it’s defined (outer variables)
            int factor = 2;
            Func<int, int> multiplier = n => { return n * factor; };

            Console.WriteLine(multiplier(3));

            factor = 3;
            Console.WriteLine(multiplier(3));


            
            // Lambda expressions can themselves update captured variables:
            int counter = 0;
            Func<int> natural = () =>
            {
                counter++;
                counter *= factor;

                return counter;
            };

            Console.WriteLine(natural());           // 0
            Console.WriteLine(natural());           // 1
            Console.WriteLine(counter);             // 2   

            
            //Lifetime of captured variable is extened to lifetime of the delegate
            Func<int> iterator1 = Iterator1();
            Console.WriteLine(iterator1());           // 0
            Console.WriteLine(iterator1());           // 1
            
            
            //A local variable instantiated withing LE is unique for the instance
            Func<int> iterator = () =>
            {
                int seed = 0;
                return seed++;
            };
            Console.WriteLine(iterator());      // 0
            Console.WriteLine(iterator());      // 0
            
        }
    }

    //Exercises:
    //1.    Create a class type with a method that returns a LE that is a closure (i.e. capures a variable in the class). 
    //2.    Instantiating the class and call the closure several times, printing out result. Is the variable in the class captured?
    //3.    Create another method in the class that changes the value of the catured variable. Call the closure and printout result.
    //      Is the variabled still captured?      
}
