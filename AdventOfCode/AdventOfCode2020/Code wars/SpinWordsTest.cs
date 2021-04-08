using NUnit.Framework;
using System;
using System.Linq;

namespace AdventOfCode2020.Code_wars
{

    [TestFixture]
    public class SpinWordsTest
    {
        public static string SpinWords(string sentence)
        {
            string[] words = sentence.Split(" ");
            string[] result = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < 5)
                    result[i] = words[i];
                else
                {
                    string revertWord = "";
                    for (int j = words[i].Length - 1; j >= 0; j--)
                    {
                        revertWord += words[i][j];
                    }
                    result[i] = revertWord;
                }
            }
            return String.Join(" ", result);
        }

        [Test]
        public static void Test1()
        {
            Assert.AreEqual("emocleW", SpinWords("Welcome"));
        }

        [Test]
        public static void Test2()
        {
            Assert.AreEqual("Hey wollef sroirraw", SpinWords("Hey fellow warriors"));
        }

        [Test]
        public static void Test3()
        {
            Assert.AreEqual("This is a test", SpinWords("This is a test"));
        }

        [Test]
        public static void Test4()
        {
            Assert.AreEqual("This is rehtona test", SpinWords("This is another test"));
        }

        [Test]
        public static void Test5()
        {
            Assert.AreEqual("You are tsomla to the last test", SpinWords("You are almost to the last test"));
        }

        [Test]
        public static void Test6()
        {
            Assert.AreEqual("Just gniddik ereht is llits one more", SpinWords("Just kidding there is still one more"));
        }
    }
}
