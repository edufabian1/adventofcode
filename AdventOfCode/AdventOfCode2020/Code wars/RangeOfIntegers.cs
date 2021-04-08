using NUnit.Framework;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdventOfCode2020.Code_wars
{   
    [TestFixture]
    class RangeOfIntegers
    {
        [Test]
        [TestCase(2, 10, 2, ExpectedResult = new int[] { 2, 4, 6, 8, 10 })]
        public static int[] FixedTest(int min, int max, int step)
        {
            return GenerateRange(min, max, step);
        }

        public static int[] GenerateRange(int min, int max, int step)
        {
            {
                // your code goes here
                int[] results = new int[((max - min) / step) + 1];
                int result = min;
                for (int i = 0; i < results.Length; i++)
                {
                    results[i] = result;
                    result += step;
                }
                return results;
            }
        }
    }
}
