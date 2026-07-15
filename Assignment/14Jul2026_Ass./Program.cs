using System;
using StationeryStoreManagement.Models;
using StationeryStoreManagement.Services;
using StationeryStoreManagement.Exceptions;

namespace StationeryStoreManagement
{
    class Program
    {
        static StationeryStore store = new StationeryStore();

        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("      STATIONERY STORE MANAGEMENT SYSTEM");
            Console.WriteLine("==============================================");

            if (!Login())
            {
                return;
            }

            bool exit = false;

            while (!exit)
            {
                try
                {
                    ShowMenu();
                    int choice = ReadInt("Enter your choice: ");

                    switch (choice)
                    {
                        case 1:
                            AddItem();
                            break;
                        case 2:
                            store.DisplayItems();
                            break;
                        case 3:
                            SearchItem();
                            break;
                        case 4:
                            UpdateItem();
                            break;
                        case 5:
                            DeleteItem();
                            break;
                        case 6:
                            PurchaseItem();
                            break;
                        case 7:
                            store.ViewLowStockItems();
                            break;
                        case 8:
                            store.SortByPrice();
                            break;
                        case 9:
                            store.SortByName();
                            break;
                        case 10:
                            store.SortByQuantity();
                            break;
                        case 0:
                            exit = true;
                            Console.WriteLine("\nThank you for using Stationery Store Management System.");
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice. Please try again.");
                            break;
                    }
                }
                catch (DuplicateItemException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
                catch (InvalidPriceException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
                catch (InvalidQuantityException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
                catch (ItemNotFoundException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
                catch (InsufficientStockException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nUnexpected Error: {ex.Message}");
                }
            }
        }

        // ---------------- LOGIN ----------------
        static bool Login()
        {
            const string validUsername = "admin";
            const string validPassword = "admin123";

            int attempts = 0;

            try
            {
                while (attempts < 3)
                {
                    Console.Write("\nUsername: ");
                    string username = Console.ReadLine();

                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    if (username == validUsername && password == validPassword)
                    {
                        Console.WriteLine("\nLogin Successful!");
                        return true;
                    }

                    attempts++;
                    Console.WriteLine($"Invalid username or password. Attempts left: {3 - attempts}");
                }

                throw new LoginFailedException();
            }
            catch (LoginFailedException ex)
            {
                Console.WriteLine($"\n{ex.Message}");
                return false;
            }
        }

        // ---------------- MENU ----------------
        static void ShowMenu()
        {
            Console.WriteLine("\n================= MAIN MENU =================");
            Console.WriteLine("1.  Add Item");
            Console.WriteLine("2.  Display All Items");
            Console.WriteLine("3.  Search Item");
            Console.WriteLine("4.  Update Item");
            Console.WriteLine("5.  Delete Item");
            Console.WriteLine("6.  Purchase Item / Generate Bill");
            Console.WriteLine("7.  View Low Stock Items");
            Console.WriteLine("8.  Sort By Price");
            Console.WriteLine("9.  Sort By Name");
            Console.WriteLine("10. Sort By Quantity");
            Console.WriteLine("0.  Exit");
            Console.WriteLine("===============================================");
        }

        // ---------------- ADD ITEM ----------------
        static void AddItem()
        {
            Console.WriteLine("\nSelect Item Type:");
            Console.WriteLine("1. Pen");
            Console.WriteLine("2. Notebook");
            Console.WriteLine("3. Marker");

            int type = ReadInt("Enter choice: ");

            int id = ReadInt("Enter Item ID: ");

            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();

            double price = ReadDouble("Enter Price: ");
            int quantity = ReadInt("Enter Quantity: ");

            StationeryItem item;

            switch (type)
            {
                case 1:
                    Console.Write("Enter Ink Color: ");
                    string inkColor = Console.ReadLine();
                    Console.Write("Enter Pen Type: ");
                    string penType = Console.ReadLine();

                    item = new Pen
                    {
                        InkColor = inkColor,
                        PenType = penType
                    };
                    break;

                case 2:
                    int pages = ReadInt("Enter Number of Pages: ");
                    Console.Write("Enter Paper Type: ");
                    string paperType = Console.ReadLine();

                    item = new Notebook
                    {
                        Pages = pages,
                        PaperType = paperType
                    };
                    break;

                case 3:
                    Console.Write("Is it Permanent? (Y/N): ");
                    bool permanent = Console.ReadLine().Trim().Equals("Y", StringComparison.OrdinalIgnoreCase);

                    item = new Marker
                    {
                        Permanent = permanent
                    };
                    break;

                default:
                    Console.WriteLine("\nInvalid item type selected.");
                    return;
            }

            item.ItemId = id;
            item.ItemName = name;
            item.Category = category;
            item.Brand = brand;
            item.Price = price;
            item.Quantity = quantity;

            store.AddItem(item);
        }

        // ---------------- SEARCH ----------------
        static void SearchItem()
        {
            Console.WriteLine("\nSearch By:");
            Console.WriteLine("1. ID");
            Console.WriteLine("2. Name");

            int choice = ReadInt("Enter choice: ");

            StationeryItem item = null;

            if (choice == 1)
            {
                int id = ReadInt("Enter Item ID: ");
                item = store.SearchById(id);
            }
            else if (choice == 2)
            {
                Console.Write("Enter Item Name: ");
                string name = Console.ReadLine();
                item = store.SearchByName(name);
            }
            else
            {
                Console.WriteLine("\nInvalid choice.");
                return;
            }

            item.DisplayDetails();
        }

        // ---------------- UPDATE ----------------
        static void UpdateItem()
        {
            int id = ReadInt("Enter Item ID to Update: ");

            double newPrice = ReadDouble("Enter New Price: ");
            int newQuantity = ReadInt("Enter New Quantity: ");

            Console.Write("Enter New Brand: ");
            string newBrand = Console.ReadLine();

            store.UpdateItem(id, newPrice, newQuantity, newBrand);
        }

        // ---------------- DELETE ----------------
        static void DeleteItem()
        {
            int id = ReadInt("Enter Item ID to Delete: ");
            store.DeleteItem(id);
        }

        // ---------------- PURCHASE ----------------
        static void PurchaseItem()
        {
            int id = ReadInt("Enter Item ID to Purchase: ");
            int qty = ReadInt("Enter Quantity to Purchase: ");

            store.PurchaseItem(id, qty);
        }

        // ---------------- INPUT HELPERS ----------------
        static int ReadInt(string prompt)
        {
            int value;

            while (true)
            {
                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static double ReadDouble(string prompt)
        {
            double value;

            while (true)
            {
                Console.Write(prompt);

                if (double.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}