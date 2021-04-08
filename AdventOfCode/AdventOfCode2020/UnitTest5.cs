using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class UnitTest5
    {   
        private string[] _lines;

        [SetUp]
        public void Setup()
        {
            _lines = File.ReadAllLines(@"D:\Proyectos\proyectos-personales\adventofcode\AdventOfCode\AdventOfCode2020\Resources\input5.txt");

            //_lines = new string[] { "BFFFBBFRRR", "FFFBBBFRRR", "BBFFBBFRLL" };
        }

        [Test]
        public void Test1andTest2()
        {
            int lowerRow = 0;
            int upperRow = 127;
            int rightColumn = 0;
            int leftColumn = 7;
            int ID = 0;

            List<int> IDs = new List<int>();

            foreach (string letters in _lines)
            {
                foreach (var letter in letters)
                {
                    switch (letter)
                    {
                        case 'F':
                            upperRow = ((upperRow - lowerRow) / 2) + lowerRow;
                            break;
                        case 'B':
                            lowerRow = (((upperRow - lowerRow) / 2) + 1) + lowerRow;
                            break;
                        case 'L':
                            leftColumn = ((leftColumn - rightColumn) / 2) + rightColumn;
                            break;
                        case 'R':
                            rightColumn = (((leftColumn - rightColumn) / 2) + 1) + rightColumn;
                            break;
                        default:
                            break;
                    }
                }
                IDs.Add(lowerRow * 8 + rightColumn);
                
                if (ID < (lowerRow * 8 + rightColumn))
                    ID = lowerRow * 8 + rightColumn;

                lowerRow = 0;
                upperRow = 127;
                rightColumn = 0;
                leftColumn = 7;
            }

            MetodoBurbuja(IDs);

            int min = IDs[0];
            List<int> results = new List<int>();


            for (int i = 0; i < IDs.Count(); i++)
            {
                if (IDs[i] != min)
                {
                    results.Add(IDs[i]);
                    i--;
                }
                    
                min++;
            }


            Console.WriteLine("Row: " + lowerRow);
            Console.WriteLine("Column: " + rightColumn);
            Console.WriteLine("Column: " + ID);
        }

        public void MetodoBurbuja(IList<int> listIds)
        {
            int t;
            for (int a = 1; a < listIds.Count(); a++)
                for (int b = listIds.Count() - 1; b >= a; b--)
                {
                    if (listIds[b - 1] > listIds[b])
                    {
                        t = listIds[b - 1];
                        listIds[b - 1] = listIds[b];
                        listIds[b] = t;
                    }
                }
        }
    }
}
