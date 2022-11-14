using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.D11
{
    public class Day11 : DayAncestor
    {

        List<List<int>> input;
        private int inputCount;
        private int lineInputCount;

        public override void GetResults()
        {

            Console.WriteLine("Day 11 Part 1 answer is {0}", Part1());
            Console.WriteLine("Day 11 Part 2 answer is {0}", Part2());
        }

        private void ReadInputFile()
        {
            input = File.ReadAllLines(@"D11\Day11.txt").Select(x => x.Select(y => (int)(y - '0')).ToList()).ToList();
            inputCount = input.Count;
            lineInputCount = input[0].Count;
        }

        private void increaseByOne()
        {
            for (var i = 0; i < inputCount; i++)
            {
                for (var j = 0; j < lineInputCount; j++)
                {
                    input[i][j]++;
                }
            }
        }

        private List<(int, int)> GetToFlash()
        {
            var toFlash = new List<(int, int)>();
            for (var i = 0; i < inputCount; i++)
            {
                for (var j = 0; j < lineInputCount; j++)
                {
                    if (input[i][j] > 9)
                    {
                        input[i][j] = 10;
                        toFlash.Add((i, j));
                    }
                }
            }
            return toFlash;
        }

        /// <summary>
        /// Solution of the Part 1 of the Day 11 challenge
        /// </summary>
        public override long Part1()
        {
            ReadInputFile();

            var result = 0;

            for (var step = 0; step < 100; step++)
            {
                increaseByOne();

                var toFlash = GetToFlash();

                var flashes = 0;

                do
                {
                    var newToFlash = new List<(int, int)>();

                    foreach (var (i, j) in toFlash)
                    {
                        flashes++;

                        foreach (var (x, y) in Adj(i, j))
                        {
                            input[x][y]++;

                            if (input[x][y] == 10)
                            {
                                newToFlash.Add((x, y));
                            }
                        }
                    }

                    toFlash = newToFlash;

                } while (toFlash.Count > 0);

                for (var i = 0; i < inputCount; i++)
                    for (var j = 0; j < lineInputCount; j++)
                    {
                        if (input[i][j] >= 10)
                        {
                            input[i][j] = 0;
                        }
                    }

                result += flashes;
            }

            return result;
        }


        /// <summary>
        /// Solution of the Part 2 of the Day 11 challenge
        /// </summary>
        public override long Part2()
        {
            ReadInputFile();

            var result = 0;
            var step = 0;

            for (step = 0; step < 1000; step++)
            {
                increaseByOne();

                var flashes = 0;

                var toFlash = GetToFlash();

                do
                {
                    var newToFlash = new List<(int, int)>();

                    foreach (var (i, j) in toFlash)
                    {
                        flashes++;

                        foreach (var (x, y) in Adj(i, j))
                        {
                            input[x][y]++;

                            if (input[x][y] == 10)
                            {
                                newToFlash.Add((x, y));
                            }
                        }
                    }

                    toFlash = newToFlash;

                } while (toFlash.Count > 0);

                for (var i = 0; i < inputCount; i++)
                    for (var j = 0; j < lineInputCount; j++)
                    {
                        if (input[i][j] >= 10)
                        {
                            input[i][j] = 0;
                        }
                    }

                if (input.SelectMany(x => x).Count(x => x == 0) == lineInputCount * inputCount)
                {
                    break;
                }

                result += flashes;
            }

            return (step + 1);
        }


        private IEnumerable<(int, int)> Adj(int r, int c)
        {
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if (InBounds(r + i, c + j))
                        yield return (r + i, c + j);
        }

        private bool InBounds(int r, int c)
        {
            return r >= 0 && r < inputCount && c >= 0 && c < lineInputCount;
        }
    }
}