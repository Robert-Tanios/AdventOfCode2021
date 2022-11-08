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


        public void Part1()
        {
            int Bingo = 0;

            //draw number from the numbers and check if exists in boards
            foreach (var number in numbers)
            {
                //Loop on each board
                foreach (var board in boards)
                {
                    //Loop on each row
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



        public void Part2()
        {
            

        }
    }
}