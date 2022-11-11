using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2021.D;

namespace AdventOfCode2021.D2 
{
    public class Day2: DayAncestor
    {
        /// <summary>
        /// Holds all the commands retreived from provided file
        /// </summary>
        private List<(string Name, int Value)> commands;

        private enum Direction
        {
            forward = 1,
            down = 2,
            up = 3

        }

        /// <summary>
        /// Main function to test both Part1 and Part2
        /// </summary>
        public override void GetResults()
        {
            GetCommands();
            Console.WriteLine("Day 2 Part 1 answer is {0}", Part1());
            Console.WriteLine("Day 2 Part 2 answer is {0}", Part2()); 
        }

        /// <summary>
        /// Initiates the vaiables with the commands from the provided file
        /// </summary>
        private void GetCommands()
        {
            commands = File.ReadAllLines(@"D2\Day2.txt")
                .Select(x => x.Split())
                .Select(x => (x[0], int.Parse(x[1])))
                .ToList();
        }

        /// <summary>
        /// Solution of the first part in day2 challenge
        /// </summary>
        public override long Part1()
        {
            var horizontalPosition = 0;
            var depth = 0;

            foreach (var (direction, value) in commands)
            {
                switch (direction)
                {
                    //forward X increases the horizontal position by X units.
                    case "forward":
                        horizontalPosition += value;
                        break;

                    //down X increases the depth by X units.
                    case "down":
                        depth += value;
                        break;

                    //up X decreases the depth by X units.
                    case "up":
                        depth -= value;
                        break;
                }
            }
            return (horizontalPosition * depth);
        }

        /// <summary>
        /// Solution of the second part in day2 challenge
        /// </summary>
        public override long Part2()
        {
            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;

            foreach (var (direction, value) in commands)
            {
                switch (direction)
                {
                    //down X increases your aim by X units.
                    case "down":
                        aim += value;
                        break;

                    //up X decreases your aim by X units.
                    case "up":
                        aim -= value;
                        break;

                    //forward X does two things:
                    //  It increases your horizontal position by X units.
                    //  It increases your depth by your aim multiplied by X.
                    case "forward":
                        horizontalPosition += value;
                        depth += aim * value;
                        break;
                }
            }

            return (horizontalPosition * depth);
        }
    }
}