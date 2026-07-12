using System;

public class Employee
{
    public int Id { get; set; }
    public string EmpName { get; set; }
    public double MonthlySalary { get; set; }

    public Employee(int id, string name, double salary)
    {
        Id = id;
        EmpName = name;
        MonthlySalary = salary;
    }

    public double CalculateAnnualSalary()
    {
        return MonthlySalary * 12;
    }

    public void Display()
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("Id : " + Id);
        Console.WriteLine("Name : " + EmpName);
        Console.WriteLine("Monthly Salary : " + MonthlySalary);
        Console.WriteLine("Annual Salary : " + CalculateAnnualSalary());
    }
}