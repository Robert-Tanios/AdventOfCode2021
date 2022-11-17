using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D15
{
    public class Day15 : DayAncestor
    {
        List<List<int>> input;
        List<Chiton> chitons = new List<Chiton>();
        public override void GetResults()
        {
            Console.WriteLine("################## Day 15 ##################");
            ReadInputFile();
            Console.WriteLine("Day 15 Part 1 answer is {0}", Part1());
            ExpandChitons();
            //Console.WriteLine("Day 15 Part 2 answer is {0}", Part2());
            Console.WriteLine("############################################");
        }

        private void ReadInputFile()
        {
            var lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D15\Day15.txt"));
            input = lines.Select(x => x.Select(y => int.Parse(y.ToString())).ToList()).ToList();

        }

        /// <summary>
        /// Solution of the Part 1 of the Day 15 challenge
        /// </summary>
        public override string Part1()
        {
            return Calculate();
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 15 challenge
        /// </summary>
        public override string Part2()
        {
            return Calculate();
        }

        private List<Chiton> GetAdjacent(int x, int y, List<Chiton> chitons)
        {
            List<Chiton> t = new List<Chiton>();
            t.Add(chitons.FirstOrDefault(chiton => chiton.X == (x + 1) && chiton.Y == y));
            t.Add(chitons.FirstOrDefault(chiton => chiton.X == (x - 1) && chiton.Y == y));
            t.Add(chitons.FirstOrDefault(chiton => chiton.X == (x) && chiton.Y == y + 1));
            t.Add(chitons.FirstOrDefault(chiton => chiton.X == (x) && chiton.Y == y - 1));

            return t;
        }

        class Chiton
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Risk { get; set; }
            public int Distance { get; set; } = Int32.MaxValue;
            public bool IsVisited { get; set; }
        }


        public string Calculate()
        {
            chitons = new List<Chiton>();

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Count; j++)
                {
                    chitons.Add(new Chiton() { X = i, Y = j, Risk = Int32.Parse(input[i][j].ToString()) });
                }
            }
            Chiton firstNode = chitons.First(x => x.X == 0 && x.Y == 0);
            firstNode.Distance = 0;
            Queue<Chiton> q = new Queue<Chiton>();
            q.Enqueue(firstNode);

            int rows = input.Count;
            int cols = input[0].Count;

            Chiton destinationNode = chitons[(rows * cols) - 1]; //.First(x => x.X == chitons.Max(a => a.X) && x.Y == chitons.Max(a => a.Y));

            while (q.Count > 0)
            {
                Chiton current = q.Dequeue();
                if (current.X == destinationNode.X && current.Y == destinationNode.Y)
                {
                    break;
                }

                if (current.IsVisited == true)
                {
                    continue;
                }

                current.IsVisited = true;
                List<Chiton> adjacentChitons = GetAdjacent(current.X, current.Y, chitons);
                foreach (var oneAdjacentChiton in adjacentChitons)
                {
                    if (oneAdjacentChiton == null)
                        continue;

                    var totalDistance = current.Distance + oneAdjacentChiton.Risk;
                    if (totalDistance < oneAdjacentChiton.Distance)
                    {
                        oneAdjacentChiton.Distance = totalDistance;
                    }

                    if (oneAdjacentChiton.Distance != int.MaxValue)
                    {
                        q.Enqueue(oneAdjacentChiton);
                    }
                }
            }

            return destinationNode.Distance.ToString();
        }


        private void ExpandChitons()
        {
            var rows = input.Count;
            for (var r = 0; r < rows; r++)
            {
                var original = input[r].ToList();

                for (var i = 1; i < 5; i++)
                {
                    input[r].AddRange(original.Select(x => 1 + (x - 1 + i) % 9));
                }
            }

            for (var i = 1; i < 5; i++)
            {
                for (var r = 0; r < rows; r++)
                {
                    var original = input[r].ToList();

                    input.Add(original.Select(x => 1 + (x - 1 + i) % 9).ToList());
                }
            }
        }
    }
}