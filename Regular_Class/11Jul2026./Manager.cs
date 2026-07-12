using System;

public class Manager : Employee
{
    public string Dept;
    public double Bonus;

    public Manager(int id, string name, double salary, string dept, double bonus)
        : base(id, name, salary)
    {
        Dept = dept;
        Bonus = bonus;
    }

    public void DisplayManager()
    {
        Display();
        Console.WriteLine("Department : " + Dept);
        Console.WriteLine("Bonus : " + Bonus);
        Console.WriteLine("---------------------------");
    }
}