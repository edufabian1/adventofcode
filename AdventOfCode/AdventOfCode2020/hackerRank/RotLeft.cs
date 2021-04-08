using NUnit.Framework;
using System;

namespace AdventOfCode2020.hackerRank
{
    class RotLeft
    {
        [Test]
        public void atest0()
        {
            rotLeft(new int[] { 1, 2, 3, 4, 5 }, 5);
        }

        int[] rotLeft(int[] a, int d)
        {
            int mover = (d >= a.Length) ? d % a.Length : d;


            int[] result = new int[a.Length];

            int posicion = 0;
            for (int i = mover; i < a.Length; i++)
            {
                result[posicion] = a[i];
                posicion++;
            }

            for (int i = 0; i < mover; i++)
            {
                result[posicion] = a[i];
                posicion++;
            }
            return result;
        }
    }
}
