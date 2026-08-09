using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _08Aug2026_Ass.Models
{
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }

        [Required(ErrorMessage = "BatchName is required")]
        [MaxLength(100, ErrorMessage = "BatchName cannot exceed 100 characters")]
        public string BatchName { get; set; } = string.Empty;

        [Required(ErrorMessage = "StartDate is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        // One Batch -> Many Students
        [JsonIgnore]
        public ICollection<Student>? Students { get; set; } = new List<Student>();
    }
}