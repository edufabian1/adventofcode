using NUnit.Framework;

namespace AdventOfCode2020.Code_wars
{
    [TestFixture]
    public class MaxSequenceTest
    {
        public static int MaxSequence(int[] arr)
        {
            int result = 0;

            for (int i = 0; i < arr.Length-1; i++)
            {
                int sum = arr[i];
                for (int j = i+1; j < arr.Length; j++)
                {
                    sum += arr[j];
                    
                    if (sum > result) result = sum;
                }
            }

            return result;
        }

        [Test]
        public void Test0()
        {
            Assert.AreEqual(0, MaxSequence(new int[0]));
        }
        [Test]
        public void Test1()
        {
            Assert.AreEqual(6, MaxSequence(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(6, MaxSequence(new int[] { 7, 4, 11, -11, 39, 36, 10, -6, 37, -10, -32, 44, -26, -34, 43, 43 }));
        }
    }
}
