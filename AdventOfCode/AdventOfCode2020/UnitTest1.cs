using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string[] lines = File.ReadAllLines(@"D:\Proyectos\proyectos-personales\adventofcode\AdventOfCode\AdventOfCode2020\Resources\input1.txt");
            //string[] lines = new string[] { "1721", "979", "366", "299", "675", "1456" };
            
            List<string> lstLines = lines.OfType<string>().ToList();

            int result = Search(lstLines, 2020);

            Assert.Pass(result.ToString());
        }

        [Test]
        public void Test2()
        {
            string[] lines = File.ReadAllLines(@"D:\Proyectos\proyectos-personales\adventofcode\AdventOfCode\AdventOfCode2020\Resources\input1.txt");
            //string[] lines = new string[] { "1721", "979", "366", "299", "675", "1456" };
            int result = 0;

            List<string> lstLines = lines.OfType<string>().ToList();

            for (int i = 0; i < lstLines.Count(); i++)
            {
                int resultPartial = 2020 - int.Parse(lstLines[i]);
                List<string> lstPartial = lstLines.GetRange(i + 1, lstLines.Count() - (i + 1));
                result = Search(lstPartial, resultPartial);
                
                if (result != 0)
                {
                    result *= int.Parse(lstLines[i]);
                    break;
                }
            }            

            Assert.Pass(result.ToString());
        }

        private int Search(List<string> lstLines, int search)
        {
            int result = 0, resultPartial = 0;

            for (int i = 0; i < lstLines.Count(); i++)
            {
                resultPartial = search - int.Parse(lstLines[i].Trim().ToString());

                var partial = lstLines.Find(x => x == resultPartial.ToString());

                if (!string.IsNullOrEmpty(partial))
                    result = int.Parse(partial.Trim().ToString()) * int.Parse(lstLines[i].Trim().ToString());
            }
            return result;
        }
    }
}