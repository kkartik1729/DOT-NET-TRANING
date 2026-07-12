using System;
using System.Collections.Generic;
using System.Linq;

public enum StudentType
{
    Regular,
    Scholarship,
    PartTime
}

public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string Department { get; set; }
    public StudentType Type { get; set; }

    public List<Course> Courses = new List<Course>();

    public int TotalCredits()
    {
        return Courses.Sum(c => c.Credits);
    }

    public double TotalFee()
    {
        return FeeCalculator.CalculateFee(Type, TotalCredits());
    }
}