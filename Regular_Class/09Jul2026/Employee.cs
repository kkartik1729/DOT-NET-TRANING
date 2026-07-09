using System;

class Employee
{
    private string _empName = "";
    private double _salary;

    public string EmpName
    {
        get
        {
            return _empName;
        }
        set
        {
            _empName = value;
        }
    }

    public double Salary
    {
        get
        {
            return _salary;
        }
        set
        {
            if (value >= 100)
            {
                _salary = value;
            }
        }
    }
}