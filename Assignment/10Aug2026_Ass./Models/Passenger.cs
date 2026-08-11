using System.ComponentModel.DataAnnotations;

namespace _10Aug2026.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(15)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage ="the number is not correct")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage ="Email id is required")]
        [EmailAddress(ErrorMessage ="email id is not correct")]
        public string Email {  get; set; }

    }
}
