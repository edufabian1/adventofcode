using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.hackerRank
{

    class JumpingOnTheClouds
    {
        [Test]
        public void Test1()
        {
            //  0, 0, 1, 0, 0, 1, 0 
            // 0,0,0,0,1,0
            // 0,0,0,1,0,0
            int result = jumpingOnClouds(new int[] { 0, 0, 1, 0, 0, 1, 0 });
        }
        int jumpingOnClouds(int[] c)
        {
            int steps = 0;

            for (int i = 0; i < c.Length; i++)
            {
                if (i == c.Length - 2)
                {
                    steps++;
                    break;
                }

                if (c[i + 2] == 0) i++;

                steps++;

                if (i >= c.Length - 2)
                    break;
            }

            return steps;
        }
    }
}
