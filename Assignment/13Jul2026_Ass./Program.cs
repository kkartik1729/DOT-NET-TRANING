using System;
using System.Collections.Generic;

namespace ShoppingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // ==========================
            // CUSTOMER REGISTRATION
            // ==========================

            Customer customer = new Customer();

            Console.WriteLine("===== CUSTOMER REGISTRATION =====");

            Console.Write("Enter Customer ID : ");
            customer.CustomerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name : ");
            customer.Name = Console.ReadLine();

            Console.Write("Enter Email : ");
            customer.Email = Console.ReadLine();

            Console.Write("Enter Password : ");
            customer.Password = Console.ReadLine();

            Console.WriteLine("\nRegistration Successful");

            // ==========================
            // LOGIN
            // ==========================

            bool loginSuccess = false;

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("\n===== LOGIN =====");

                Console.Write("Enter Email : ");
                string email = Console.ReadLine();

                Console.Write("Enter Password : ");
                string password = Console.ReadLine();

                if (email == customer.Email && password == customer.Password)
                {
                    Console.WriteLine($"\nWelcome {customer.Name}");
                    loginSuccess = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Email or Password");
                }
            }

            if (!loginSuccess)
            {
                Console.WriteLine("\nAccount Locked");
                return;
            }

            // ==========================
            // ADD PRODUCTS
            // ==========================

            List<Product> products = new List<Product>();

            Console.Write("\nHow many products do you want to add? ");
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Product p = new Product();

                Console.WriteLine($"\nProduct {i + 1}");

                Console.Write("Enter Product ID : ");
                p.ProductId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Product Name : ");
                p.ProductName = Console.ReadLine();

                Console.Write("Enter Price : ");
                p.Price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Stock : ");
                p.Stock = Convert.ToInt32(Console.ReadLine());

                products.Add(p);
            }

            // ==========================
            // DISPLAY PRODUCTS
            // ==========================

            Console.WriteLine("\n===== PRODUCT LIST =====");

            foreach (Product p in products)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"ID : {p.ProductId}");
                Console.WriteLine($"Name : {p.ProductName}");
                Console.WriteLine($"Price : {p.Price}");
                Console.WriteLine($"Stock : {p.Stock}");
            }

            // ==========================
            // SEARCH PRODUCT
            // ==========================

            Console.Write("\nEnter Product Name to Search : ");
            string searchName = Console.ReadLine();

            Product foundProduct = products.Find
            (
                x => x.ProductName.Equals(searchName,
                StringComparison.OrdinalIgnoreCase)
            );

            if (foundProduct != null)
            {
                Console.WriteLine("\nProduct Found");
                Console.WriteLine($"Product ID : {foundProduct.ProductId}");
                Console.WriteLine($"Product Name : {foundProduct.ProductName}");
                Console.WriteLine($"Price : {foundProduct.Price}");
                Console.WriteLine($"Stock : {foundProduct.Stock}");
            }
            else
            {
                Console.WriteLine("\nProduct Not Found");
            }

            // ==========================
            // ADD TO CART
            // ==========================

            List<CartItem> cart = new List<CartItem>();

            while (true)
            {
                Console.Write("\nEnter Product ID : ");
                int pid = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Quantity : ");
                int qty = Convert.ToInt32(Console.ReadLine());

                Product product = products.Find(x => x.ProductId == pid);

                if (product != null)
                {
                    if (product.Stock >= qty)
                    {
                        product.Stock -= qty;

                        CartItem item = new CartItem();

                        item.Product = product;
                        item.Quantity = qty;

                        cart.Add(item);

                        Console.WriteLine("Added to Cart");
                    }
                    else
                    {
                        Console.WriteLine("Stock Not Available");
                    }
                }
                else
                {
                    Console.WriteLine("Product Not Found");
                }

                Console.WriteLine();
                Console.WriteLine("Do you want to add another product?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 2)
                    break;
            }

            // ==========================
            // DISPLAY CART
            // ==========================

            Console.WriteLine("\n========== CART ==========");

            decimal totalAmount = 0;

            foreach (CartItem item in cart)
            {
                Console.WriteLine($"{item.Product.ProductName} x {item.Quantity}");

                totalAmount += item.Product.Price * item.Quantity;
            }

            // ==========================
            // DISCOUNT
            // ==========================

            decimal discount = 0;

            if (totalAmount < 1000)
            {
                discount = 0;
            }
            else if (totalAmount >= 1000 && totalAmount < 5000)
            {
                discount = totalAmount * 0.10m;
            }
            else if (totalAmount >= 5000 && totalAmount < 10000)
            {
                discount = totalAmount * 0.20m;
            }
            else
            {
                discount = totalAmount * 0.30m;
            }

            decimal finalAmount = totalAmount - discount;

            Console.WriteLine("\n========== BILL ==========");

            Console.WriteLine($"Total Amount : {totalAmount}");
            Console.WriteLine($"Discount     : {discount}");
            Console.WriteLine($"Final Amount : {finalAmount}");

            // ==========================
            // PAYMENT
            // ==========================

            Console.WriteLine("\nChoose Payment Method");
            Console.WriteLine("1. UPI");
            Console.WriteLine("2. Credit Card");
            Console.WriteLine("3. Debit Card");
            Console.WriteLine("4. Cash On Delivery");

            int payment = Convert.ToInt32(Console.ReadLine());

            switch (payment)
            {
                case 1:
                    Console.WriteLine("Payment Successful through UPI");
                    break;

                case 2:
                    Console.WriteLine("Payment Successful through Credit Card");
                    break;

                case 3:
                    Console.WriteLine("Payment Successful through Debit Card");
                    break;

                case 4:
                    Console.WriteLine("Payment Successful through Cash On Delivery");
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

            Console.WriteLine("\nThank You for Shopping.");
        }
    }
}