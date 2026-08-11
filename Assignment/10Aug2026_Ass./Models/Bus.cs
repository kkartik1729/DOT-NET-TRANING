using System.ComponentModel.DataAnnotations;

namespace _10Aug2026.Models
{
    public class Bus
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bus number is required")]
        [StringLength(50)]
        public string BusNumber {  get; set; }

        [Required(ErrorMessage ="total sets are required")]
        [Range(1,50)]
        public int TotalSeats {  get; set; }

        public string BusType { get; set; } = string.Empty;
    }
}
