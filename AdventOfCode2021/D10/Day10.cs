using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D10
{

    public class Day10 : DayAncestor
    {
        private List<string> navigationSubsystemLines;


        public override void GetResults()
        {
            Console.WriteLine("################## Day 10 ##################");
            ReadInputFile();
            Console.WriteLine("Day 10 Part 1 answer is {0}", Part1());
            Console.WriteLine("Day 10 Part 2 answer is {0}", Part2());
        }

        private void ReadInputFile()
        {

            navigationSubsystemLines = File.ReadAllLines(@"D10\Day10.txt").ToList();
        }

        private char GetClosingChunk(char openingChunk)
        {
            char closing = ' ';
            switch (openingChunk)
            {
                case '}':
                    closing = '{';
                    break;

                case ')':
                    closing = '(';
                    break;

                case ']':
                    closing = '[';
                    break;

                case '>':
                    closing = '<';
                    break;
            }

            return closing;
        }

        /// <summary>
        /// Solution of the Part 1 of the Day 10 challenge
        /// </summary>
        public override string Part1()
        {

            Dictionary<char, int> points = new Dictionary<char, int>() { ['}'] = 1197, [')'] = 3, [']'] = 57, ['>'] = 25137, };

            var syntaxErrorScore = 0;

            foreach (var line in navigationSubsystemLines)
            {
                var openingChunks = new Stack<char>();

                foreach (var chunk in line)
                {
                    //if it is an opening chunk, add it to the stack
                    if (isOpeningChunk(chunk))
                    {
                        openingChunks.Push(chunk);
                        //move to the next
                        continue;
                    }

                    //if not an opening, it should be a closing one related to the last one in the opening chunks
                    var openingChunk = openingChunks.Pop();

                    if (openingChunk != GetClosingChunk(chunk))
                    {
                        syntaxErrorScore += points[chunk];
                        break;
                    }
                }
            }

            return syntaxErrorScore.ToString();
        }


        private bool isOpeningChunk(char chunk)
        {
            return chunk.Equals('(') || chunk.Equals('{') || chunk.Equals('[') || chunk.Equals('<');
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 10 challenge
        /// </summary>
        public override string Part2()
        {
            Dictionary<char, int> points = new Dictionary<char, int>() { ['('] = 1, ['['] = 2, ['{'] = 3, ['<'] = 4 };

            var scores = new List<long>();

            foreach (var line in navigationSubsystemLines)
            {
                var incompleteLine = true;
                var openingChunks = new Stack<char>();

                foreach (var chunk in line)
                {
                    if (isOpeningChunk(chunk))
                    {
                        openingChunks.Push(chunk);
                        continue;
                    }

                    var openingChunk = openingChunks.Pop();

                    if (openingChunk != GetClosingChunk(chunk))
                    {
                        incompleteLine = false;
                        break;
                    }
                }

                if (incompleteLine)
                {
                    long score = 0;

                    while (openingChunks.Count > 0)
                    {
                        score = (score * 5) + points[openingChunks.Pop()];
                    }

                    scores.Add(score);
                }
            }

            //the winner is found by sorting all of the scores and then taking the middle score
            scores.Sort();
            var middleScore = scores[scores.Count / 2];

            return middleScore.ToString();
        }
    }
}