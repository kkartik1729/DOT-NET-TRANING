using System.ComponentModel.DataAnnotations;

namespace AutomobileManagementSystem.Models
{
    public class Automobile
    {
        [Required(ErrorMessage = "Vehicle ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Vehicle ID must be a positive number.")]
        [Display(Name = "Vehicle ID")]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Vehicle name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Vehicle name must be between 2 and 100 characters.")]
        [Display(Name = "Vehicle Name")]
        public string VehicleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Brand must be between 2 and 50 characters.")]
        [Display(Name = "Brand")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model year is required.")]
        [Range(1980, 2035, ErrorMessage = "Model year must be between 1980 and 2035.")]
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Fuel type is required.")]
        [RegularExpression("^(Petrol|Diesel|Electric|Hybrid|CNG)$",
            ErrorMessage = "Fuel type must be Petrol, Diesel, Electric, Hybrid or CNG.")]
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; } = string.Empty;
    }
}
