using System.ComponentModel.DataAnnotations;

namespace _22Jul2026.Models
{
    public class Stationary
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Item Name is Mandatory")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Price is Mandatory")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Brand is Mandatory")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Quantity is Mandatory")]
        public int Quantity { get; set; }
    }
}