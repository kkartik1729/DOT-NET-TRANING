using _29Jul2026.Models;

namespace _29Jul2026.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 101,
                Name = "Kartik",
                PhoneN = 9876543210,
                Email = "kartik@gmail.com",
                DeptId = 11
            },

            new Employee
            {
                Id = 102,
                Name = "Pratik",
                PhoneN = 9876543211,
                Email = "pratik@gmail.com",
                DeptId = 12
            },

            new Employee
            {
                Id = 103,
                Name = "Ram",
                PhoneN = 9876543212,
                Email = "ram@gmail.com",
                DeptId = 13
            }
        };

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee? GetEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee? GetEmployee(string name)
        {
            return employees.FirstOrDefault(e => e.Name == name);
        }

        public Employee AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return employee;
        }

        public Employee? UpdateEmployee(Employee employee)
        {
            var emp = employees.FirstOrDefault(e => e.Id == employee.Id);

            if (emp == null)
                return null;

            emp.Name = employee.Name;
            emp.PhoneN = employee.PhoneN;
            emp.Email = employee.Email;
            emp.DeptId = employee.DeptId;

            return emp;
        }

        public bool DeleteEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
                return false;

            employees.Remove(emp);
            return true;
        }
    }
}