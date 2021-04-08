using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Code_wars
{
    [TestFixture]
    public class AnagramsTest
    {
        public static List<string> Anagrams(string word, List<string> words)
        {
            List<string> results = new List<string>();
            char[] initial = word.ToCharArray();
            Array.Sort(initial);
            word = new string(initial);

            foreach (var item in words)
            {
                char[] compare = item.ToCharArray();
                Array.Sort(compare);
                
                string strCompare = new string(compare);

                if (String.Equals(strCompare, word))
                    results.Add(item);
            }
            return results;
        }

        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new List<string> { "a" }, Anagrams("a", new List<string> { "a", "b", "c", "d" }));
            Assert.AreEqual(new List<string> { "carer", "arcre", "carre" }, Anagrams("racer", new List<string> { "carer", "arcre", "carre", "racrs", "racers", "arceer", "raccer", "carrer", "cerarr" }));
        }
    }
}
