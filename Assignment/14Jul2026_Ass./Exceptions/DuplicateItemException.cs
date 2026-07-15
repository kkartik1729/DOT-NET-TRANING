using System;

namespace StationeryStoreManagement.Exceptions
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException()
            : base("Item ID already exists.")
        {
        }

        public DuplicateItemException(string message)
            : base(message)
        {
        }
    }
}