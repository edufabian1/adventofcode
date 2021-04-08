using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2020.Code_wars
{
    [TestFixture]
    public class DeleteNthTests
    {
        public static int[] DeleteNth(int[] arr, int x)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            List<int> result = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!dictionary.ContainsKey(arr[i]))
                {
                    result.Add(arr[i]);
                    dictionary.Add(arr[i], x - 1);
                }
                else if (dictionary.ContainsKey(arr[i]) && dictionary[arr[i]] > 0)
                {
                    result.Add(arr[i]);
                    dictionary[arr[i]]--;
                }
            }
            return result.ToArray();
        }
        [Test]
        public void TestSimple()
        {
            var expected = new int[] { 20, 37, 21 };

            var actual = DeleteNth(new int[] { 20, 37, 20, 21 }, 1);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSimple2()
        {
            var expected = new int[] { 1, 1, 3, 3, 7, 2, 2, 2 };

            var actual = DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
