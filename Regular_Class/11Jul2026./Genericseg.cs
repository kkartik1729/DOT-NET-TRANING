using System;
class Genericseg
{
    void printt(int number)
    {
        Console.WriteLine(number);
    }

    void printt1(string namee)
    {
        Console.WriteLine(namee);
    }
    public class Genericse<T>
    {
        public void Print(T value)
        {
            Console.WriteLine(value);
        }
    }
}