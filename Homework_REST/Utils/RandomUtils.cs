using System;
using Bogus;

namespace Homework_REST.Utils
{
    public static class RandomUtils
    {
        public static readonly Func<int, string> GenerateString = maxLength =>
            new Faker().Random.AlphaNumeric(maxLength);
    }
}