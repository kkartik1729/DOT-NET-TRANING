using System;

namespace StationeryStoreManagement.Exceptions
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException()
            : base("Login Failed! You have entered invalid username or password 3 times.")
        {
        }

        public LoginFailedException(string message)
            : base(message)
        {
        }
    }
}