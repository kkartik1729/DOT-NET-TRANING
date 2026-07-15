using System;
using StationeryStoreManagement.Exceptions;

namespace StationeryStoreManagement.Models
{
    public class StationeryItem : Product
    {
        private int itemId;
        private string itemName;
        private string category;
        private string brand;
        private double price;
        private int quantity;

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                    throw new InvalidPriceException();

                price = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value <= 0)
                    throw new InvalidQuantityException();

                quantity = value;
            }
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Item ID   : {ItemId}");
            Console.WriteLine($"Name      : {ItemName}");
            Console.WriteLine($"Category  : {Category}");
            Console.WriteLine($"Brand     : {Brand}");
            Console.WriteLine($"Price     : ₹{Price}");
            Console.WriteLine($"Quantity  : {Quantity}");
        }

        public void UpdateQuantity(int qty)
        {
            Quantity = qty;
        }

        public override double CalculateDiscount(double totalAmount)
        {
            return 0;
        }
    }
}