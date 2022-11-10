using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D6
{
    public class Day6
    {
        private List<int> listOfAges;

        public void TryMe()
        {
            Part1();

            Part2();
            Console.ReadKey();
        }

        /// <summary>
        /// Get all the ages from the provided file
        /// </summary>
        public void ReadListOfAges()
        {
            listOfAges = File.ReadAllText(@"D6\Day6.txt").Split(',').Select(int.Parse).ToList();
        }

        /// <summary>
        /// Solution of the Part 1 of the Day 6 challenge
        /// </summary>
        public void Part1()
        {
            Console.WriteLine("Part 1 answer is {0}", GetNumberOfFishesAfterManyDays(80));
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 6 challenge
        /// </summary>
        public void Part2()
        {
            Console.WriteLine("Part 2 answer is {0}", GetNumberOfFishesAfterManyDays(256));
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