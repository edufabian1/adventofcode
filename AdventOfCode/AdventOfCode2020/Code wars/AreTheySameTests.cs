using NUnit.Framework;
using System;

namespace AdventOfCode2020.Code_wars
{

    [TestFixture]
    public class AreTheySameTests
    {
        [Test]
        public void Test1()
        {
            int[] a = new int[] { 2,2,3 };
            int[] b = new int[] { 4,9,9 };
            bool r = comp(a, b); // True
            Assert.AreEqual(true, r);
        }
        public static bool comp(int[] a, int[] b)
        {
            foreach (var item in a) Console.Write(item);
            foreach (var item in b) Console.Write(item);

            if (b == null || a == null || a.Length == 0) return false;

            Array.Sort(a);
            Array.Sort(b);

            for (int i = 0; i < b.Length; i++)
            {
                double compare, partial = b[i];
                compare = Math.Sqrt(partial);
                
                if (compare % 1 != 0) return false;
                
                if (a[i] != int.Parse(compare.ToString())) return false;
            }

            return true;
        }
    }
}
