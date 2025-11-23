using System;
using InADifferentFile;

namespace InADifferentFile
{
    //Delegate Type could be in a different namespace
    delegate string AlarmResponse(int priority);
}

namespace ADOPM3_03_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the delegate on the fly using Lambda Expressions 
            
            //AlarmResponse CompanyResponse = (int priority) =>
            AlarmResponse CompanyResponse = priority =>     //parenthesis and type can be removed (single parameter, type inferred) 
            (priority) switch
            {
                1 => "Company1 Critical Level",
                2 => "Company1 Moderate Level",
                3 => "Company1 Easy Level",
                _ => "Comapny1 Unknown Level"
            };
            
            string response = CompanyResponse(1); // Invoke delegate - shorthand
            Console.WriteLine(response); // Company1 Critical Level
        }
    }

    //Exercises:
    //1.    Modify code  in Example 4.17 to use Lambda Expressions as the delegates
}
