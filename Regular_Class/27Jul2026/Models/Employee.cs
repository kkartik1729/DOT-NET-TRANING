using System.ComponentModel.DataAnnotations;

namespace _27Jul2026.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Employee Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 25 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employee Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [StringLength(25)]
        public string Dept { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNum { get; set; }
    }
}