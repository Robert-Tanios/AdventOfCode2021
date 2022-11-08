using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D2
{
    class Day2
    {
        private List<(string Name, int Value)> commands;

        private enum Direction
        {
            forward = 1, 
            down = 2, 
            up = 3

        }
        public void TryMe()
        {
            GetCommands();
            Part1();
            Part2();
            Console.ReadKey();
        }

        public void GetCommands()
        {
            commands = File.ReadAllLines(@"D2\Day2.txt")
                .Select(x => x.Split())
                .Select(x => (x[0], int.Parse(x[1])))
                .ToList();
        }


        public void Part1()
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
            Console.WriteLine(horizontalPosition * depth);
        }


        public void Part2()
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

            Console.WriteLine(horizontalPosition * depth);
        }
    }
}