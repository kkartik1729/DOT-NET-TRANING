using System;

namespace StationeryStoreManagement.Exceptions
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException()
            : base("Insufficient stock available for this purchase.")
        {
        }

        public InsufficientStockException(string message)
            : base(message)
        {
        }
    }
}