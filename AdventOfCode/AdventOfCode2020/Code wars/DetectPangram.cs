using NUnit.Framework;

namespace AdventOfCode2020.Code_wars
{

    [TestFixture]
    public class DetectPangram
    {
        public static bool IsPangram(string str)
        {
            char[] abc = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string word = str.ToLower();
            for (int i = 0; i < abc.Length; i++)
                if (!word.Contains(abc[i])) return false;

            return true;
        }

        [Test]
        public void SampleTests()
        {
            Assert.AreEqual(true, IsPangram("Pack my box with five dozen liquor jugs."));
        }
    }
}
