using ShopEaseConsoleApp.Models;
using ShopEaseConsoleApp.Services;
using ShopEaseConsoleApp.Utils;

// ------------------------------------------------------------
// ShopEase Console Application - 17Jul2026_Ass
// A lightweight console-based e-commerce management system
// demonstrating clean architecture and OOP principles.
// ------------------------------------------------------------

var authService = new AuthService();
var productService = new ProductService();
var categoryService = new CategoryService();
var cartService = new CartService();
var orderService = new OrderService(productService);
var paymentService = new PaymentService();
var invoiceService = new InvoiceService();
var reportService = new ReportService();

RunWelcomeMenu();

// =========================================================
// Top level menu: Register / Login / Admin Login / Exit
// =========================================================
void RunWelcomeMenu()
{
    bool exit = false;
    while (!exit)
    {
        ConsoleHelper.PrintHeader("Welcome to ShopEase");
        Console.WriteLine("1. Customer Register");
        Console.WriteLine("2. Customer Login");
        Console.WriteLine("3. Admin Login");
        Console.WriteLine("4. Exit");
        int choice = ConsoleHelper.ReadInt("Choose an option: ");

        switch (choice)
        {
            case 1: RegisterCustomer(); break;
            case 2: CustomerLogin(); break;
            case 3: AdminLogin(); break;
            case 4: exit = true; break;
            default: ConsoleHelper.PrintError("Invalid choice."); ConsoleHelper.Pause(); break;
        }
    }
    Console.WriteLine("Thank you for visiting ShopEase. Goodbye!");
}

void RegisterCustomer()
{
    ConsoleHelper.PrintHeader("Customer Registration");
    string name = ConsoleHelper.ReadNonEmptyString("Full Name: ");
    string username = ConsoleHelper.ReadNonEmptyString("Choose Username: ");
    string password = ConsoleHelper.ReadNonEmptyString("Choose Password: ");
    string email = ConsoleHelper.ReadNonEmptyString("Email: ");
    string phone = ConsoleHelper.ReadNonEmptyString("Phone: ");
    string address = ConsoleHelper.ReadNonEmptyString("Address: ");

    try
    {
        var customer = authService.Register(name, username, password, email, phone, address);
        ConsoleHelper.PrintSuccess($"Registration successful! Your Customer Id is {customer.Id}.");
    }
    catch (Exception ex)
    {
        ConsoleHelper.PrintError(ex.Message);
    }
    ConsoleHelper.Pause();
}

void CustomerLogin()
{
    ConsoleHelper.PrintHeader("Customer Login");
    string username = ConsoleHelper.ReadNonEmptyString("Username: ");
    string password = ConsoleHelper.ReadNonEmptyString("Password: ");

    var customer = authService.Login(username, password);
    if (customer == null)
    {
        ConsoleHelper.PrintError("Invalid username or password.");
        ConsoleHelper.Pause();
        return;
    }

    ConsoleHelper.PrintSuccess($"Welcome back, {customer.Name}!");
    ConsoleHelper.Pause();
    RunCustomerDashboard(customer);
}

void AdminLogin()
{
    ConsoleHelper.PrintHeader("Admin Login");
    string username = ConsoleHelper.ReadNonEmptyString("Username: ");
    string password = ConsoleHelper.ReadNonEmptyString("Password: ");

    if (!authService.AdminLogin(username, password))
    {
        ConsoleHelper.PrintError("Invalid admin credentials.");
        ConsoleHelper.Pause();
        return;
    }

    ConsoleHelper.PrintSuccess("Admin login successful!");
    ConsoleHelper.Pause();
    RunAdminDashboard();
}

// =========================================================
// Admin Dashboard
// =========================================================
void RunAdminDashboard()
{
    bool back = false;
    while (!back)
    {
        ConsoleHelper.PrintHeader("Admin Dashboard");
        Console.WriteLine("1. Product Management");
        Console.WriteLine("2. Category Management");
        Console.WriteLine("3. View All Orders");
        Console.WriteLine("4. Reports");
        Console.WriteLine("5. Logout");
        int choice = ConsoleHelper.ReadInt("Choose an option: ");

        switch (choice)
        {
            case 1: RunProductManagement(); break;
            case 2: RunCategoryManagement(); break;
            case 3: ViewAllOrders(); break;
            case 4: ShowReports(); break;
            case 5: authService.Logout(); back = true; break;
            default: ConsoleHelper.PrintError("Invalid choice."); ConsoleHelper.Pause(); break;
        }
    }
}

void RunProductManagement()
{
    bool back = false;
    while (!back)
    {
        ConsoleHelper.PrintHeader("Product Management");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. Update Product");
        Console.WriteLine("3. Delete Product");
        Console.WriteLine("4. Search Product");
        Console.WriteLine("5. View All Products");
        Console.WriteLine("6. Back");
        int choice = ConsoleHelper.ReadInt("Choose an option: ");

        switch (choice)
        {
            case 1: AddProduct(); break;
            case 2: UpdateProduct(); break;
            case 3: DeleteProduct(); break;
            case 4: SearchProduct(); break;
            case 5: ViewAllProducts(); break;
            case 6: back = true; break;
            default: ConsoleHelper.PrintError("Invalid choice."); ConsoleHelper.Pause(); break;
        }
    }
}

void AddProduct()
{
    ConsoleHelper.PrintHeader("Add Product");
    string name = ConsoleHelper.ReadNonEmptyString("Name: ");
    ShowCategories();
    string category = ConsoleHelper.ReadNonEmptyString("Category: ");
    string description = ConsoleHelper.ReadNonEmptyString("Description: ");
    decimal price = ConsoleHelper.ReadDecimal("Price: ");
    int quantity = ConsoleHelper.ReadInt("Quantity: ");
    string brand = ConsoleHelper.ReadNonEmptyString("Brand: ");
    decimal discount = ConsoleHelper.ReadDecimal("Discount (%): ");
    double rating = ConsoleHelper.ReadDouble("Rating (0-5): ");

    var product = productService.Add(name, category, description, price, quantity, brand, discount, rating);
    ConsoleHelper.PrintSuccess($"Product added with Id {product.Id}.");
    ConsoleHelper.Pause();
}

void UpdateProduct()
{
    ConsoleHelper.PrintHeader("Update Product");
    int id = ConsoleHelper.ReadInt("Enter Product Id: ");
    var existing = productService.GetById(id);
    if (existing == null)
    {
        ConsoleHelper.PrintError("Product not found.");
        ConsoleHelper.Pause();
        return;
    }

    Console.WriteLine($"Current details: {existing}");
    string name = ConsoleHelper.ReadNonEmptyString($"New Name [{existing.Name}]: ");
    string category = ConsoleHelper.ReadNonEmptyString($"New Category [{existing.Category}]: ");
    string description = ConsoleHelper.ReadNonEmptyString($"New Description [{existing.Description}]: ");
    decimal price = ConsoleHelper.ReadDecimal("New Price: ");
    int quantity = ConsoleHelper.ReadInt("New Quantity: ");
    string brand = ConsoleHelper.ReadNonEmptyString("New Brand: ");
    decimal discount = ConsoleHelper.ReadDecimal("New Discount (%): ");
    double rating = ConsoleHelper.ReadDouble("New Rating (0-5): ");

    productService.Update(id, name, category, description, price, quantity, brand, discount, rating);
    ConsoleHelper.PrintSuccess("Product updated successfully.");
    ConsoleHelper.Pause();
}

void DeleteProduct()
{
    ConsoleHelper.PrintHeader("Delete Product");
    int id = ConsoleHelper.ReadInt("Enter Product Id: ");
    bool ok = productService.Delete(id);
    if (ok) ConsoleHelper.PrintSuccess("Product deleted.");
    else ConsoleHelper.PrintError("Product not found.");
    ConsoleHelper.Pause();
}

void SearchProduct()
{
    ConsoleHelper.PrintHeader("Search Product");
    string keyword = ConsoleHelper.ReadNonEmptyString("Enter name/category/brand keyword: ");
    var results = productService.Search(keyword);
    if (results.Count == 0)
        Console.WriteLine("No products found.");
    else
        results.ForEach(p => Console.WriteLine(p));
    ConsoleHelper.Pause();
}

void ViewAllProducts()
{
    ConsoleHelper.PrintHeader("All Products");
    var products = productService.GetAll();
    if (products.Count == 0)
        Console.WriteLine("No products available.");
    else
        products.ForEach(p => Console.WriteLine(p));
    ConsoleHelper.Pause();
}

void RunCategoryManagement()
{
    bool back = false;
    while (!back)
    {
        ConsoleHelper.PrintHeader("Category Management");
        ShowCategories();
        Console.WriteLine("1. Add Category");
        Console.WriteLine("2. Update Category");
        Console.WriteLine("3. Delete Category");
        Console.WriteLine("4. Back");
        int choice = ConsoleHelper.ReadInt("Choose an option: ");

        switch (choice)
        {
            case 1:
                string name = ConsoleHelper.ReadNonEmptyString("New category name: ");
                try { categoryService.Add(name); ConsoleHelper.PrintSuccess("Category added."); }
                catch (Exception ex) { ConsoleHelper.PrintError(ex.Message); }
                ConsoleHelper.Pause();
                break;
            case 2:
                int updateId = ConsoleHelper.ReadInt("Category Id to update: ");
                string newName = ConsoleHelper.ReadNonEmptyString("New name: ");
                if (categoryService.Update(updateId, newName)) ConsoleHelper.PrintSuccess("Category updated.");
                else ConsoleHelper.PrintError("Category not found.");
                ConsoleHelper.Pause();
                break;
            case 3:
                int deleteId = ConsoleHelper.ReadInt("Category Id to delete: ");
                try
                {
                    if (categoryService.Delete(deleteId)) ConsoleHelper.PrintSuccess("Category deleted.");
                    else ConsoleHelper.PrintError("Category not found.");
                }
                catch (Exception ex) { ConsoleHelper.PrintError(ex.Message); }
                ConsoleHelper.Pause();
                break;
            case 4: back = true; break;
            default: ConsoleHelper.PrintError("Invalid choice."); ConsoleHelper.Pause(); break;
        }
    }
}

void ShowCategories()
{
    Console.WriteLine("Categories: " + string.Join(", ", categoryService.GetAll().Select(c => c.Name)));
}

void ViewAllOrders()
{
    ConsoleHelper.PrintHeader("All Orders");
    var orders = orderService.GetAllOrders();
    if (orders.Count == 0)
        Console.WriteLine("No orders placed yet.");
    else
        orders.ForEach(o => Console.WriteLine(o));
    ConsoleHelper.Pause();
}

void ShowReports()
{
    ConsoleHelper.PrintHeader("Reports");
    Console.WriteLine($"Total Customers : {reportService.TotalCustomers()}");
    Console.WriteLine($"Total Products  : {reportService.TotalProducts()}");
    Console.WriteLine($"Total Orders    : {reportService.TotalOrders()}");
    Console.WriteLine($"Total Revenue   : {reportService.TotalRevenue():C}");

    Console.WriteLine("\nTop Selling Products:");
    var top = reportService.TopSellingProducts();
    if (top.Count == 0) Console.WriteLine("  No sales data yet.");
    else foreach (var (product, units) in top)
            Console.WriteLine($"  {product.Name} - {units} units sold");

    Console.WriteLine("\nLow Stock Products (<=5 units):");
    var lowStock = reportService.LowStockProducts();
    if (lowStock.Count == 0) Console.WriteLine("  None.");
    else lowStock.ForEach(p => Console.WriteLine($"  {p.Name} - {p.Quantity} left"));

    ConsoleHelper.Pause();
}

// =========================================================
// Customer Dashboard
// =========================================================
void RunCustomerDashboard(Customer customer)
{
    bool back = false;
    while (!back)
    {
        ConsoleHelper.PrintHeader($"Customer Dashboard - {customer.Name}");
        Console.WriteLine("1. View Products");
        Console.WriteLine("2. Shopping Cart");
        Console.WriteLine("3. Checkout");
        Console.WriteLine("4. Order History");
        Console.WriteLine("5. Update Profile");
        Console.WriteLine("6. Change Password");
        Console.WriteLine("7. Logout");
        int choice = ConsoleHelper.ReadInt("Choose an option: ");

        switch (choice)
        {
            case 1: ViewProducts(customer); break;
            case 2: RunCartMenu(customer); break;
            case 3: Checkout(customer); break;
            case 4: RunOrderHistoryMenu(customer); break;
            case 5: UpdateProfile(customer); break;
            case 6: ChangePassword(customer); break;
            case 7: authService.Logout(); back = true; break;
            default: ConsoleHelper.PrintError("Invalid choice."); ConsoleHelper.Pause(); break;
        }
    }
}

void ViewProducts(Customer customer)
{
    ConsoleHelper.PrintHeader("Available Products");
    var products = productService.GetAll();
    if (products.Count == 0)
    {
        Console.WriteLine("No products available.");
        ConsoleHelper.Pause();
        return;
    }
    products.ForEach(p => Console.WriteLine(p));

    Console.WriteLine("\nEnter Product Id to add to cart, or 0 to go back.");
    int id = ConsoleHelper.ReadInt("Product Id: ");
    if (id == 0) return;

    var product = productService.GetById(id);
    if (product == null)
    {
        ConsoleHelper.PrintError("Product not found.");
        ConsoleHelper.Pause();
        return;
    }

    int qty = ConsoleHelper.ReadInt("Quantity: ");
    if (qty <= 0 || qty > product.Quantity)
    {
        ConsoleHelper.PrintError("Invalid quantity or insufficient stock.");
        ConsoleHelper.Pause();
        return;
    }

    cartService.AddToCart(customer.Id, product, qty);
    ConsoleHelper.PrintSuccess($"{qty} x {product.Name} added to cart.");
    ConsoleHelper.Pause();
}

void RunCartMenu(Customer customer)
{
    bool back = false;
    while (!back)
    {
        ConsoleHelper.PrintHeader("Shopping Cart");
        var cart = cartService.GetCart(customer.Id);
        PrintCart(cart);

        Console.WriteLine("\n1. Remove Item");
        Console.WriteLine("2. Update Quantity");
        Console.WriteLine("3. Clear Cart");
        Console.WriteLine("4. Apply Coupon");
        Console.WriteLine("5. Back");
        int choice = ConsoleHelper.ReadInt("Choose an option: ");

        switch (choice)
        {
            case 1:
                int removeId = ConsoleHelper.ReadInt("Product Id to remove: ");
                if (cartService.RemoveItem(customer.Id, removeId)) ConsoleHelper.PrintSuccess("Item removed.");
                else ConsoleHelper.PrintError("Item not found in cart.");
                ConsoleHelper.Pause();
                break;
            case 2:
                int updateId = ConsoleHelper.ReadInt("Product Id to update: ");
                int newQty = ConsoleHelper.ReadInt("New quantity (0 to remove): ");
                if (cartService.UpdateQuantity(customer.Id, updateId, newQty)) ConsoleHelper.PrintSuccess("Cart updated.");
                else ConsoleHelper.PrintError("Item not found in cart.");
                ConsoleHelper.Pause();
                break;
            case 3:
                cartService.ClearCart(customer.Id);
                ConsoleHelper.PrintSuccess("Cart cleared.");
                ConsoleHelper.Pause();
                break;
            case 4:
                string code = ConsoleHelper.ReadNonEmptyString("Enter coupon code: ");
                if (cartService.ApplyCoupon(customer.Id, code)) ConsoleHelper.PrintSuccess("Coupon applied.");
                else ConsoleHelper.PrintError("Invalid coupon code.");
                ConsoleHelper.Pause();
                break;
            case 5: back = true; break;
            default: ConsoleHelper.PrintError("Invalid choice."); ConsoleHelper.Pause(); break;
        }
    }
}

void PrintCart(Cart cart)
{
    if (cart.IsEmpty)
    {
        Console.WriteLine("Your cart is empty.");
        return;
    }

    foreach (var item in cart.Items)
        Console.WriteLine(item);

    Console.WriteLine("-----------------------------------");
    Console.WriteLine($"Sub Total       : {cart.SubTotal:C}");
    if (cart.CouponDiscountPercent > 0)
        Console.WriteLine($"Coupon ({cart.CouponCode}) : -{cart.CouponDiscountAmount:C}");
    Console.WriteLine($"GST (18%)       : {cart.GstAmount:C}");
    Console.WriteLine($"Grand Total     : {cart.GrandTotal:C}");
}

void Checkout(Customer customer)
{
    ConsoleHelper.PrintHeader("Checkout");
    var cart = cartService.GetCart(customer.Id);
    if (cart.IsEmpty)
    {
        ConsoleHelper.PrintError("Your cart is empty. Add products before checking out.");
        ConsoleHelper.Pause();
        return;
    }

    PrintCart(cart);

    Console.WriteLine($"\nShip to saved address: {customer.Address}");
    Console.WriteLine("1. Use saved address");
    Console.WriteLine("2. Enter a new address");
    int addrChoice = ConsoleHelper.ReadInt("Choose an option: ");
    string shippingAddress = addrChoice == 2
        ? ConsoleHelper.ReadNonEmptyString("New shipping address: ")
        : customer.Address;

    Console.WriteLine("\nSelect Payment Method:");
    Console.WriteLine("1. Credit Card");
    Console.WriteLine("2. Debit Card");
    Console.WriteLine("3. UPI");
    Console.WriteLine("4. Cash On Delivery");
    int payChoice = ConsoleHelper.ReadInt("Choose an option: ");

    PaymentMethod method = payChoice switch
    {
        1 => PaymentMethod.CreditCard,
        2 => PaymentMethod.DebitCard,
        3 => PaymentMethod.UPI,
        4 => PaymentMethod.CashOnDelivery,
        _ => PaymentMethod.CashOnDelivery
    };

    var paymentStatus = paymentService.ProcessPayment(method, cart.GrandTotal);
    Console.WriteLine($"\nPayment Status: {paymentStatus}");

    if (paymentStatus == PaymentStatus.Failed)
    {
        ConsoleHelper.PrintError("Payment failed. Order not placed. Please try again.");
        ConsoleHelper.Pause();
        return;
    }

    var order = orderService.PlaceOrder(customer, cart, shippingAddress, method, paymentStatus);
    cartService.ClearCart(customer.Id);

    ConsoleHelper.PrintSuccess($"Order placed successfully! Order Id: {order.Id}");
    Console.WriteLine(invoiceService.BuildInvoiceText(order));
    string path = invoiceService.SaveInvoiceToFile(order);
    Console.WriteLine($"Invoice saved to: {path}");
    ConsoleHelper.Pause();
}

void RunOrderHistoryMenu(Customer customer)
{
    bool back = false;
    while (!back)
    {
        ConsoleHelper.PrintHeader("Order History");
        Console.WriteLine("1. View All Orders");
        Console.WriteLine("2. Search Order by Id");
        Console.WriteLine("3. Cancel Order");
        Console.WriteLine("4. Download Invoice");
        Console.WriteLine("5. Back");
        int choice = ConsoleHelper.ReadInt("Choose an option: ");

        switch (choice)
        {
            case 1:
                var orders = orderService.GetOrderHistory(customer.Id);
                if (orders.Count == 0) Console.WriteLine("No orders yet.");
                else orders.ForEach(o => Console.WriteLine(o));
                ConsoleHelper.Pause();
                break;
            case 2:
                int searchId = ConsoleHelper.ReadInt("Enter Order Id: ");
                var found = orderService.SearchOrder(customer.Id, searchId);
                if (found == null) ConsoleHelper.PrintError("Order not found.");
                else Console.WriteLine(found);
                ConsoleHelper.Pause();
                break;
            case 3:
                int cancelId = ConsoleHelper.ReadInt("Enter Order Id to cancel: ");
                if (orderService.CancelOrder(customer.Id, cancelId)) ConsoleHelper.PrintSuccess("Order cancelled.");
                else ConsoleHelper.PrintError("Order not found or cannot be cancelled.");
                ConsoleHelper.Pause();
                break;
            case 4:
                int invId = ConsoleHelper.ReadInt("Enter Order Id: ");
                var invOrder = orderService.SearchOrder(customer.Id, invId);
                if (invOrder == null)
                {
                    ConsoleHelper.PrintError("Order not found.");
                }
                else
                {
                    string path = invoiceService.SaveInvoiceToFile(invOrder);
                    ConsoleHelper.PrintSuccess($"Invoice saved to: {path}");
                }
                ConsoleHelper.Pause();
                break;
            case 5: back = true; break;
            default: ConsoleHelper.PrintError("Invalid choice."); ConsoleHelper.Pause(); break;
        }
    }
}

void UpdateProfile(Customer customer)
{
    ConsoleHelper.PrintHeader("Update Profile");
    Console.WriteLine($"Current details: {customer}");
    string name = ConsoleHelper.ReadNonEmptyString($"New Name [{customer.Name}]: ");
    string email = ConsoleHelper.ReadNonEmptyString($"New Email [{customer.Email}]: ");
    string phone = ConsoleHelper.ReadNonEmptyString($"New Phone [{customer.Phone}]: ");
    string address = ConsoleHelper.ReadNonEmptyString($"New Address [{customer.Address}]: ");

    authService.UpdateProfile(customer, name, email, phone, address);
    ConsoleHelper.PrintSuccess("Profile updated successfully.");
    ConsoleHelper.Pause();
}

void ChangePassword(Customer customer)
{
    ConsoleHelper.PrintHeader("Change Password");
    string oldPassword = ConsoleHelper.ReadNonEmptyString("Current Password: ");
    string newPassword = ConsoleHelper.ReadNonEmptyString("New Password: ");

    if (authService.ChangePassword(customer, oldPassword, newPassword))
        ConsoleHelper.PrintSuccess("Password changed successfully.");
    else
        ConsoleHelper.PrintError("Current password is incorrect.");
    ConsoleHelper.Pause();
}
