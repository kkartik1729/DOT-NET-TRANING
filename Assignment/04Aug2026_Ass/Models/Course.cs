using System.ComponentModel.DataAnnotations;

namespace _04Aug2026_Ass.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        [StringLength(50)]
        public string CourseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student Name is required")]
        [StringLength(30)]
        public string StudentName { get; set; } = string.Empty;
    }
}
