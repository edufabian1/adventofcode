using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public class UnitTest6
    {
        private string[] _lines;

        [SetUp]
        public void Setup()
        {
            //_lines = File.ReadAllLines(@"D:\Proyectos\proyectos-personales\adventofcode\AdventOfCode\AdventOfCode2020\Resources\input6.txt");

            _lines = new string[] {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b"
            };
        }

        [Test]
        public void Test1()
        {
            //Group
            string abc = "abcdefghijklmnopqrstuvwxyz";
            int countGroup = 0;
            IList<int> lstCountsGroups = new List<int>();

            foreach (string line in _lines)
            {
                if (line.Equals(string.Empty))
                {
                    abc = "abcdefghijklmnopqrstuvwxyz";
                    lstCountsGroups.Add(countGroup);
                    countGroup = 0;
                }
                foreach (char letter in line)
                {
                    if (abc.Contains(letter))
                    {
                        countGroup++;
                        abc = abc.Replace(letter, '-');
                    }
                }              
            }

            foreach (int count in lstCountsGroups)
                countGroup += count;

            Console.WriteLine("Results: " + countGroup);
        }

        [Test]
        public void Test2()
        {
            //Group            
            string acumLetter = string.Empty;
            int countGroup = 0;
            IList<int> lstCountsGroups = new List<int>();

            foreach (string line in _lines)
            {
                if (line.Equals(string.Empty))
                {
                    acumLetter = string.Empty;
                    lstCountsGroups.Add(countGroup);
                    countGroup = 0;
                }
                if (acumLetter.Equals(string.Empty))
                {
                    acumLetter = line;
                    countGroup = acumLetter.Length;
                }   
                else
                {
                    foreach (char letter in line)
                    {
                        if (!acumLetter.Contains(letter))
                            countGroup--;
                    }
                }                
            }

            foreach (int count in lstCountsGroups)
                countGroup += count;

            Console.WriteLine("Results: " + countGroup);
        }

        [Test]
        public void Test3()
        {
            string palindromo = "neuquen", result = string.Empty;

            for (int i = palindromo.Length - 1; i >= 0; i--)
                result += palindromo[i];

            Assert.AreEqual(result, palindromo);
        }
    }
}
