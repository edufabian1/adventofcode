using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class UnitTest2
    {
        private List<string> _lstLines;

        [SetUp]
        public void Setup()
        {
            string[] lines = File.ReadAllLines(@"D:\Proyectos\proyectos-personales\adventofcode\AdventOfCode\AdventOfCode2020\Resources\input2.txt");
            //string[] lines = new string[] { "1 - 3 a: abcde", "1 - 3 b: cdefg", "2 - 9 c: ccccccccc" };

            _lstLines = lines.OfType<string>().ToList();
        }

        [Test]
        public void Test1()
        {
            int result = 0;

            for (int i = 0; i < _lstLines.Count(); i++)
            {
                string[] aLines = _lstLines[i].Trim().Split(':');

                char search = aLines[0][aLines[0].Length - 1];

                string tempLine = aLines[0].Replace(search, ' ');

                string[] aNums = tempLine.Split('-');

                int num1 = int.Parse(aNums[0].Trim());
                int num2 = int.Parse(aNums[1].Trim());

                int count = 0;
                for (int j = 0; j < aLines[1].Length; j++)
                {
                    string value = aLines[1][j].ToString();
                    if (value.Equals(search.ToString()))
                        count++;
                }
                result += count >= num1 && count <= num2 ? 1 : 0;
            }

            Console.WriteLine("Result: " + result);
            Assert.IsNotNull(result.ToString());
        }

        [Test]
        public void Test2()
        {
            int result = 0;

            for (int i = 0; i < _lstLines.Count(); i++)
            {
                string[] aLines = _lstLines[i].Trim().Split(':');

                char search = aLines[0][aLines[0].Length - 1];

                string tempLine = aLines[0].Replace(search, ' ');

                string[] aNums = tempLine.Split('-');

                int num1 = int.Parse(aNums[0].Trim());
                int num2 = int.Parse(aNums[1].Trim());

                int count = 0;
                string searchInLine = aLines[1].Trim();

                if (num1 <= searchInLine.Length && searchInLine[num1 - 1].Equals(search)) count++;

                if (num2 <= searchInLine.Length && searchInLine[num2 - 1].Equals(search)) count++;

                if (count == 1) result++;
            }

            Console.WriteLine("Result: " + result);
            Assert.IsNotNull(result.ToString());
        }
    }
}
