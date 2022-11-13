using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D8
{

    public class Day8 : DayAncestor
    {
        private List<(List<string> SignalPattern, List<string> Display)> digitsAndDisplay;


        public override void GetResults()
        {
            Console.WriteLine("Day 8 Part 1 answer is {0}", Part1());
            Console.WriteLine("Day 8 Part 2 answer is {0}", Part2());
        }

        /// <summary>
        /// Get Digits and Displays from input stream
        /// </summary>
        public void GetDigitsAndDisplay()
        {
            digitsAndDisplay = new List<(List<string> SignalPattern, List<string> Display)>();

            foreach (var line in File.ReadAllText(@"D8\Day8.txt").Split('\n'))
            {
                var digits = line.Split('|')[0].Trim().Split(' ').ToList();
                var display = line.Split('|')[1].Trim().Split(' ').ToList();

                digitsAndDisplay.Add((digits, display));
            }
        }


        /// <summary>
        /// Solution of the Part 1 of the Day 8 challenge
        /// </summary>
        public override long Part1()
        {
            GetDigitsAndDisplay();
            //one : 2
            //four : 4
            //seven : 3
            //eight : 7
            var count = digitsAndDisplay.SelectMany(x => x.Display).Count(x => x.Count() is 2 || x.Count() is 3 || x.Count() is 4 || x.Count() is 7);

            return (count);
        }


        /// <summary>
        /// Solution of the Part 2 of the Day 8 challenge
        /// </summary>
        public override long Part2()
        {
            var result = 0;

            foreach (var (signalPatterns, display) in digitsAndDisplay)
            {
                var one = signalPatterns.First(x => x.Length == 2).Sort();
                var four = signalPatterns.First(x => x.Length == 4).Sort();
                var seven = signalPatterns.First(x => x.Length == 3).Sort();
                var eight = signalPatterns.First(x => x.Length == 7).Sort();

                var fiveSegmentsSignalPatterns = signalPatterns.Where(x => x.Length == 5).ToArray();
                var sixSegmentsSignalPatternsAndOne = signalPatterns.Where(x => x.Length == 6).Union(new[] { one }).ToArray();

                var three = (GetSharedSegments(fiveSegmentsSignalPatterns) + one).Sort();
                var nine = (sixSegmentsSignalPatternsAndOne.First(x => GetNotSharedSegment(x, three).Count() == 1)).Sort();

                var a = seven.Except(one).First();
                var b = GetNotSharedSegment(three, nine).First();
                var f = GetSharedSegments(sixSegmentsSignalPatternsAndOne).First();
                var c = one.First(x => x != f);
                var d = GetNotSharedSegment(four, $"{b}{c}{f}").First();
                var g = GetNotSharedSegment(nine, $"{a}{b}{c}{d}{f}").First();
                var e = GetNotSharedSegment("abcdefg", $"{a}{b}{c}{d}{f}{g}").First();

                var zero = $"{a}{b}{c}{e}{f}{g}".Sort();
                var two = $"{a}{c}{d}{e}{g}".Sort();
                var five = $"{a}{b}{d}{f}{g}".Sort();
                var six = $"{a}{b}{d}{e}{f}{g}".Sort();


                var map = new Dictionary<string, char>
                {
                    [zero] = '0',
                    [one] = '1',
                    [two] = '2',
                    [three] = '3',
                    [four] = '4',
                    [five] = '5',
                    [six] = '6',
                    [seven] = '7',
                    [eight] = '8',
                    [nine] = '9',
                };

                var outputValue = int.Parse(new string(display.Select(x => x.Sort()).Select(x => map[x]).ToArray()));


                result += outputValue;
            }

            return (result);

            string GetSharedSegments(params string[] digits) => new string("abcdefg".Where(x => digits.All(c => c.Contains(x))).ToArray());

            string GetNotSharedSegment(params string[] digits)
            {
                var sharedSegments = GetSharedSegments(digits);

                return new string("abcdefg".Where(x => !sharedSegments.Contains(x) && digits.Any(d => d.Contains(x))).ToArray());
            }
        }
    }

    public static class StringExtensions
    {
        public static string Sort(this string s) => new string(s.OrderBy(x => x).ToArray());
    }

}