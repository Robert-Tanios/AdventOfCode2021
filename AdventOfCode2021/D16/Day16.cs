
using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D16
{
    public class Day16 : DayAncestor
    {

        public override void GetResults()
        {
            Console.WriteLine("################## Day 16 ##################");
            ReadInputFile();
            Console.WriteLine("Day 16 Part 1 answer is {0}", Part1());

            //Console.WriteLine("Day 16 Part 2 answer is {0}", Part2());

        }

        private void ReadInputFile()
        {
            var lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D16\Day16.txt"));


        }

        /// <summary>
        /// Solution of the Part 1 of the Day 16 challenge
        /// </summary>
        public override string Part1()
        {
            return "";
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 16 challenge
        /// </summary>
        public override string Part2()
        {
            return "";
        }

    }
}