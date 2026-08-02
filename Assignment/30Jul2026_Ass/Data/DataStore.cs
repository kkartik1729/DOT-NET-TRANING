using _30Jul2026_Ass.Models;

namespace _30Jul2026_Ass.Data
{
    /// <summary>
    /// Simple in-memory data store shared between DepartmentController and EmployeeController.
    /// </summary>
    public static class DataStore
    {
        public static List<Department> Departments { get; set; } = new List<Department>
        {
            new Department { Id = 1, Name = "Human Resources", Code = "HR", Status = DepartmentStatus.Active },
            new Department { Id = 2, Name = "Information Technology", Code = "IT", Status = DepartmentStatus.Active },
            new Department { Id = 3, Name = "Finance", Code = "FIN", Status = DepartmentStatus.Active },
            new Department { Id = 4, Name = "Sales", Code = "SALES", Status = DepartmentStatus.Active },
            new Department { Id = 5, Name = "Operations", Code = "OPS", Status = DepartmentStatus.Active }
        };

        public static List<Employee> Employees { get; set; } = new List<Employee>
        {
            new Employee
            {
                EmployeeId = 1,
                FirstName = "Aarav",
                LastName = "Sharma",
                Email = "aarav.sharma@company.com",
                MobileNumber = "9876543210",
                DateOfBirth = new DateTime(1995, 4, 12),
                Gender = Gender.Male,
                Salary = 45000,
                DateOfJoining = new DateTime(2022, 6, 1),
                DepartmentId = 2,
                Designation = "Software Engineer",
                Status = EmployeeStatus.Active
            },
            new Employee
            {
                EmployeeId = 2,
                FirstName = "Priya",
                LastName = "Verma",
                Email = "priya.verma@company.com",
                MobileNumber = "9876500001",
                DateOfBirth = new DateTime(1993, 9, 21),
                Gender = Gender.Female,
                Salary = 52000,
                DateOfJoining = new DateTime(2021, 1, 15),
                DepartmentId = 1,
                Designation = "HR Manager",
                Status = EmployeeStatus.Active
            }
        };

        public static int NextDepartmentId => Departments.Count == 0 ? 1 : Departments.Max(d => d.Id) + 1;

        public static int NextEmployeeId => Employees.Count == 0 ? 1 : Employees.Max(e => e.EmployeeId) + 1;
    }
}
