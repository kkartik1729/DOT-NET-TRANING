using System;
using System.Collections.Generic;
using System.Linq;
using StationeryStoreManagement.Models;
using StationeryStoreManagement.Exceptions;
using StationeryStoreManagement.Interfaces;

namespace StationeryStoreManagement.Services
{
    public class StationeryStore : IBill
    {
        private List<StationeryItem> items = new List<StationeryItem>();

        private StationeryItem purchasedItem;
        private int purchasedQuantity;

        // Add Item
        public void AddItem(StationeryItem item)
        {
            if (items.Any(i => i.ItemId == item.ItemId))
                throw new DuplicateItemException();

            items.Add(item);

            Console.WriteLine("\nItem Added Successfully.");
        }

        // Display All Items
        public void DisplayItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("\nNo Items Available.");
                return;
            }

            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("ID\tName\tCategory\tBrand\tPrice\tQty");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var item in items)
            {
                Console.WriteLine($"{item.ItemId}\t{item.ItemName}\t{item.Category}\t{item.Brand}\t{item.Price}\t{item.Quantity}");
            }

            Console.WriteLine("-------------------------------------------------------------");
        }

        // Search by ID
        public StationeryItem SearchById(int id)
        {
            var item = items.FirstOrDefault(i => i.ItemId == id);

            if (item == null)
                throw new ItemNotFoundException();

            return item;
        }

        // Search by Name
        public StationeryItem SearchByName(string name)
        {
            var item = items.FirstOrDefault(i =>
                i.ItemName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (item == null)
                throw new ItemNotFoundException();

            return item;
        }

        // Update Item
        public void UpdateItem(int id, double newPrice, int newQuantity, string newBrand)
        {
            StationeryItem item = SearchById(id);

            item.Price = newPrice;
            item.Quantity = newQuantity;
            item.Brand = newBrand;

            Console.WriteLine("\nItem Updated Successfully.");
        }

        // Delete Item
        public void DeleteItem(int id)
        {
            StationeryItem item = SearchById(id);

            Console.Write("\nAre you sure you want to delete this item? (Y/N): ");
            string choice = Console.ReadLine();

            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                items.Remove(item);
                Console.WriteLine("Item Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Delete Operation Cancelled.");
            }
        }

        // Purchase Item
        public void PurchaseItem(int id, int qty)
        {
            StationeryItem item = SearchById(id);

            if (qty > item.Quantity)
                throw new InsufficientStockException();

            item.Quantity -= qty;

            purchasedItem = item;
            purchasedQuantity = qty;

            GenerateBill();
        }

        // Generate Bill
        public void GenerateBill()
        {
            double subTotal = purchasedItem.Price * purchasedQuantity;

            double discount = purchasedItem.CalculateDiscount(subTotal);

            double amountAfterDiscount = subTotal - discount;

            double gst = amountAfterDiscount * 0.18;

            double total = amountAfterDiscount + gst;

            Console.WriteLine("\n==============================================");
            Console.WriteLine("              STATIONERY STORE BILL");
            Console.WriteLine("==============================================");

            Console.WriteLine($"Item Name : {purchasedItem.ItemName}");
            Console.WriteLine($"Price     : ₹{purchasedItem.Price}");
            Console.WriteLine($"Quantity  : {purchasedQuantity}");

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine($"Sub Total : ₹{subTotal}");
            Console.WriteLine($"Discount  : ₹{discount}");
            Console.WriteLine($"GST (18%) : ₹{gst}");

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine($"Total     : ₹{total}");

            Console.WriteLine("==============================================");
        }

        // View Low Stock Items
        public void ViewLowStockItems()
        {
            var lowStockItems = items.Where(i => i.Quantity < 5).ToList();

            if (lowStockItems.Count == 0)
            {
                Console.WriteLine("\nNo Low Stock Items Found.");
                return;
            }

            Console.WriteLine("\n========== LOW STOCK ITEMS ==========");

            foreach (var item in lowStockItems)
            {
                item.DisplayDetails();
            }
        }

        // Sort By Price
        public void SortByPrice()
        {
            items = items.OrderBy(i => i.Price).ToList();

            Console.WriteLine("\nItems Sorted By Price.");

            DisplayItems();
        }

        // Sort By Name
        public void SortByName()
        {
            items = items.OrderBy(i => i.ItemName).ToList();

            Console.WriteLine("\nItems Sorted By Name.");

            DisplayItems();
        }

        // Sort By Quantity
        public void SortByQuantity()
        {
            items = items.OrderByDescending(i => i.Quantity).ToList();

            Console.WriteLine("\nItems Sorted By Quantity.");

            DisplayItems();
        }

        // Return Item List
        public List<StationeryItem> GetItems()
        {
            return items;
        }
    }
}