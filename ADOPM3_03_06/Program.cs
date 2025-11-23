using System;

namespace ADOPM3_03_06
{
    class Program
    {
        public class Car
        {
            string _make;
            public string Make { get {return _make; } set => _make = value; } //Expression body
            public string Model { get; set; }
            public int Year { get; set; }
            public string Comment => Make switch
            {
                "Volvo" when Year >= 2021 => "...a brand new Volvo",   // Switch expressions
                "BMW" when Year >= 2019 => "...a better used BMW",
                _ => ""
            };

            // Override ToString()
            public override string ToString() { return MyOwnComment?.Invoke(Year) ?? $"Make:{Make} Model:{Model} Year:{Year} {Comment}";} //Expression body

            public Func<int, string> MyOwnComment { get; set; } // delegate
         }

        static void Main(string[] args)
        {
            Console.WriteLine(new Car() { Make = "Volvo", Year = 2021 }); // Make:Volvo Model: Year:2021 ...a brand new Volvo
            Console.WriteLine(new Car() { Make = "BMW", Year = 2019 });   // Make:BMW Model: Year:2019 ...a better used BMW
            Console.WriteLine(new Car() { Make = "Volvo", Year = 2019 }); // Make: Volvo Model: Year: 2019

            Car myCar = new Car() { Make = "Jaguar", Year = 1999,
                MyOwnComment = year =>     // Lambda Expression as delegate
                {
                    if (year < 2000)
                        return "...soon antique";
                    return null;
                } 
            };
            Console.WriteLine(myCar); // ...soon an antique Jaguar
        }
    }

    //Exercises:
    //1.    Go through all the "=>" and understand what they are. 
    //      Can Expression body have multiple statements?
    //      Can a switch expression have multiple statements?
    //      Can the Lambda expression have a single expression and multiple statements?
    //2.    Why is the ToString() and expression body and not a Lambda Expression. Do you understand the ToString()? Explain
    //3.    Make your own comments to various Car instances based on Make, Model and Year. Make, Model and Year 
    //      should be part of your comment. Prinout
}
