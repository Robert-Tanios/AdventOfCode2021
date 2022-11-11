using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D8
{

    public class Day8 : DayAncestor
    {
        private List<(List<string> SignalPattern, List<string> Display)> input;


        public override void GetResults()
        {
            Console.WriteLine("Day 8 Part 1 answer is {0}", Part1());
            //Console.WriteLine("Day 8 Part 2 answer is {0}", Part2());
        }

        /// <summary>
        /// Get Digits and Displays from input stream
        /// </summary>
        public void GetDigitsAndDisplay()
        {
            input = new List<(List<string> SignalPattern, List<string> Display)> ();

            foreach (var line in File.ReadAllText(@"D8\Day8.txt").Split('\n'))
            {
                var digits = line.Split('|')[0].Trim().Split(' ').ToList();
                var display = line.Split('|')[1].Trim().Split(' ').ToList();

                input.Add((digits, display));
            }
        }


        public override long Part1()
        {
            GetDigitsAndDisplay();

            var count = input.SelectMany(x => x.Display).Count(x => x.Count() is 2 || x.Count() is 3 || x.Count() is 4 || x.Count() is 7);
            
            return (count);
        }


        public override long Part2()
        {
            return 0;
        }

 
    }
}