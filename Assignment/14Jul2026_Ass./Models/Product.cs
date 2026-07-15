using System;

namespace StationeryStoreManagement.Models
{
    public abstract class Product
    {
        // Abstract method for discount calculation
        public abstract double CalculateDiscount(double totalAmount);
    }
}