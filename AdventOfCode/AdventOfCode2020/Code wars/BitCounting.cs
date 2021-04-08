using NUnit.Framework;
using System;

namespace AdventOfCode2020.Code_wars
{
    [TestFixture]
    public class BitCounting
    {
        public static int CountBits(int n)
        {
            int count = 0;
            string binary = Convert.ToString(n, 2);

            for (int i = 0; i < binary.Length; i++)
                if (binary[i] == '1') count++;

            return count;
        }

        [Test]
        public void CountBits()
        {
            Assert.AreEqual(0, CountBits(0));
            Assert.AreEqual(1, CountBits(4));
            Assert.AreEqual(3, CountBits(7));
            Assert.AreEqual(2, CountBits(9));
            Assert.AreEqual(2, CountBits(10));
        }
    }
}
