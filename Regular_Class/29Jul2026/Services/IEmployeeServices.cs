using _29Jul2026.Models;

namespace _29Jul2026.Services
{
    public interface IEmployeeServices
    {
        List<Employee> GetEmployees();

        Employee? GetEmployee(int id);

        Employee? GetEmployee(string name);

        Employee AddEmployee(Employee employee);

        Employee? UpdateEmployee(Employee employee);

        bool DeleteEmployee(int id);
    }
}