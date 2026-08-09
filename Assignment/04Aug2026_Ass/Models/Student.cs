using System.ComponentModel.DataAnnotations;

namespace _04Aug2026_Ass.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, ErrorMessage = "Name max length is 25 letters only", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 25, ErrorMessage = "Age must be 18 to 25 only")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not correct")]
        public string Email { get; set; } = string.Empty;
    }
}
