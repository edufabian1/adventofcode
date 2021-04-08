using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2020.Code_wars
{
    [TestFixture]
    public class ReplaceWithAlphabetPosition
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11", AlphabetPosition("The sunset sets at twelve o' clock."));
            Assert.AreEqual("20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20", AlphabetPosition("The narwhal bacons at midnight."));
        }
        public static string AlphabetPosition(string text)
        {
            string result = "";
            List<int> array = new List<int>();

            char[] abc = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string word = text.ToLower();

            for (int i = 0; i < abc.Length; i++)
                if (word.Contains(abc[i]))
                    result += (i + 1) + " ";

            return result.Trim();
        }
    }
}
