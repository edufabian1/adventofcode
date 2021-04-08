using NUnit.Framework;

namespace AdventOfCode2020.hackerRank
{

    public class HourglassSum
    {
        [Test]
        public void atest0()
        {
            int[][] array = new int[][] { new int[] { -1, -1, 0, -9, -2, -2 }, 
                new int[] {-2, -1, -6, -8, -2, -5 },
            new int[] { -1, -1, -1, -2, -3, -4 },
            new int[] { -1, -9, -2, -4, -4, -5 } ,
            new int[] { -7, -3, -3, -2, -9, -9 } ,
            new int[] { -1, -3, -1, -2, -4, -5 } };
            hourglassSum(array);
        }

        int hourglassSum(int[][] arr)
        {
            int result = 0;

            for (int i = 0; i < arr.Length-3; i++)
            {
                for (int j = 0; j < arr.Length-3; j++)
                {
                    int partial = sumOneHourglass(arr, j, i);
                    if (i == 0 && j == 0)
                        result = partial;
                    else if (partial > result)
                        result = partial;
                }
            }

            return result;
        }

        int sumOneHourglass(int[][] arr, int moverX, int moverY)
        {
            return arr[0+moverY][0+moverX] + arr[0+ moverY][1 + moverX] + arr[0+ moverY][2 + moverX] +
                arr[1 + moverY][1 + moverX] +
                arr[2 + moverY][0 + moverX] + arr[2 + moverY][1 + moverX] + arr[2 + moverY][2 + moverX];
        }
    }
}
