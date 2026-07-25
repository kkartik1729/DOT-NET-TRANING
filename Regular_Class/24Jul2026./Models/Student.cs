using System.ComponentModel.DataAnnotations;

namespace _24Jul2026.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}