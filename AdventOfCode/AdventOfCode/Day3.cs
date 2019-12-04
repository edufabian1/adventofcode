using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnecionTest
{
    [TestClass]
    public class Day3
    {
        [TestMethod]
        public void Day3_part1_part2c_Test()
        {
            string text = System.IO.File.ReadAllText(@"D:\AdventOfCode\Puzzle input\input3.txt");
            var list = text.Split('\n');

            // Recorrido 1
            // "R8", "U5", "L5", "D3"
            // "R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72"
            // "R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51"
            //var aList1 = new string[] { "R8", "U5", "L5", "D3" };
            var aList1 = list[0].Split(',');

            var pInicial1 = new int[2];

            var recorrido1 = new List<int[]>();
            //recorrido1.Add(new int[] { 0,0 });

            RetornarRecorrido(aList1, pInicial1, recorrido1);

            // Recoriddo 2
            // "U7", "R6", "D4", "L4"
            // "U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83"
            // "U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7"
            //var aList2 = new string[] { "U7", "R6", "D4", "L4" };
            var aList2 = list[1].Split(',');

            var pInicial2 = new int[2];

            var recorrido2 = new List<int[]>();
            //recorrido2.Add(new int[] { 0, 0 });

            RetornarRecorrido(aList2, pInicial2, recorrido2);

            Assert.IsNotNull(recorrido1);
            Assert.IsNotNull(recorrido2);

            var result = new List<int[]>();
            foreach (var item in recorrido1)
            {
                var coincidencia = recorrido2.Find(element => element[0] == item[0] && element[1] == item[1]);

                if (coincidencia != null)
                    result.Add(coincidencia);
            }

            // Vectores de coincidencia
            Assert.IsNotNull(result);

            var distance = 0;

            foreach (var item in result)
            {
                if (distance == 0 || distance > Math.Abs(item[0]) + Math.Abs(item[1]))
                    distance = Math.Abs(item[0]) + Math.Abs(item[1]);
            }

            Assert.IsNotNull(distance);

            var sumatoria = 0;

            foreach (var item in result)
            {
                var temp = RetornarCantPasos(recorrido1, recorrido2, item);
                if (sumatoria == 0 || sumatoria > temp)
                    sumatoria = temp;
            }

            Assert.IsNotNull(sumatoria);
        }

        private int RetornarCantPasos(List<int[]> recorrido1, List<int[]> recorrido2, int[] puntoCercano)
        {
            var pasos1 = 0;
            var pasos2 = 0;

            foreach (var item in recorrido1)
            {
                if (item[0] == puntoCercano[0] && item[1] == puntoCercano[1])
                {
                    pasos1++;
                    break;
                }
                pasos1++;
            }

            foreach (var item in recorrido2)
            {
                if (item[0] == puntoCercano[0] && item[1] == puntoCercano[1])
                {
                    pasos2++;
                    break;
                }
                pasos2++;
            }

            return pasos1 + pasos2;
        }

        private void RetornarRecorrido(string[] aList, int[] pInicial, List<int[]> recorrido)
        {
            for (int i = 0; i < aList.Length; i++)
            {
                //Movimiento a la derecha
                if (aList[i].Contains("R"))
                {
                    var num = int.Parse(aList[i].Replace("R", ""));
                    while (num > 0)
                    {
                        pInicial[0] += 1;
                        recorrido.Add(new int[] { pInicial[0], pInicial[1] });

                        num--;
                    }
                }
                else if (aList[i].Contains("U"))
                {
                    var num = int.Parse(aList[i].Replace("U", ""));
                    while (num > 0)
                    {
                        pInicial[1] += 1;
                        recorrido.Add(new int[] { pInicial[0], pInicial[1] });

                        num--;
                    }
                }
                else if (aList[i].Contains("L"))
                {
                    var num = int.Parse(aList[i].Replace("L", ""));
                    while (num > 0)
                    {
                        pInicial[0] -= 1;
                        recorrido.Add(new int[] { pInicial[0], pInicial[1] });

                        num--;
                    }
                }
                else if (aList[i].Contains("D"))
                {
                    var num = int.Parse(aList[i].Replace("D", ""));
                    while (num > 0)
                    {
                        pInicial[1] -= 1;
                        recorrido.Add(new int[] { pInicial[0], pInicial[1] });

                        num--;
                    }
                }
            }
        }
    }
}
