using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D12
{
    public class Day12 : DayAncestor
    {

        private int counter = 0;
        private Dictionary<string, List<string>> connections;

        private List<(string From, string To)> input;

        public override void GetResults()
        {
            ReadInputFile();
            Console.WriteLine("Day 12 Part 1 answer is {0}", Part1());
            Console.WriteLine("Day 12 Part 2 answer is {0}", Part2());
        }

        private void ReadInputFile()
        {
            input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D12\Day12.txt"))
                        .Select(x => x.Split('-'))
                        .Select(x => (x[0], x[1])) 
                        .ToList();

            connections = GetConnections(); 
        }


        private Dictionary<string, List<string>> GetConnections()
        {
            connections = new Dictionary<string, List<string>>();
            foreach (var (From, To) in input)
            {
                if (To != "start")
                {
                    if (connections.ContainsKey(From))
                    {
                        connections[From].Add(To);
                    }
                    else
                    {
                        connections.Add(From, new List<string>() { To });
                    }
                }

                if (From != "start")
                {
                    if (connections.ContainsKey(To))
                    {
                        connections[To].Add(From);
                    }
                    else
                    {
                        connections.Add(To, new List<string>() { From });
                    }
                }
            }

            return connections;
        }


        /// <summary>
        /// Solution of the Part 1 of the Day 12 challenge
        /// </summary>
        public override string Part1()
        {
            Explore("start", connections, new Stack<string>(), true);

            return counter.ToString();
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 12 challenge
        /// </summary>
        public override string Part2()
        {
            counter = 0;

            Explore("start", connections, new Stack<string>(), false);

            return counter.ToString();
        }


        private void Explore(string cave, Dictionary<string, List<string>> connections, Stack<string> stack, bool visitSmallCavesOnce)
        {
            stack.Push(cave);
            if (connections[cave].Contains("end"))
            {
                counter++;
            }

            foreach (string nextCave in connections[cave])
            {
                if (visitSmallCavesOnce)
                {
                    if (nextCave != "end" && (!stack.Contains(nextCave) || char.IsUpper(nextCave[0])))
                    {
                        Explore(nextCave, connections, new Stack<string>(stack), visitSmallCavesOnce);
                    }
                }
                else
                {
                    var test = stack.Where(x => x == nextCave && char.IsLower(x[0])).GroupBy(x => x).Count();
                    int num = 0;
                    if (test != 0)
                    {
                        num = stack.Where(x => char.IsLower(x[0])).GroupBy(x => x).Max(x => x.Count());
                    }

                    if (nextCave != "end" && (num != 2 || !stack.Contains(nextCave) || char.IsUpper(nextCave[0])))
                    {
                        Explore(nextCave, connections, new Stack<string>(stack), visitSmallCavesOnce);
                    }
                }
            }
        }
    }
}