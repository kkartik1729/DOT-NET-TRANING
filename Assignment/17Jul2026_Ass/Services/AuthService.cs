using ShopEaseConsoleApp.Data;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Services
{
    public class AuthService
    {
        public Customer Register(string name, string username, string password, string email, string phone, string address)
        {
            if (DataStore.Customers.Any(c => c.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Username already exists.");

            var customer = new Customer
            {
                Id = DataStore.NextCustomerId(),
                Name = name,
                Username = username,
                Password = password,
                Email = email,
                Phone = phone,
                Address = address
            };
            DataStore.Customers.Add(customer);
            return customer;
        }

        public Customer? Login(string username, string password)
        {
            var customer = DataStore.Customers.FirstOrDefault(c =>
                c.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && c.Password == password);

            if (customer != null)
                DataStore.LoggedInCustomer = customer;

            return customer;
        }

        public bool AdminLogin(string username, string password)
        {
            bool ok = username == DataStore.AdminUsername && password == DataStore.AdminPassword;
            DataStore.IsAdminLoggedIn = ok;
            return ok;
        }

        public void Logout()
        {
            DataStore.LoggedInCustomer = null;
            DataStore.IsAdminLoggedIn = false;
        }

        public void UpdateProfile(Customer customer, string name, string email, string phone, string address)
        {
            customer.Name = name;
            customer.Email = email;
            customer.Phone = phone;
            customer.Address = address;
        }

        public bool ChangePassword(Customer customer, string oldPassword, string newPassword)
        {
            if (customer.Password != oldPassword) return false;
            customer.Password = newPassword;
            return true;
        }
    }
}
