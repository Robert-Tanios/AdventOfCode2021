using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D2
{
    class Day2
    {
        private List<(string Name, int Value)> commands;

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

            foreach (var (name, value) in commands)
            {
                switch (name)
                {
                    case "forward":
                        horizontalPosition += value;
                        break;

                    case "down":
                        depth += value;
                        break;

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

            foreach (var (name, value) in commands)
            {
                switch (name)
                {
                    case "down":
                        aim += value;
                        break;

                    case "up":
                        aim -= value;
                        break;

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