using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // List<Employee> employees = new List<Employee>();
        // List<Manager> managers = new List<Manager>();

        // Genericse<int> n = new Genericse<int>();
        // n.Print(100);

        // Genericse<string> n1 = new Genericse<string>();
        // n1.Print("Mamta");

        // Genericse<double> n2 = new Genericse<double>();
        // n2.Print(100.25);

        string empName = "kartik";
        Console.WriteLine(empName.ProperCase());

        // while (true)
        // {
        //     Console.WriteLine("\n===== Employee Management System =====");
        //     Console.WriteLine("1. Add Employee");
        //     Console.WriteLine("2. Add Manager");
        //     Console.WriteLine("3. View Employees");
        //     Console.WriteLine("4. View Managers");
        //     Console.WriteLine("5. Search Employee by Id");
        //     Console.WriteLine("6. Search Manager by Id");
        //     Console.WriteLine("7. Exit");

        //     Console.Write("Enter Choice : ");

        //     try
        //     {
        //         int choice = Convert.ToInt32(Console.ReadLine());

        //         switch (choice)
        //         {
        //             case 1:

        //                 Console.Write("Enter Employee Id : ");
        //                 int id = Convert.ToInt32(Console.ReadLine());

        //                 bool empExists = false;

        //                 foreach (Employee emp in employees)
        //                 {
        //                     if (emp.Id == id)
        //                     {
        //                         empExists = true;
        //                         break;
        //                     }
        //                 }

        //                 if (empExists)
        //                 {
        //                     Console.WriteLine("Employee Id Already Exists.");
        //                     break;
        //                 }

        //                 Console.Write("Enter Employee Name : ");
        //                 string name = Console.ReadLine();

        //                 Console.Write("Enter Salary : ");
        //                 double salary = Convert.ToDouble(Console.ReadLine());

        //                 Employee employee = new Employee(id, name, salary);

        //                 employees.Add(employee);

        //                 Console.WriteLine("Employee Added Successfully.");
        //                 break;

        //             case 2:

        //                 Console.Write("Enter Manager Id : ");
        //                 int mid = Convert.ToInt32(Console.ReadLine());

        //                 bool mgrExists = false;

        //                 foreach (Manager mgr in managers)
        //                 {
        //                     if (mgr.Id == mid)
        //                     {
        //                         mgrExists = true;
        //                         break;
        //                     }
        //                 }

        //                 if (mgrExists)
        //                 {
        //                     Console.WriteLine("Manager Id Already Exists.");
        //                     break;
        //                 }

        //                 Console.Write("Enter Manager Name : ");
        //                 string mname = Console.ReadLine();

        //                 Console.Write("Enter Salary : ");
        //                 double msalary = Convert.ToDouble(Console.ReadLine());

        //                 Console.Write("Enter Department : ");
        //                 string dept = Console.ReadLine();

        //                 Console.Write("Enter Bonus : ");
        //                 double bonus = Convert.ToDouble(Console.ReadLine());

        //                 Manager manager = new Manager(mid, mname, msalary, dept, bonus);

        //                 managers.Add(manager);

        //                 Console.WriteLine("Manager Added Successfully.");
        //                 break;

        //             case 3:

        //                 if (employees.Count == 0)
        //                 {
        //                     Console.WriteLine("No Employees Found.");
        //                 }
        //                 else
        //                 {
        //                     foreach (Employee emp in employees)
        //                     {
        //                         emp.Display();
        //                     }
        //                 }

        //                 break;

        //             case 4:

        //                 if (managers.Count == 0)
        //                 {
        //                     Console.WriteLine("No Managers Found.");
        //                 }
        //                 else
        //                 {
        //                     foreach (Manager mgr in managers)
        //                     {
        //                         mgr.DisplayManager();
        //                     }
        //                 }

        //                 break;

        //             case 5:

        //                 Console.Write("Enter Employee Id : ");
        //                 int searchId = Convert.ToInt32(Console.ReadLine());

        //                 bool foundEmp = false;

        //                 foreach (Employee emp in employees)
        //                 {
        //                     if (emp.Id == searchId)
        //                     {
        //                         emp.Display();
        //                         foundEmp = true;
        //                         break;
        //                     }
        //                 }

        //                 if (!foundEmp)
        //                 {
        //                     Console.WriteLine("Employee Not Found.");
        //                 }

        //                 break;

        //             case 6:

        //                 Console.Write("Enter Manager Id : ");
        //                 int searchManager = Convert.ToInt32(Console.ReadLine());

        //                 bool foundMgr = false;

        //                 foreach (Manager mgr in managers)
        //                 {
        //                     if (mgr.Id == searchManager)
        //                     {
        //                         mgr.DisplayManager();
        //                         foundMgr = true;
        //                         break;
        //                     }
        //                 }

        //                 if (!foundMgr)
        //                 {
        //                     Console.WriteLine("Manager Not Found.");
        //                 }

        //                 break;

        //             case 7:

        //                 Console.WriteLine("Thank You...");
        //                 return;

        //             default:

        //                 Console.WriteLine("Invalid Choice.");
        //                 break;
        //         }
        //     }
        //     catch (FormatException)
        //     {
        //         Console.WriteLine("Please Enter Numbers Only.");
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //     }
        // }
    }
}