namespace _29Jul2026_Ass.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VehicleNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Type { get; set; } = string.Empty; // e.g. Car, Bike, Truck
        public bool IsAvailable { get; set; }
    }
}
