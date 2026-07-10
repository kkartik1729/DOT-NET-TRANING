using System;
using System.Linq;

class LInqeg
{
    static void Main()
    {
        int[] number = { 1, 2, 3, 4, 5, 6, 7, 8 };

        var even = number.Where(x => x % 2 == 0);

        foreach (var n in even)
        {
            Console.WriteLine(n);
        }
    }
}