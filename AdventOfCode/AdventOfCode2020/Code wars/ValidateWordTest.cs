using NUnit.Framework;
using System;

namespace AdventOfCode2020.Code_wars
{
    [TestFixture]
    public class ValidateWordTest
    {
        public static int FindEvenIndex(int[] arr)
        {
            int pivot = 0, result = -1;

            while (pivot < arr.Length)
            {
                int[] array1 = new int[pivot];
                Array.Copy(arr, array1, pivot);
                int[] array2 = new int[arr.Length - pivot];
                Array.Copy(arr, array2, arr.Length - pivot);
                int result1 = 0, result2 = 0;

                foreach (int item in array1)
                    result1 += item;
                foreach (int item in array2)
                    result2 += item;

                if (result1 == result2) result = result1;

                pivot++;
            }
            return result;
        }

        [Test]
        public void GenericTests()
        {
            Assert.AreEqual(3, FindEvenIndex(new int[] { 1, 2, 3, 4, 3, 2, 1 }));
            Assert.AreEqual(1, FindEvenIndex(new int[] { 1, 100, 50, -51, 1, 1 }));
            Assert.AreEqual(-1, FindEvenIndex(new int[] { 1, 2, 3, 4, 5, 6 }));
            Assert.AreEqual(3, FindEvenIndex(new int[] { 20, 10, 30, 10, 10, 15, 35 }));
        }
    }
}
