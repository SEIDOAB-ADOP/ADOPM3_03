using System;

namespace ADOPM3_03_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // public delegate void Action();  is a .NET delegate type

            // Consequences that Capatured Variables are evaluated when LE is invoked 
            {
                Action[] actions = new Action[3];
                
                for (int i = 0; i < 3; i++)
                    actions[i] = () => Console.Write(i);    // "i" is not yet evaluated

                foreach (Action a in actions) a();     // 333 because i is evaluated as LE is invoked 
            }
            
            // The solution, if we want to write 012, is to assign the iteration variable to a local
            // variable that’s scoped inside the loop:
            {
                Action[] actions = new Action[3];

                for (int i = 0; i < 3; i++)
                {
                    int m = i;
                    actions[i] = () => Console.Write(m); // LE is closed with m, unique each iteration
                }

                foreach (Action a in actions) a();     // 012
            }
            
        }
    }
    //Exercises:
    //1.    What happens if you execute the LE inside the first for loop right after assignment?
    //2.    What happens if you declare m outside the for loop but makes the assignment inside the for loop? Discuss before trying.
    //3.    Run example and discuss in the group. Make sure you understand. 
    //      Where is the delegate?
    //      Explain the difference between scoped and captured variables.
    //4.    Discuss similarities and differences with Exercises 5_02. Explain
}
