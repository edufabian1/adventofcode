using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2020.Code_wars
{
    [TestFixture]
    public class ArrayDiffTest
    {
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            if (a.Length == 0 || b.Length == 0) return a;

            Dictionary<int, bool> dictionary = new Dictionary<int, bool>();

            List<int> results = new List<int>();

            foreach (var item in b)
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, true);

            for (int i = 0; i < a.Length; i++)
                if (!dictionary.ContainsKey(a[i])) results.Add(a[i]);

            return results.ToArray();
        }

        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new int[] { 2 }, ArrayDiff(new int[] { 1, 2 }, new int[] { 1 }));
            Assert.AreEqual(new int[] { 2, 2 }, ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 1 }));
            Assert.AreEqual(new int[] { 1 }, ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 2 }));
            Assert.AreEqual(new int[] { 1, 2, 2 }, ArrayDiff(new int[] { 1, 2, 2 }, new int[] { }));
            Assert.AreEqual(new int[] { }, ArrayDiff(new int[] { }, new int[] { 1, 2 }));
            Assert.AreEqual(new int[] { 3 }, ArrayDiff(new int[] { 1, 2, 3 }, new int[] { 1, 2 }));
        }
    }
}
