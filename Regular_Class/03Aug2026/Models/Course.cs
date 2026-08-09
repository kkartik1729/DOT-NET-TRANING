using System.ComponentModel.DataAnnotations;

namespace _3Aug.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        [StringLength(50, ErrorMessage = "Course name cannot exceed 50 characters")]
        public string CourseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course Duration is required")]
        public string Duration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course Fee is required")]
        [Range(1000, 1000000, ErrorMessage = "Invalid course fee")]
        public decimal Fee { get; set; }

        [Required(ErrorMessage = "Course Description is required")]
        public string Description { get; set; } = string.Empty;
    }
}