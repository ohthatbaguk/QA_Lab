using System;
using Bogus;

namespace Homework_REST.Utils
{
    public class RandomUtils
    {
        public static readonly Func<int, string> GenerateString = maxLength =>
            new Faker().Random.AlphaNumeric(maxLength);
    }
}