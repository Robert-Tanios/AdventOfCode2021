using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D6
{
    public class Day6
    {
        private List<int> listOfAges;

        public void SetUp()
        {
            listOfAges = File.ReadAllText(@"D6\Day6.txt").Split(',').Select(int.Parse).ToList();
        }


        public void Part1()
        {
            for (var i = 0; i < 80; i++)
            {
                var newFishes = 0;

                for (var j = 0; j < listOfAges.Count; j++)
                {
                    if (listOfAges[j] > 0) listOfAges[j]--;
                    else
                    {
                        listOfAges[j] = 6;
                        newFishes++;
                    }
                }
            }
        }

        public void Part2()
        {
            const int n = 10;
            var fishCountByAge = new long[n];

            foreach (var age in listOfAges)
            {
                fishCountByAge[age]++;
            }

            var zeroAgeIndex = 0;

            for (var i = 0; i < 256; i++)
            {
                fishCountByAge[(zeroAgeIndex + 9) % n] += fishCountByAge[zeroAgeIndex];
                fishCountByAge[(zeroAgeIndex + 7) % n] += fishCountByAge[zeroAgeIndex];
                fishCountByAge[zeroAgeIndex] = 0;

                zeroAgeIndex = (zeroAgeIndex + 1) % n;
            }

        }
    }
}