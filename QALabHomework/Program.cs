using System;

namespace QALabHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isChecked = true;
            if (isChecked)
            {
                Console.WriteLine("It is true!");
                isChecked = false;
                Console.WriteLine(isChecked);
            }

            byte x = 24;
            if (x < 10)
            {
                Console.WriteLine(++x);
            }
            else
            {
                Console.WriteLine(--x);
            }

            sbyte x1 = -10;
            if (x1 != 1)
            {
                Console.WriteLine(x1--);
                Console.WriteLine(x1);
                Console.WriteLine(x1++);
                Console.WriteLine(x1);
            }

            char x3 = 'A';
            Console.WriteLine(x3);

            decimal x4 = 45.89m;
            if (x4 <= 50 | x4 >= 60)
            {
                Console.WriteLine("True");
            }

            double x5 = 23.34;
            if (x5 >= 15 && 14 <= x5)
            {
                Console.WriteLine("True");
            }

            float x6 = -3.14f;
            var result = x6 / 2;
            Console.WriteLine(result);

            int x7 = 345;
            if (x7 % 3 == 0)
            {
                var result1 = x7 * 3;
                Console.WriteLine(result1);
            }

            uint x8 = 67;
            uint x9 = 9;
            uint result3;
            result3 = x8 < x9 ? x8 + 10 : 2*3;
            Console.WriteLine(result3);

            long x10 = -76;
            long x11 = -77;
            if (x10 >= -78 || x11 >= 1000)
            {
                Console.WriteLine("True");
            }

            ulong x12 = 10000;
            if (x12 > 9000 & x12 < 12000)
            {
                Console.WriteLine("True");
            }

            short x13 = 457;
            if (x13 < 500 ^ x13 < 345)
            {
                Console.WriteLine("True");
            }

            dynamic x14 = 24;
            x14 += 1;
            Console.WriteLine(x14);
            
            string text = "Hello World!";
            if (text is object)
            {
                Console.WriteLine(text);
            }
        }
    }
}
