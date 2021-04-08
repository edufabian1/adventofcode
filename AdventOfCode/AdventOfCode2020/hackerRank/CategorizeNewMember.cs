using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2020.hackerRank
{
    class CategorizeNewMember
    {
        [Test]
        public void Test1()
        {
            int[][] input = new[] { new[] { 45, 12 }, new[] { 55, 21 }, new[] { 19, 2 }, new[] { 104, 20 } };
            var result = OpenOrSenior(input);
        }

        IEnumerable<string> OpenOrSenior(int[][] data)
        {
            //your code here
            List<string> result = new List<string>();
            foreach (int[] item in data)
            {
                int year = item[0];
                int handicap = item[1];

                if (year >= 55 && handicap > 7)
                    result.Add("Senior");
                else result.Add("Open");
            }
            
            return result.ToArray(); ;
        }
    }
}
