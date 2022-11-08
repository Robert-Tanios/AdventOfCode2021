using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D1
{
    class Day1
    {
        private List<int> depthReadings;

        public void TryMe()
        {
            GetDepthReadings();
            Part1();
            Part2();
            Console.ReadKey();
        }
        public void GetDepthReadings()
        {
            depthReadings = File.ReadAllLines(@"D1\Day1.txt").Select(int.Parse).ToList();
        }

        public void Part1()
        {
            int result = 0;

            for (int i = 1; i < depthReadings.Count; i++)
            {
                if (depthReadings[i] > depthReadings[i - 1]) result++;
            }
            Console.WriteLine(result);
        }


        public void Part2()
        {
            int result = 0;

            for (int i = 3; i < depthReadings.Count; i++)
            {
                if (depthReadings[i] + depthReadings[i - 1] + depthReadings[i - 2] > depthReadings[i - 1] + depthReadings[i - 2] + depthReadings[i - 3])
                {
                    result++;
                }
            }

            Console.WriteLine(result);

        }
    }
}
