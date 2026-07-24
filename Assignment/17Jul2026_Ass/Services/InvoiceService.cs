using System.Text;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Services
{
    public class InvoiceService
    {
        private const string InvoiceFolder = "Invoices";

        public string BuildInvoiceText(Order order)
        {
            var sb = new StringBuilder();
            sb.AppendLine("=========================================");
            sb.AppendLine("               SHOPEASE INVOICE           ");
            sb.AppendLine("=========================================");
            sb.AppendLine($"Order Id      : {order.Id}");
            sb.AppendLine($"Date          : {order.OrderDate:dd-MMM-yyyy HH:mm}");
            sb.AppendLine($"Customer      : {order.CustomerName}");
            sb.AppendLine($"Address       : {order.ShippingAddress}");
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine($"{"Item",-15}{"Qty",5}{"Price",12}{"Total",12}");
            foreach (var item in order.Items)
            {
                sb.AppendLine($"{item.ProductName,-15}{item.Quantity,5}{item.UnitPrice,12:C}{item.LineTotal,12:C}");
            }
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine($"{"Sub Total",-27}{order.SubTotal,15:C}");
            sb.AppendLine($"{"Coupon Discount",-27}{order.CouponDiscount,15:C}");
            sb.AppendLine($"{"GST (18%)",-27}{order.Gst,15:C}");
            sb.AppendLine($"{"Grand Total",-27}{order.GrandTotal,15:C}");
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine($"Payment Method : {order.PaymentMethod}");
            sb.AppendLine($"Payment Status : {order.PaymentStatus}");
            sb.AppendLine($"Order Status   : {order.Status}");
            sb.AppendLine("=========================================");
            sb.AppendLine("     Thank you for shopping with us!      ");
            sb.AppendLine("=========================================");
            return sb.ToString();
        }

        public string SaveInvoiceToFile(Order order)
        {
            Directory.CreateDirectory(InvoiceFolder);
            string path = Path.Combine(InvoiceFolder, $"Invoice_{order.Id}.txt");
            File.WriteAllText(path, BuildInvoiceText(order));
            return path;
        }
    }
}
