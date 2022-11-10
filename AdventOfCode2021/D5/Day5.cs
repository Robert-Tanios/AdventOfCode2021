using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D5
{
    public class Day5
    {
        private List<(int X1, int Y1, int X2, int Y2)> vents;

        public void TryMe()
        {
            ReadLinesOfVents();
            Part1();
            Part2();
            Console.ReadKey();
        }

        /// <summary>
        /// Get alll the line vents from the provided file
        /// </summary>
        public void ReadLinesOfVents()
        {
            string[] separator = new string[] { " -> " };
            vents = File.ReadAllLines(@"D5\Day5.txt")
                .Select(vent =>
                    (int.Parse(vent.Split(separator, StringSplitOptions.None)[0].Split(',')[0]),
                     int.Parse(vent.Split(separator, StringSplitOptions.None)[0].Split(',')[1]),
                     int.Parse(vent.Split(separator, StringSplitOptions.None)[1].Split(',')[0]),
                     int.Parse(vent.Split(separator, StringSplitOptions.None)[1].Split(',')[1])))
                .ToList();
        }


        /// <summary>
        /// Solution of the Part 1 of the Day 5 challenge
        /// </summary>
        public void Part1()
        {
            var points = new int[1000, 1000];

            foreach (var (x1, y1, x2, y2) in vents)
            {
                //only consider horizontal and vertical lines: lines where either x1 = x2 or y1 = y2.
                if (x1 == x2)
                {
                    //if the x is the same, increase the values of the cells from the lowest y to the highest y inclusive
                    for (var y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                    {
                        points[x1, y]++;
                    }
                }
                else if (y1 == y2)
                {
                    //if the y is the same, increase the values of the cells from the lowest x to the highest x inclusive
                    for (var x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                    {
                        points[x, y1]++;
                    }
                }
            }

            //count the number of cells that have their value >= 2
            var overlapsCount = points.Cast<int>().Count(v => v >= 2);

            Console.WriteLine(overlapsCount);
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 5 challenge
        /// </summary>
        public void Part2()
        {
            var points = new int[1000, 1000];
            //the lines in your list will only ever be horizontal, vertical, or a diagonal line at exactly 45 degrees.
            foreach (var (x1, y1, x2, y2) in vents)
            {
                var x = x1;
                var y = y1;
                var ax = Math.Sign(x2 - x1);
                var ay = Math.Sign(y2 - y1);

                while ((x, y) != (x2, y2))
                {
                    points[x, y]++;
                    x += ax;
                    y += ay;
                }

                points[x, y]++;
            }

            var overlapsCount = points.Cast<int>().Count(p => p >= 2);
            Console.WriteLine(overlapsCount);
        }
    }
}