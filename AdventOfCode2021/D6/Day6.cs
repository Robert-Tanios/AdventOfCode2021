using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D6
{
    public class Day6 : DayAncestor
    {
        private List<int> listOfAges;

        public override void GetResults()
        {
            Console.WriteLine("Day 6 Part 1 answer is {0}", Part1());
            Console.WriteLine("Day 6 Part 2 answer is {0}", Part2());
        }

        /// <summary>
        /// Get all the ages from the provided file
        /// </summary>
        private void ReadListOfAges()
        {
            listOfAges = File.ReadAllText(@"D6\Day6.txt").Split(',').Select(int.Parse).ToList();
        }

        /// <summary>
        /// Solution of the Part 1 of the Day 6 challenge
        /// </summary>
        public override long Part1()
        {
            return GetNumberOfFishesAfterManyDays(80);
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 6 challenge
        /// </summary>
        public override long Part2()
        {
            return GetNumberOfFishesAfterManyDays(256);
        }

        /// <summary>
        /// Counts the number of fishes after n days
        /// </summary>
        /// <param name="nDays">Number of days to calculate fishes after</param>
        /// <returns></returns>
        private long GetNumberOfFishesAfterManyDays(int nDays)
        {
            ReadListOfAges();

            const int numberOfAges = 10; //9 for the ages of 0 to 8 plus 1 or the newly born
            var fishesByAgesCount = new long[numberOfAges];

            foreach (var age in listOfAges)
            {
                fishesByAgesCount[age]++;
            }

            var zeroAgeIndex = 0;

            for (var i = 0; i < nDays; i++)
            {
                fishesByAgesCount[(zeroAgeIndex + 9) % numberOfAges] += fishesByAgesCount[zeroAgeIndex];
                fishesByAgesCount[(zeroAgeIndex + 7) % numberOfAges] += fishesByAgesCount[zeroAgeIndex];
                fishesByAgesCount[zeroAgeIndex] = 0;

                zeroAgeIndex = (zeroAgeIndex + 1) % numberOfAges;
            }

            return fishesByAgesCount.Sum();
        }
    }
}