using System;

namespace StationeryStoreManagement.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
            : base("Item not found.")
        {
        }

        public ItemNotFoundException(string message)
            : base(message)
        {
        }
    }
}