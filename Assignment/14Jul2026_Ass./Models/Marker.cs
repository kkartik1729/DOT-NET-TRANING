using System;

namespace StationeryStoreManagement.Models
{
    public class Marker : StationeryItem
    {
        public bool Permanent { get; set; }

        public override void DisplayDetails()
        {
            base.DisplayDetails();

            Console.WriteLine($"Permanent : {(Permanent ? "Yes" : "No")}");
            Console.WriteLine("--------------------------------------------");
        }

        public override double CalculateDiscount(double totalAmount)
        {
            // 8% Discount
            return totalAmount * 0.08;
        }
    }
}