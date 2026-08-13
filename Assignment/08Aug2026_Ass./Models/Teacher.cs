using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _08Aug2026_Ass.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Experience is required")]
        [Range(1, 40, ErrorMessage = "Experience must be between 1 and 40 years")]
        public int Experience { get; set; }
        public ICollection<Course>? Courses { get; set; } = new List<Course>();
    }
}
