using System;

class Jul082026_Ass1
{
    public void Display()
    {

        // Array to store monthly sales of 6 employees
        int[] sales = { 25000, 30000, 18000, 45000, 27000, 35000 };

        int total = 0;
        int highest = sales[0];
        int lowest = sales[0];

        Console.WriteLine("Monthly Sales of Employees:");

        foreach (int amount in sales)
        {
            Console.WriteLine("₹" + amount);

            total += amount;

            if (amount > highest)
                highest = amount;

            if (amount < lowest)
                lowest = amount;
        }

        double average = (double)total / sales.Length;

        Console.WriteLine("\nTotal Sales = ₹" + total);
        Console.WriteLine("Average Sales = ₹" + average);
        Console.WriteLine("Highest Sales = ₹" + highest);
        Console.WriteLine("Lowest Sales = ₹" + lowest);
    }
}
