using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Student> students = new List<Student>();
    static List<Course> courses = new List<Course>();

    const int MAX_COURSES = 5;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== STUDENT MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Add Course");
            Console.WriteLine("5. View Courses");
            Console.WriteLine("6. Register Course");
            Console.WriteLine("7. Display Student Details");
            Console.WriteLine("8. Exit");

            Console.Write("Enter Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterStudent();
                    break;

                case 2:
                    ViewStudents();
                    break;

                case 3:
                    SearchStudent();
                    break;

                case 4:
                    AddCourse();
                    break;

                case 5:
                    ViewCourses();
                    break;

                case 6:
                    RegisterCourse();
                    break;

                case 7:
                    DisplayStudentDetails();
                    break;

                case 8:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void RegisterStudent()
    {
        Student s = new Student();

        Console.Write("Student ID : ");
        s.StudentId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Student Name : ");
        s.StudentName = Console.ReadLine();

        Console.Write("Department : ");
        s.Department = Console.ReadLine();

        Console.WriteLine("Student Type");
        Console.WriteLine("1. Regular");
        Console.WriteLine("2. Scholarship");
        Console.WriteLine("3. PartTime");

        Console.Write("Choice : ");
        int type = Convert.ToInt32(Console.ReadLine());

        switch (type)
        {
            case 1:
                s.Type = StudentType.Regular;
                break;

            case 2:
                s.Type = StudentType.Scholarship;
                break;

            case 3:
                s.Type = StudentType.PartTime;
                break;
        }

        students.Add(s);

        Console.WriteLine("Student Registered Successfully.");
    }

    static void ViewStudents()
    {
        foreach (Student s in students)
        {
            Console.WriteLine($"{s.StudentId} {s.StudentName} {s.Department} {s.Type}");
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter Student ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Student s = students.Find(x => x.StudentId == id);

        if (s != null)
        {
            Console.WriteLine($"{s.StudentId} {s.StudentName} {s.Department} {s.Type}");
        }
        else
        {
            Console.WriteLine("Student Not Found");
        }
    }

    static void AddCourse()
    {
        Course c = new Course();

        Console.Write("Course ID : ");
        c.CourseId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Course Name : ");
        c.CourseName = Console.ReadLine();

        Console.Write("Credits : ");
        c.Credits = Convert.ToInt32(Console.ReadLine());

        courses.Add(c);

        Console.WriteLine("Course Added Successfully.");
    }

    static void ViewCourses()
    {
        foreach (Course c in courses)
        {
            Console.WriteLine($"{c.CourseId} {c.CourseName} Credits:{c.Credits}");
        }
    }

    static void RegisterCourse()
    {
        Console.Write("Student ID : ");
        int sid = Convert.ToInt32(Console.ReadLine());

        Student s = students.Find(x => x.StudentId == sid);

        if (s == null)
        {
            Console.WriteLine("Student Not Found");
            return;
        }

        if (s.Courses.Count >= MAX_COURSES)
        {
            Console.WriteLine("Maximum Course Limit Reached.");
            return;
        }

        Console.Write("Course ID : ");
        int cid = Convert.ToInt32(Console.ReadLine());

        Course c = courses.Find(x => x.CourseId == cid);

        if (c == null)
        {
            Console.WriteLine("Course Not Found");
            return;
        }

        if (s.Courses.Any(x => x.CourseId == cid))
        {
            Console.WriteLine("Duplicate Course Registration Not Allowed.");
            return;
        }

        s.Courses.Add(c);

        Console.WriteLine("Course Registered Successfully.");
    }

    static void DisplayStudentDetails()
    {
        Console.Write("Student ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Student s = students.Find(x => x.StudentId == id);

        if (s == null)
        {
            Console.WriteLine("Student Not Found");
            return;
        }

        Console.WriteLine("\nStudent Details");
        Console.WriteLine("---------------------");
        Console.WriteLine("ID : " + s.StudentId);
        Console.WriteLine("Name : " + s.StudentName);
        Console.WriteLine("Department : " + s.Department);
        Console.WriteLine("Type : " + s.Type);

        Console.WriteLine("\nEnrolled Courses");

        foreach (Course c in s.Courses)
        {
            Console.WriteLine($"{c.CourseId} {c.CourseName} Credits:{c.Credits}");
        }

        Console.WriteLine("Total Credits : " + s.TotalCredits());
        Console.WriteLine("Total Fee : " + s.TotalFee());
    }
}