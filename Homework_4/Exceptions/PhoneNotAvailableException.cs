using System;
using System.Reflection;
using log4net;

namespace Homework_4.Exceptions
{
    public class PhoneNotAvailableException : Exception
    {
        private static readonly ILog Logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public PhoneNotAvailableException()
        {
        }

        public PhoneNotAvailableException(string message)
        {
            Logger.Error(message);
        }

        public PhoneNotAvailableException(string message, Exception inner)
        {
        }
    }
}