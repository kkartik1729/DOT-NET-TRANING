using System.ComponentModel.DataAnnotations;

namespace _30Jul2026_Ass.Models
{
    public enum DepartmentStatus
    {
        Active,
        Inactive
    }

    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [MaxLength(100, ErrorMessage = "Department name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(20, ErrorMessage = "Department code cannot exceed 20 characters.")]
        public string? Code { get; set; }

        public DepartmentStatus Status { get; set; } = DepartmentStatus.Active;
    }
}
