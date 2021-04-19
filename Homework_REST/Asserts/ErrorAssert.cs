using FluentAssertions;
using Homework_REST.Models.Message;

namespace Homework_REST.Asserts
{
    public class ErrorAssert
    {
        public static void ValidateErrorMessage(Error error, string typeError)
        {
            error.Message.Should().Be(typeError);
        }
    }
}