using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D13
{
    public class Day13 : DayAncestor
    {
        private List<(string From, string To)> input;

        public override void GetResults()
        {
            ReadInputFile();
            Console.WriteLine("Day 13 Part 1 answer is {0}", Part1());
            Console.WriteLine("Day 13 Part 2 answer is {0}", Part2());
        }

        private void ReadInputFile()
        {
            input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D13\Day13.txt"))
                        .Select(x => x.Split('-'))
                        .Select(x => (x[0], x[1]))
                        .ToList();
        }

        /// <summary>
        /// Solution of the Part 1 of the Day 13 challenge
        /// </summary>
        public override long Part1()
        {
            return 0;
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 13 challenge
        /// </summary>
        public override long Part2()
        {
            return 0;
        }

    }
}