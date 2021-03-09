using System;

namespace Homework_4.Exceptions
{
    public class PhoneNotAvailableException : Exception
    {
        public PhoneNotAvailableException()
        {
        }

        public PhoneNotAvailableException(string message) : base(message)
        {
        }

        public PhoneNotAvailableException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}