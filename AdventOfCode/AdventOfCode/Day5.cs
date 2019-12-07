using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode
{
    [TestClass]
    public class Day5
    {
        [TestMethod]
        public void TestMethod1()
        {
            string input = System.IO.File.ReadAllText(@"D:\AdventOfCode\Puzzle input\input5.txt");

            var list = input.Split(',');

            //list[1] = "12";
            //list[2] = "2";

            var myInts = Array.ConvertAll(list, s => int.Parse(s));

            int var1, var2, res;
            //1 suma, 2 multiplica, 99 finaliza
            for (int i = 0; i < myInts.Length; i++)
            {
                if (myInts[i] == 1)
                {
                    var1 = myInts[i + 1];
                    var2 = myInts[i + 2];
                    res = myInts[i + 3];
                    myInts[res] = myInts[var1] + myInts[var2];
                    i += 3;
                }
                else if (myInts[i] % 4 == 1)
                {
                    string strNumero = QuitarDosUltimos(myInts[i]);
                    if (int.Parse(strNumero[0].ToString()) == 0)
                        var1 = myInts[i + 1];
                    else
                        var1 = myInts[myInts[i + 1]];
                    if (int.Parse(strNumero[1].ToString()) == 0)
                        var2 = myInts[i + 1];
                    else
                        var2 = myInts[myInts[i + 1]];

                    res = myInts[i + 3];
                    myInts[res] = myInts[var1] + myInts[var2];
                    i += 3;
                }
                else if (myInts[i] == 2)
                {
                    var1 = myInts[i + 1];
                    var2 = myInts[i + 2];
                    res = myInts[i + 3];
                    myInts[res] = myInts[var1] * myInts[var2];
                    i += 3;
                }
                else if (myInts[i] % 4 == 2)
                {
                    string strNumero = QuitarDosUltimos(myInts[i]);
                    if (strNumero[0] == 0)
                        var1 = myInts[i + 1];
                    else
                        var1 = myInts[myInts[i + 1]];
                    if (strNumero[1] == 0)
                        var2 = myInts[i + 1];
                    else
                        var2 = myInts[myInts[i + 1]];

                    res = myInts[i + 3];
                    myInts[res] = myInts[var1] * myInts[var2];
                    i += 3;
                }
                else if (myInts[i] == 3 || myInts[i] % 4 == 3)
                {
                    var numero = "1";
                    myInts[myInts[i + 1]] = int.Parse(numero);
                    i += 1;
                }
                else if (myInts[i] == 4 || myInts[i] % 4 == 0)
                {
                    Console.WriteLine(myInts[i + 1]);
                    i += 1;
                }
                else if (myInts[i] == 99)
                    break;
            }
            var result = myInts[0];

            Assert.IsNotNull(result);
        }

        public string QuitarDosUltimos(int numero)
        {
            var temporal = Math.Floor((float)numero / 100);
            string result = "";

            var longitud = temporal.ToString().Length;
            while (longitud < 3)
            {
                result += "0";

                longitud++;
            }
            return result + temporal;
        }

        public void ValidarNumero(int numero)
        {
            var strNumero = numero.ToString();

            switch (strNumero.Length)
            {
                case 5:
                    var temporal1 = strNumero.Substring(0, 3);
                    break;
                case 4:
                    var temporal2 = strNumero.Substring(0, 2);
                    break;
                case 3:
                    var temporal3 = strNumero.Substring(0, 1);
                    break;
                default:
                    break;
            }
        }
    }
}
