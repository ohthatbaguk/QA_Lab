using System;

namespace Homework_4.Exceptions
{
    public class PhoneNotAvailableException : Exception
    {
        public PhoneNotAvailableException()
        {
        }

        public PhoneNotAvailableException(string message)
        {
        }

        public PhoneNotAvailableException(string message, Exception inner)
        {
        }
    }
}