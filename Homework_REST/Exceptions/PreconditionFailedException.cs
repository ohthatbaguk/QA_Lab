using System;

namespace Homework_REST.Exceptions
{
    public class PreconditionFailedException : Exception
    {
        public PreconditionFailedException()
        {
        }

        public PreconditionFailedException(string message) : base(message)
        {
        }

        public PreconditionFailedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}