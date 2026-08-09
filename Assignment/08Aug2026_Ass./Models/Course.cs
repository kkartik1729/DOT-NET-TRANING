using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace _08Aug2026_Ass.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "CourseName is required")]
        [MaxLength(100, ErrorMessage = "CourseName cannot exceed 100 characters")]
        public string CourseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 24, ErrorMessage = "Duration must be between 1 and 24 months")]
        public int Duration { get; set; }

        // One Teacher -> Many Courses (FK)
        [Required(ErrorMessage = "TeacherId is required")]
        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher? Teacher { get; set; }

        // Many Students <-> Many Courses
        [JsonIgnore]
        public ICollection<Student>? Students { get; set; } = new List<Student>();
    }
}