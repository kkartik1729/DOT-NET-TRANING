using _06Aug_2026.Data;
using _06Aug_2026.Models;
using _06Aug_2026.Repository;

namespace _06Aug_2026.Services
{
    
    public class OrderService : IOrderService
    {
        private readonly AppDbContext context;

        public OrderService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddOrder(Order order)
        {
            context.orders.Add(order); 
            context.SaveChanges(); 
        }

        public void DeleteOrder(int id)
        {
            var order = context.orders.Find(id);

            if (order != null)
            {
                context.orders.Remove(order); 
                context.SaveChanges(); 
            }
        }

        public Order? GetOrderById(int id)
        {
            return context.orders.Find(id);
        }

        public List<Order> GetOrders()
        {
            return context.orders.ToList(); 

        public void UpdateOrder(Order order)
        {
            context.orders.Update(order); 
            context.SaveChanges();
        }
    }

