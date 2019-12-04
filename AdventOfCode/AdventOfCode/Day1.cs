using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode
{
    [TestClass]
    public class Day1
    {
        // https://adventofcode.com/2019/day/1
        [TestMethod]
        public void Day1_part1_Test()
        {
            string text = System.IO.File.ReadAllText(@"D:\AdventOfCode\Puzzle input\input1.txt");
            var list = text.Split('\n');

            int result = 0;
            float floatresult;
            foreach (var item in list)
            {
                if (float.TryParse(item, out floatresult))
                    result += Convert.ToInt32(Math.Floor(floatresult / 3)) - 2;
            }

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Day1_part2_Test()
        {
            string text = System.IO.File.ReadAllText(@"D:\AdventOfCode\Puzzle input\input1.txt");
            var list = text.Split('\n');

            int result = 0;

            float floatresult = 0;

            foreach (var item in list)
            {
                if (float.TryParse(item, out floatresult))
                {
                    int totalActual = 0;
                    float valorActual = floatresult;

                    while ((Convert.ToInt32(Math.Floor(valorActual / 3)) - 2) >= 0)
                    {
                        totalActual += Convert.ToInt32(Math.Floor(valorActual / 3)) - 2;
                        valorActual = Convert.ToInt32(Math.Floor(valorActual / 3)) - 2;
                    };

                    result += totalActual;
                }
            }

            Assert.IsNotNull(result);
        }
    }
}
