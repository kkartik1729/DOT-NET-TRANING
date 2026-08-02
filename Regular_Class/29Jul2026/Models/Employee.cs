using System.ComponentModel.DataAnnotations;

namespace _29Jul2026.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must contain at least 3 letters")]
        public string Name { get; set; }

        [Range(8, 10, ErrorMessage = "Number must be 8digit or 10 digits")]
        public long PhoneN { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "DeptId is required")]
        public int DeptId { get; set; }
    }
}