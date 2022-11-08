using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.D3
{
    class Day3
    {

        private List<string> binaryNumbers;
        private int numberOfBits;

        /// <summary>
        /// Main function to test both Part1 and Part2
        /// </summary>
        public void TryMe()
        {
            ReadBinaryNumbers();
            Part1();
            Part2();
            Console.ReadKey();
        }


        /// <summary>
        /// Main function to test both Part1 and Part2
        /// </summary>
        public void ReadBinaryNumbers()
        {
            binaryNumbers = File.ReadAllLines(@"D3\Day3.txt").ToList();
            numberOfBits = binaryNumbers[0].Length;
        }

        public void Part1()
        {
            //Each bit in the gamma rate can be determined by finding the most common bit in the corresponding
            //position of all numbers in the diagnostic report
            string gammaRate = new string(Enumerable.Range(0, numberOfBits)
                .Select(i => binaryNumbers.Count(c => c[i] == '1') >
                             binaryNumbers.Count(c => c[i] == '0') ? '1' : '0')
                .ToArray());

            //The epsilon rate is calculated in a similar way thab gamma;
            //rather than use the most common bit, the least common bit from each position is used
            //It is also the inverse of the gamma rate
            string epsilonRate = new string(gammaRate.Select(x => x == '1' ? '0' : '1')
                .ToArray());

            //The power consumption can then be found by multiplying the gamma rate by the epsilon rate.
            int powerConsumption = Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);

            Console.WriteLine(powerConsumption);
        }

        public void Part2()
        {
           
        }
    }
}