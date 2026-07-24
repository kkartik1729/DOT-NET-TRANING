using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [Required(ErrorMessage = "Department name is required.")]
        [Display(Name = "Department Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department head is required.")]
        [Display(Name = "Department Head")]
        public string DepartmentHead { get; set; } = string.Empty;

        [Required(ErrorMessage = "Head contact number is required.")]
        [Phone(ErrorMessage = "Please enter a valid contact number.")]
        [Display(Name = "Head Contact Number")]
        public string HeadContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Head email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Head Email")]
        public string HeadEmail { get; set; } = string.Empty;
    }
}
