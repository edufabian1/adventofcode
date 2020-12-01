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
        private List<string> _lstLines;

        [SetUp]
        public void Setup()
        {
            string[] lines = File.ReadAllLines(@"D:\Proyectos\proyectos-personales\adventofcode\AdventOfCode\AdventOfCode2020\Resources\input1.txt");
            //string[] lines = new string[] { "1721", "979", "366", "299", "675", "1456" };
            
            _lstLines = lines.OfType<string>().ToList();
        }

        [Test]
        public void Test1()
        {
            int result = Search(_lstLines, 2020);

            Console.WriteLine("Result: " + result);
            Assert.IsNotNull(result.ToString());
        }

        [Test]
        public void Test2()
        {
            int result = 0, resultPartial = 0;

            for (int i = 0; i < _lstLines.Count(); i++)
            {
                resultPartial = 2020 - int.Parse(_lstLines[i]);
                
                List<string> lstPartial = _lstLines.GetRange(i + 1, _lstLines.Count() - (i + 1));
                
                result = Search(lstPartial, resultPartial);
                
                if (result != 0) break;
            }

            Console.WriteLine("Result: " + result * (2020 - resultPartial));
            Assert.IsNotNull(result.ToString());
        }

        private int Search(List<string> lstLines, int search)
        {
            int result = 0, resultPartial = 0;

            for (int i = 0; i < lstLines.Count(); i++)
            {
                resultPartial = search - int.Parse(lstLines[i].Trim().ToString());

                for (int j = i + 1; j <= lstLines.Count() - 1; j++)
                    if (lstLines[j].Trim().ToString().Equals(resultPartial.ToString()))
                        return resultPartial * int.Parse(lstLines[i].Trim().ToString());
            }
            return result;
        }
    }
}