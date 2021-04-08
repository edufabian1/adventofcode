using NUnit.Framework;
using System.Linq;

namespace AdventOfCode2020.hackerRank
{
    public class Dubstep
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("ABC", Dubstep.SongDecoder("WUBWUBABCWUB"));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual("R L", Dubstep.SongDecoder("RWUBWUBWUBLWUB"));
        }

        public static string SongDecoder(string input)
        {
            string result = "";
            string[] resultsInputs = input.Split("WUB").Where(x => x != "").ToArray();
            foreach (string item in resultsInputs)
            {
                result += item + " ";
            }
            return result.Trim();
        }
    }
}
