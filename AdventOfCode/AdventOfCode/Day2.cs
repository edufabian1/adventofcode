using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode
{
    [TestClass]
    public class Day2
    {

        [TestMethod]
        public void Day2_part1_Test()
        {
            string input = System.IO.File.ReadAllText(@"D:\AdventOfCode\Puzzle input\input2.txt");

            var list = input.Split(',');

            list[1] = "12";
            list[2] = "2";

            var myInts = Array.ConvertAll(list, s => int.Parse(s));

            int var1, var2, res;
            //1 suma, 2 multiplica, 99 finaliza
            for (int i = 0; i < myInts.Length; i++)
            {
                if (i % 4 == 0)
                {
                    if (myInts[i] == 1)
                    {
                        var1 = myInts[i + 1];
                        var2 = myInts[i + 2];
                        res = myInts[i + 3];
                        myInts[res] = myInts[var1] + myInts[var2];
                    }
                    else if (myInts[i] == 2)
                    {
                        var1 = myInts[i + 1];
                        var2 = myInts[i + 2];
                        res = myInts[i + 3];
                        myInts[res] = myInts[var1] * myInts[var2];
                    }
                    else if (myInts[i] == 99)
                        break;
                }
            }
        }

        [TestMethod]
        // Restarle a input1 -1
        public void Day2_part2_Test()
        {
            var resultado = 0;
            var input1 = 0;
            var input2 = 0;

            while (resultado != 19690720)
            {
                string input = System.IO.File.ReadAllText(@"D:\AdventOfCode\Puzzle input\input2.txt");

                var list = input.Split(',');

                var myInts = Array.ConvertAll(list, s => int.Parse(s));

                int var1, var2, res;

                myInts[1] = input1;
                myInts[2] = input2;

                for (int i = 0; i < myInts.Length; i++)
                {
                    if (i % 4 == 0)
                    {
                        if (myInts[i] == 1)
                        {
                            var1 = myInts[i + 1];
                            var2 = myInts[i + 2];
                            res = myInts[i + 3];
                            myInts[res] = myInts[var1] + myInts[var2];
                        }
                        else if (myInts[i] == 2)
                        {
                            var1 = myInts[i + 1];
                            var2 = myInts[i + 2];
                            res = myInts[i + 3];
                            myInts[res] = myInts[var1] * myInts[var2];
                        }
                        else if (myInts[i] == 99)
                            break;
                    }
                }
                resultado = myInts[0];

                if (input1 < 99)
                    input1++;
                else
                {
                    input2++;
                    input1 = 0;
                }
            };

            Assert.IsNotNull(resultado);
        }
    }
}
