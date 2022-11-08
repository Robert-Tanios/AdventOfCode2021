using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.D4
{

    public class Day4
    {
        private List<int> numbers;
        private readonly List<List<List<int>>> boards = new List<List<List<int>>>();

        /// <summary>
        /// Main function to test both Part1 and Part2
        /// </summary>
        public void TryMe()
        {
            ReadBoards();
            Part1();
            Part2();
            Console.ReadKey();
        }

        /// <summary>
        /// Reads the numbers and boards to initiate related variables
        /// </summary>
        public void ReadBoards()
        {
            var dataFromFile = File.ReadAllLines(@"D4\Day4.txt").ToList();
            var numberOfBoards = (dataFromFile.Count - 1) / 6;//each grid occupies 5 rows plus one blank

            numbers = dataFromFile[0].Split(',').Select(int.Parse).ToList();

            for (var i = 0; i < numberOfBoards; i++)
            {
                var board = new List<List<int>>();

                //each grid occupies 5 rows plus one blank and, each number could be one or two digits therefore trim blank
                for (var row = 0; row < 5; row++)
                {
                    board.Add(dataFromFile[2 + 6 * i + row].Split().Where(x => x.Trim() != "").Select(int.Parse).ToList());
                }

                boards.Add(board);
            }
        }


        /// <summary>
        /// Solution of the Part 1 in day3 challenge
        /// </summary>
        public void Part1()
        {
            int Bingo = 0;

            //draw number from the numbers and check if exists in boards
            foreach (var number in numbers)
            {
                markHit(number);

                //Once all numbers that matches were set to -1, check if any row/column hits bingo (sum=-5)
                foreach (var board in boards)
                {
                    //loop on the borads
                    for (var i = 0; i < 5; i++)
                    {
                        //if the 5 entries = -1, then their sum is -5, which means we have bingo
                        if (board[i].Sum() == -5 || board.Select(x => x[i]).Sum() == -5)
                        {
                            //sum of all unmarked numbers on the winning board
                            //Then, multiply that sum by the number that was just called when the board won (number) to get the final score
                            Bingo = board.SelectMany(x => x).Where(x => x != -1).Sum() * number;
                            Console.WriteLine(Bingo);
                            return;
                        }
                    }
                }
            }
            Console.WriteLine(Bingo);
        }

        /// <summary>
        /// Mark the number if found in the boards
        /// </summary>
        /// <param name="number">The number to be found</param>
        private void markHit(int number)
        {
            foreach (var board in boards)
            { //Loop on each row
                for (var i = 0; i < 5; i++)
                {
                    //loop on each entry in the row
                    for (var j = 0; j < 5; j++)
                    {
                        if (board[i][j] == number)
                        {
                            //if there's a match with the selected number, set its value to -1
                            board[i][j] = -1;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Solution of the second part in day 4 challenge
        /// </summary>
        public void Part2()
        {
            var finalScore = 0;

            foreach (var number in numbers)
            {
                //Mark the current number
                markHit(number);
                
                var winningBoards = new List<List<List<int>>>();

                foreach (var board in boards)
                {
                    //loop on the boards and get the winning ones and put them in a list to withdraw them later on
                    //also, many grid could probably in the same time when a number is withdrawn
                    for (var r = 0; r < 5; r++)
                    {
                        if (board[r].Sum() == -5 || board.Select(x => x[r]).Sum() == -5)
                        {
                            //get the score of the last winning board while looping on boards
                            finalScore = board.SelectMany(x => x).Where(x => x != -1).Sum() * number;

                            //add winning board to a list
                            winningBoards.Add(board);
                        }
                    }
                }

                //at this stage, all winning boards are in the winningBoards list
                foreach (var board in winningBoards)
                {
                    //remove the winning ones from the boards even if no board is left as "finalScore" contains the score of the last winning board
                    boards.Remove(board);
                }
            }

            Console.WriteLine(finalScore);
        }
    }
}