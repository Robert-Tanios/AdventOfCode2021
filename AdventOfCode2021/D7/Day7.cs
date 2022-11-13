using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.D7
{

    public class Day7 : DayAncestor
    {
        private List<int> positions;

        public override void GetResults()
        {
            Console.WriteLine("Day 7 Part 1 answer is {0}", Part1());
            Console.WriteLine("Day 7 Part 2 answer is {0}", Part2());
        }


        public void GetAllPositions()
        {
            positions = File.ReadAllText(@"D7\Day7.txt").Split(',').Select(int.Parse).ToList();
        }

        /// <summary>
        /// Solution of the Part 1 of the Day 7 challenge
        /// </summary>
        public override long Part1()
        {
            GetAllPositions();
            var minAlignmentNeededFuel = int.MaxValue;
            int maxPosition = positions.Max();

            for (var i = 0; i <= maxPosition; i++)
            {
                //get the needed fuel quantity to do the alignement
                var alignmentNeededFuel = positions.Sum(x => Math.Abs(i - x));

                //take the lowest between the current and the previously calculated
                minAlignmentNeededFuel = Math.Min(alignmentNeededFuel, minAlignmentNeededFuel);
            }

            return minAlignmentNeededFuel;
        }

        /// <summary>
        /// Solution of the Part 2 of the Day 7 challenge
        /// </summary>
        public override long Part2()
        {
            GetAllPositions();
            var minAlignmentNeededFuel = int.MaxValue;

            // crab submarine engines don't burn fuel at a constant rate.
            // Instead, each change of 1 step in horizontal position costs 1 more unit of fuel than the last:
            // the first step costs 1, the second step costs 2, the third step costs 3, and so on.
            //10*11/2 = 55
            //10+9+8+7+6+5+4+3+2+1=55
            //this applies to all numbers where its sum with all previous numbers  = its value multiplied by the next value/2


            for (var i = 0; i <= positions.Max(); i++)
            {
                var alignmentNeededFuel = positions.Sum(x => Math.Abs(i - x) * (Math.Abs(i - x) + 1) / 2);

                minAlignmentNeededFuel = Math.Min(alignmentNeededFuel, minAlignmentNeededFuel);
            }

            return minAlignmentNeededFuel;
        }
    }
}