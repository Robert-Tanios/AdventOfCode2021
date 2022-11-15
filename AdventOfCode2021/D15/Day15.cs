using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.D15
{
    public class Day15 : DayAncestor
    {
        string[] input;

        public override void GetResults()
        {
            Console.WriteLine("################## Day 15 ##################");
            ReadInputFile();
            Console.WriteLine("Day 15 Part 1 answer is {0}", Part1());
            Console.WriteLine("Day 15 Part 2 answer is {0}", Part2());
        }

        private void ReadInputFile()
        {
            input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D15\Day15.txt"));
        }

        /// <summary>
        /// Solution of the Part 1 of the Day 15 challenge
        /// </summary>
        public override string Part1()
        {
            return "";
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 15 challenge
        /// </summary>
        public override string Part2()
        {
            return "";
        }
    }
}