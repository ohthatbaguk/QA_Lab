using System;

namespace Homework_4.Exceptions
{
    public class ShopNotFoundException : Exception
    {
        public ShopNotFoundException()
        {
        }

        public ShopNotFoundException(string message)
        {
        }

        public ShopNotFoundException(string message, Exception inner)
        {
        }
    }
}