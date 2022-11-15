using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D13
{
    public class Day13 : DayAncestor
    {
        List<(int X, int Y)> dots;
        List<(string FoldAlong, int Value)> folds;
        int numberOfRows;
        int numberOfColumns;
        bool[,] map;

        public override void GetResults()
        {
            Console.WriteLine("################## Day 13 ##################");
            ReadInputFile();
            Fold();
            Console.WriteLine("Day 13 Part 2 answer is CJHAZHKU");
            Console.WriteLine("############################################");
        }


        private void ReadInputFile()
        {
            var lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D13\Day13.txt"));
            dots = lines.TakeWhile(x => x != "").Select(x => (int.Parse(x.Split(',')[0]), int.Parse(x.Split(',')[1]))).ToList();
            folds = lines.SkipWhile(x => !x.Contains("fold along"))
                         .TakeWhile(x => x.Contains("fold along"))
                         .Select(x => x.Substring(11))
                         .Select(x => (x.Split('=')[0], int.Parse(x.Split('=')[1])))
                         .ToList();
            numberOfRows = dots.Select(x => x.Y).Max() + 1;
            numberOfColumns = dots.Select(x => x.X).Max() + 1;
        }

        /// <summary>
        /// Solution of the Part 1 of the Day 13 challenge
        /// </summary>
        private void Fold()
        {
            map = new bool[numberOfRows, numberOfColumns];

            foreach (var (x, y) in dots)
            {
                map[y, x] = true;
            }

            int visibleDots = 0;

            int upperLimit = 0;
            int counter = 0;
            foreach (var fold in folds)
            {
                counter++;
                if (fold.FoldAlong == "y")
                {
                    upperLimit = (int)(Math.Min(fold.Value, Math.Floor((numberOfRows - 1) / 2.0)));
                    for (var y = 0; y < upperLimit; y++)
                        for (var x = 0; x < numberOfColumns; x++)
                        {
                            if (map[y + fold.Value + 1, x])
                            {
                                map[fold.Value - y - 1, x] = true;
                                map[y + fold.Value + 1, x] = false;
                            }

                            map[fold.Value, x] = false;
                        }

                    numberOfRows = fold.Value;
                }

                if (fold.FoldAlong == "x")
                {
                    upperLimit = (int)(Math.Min(fold.Value, Math.Floor((numberOfColumns - 1) / 2.0)));
                    for (var y = 0; y < numberOfRows; y++)
                        for (var x = 0; x < upperLimit; x++)
                        {
                            if (map[y, x + fold.Value + 1])
                            {
                                map[y, fold.Value - x - 1] = true;
                                map[y, x + fold.Value + 1] = false;
                            }

                            map[y, fold.Value] = false;
                        }

                    numberOfColumns = fold.Value;
                }

                visibleDots = map.Cast<bool>().Count(x => x == true);
                if (counter == 1) Console.WriteLine("Day 13 Part 1 answer is {0}", visibleDots);

            }
            Print();

        }

        void Print()
        {
            for (var y = 0; y < numberOfRows; y++)
            {
                for (var x = 0; x < numberOfColumns; x++)
                    Console.Write(map[y, x] ? '#' : ' ');
                Console.WriteLine();
            }
            Console.WriteLine();
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