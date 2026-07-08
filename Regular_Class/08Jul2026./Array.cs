// array is same data type
// size is fixed 

using System;

class Array
{
    static void Main()
    {
        int[] rollno = { 1, 2, 3, 4, 5 };

        foreach (int r in rollno)
        {
            Console.WriteLine(r);
        }
    }
}