using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText(@"D:\AdventOfCode\Puzzle input\input5.txt");
            //string input = "1002,4,3,4,33";
            //string input = "3,9,8,9,10,9,4,9,99,-1,8";
            //string input = "3,9,7,9,10,9,4,9,99,-1,8";
            //string input = "3,3,1108,-1,8,3,4,3,99";
            //string input = "3,3,1107,-1,8,3,4,3,99";
            //string input = "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9";
            //string input = "3,3,1105,-1,9,1101,0,0,12,4,12,99,1";
            //string input = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99";
            var list = input.Split(',');

            Day2Modify(list);
            Console.ReadKey();
        }
        private static void Day2Modify(string[] list)
        {
            var myInts = Array.ConvertAll(list, s => int.Parse(s));

            int var1, var2, res;
            //1 suma, 2 multiplica, 99 finaliza
            for (int i = 0; i < myInts.Length; i++)
            {
                var strNumero = AgregarCeros(myInts[i].ToString());
                int puntero = int.Parse(strNumero[4].ToString());
                if (puntero == 1)
                {
                    var1 = strNumero[2].Equals('1') ? myInts[i + 1] : myInts[myInts[i + 1]];
                    var2 = strNumero[1].Equals('1') ? myInts[i + 2] : myInts[myInts[i + 2]];
                    res = myInts[i + 3];
                    myInts[res] = var1 + var2;
                    i += 3;
                }
                else if (puntero == 2)
                {
                    var1 = strNumero[2].Equals('1') ? myInts[i + 1] : myInts[myInts[i + 1]];
                    var2 = strNumero[1].Equals('1') ? myInts[i + 2] : myInts[myInts[i + 2]];
                    res = myInts[i + 3];
                    myInts[res] = var1 * var2;
                    i += 3;
                }
                else if (puntero == 3)
                {
                    var input = int.Parse(Console.ReadLine());
                    myInts[myInts[i + 1]] = input;
                    i += 1;
                }
                else if (puntero == 4)
                {
                    var1 = strNumero[2].Equals('1') ? myInts[i + 1] : myInts[myInts[i + 1]];
                    Console.WriteLine(var1);
                    i += 1;
                }

                #region PART TWO
                else if (puntero == 5)
                {
                    var1 = strNumero[2].Equals('1') ? myInts[i + 1] : myInts[myInts[i + 1]];
                    var2 = strNumero[1].Equals('1') ? myInts[i + 2] : myInts[myInts[i + 2]];

                    if (var1 != 0)
                    {
                        myInts[i] = var2;
                        i = var2 - 1;
                    }
                    else
                        i += 2;
                }
                else if (puntero == 6)
                {
                    var1 = strNumero[2].Equals('1') ? myInts[i + 1] : myInts[myInts[i + 1]];
                    var2 = strNumero[1].Equals('1') ? myInts[i + 2] : myInts[myInts[i + 2]];

                    if (var1 == 0)
                    {
                        myInts[i] = var2;
                        i = var2 - 1;
                    }
                    else
                        i += 2;
                }
                else if (puntero == 7)
                {
                    var1 = strNumero[2].Equals('1') ? myInts[i + 1] : myInts[myInts[i + 1]];
                    var2 = strNumero[1].Equals('1') ? myInts[i + 2] : myInts[myInts[i + 2]];

                    res = var1 < var2 ? 1 : 0;
                    myInts[myInts[i + 3]] = res;
                    i += 3;
                }
                else if (puntero == 8)
                {
                    var1 = strNumero[2].Equals('1') ? myInts[i + 1] : myInts[myInts[i + 1]];
                    var2 = strNumero[1].Equals('1') ? myInts[i + 2] : myInts[myInts[i + 2]];

                    res = var1 == var2 ? 1 : 0;
                    myInts[myInts[i + 3]] = res;
                    i += 3;
                }
                #endregion

                else if (puntero == 9)
                    break;
            }
        }

        private static string AgregarCeros(string numero)
        {
            string valor = "";
            int longitud = numero.Length;
            while (longitud < 5)
            {
                valor += "0";
                longitud++;
            }
            return valor + numero;
        }
    }
}
