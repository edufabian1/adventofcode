using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode
{
    [TestClass]
    public class Day4
    {
        [TestMethod]
        public void Day4_part1_Test()
        {
            var input = "165432 - 707912".Split('-');

            var inferior = input[0].Trim();
            var superior = input[1].Trim();

            var contador = 0;
            var resultList = new List<string>();

            while (int.Parse(inferior) <= int.Parse(superior))
            {
                for (int i = 0; i < inferior.Length - 1; i++)
                {
                    if (!resultList.Contains(inferior))
                    {
                        if (inferior[i].Equals(inferior[i + 1]))
                        {
                            if (ValidarDosNumerosConsecutivos(inferior))
                            {
                                resultList.Add(inferior);
                                contador++;
                            }
                        }
                    }
                }
                inferior = Convert.ToString(int.Parse(inferior) + 1);
            }
            
            Assert.IsNotNull(contador);
            Assert.IsNotNull(resultList);

            var contador2 = 0;
            var listaFinal = "";

            foreach (var item in resultList)
            {
                if (Validar(item) == 2)
                {
                    listaFinal += item + "\n";
                    contador2++;
                }
            }

            Assert.IsNotNull(contador2);
        }

        private bool ValidarDosNumerosConsecutivos(string numero)
        {
            for (int i = 0; i < numero.Length - 1; i++)
            {
                if (int.Parse(numero[i].ToString()) > int.Parse(numero[i + 1].ToString()))
                    return false;
            }
            return true;
        }

        [TestMethod]
        public void DosNumerosConsecutivos_Test()
        {
            var result1 = ValidarDosNumerosConsecutivos("123456");
            var result2 = ValidarDosNumerosConsecutivos("654321");
            var result3 = ValidarDosNumerosConsecutivos("111111");
            var result4 = ValidarDosNumerosConsecutivos("111336");

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);
        }


        private int Validar(string numero)
        {
            var contador = 1;
            for (int i = 0; i < numero.Length - 1; i++)
            {
                if (numero[i] == numero[i + 1])
                    contador++;
                else if (contador > 2)
                    contador = 1;
                else if (contador == 2)
                    return contador;
            }
            return contador;
        }

        [TestMethod]
        public void Random_Test()
        {
            var input = "12344";

            var result = Validar(input);

            Assert.AreEqual(result, 2);
        }
    }
}
