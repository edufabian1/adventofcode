using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace AdventOfCode2020
{

    public class UnitTest3
    {
        private List<string> _lstLines;
        private string[] _lines;

        [SetUp]
        public void Setup()
        {
            _lines = File.ReadAllLines(@"D:\Proyectos\proyectos-personales\adventofcode\AdventOfCode\AdventOfCode2020\Resources\input3.txt");            
            //_lines = new string[] { "..##.......",
            //                        "#...#...#..",
            //                        ".#....#..#.",
            //                        "..#.#...#.#",
            //                        ".#...##..#.",
            //                        "..#.##.....",
            //                        ".#.#.#....#",
            //                        ".#........#",
            //                        "#.##...#...",
            //                        "#...##....#",
            //                        ".#..#...#.#"
            //};
            //_lstLines = _lines.OfType<string>().ToList();
        }

        [Test]
        public void Test1()
        {
            int tree = SearchTree(3, 1);

            Console.WriteLine("Result: " + tree);
            Assert.IsNotNull(tree.ToString());
        }

        [Test]
        public void Test2()
        {
            int value1 = SearchTree(1, 1);
            int value2 = SearchTree(3, 1);
            int value3 = SearchTree(5, 1);
            int value4 = SearchTree(7, 1);
            int value5 = SearchTree(1, 2);

            int resutlt = value1 * value2 * value3 * value4 * value5;

            Console.WriteLine("Result: " + resutlt);
            Assert.IsNotNull(resutlt.ToString());
        }

        private string stringToSearch(int position, string search)
        {
            string result = search;
            while (position > result.Length - 1)
                result += search;
            return result;
        }

        private int SearchTree(int rightInitial, int downInitial)
        {
            int tree = 0;
            string search;

            int right = rightInitial, down = downInitial;

            while (down < _lines.Length -1)
            {
                search = (right > _lines[down].Length - 1) ? stringToSearch(right, _lines[down]) : _lines[down];
                search = search[right].ToString();

                if (search.Equals("#")) tree++;

                down += downInitial;
                right += rightInitial;
            }
            return tree;
        }

        private int Calculate(int rightInitial, int downInitial)
        {
            int tree = 0;
            string search;

            int right = rightInitial, down = downInitial;

            for (int i = downInitial; i < _lines.Length; downInitial++)
            {
                if (right > _lines[i].Length - 1)
                    search = stringToSearch(right, _lines[i]);
                else
                    search = _lines[i];

                if (search[right].Equals('#')) tree++;
            }
            return tree;
        }
    }
}
