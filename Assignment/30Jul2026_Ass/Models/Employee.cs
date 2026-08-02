using System.ComponentModel.DataAnnotations;

namespace _30Jul2026_Ass.Models
{
    public enum EmployeeStatus
    {
        Active,
        Inactive
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Email address is not in a valid format.")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Mobile number is not in a valid format.")]
        public string? MobileNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Salary cannot be negative.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Date of joining is required.")]
        public DateTime DateOfJoining { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public int DepartmentId { get; set; }

        [MaxLength(50, ErrorMessage = "Designation cannot exceed 50 characters.")]
        public string? Designation { get; set; }

        public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
    }
}
