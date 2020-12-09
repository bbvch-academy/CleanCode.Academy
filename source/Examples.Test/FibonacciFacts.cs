namespace Examples
{
    using System;

    using FluentAssertions;

    using NUnit.Framework;

    public static class FibonacciInSequence
    {
        public static int ValueOf(int n)
        {
            if (n <= 2)
                return n - 1;

            int a = 0, b = 1, c = 0;
            for (int i = 2; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }
    }

    public static class FibonacciWithRecursion
    {
        public static int ValueOf(int n)
        {
            return Recursion(n - 1);
        }

        private static int Recursion(int i)
        {
            if (i < 2) return i;
            return Recursion(i - 1) + Recursion(i - 2);
        }
    }

    [TestFixture]
    public class FibonacciFacts
    {
        [Test]
        public void CalculatesFibonacciSequence()
        {
            FibonacciWithRecursion.ValueOf(1).Should().Be(0);
            FibonacciWithRecursion.ValueOf(2).Should().Be(1);
            FibonacciWithRecursion.ValueOf(3).Should().Be(1);
            FibonacciWithRecursion.ValueOf(4).Should().Be(2);
            FibonacciWithRecursion.ValueOf(5).Should().Be(3);
            FibonacciWithRecursion.ValueOf(6).Should().Be(5);

            FibonacciWithRecursion.ValueOf(11).Should().Be(55);
        }
    }
}
