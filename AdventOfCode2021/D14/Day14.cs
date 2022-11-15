using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.D14
{
    public class Day14 : DayAncestor
    {

        string input;
        Dictionary<string, char> pairs;

        public override void GetResults()
        {
            Console.WriteLine("################## Day 14 ##################");
            ReadInputFile();
            Console.WriteLine("Day 14 Part 1 answer is {0}", Part1());
            ReadInputFile();
            Console.WriteLine("Day 14 Part 2 answer is {0}", Part2());
        }

        private void ReadInputFile()
        {
            var lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D14\Day14.txt")).ToList();
            input = lines[0];
            pairs = lines.Skip(2).Select(x => x.Split(new string[] { " -> " }, StringSplitOptions.None)).ToDictionary(x => x[0], y => y[1][0]);
        }


        /// <summary>
        /// Solution of the Part 1 of the Day 14 challenge
        /// </summary>
        public override string Part1()
        {
            return WorkThePolimer(10);
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 14 challenge
        /// </summary>
        public override string Part2()
        {
            return WorkThePolimer(40);
        }

        private string WorkThePolimer(int steps)
        {
            var polimerPairs = new Dictionary<string, long>();
            var count = new Dictionary<char, long>();

            foreach (var c in input)
            {
                if (count.ContainsKey(c)) count[c] += 1;
                else count[c] = 1;
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                var polimerPair = "" + input[i] + input[i + 1];
                Add(polimerPair);
            }

            for (var j = 0; j < steps; j++)
            {
                var workingPair = new Dictionary<string, long>(polimerPairs);

                foreach (var pair in workingPair)
                {
                    var k = pair.Key;
                    var v = pair.Value;
                    polimerPairs[k] -= v;

                    if (polimerPairs[k] <= 0)
                    {
                        polimerPairs.Remove(k);
                    }

                    var c = pairs[k];

                    var first = $"{k[0]}{c}";
                    var second = $"{c}{k[1]}";

                    Add(first, v);
                    Add(second, v);

                    if (count.ContainsKey(c)) count[c] += v;
                    else count[c] = v;
                }
            }

            var mostCommon = count.Max(x => x.Value);
            var leastCommon = count.Min(x => x.Value);
            var result = mostCommon - leastCommon;

            return result.ToString();

            void Add(string s, long v = 1)
            {
                if (polimerPairs.ContainsKey(s)) polimerPairs[s] += v;
                else polimerPairs[s] = v;
            }
        }
    }
}