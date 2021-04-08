using NUnit.Framework;
using System;

namespace AdventOfCode2020.Code_wars
{
    [TestFixture]
    public class XbonacciTest
    {   
        public double[] Tribonacci(double[] signature, int n)
        {
            // hackonacci me
            foreach (var item in signature) Console.WriteLine(item);
            double[] result = new double[n];
            
            if (result.Length == 0) return result;
            if (result.Length == 1) result[0] = signature[0];
            if (result.Length == 2) result[1] = signature[1];
            if (result.Length == 3) result[2] = signature[2];


            for (int i = 3; i < result.Length; i++)
                result[i] = result[i - 3] + result[i - 2] + result[i - 1];

            return result;
        }

        [Test]
        public void Tests()
        {
            Assert.AreEqual(new double[] { 1, 1, 1, 3, 5, 9, 17, 31, 57, 105 }, Tribonacci(new double[] { 1, 1, 1 }, 10));
            Assert.AreEqual(new double[] { 0, 0, 1, 1, 2, 4, 7, 13, 24, 44 }, Tribonacci(new double[] { 0, 0, 1 }, 10));
            Assert.AreEqual(new double[] { 0, 1, 1, 2, 4, 7, 13, 24, 44, 81 }, Tribonacci(new double[] { 0, 1, 1 }, 10));
        }
    }
}
