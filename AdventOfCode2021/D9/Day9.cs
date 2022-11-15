using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D9
{

    public class Day9 : DayAncestor
    {
        private List<string> heightMap;
        private bool[,] alreadyConsidered;
        private int rows, columns;

        public override void GetResults()
        {
            Console.WriteLine("################## Day 09 ##################");
            Console.WriteLine("Day 9 Part 1 answer is {0}", Part1());
            Console.WriteLine("Day 9 Part 2 answer is {0}", Part2());
        }

        private void ReadInputFile()
        {
            heightMap = File.ReadAllLines(@"D9\Day9.txt").ToList();
            rows = heightMap.Count;
            columns = heightMap[0].Length;
        }

        /// <summary>
        /// Returns the height for a given point
        /// </summary>
        /// <param name="r">row of the point in the grid</param>
        /// <param name="c">column of the point in the grid</param>
        /// <returns>Returns the height</returns>
        private int GetPointHeight(int r, int c)
        {
            //Returns the height of a point, taking into consideraiton the edges
            return r < 0 || r >= rows || c < 0 || c >= columns ? int.MaxValue : heightMap[r][c] - '0';
        }

        /// <summary>
        /// Calculates the risk level for the provided point
        /// </summary>
        /// <param name="r">row of the point in the grid</param>
        /// <param name="c">column of the point in the grid</param>
        /// <returns>Returns the risk level</returns>
        private int GetPointRiskLevel(int r, int c)
        {
            var height = GetPointHeight(r, c);
            //The risk level of a low point is 1 plus its height, in case it is the lowest point
            return height < GetPointHeight(r - 1, c) && height < GetPointHeight(r + 1, c) && height < GetPointHeight(r, c - 1) && height < GetPointHeight(r, c + 1)
                    ? 1 + height
                    : 0;
        }

        /// <summary>
        /// Solution of the Part 1 of the Day 9 challenge
        /// </summary>
        public override string Part1()
        {
            ReadInputFile();
            var result = 0;

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    result += GetPointRiskLevel(r, c);
                }
            }

            return result.ToString();

        }


        private long BasinSize(int r, int c)
        {
            if (GetPointHeight(r, c) == 9 || PointAlreadyConsidered(r, c)) return 0;

            alreadyConsidered[r, c] = true;

            return 1 + BasinSize(r - 1, c) + BasinSize(r + 1, c) + BasinSize(r, c - 1) + BasinSize(r, c + 1);
        }


        /// <summary>
        /// Checks if the point was already considered while checking basin size
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool PointAlreadyConsidered(int r, int c)
        {
            return (r < 0 || r >= rows || c < 0 || c >= columns || alreadyConsidered[r, c]);
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 9 challenge
        /// </summary>
        public override string Part2()
        {
            long result = 0;
            var basinSizes = new List<long>();

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    var heightValue = GetPointHeight(r, c);

                    if (heightValue < GetPointHeight(r - 1, c) && heightValue < GetPointHeight(r + 1, c) && heightValue < GetPointHeight(r, c - 1) && heightValue < GetPointHeight(r, c + 1))
                    {
                        alreadyConsidered = new bool[rows, columns];
                        var basinSize = BasinSize(r, c);

                        basinSizes.Add(basinSize);
                    }
                }
            }
            result = basinSizes.OrderByDescending(x => x).Take(3).Aggregate(1L, (x, y) => x * y);

            return result.ToString();
        }
    }

}