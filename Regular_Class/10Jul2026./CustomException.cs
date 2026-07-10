using System;

class CustomException
{
    static void CheckAge(int age)
    {
        if (age < 20)
        {
            throw new InvalidAgeException("Age should be above 20 for Placement drive");
        }

        Console.WriteLine("Age is 20 and above, eligible for placement drive.");
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            CheckAge(age);
        }
        catch (InvalidAgeException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid age.");
        }
    }
}