using System;

class LambdaExp
{
    static void Main()
    {
        Func<int, int> square = x => x * x;

        Console.WriteLine(square(6));

        Func<int, int, int> subb = (a, b) => a - b;

        Console.WriteLine(subb(10, 20));
    }
}