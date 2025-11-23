using System;


namespace ADOPM3_03_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array2 = new int[] { 1, 3, 5, 7, 9 };

            int[] array3 = Array.FindAll<int>(array2, x => x > 3);

            foreach (int i in array3)
                Console.WriteLine(i); // 5, 7, 9

            //...and also calculating sum using a captured variable
            int mysum = 0;
            int[] array4 = Array.FindAll<int>(array2, x => { mysum += x > 3 ? x : 0; return x > 3;});
            Console.WriteLine(mysum); // 21

            foreach (int i in array4)
                Console.WriteLine(i);  // 5, 7, 9
        }
    }
    //Exercises:
    //1.    Use the classes from Example 1.19. Create an array of Shape. Populate it with Triangles and Rectangles. Use LE to find all Shapes meeting
    //      certain Height, Width and Area criterias. Printout the Area, Width, Height of the found Shapes. 
    //      Remember Virtual methods and Override.
    //2.    Caluclate and Printout the sum of all Areas using a captured variable
}
