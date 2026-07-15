using System;

namespace StationeryStoreManagement.Exceptions
{
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException()
            : base("Quantity must be greater than 0.")
        {
        }

        public InvalidQuantityException(string message)
            : base(message)
        {
        }
    }
}