using System;

namespace Homework_4.Exceptions
{
    public class PhoneNotFoundException : Exception
    {
        public PhoneNotFoundException()
        {
        }

        public PhoneNotFoundException(string message)
        {
        }

        public PhoneNotFoundException(string message, Exception inner)
        {
        }
    }
}