using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2020.Code_wars
{
    [TestFixture]
    public class FindTheUniqueNumberTest
    {
        public static int GetUnique(IEnumerable<int> numbers)
        {
            List<int> lstNumbers = new List<int>(numbers);
            
            int repeatNumber = 0;

            if (lstNumbers[0] == lstNumbers[1]) repeatNumber = lstNumbers[0];
            if (lstNumbers[1] == lstNumbers[2]) repeatNumber = lstNumbers[1];
            if (lstNumbers[2] == lstNumbers[0]) repeatNumber = lstNumbers[2];

            for (int i = 0; i < lstNumbers.Count; i++)
                if (lstNumbers[i] != repeatNumber) return lstNumbers[i];
            return 0;
        }

        [TestCase(new[] { 1, 2, 2, 2 }, ExpectedResult = 1)]
        [TestCase(new[] { -2, 2, 2, 2 }, ExpectedResult = -2)]
        [TestCase(new[] { 11, 11, 14, 11, 11 }, ExpectedResult = 14)]
        public int BaseTest(IEnumerable<int> numbers)
        {
            return GetUnique(numbers);
        }
    }
}
