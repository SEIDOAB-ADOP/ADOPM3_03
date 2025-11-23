using System;

namespace ADOPM3_03_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> CompanyResponse = priority => Console.WriteLine(theResponse("Company1", priority)); 
            CompanyResponse += priority => Console.WriteLine(theResponse("Company2", priority)); 
            CompanyResponse += priority => Console.WriteLine(theResponse("Company3", priority));

            CompanyResponse(1); // Company1 Critical Level
                                // Company2 Critical Level
                                // Company3 Critical Level
        }
        static string theResponse(string Company, int priority) =>
        (priority) switch
        {
            1 => $"{Company} Critical Level",
            2 => $"{Company} Moderate Level",
            3 => $"{Company} Easy Level",
            _ => $"{Company} Unknown Level"
        };
    }
}
