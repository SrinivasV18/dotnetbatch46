using System;
namespace ErrorHandling.Shared
{
    public class InvalidProductException: Exception
    {
        public InvalidProductException(string message) : base(message)
        {
        }
    }
}
