using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D1
{
    class Day1 : DayAncestor
    {
        /// <summary>
        /// Holds all the depth readings retrivedf from provided file
        /// </summary>
        private List<int> depthReadings;

        /// <summary>
        /// Main function to test both Part1 and Part2
        /// </summary>
        public override void GetResults()
        {
            Console.WriteLine("################## Day 01 ##################");
            GetDepthReadings();
            Console.WriteLine("Day 1 Part 1 answer is {0}", Part1());
            Console.WriteLine("Day 1 Part 2 answer is {0}", Part2());
        }

        /// <summary>
        /// Initiates the vaiables with the readings from the provided file
        /// </summary>
        private void GetDepthReadings()
        {
            depthReadings = File.ReadAllLines(@"D1\Day1.txt").Select(int.Parse).ToList();
        }

        /// <summary>
        /// Solution of the first part in day 1 challenge
        /// </summary>
        public override string Part1()
        {
            int result = 0;

            for (int i = 1; i < depthReadings.Count; i++)
            {
                if (depthReadings[i] > depthReadings[i - 1]) result++;
            }
            return result.ToString();
        }

        /// <summary>
        /// Solution of the first part in day 1 challenge
        /// </summary>
        public override string Part2()
        {
            int result = 0;

            for (int i = 3; i < depthReadings.Count; i++)
            {
                if (depthReadings[i] + depthReadings[i - 1] + depthReadings[i - 2] > depthReadings[i - 1] + depthReadings[i - 2] + depthReadings[i - 3])
                {
                    result++;
                }
            }
            return result.ToString();
        }
    }
}
