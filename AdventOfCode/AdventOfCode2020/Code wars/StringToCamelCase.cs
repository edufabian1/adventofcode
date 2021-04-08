using NUnit.Framework;

namespace AdventOfCode2020.Code_wars
{
    [TestFixture]
    public class StringToCamelCase
    {
        [Test]
        public void KataTests()
        {
            Assert.AreEqual("theStealthWarrior", ToCamelCase("the_stealth_warrior"), "Kata.ToCamelCase('the_stealth_warrior') did not return correct value");
            Assert.AreEqual("TheStealthWarrior", ToCamelCase("The-Stealth-Warrior"), "Kata.ToCamelCase('The-Stealth-Warrior') did not return correct value");
            Assert.AreEqual("nxdhddxmheEmhbkrggsiLstdtevsry", ToCamelCase("nxdhddxmheEmhbkrggsi-lstdtevsry"), "Kata.ToCamelCase('The-Stealth-Warrior') did not return correct value");
        }

        public static string ToCamelCase(string str)
        {

            string[] result = str.Contains('_') ? str.Split('_') : str.Split('-');
            string wordResult = "";

            for (int i = 0; i < result.Length; i++)
            {
                if (i == 0)
                {
                    wordResult += result[i];
                    continue;
                }
                
                string word = result[i];
                string secondWord = word.Length > 1 ? word.Substring(1) : string.Empty;
                word = word[0].ToString().ToUpper() + secondWord;
                result[i] = word;

                wordResult += result[i];
            }
            return wordResult;
        }
    }
}
