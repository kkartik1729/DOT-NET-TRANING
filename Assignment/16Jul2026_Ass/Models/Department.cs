namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DepartmentHead { get; set; } = string.Empty;
        public string HeadContact { get; set; } = string.Empty;
        public string HeadEmail { get; set; } = string.Empty;
    }
}
