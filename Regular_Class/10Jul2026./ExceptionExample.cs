using System;

class ExceptionExample
{
    static void Main()
    {
        try
        {
            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            if (age < 20)
            {
                throw new System.Exception("Not eligible for placement drive");
            }

            Console.WriteLine("Eligible for placement drive.");

            int a = 10;
            int b = 5;
            int c = a / b;

            Console.WriteLine("Result = " + c);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Program Finished.");
        }
    }
}