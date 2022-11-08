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
        /// Reads the binary data in the provided file
        /// </summary>
        public void ReadBinaryNumbers()
        {
            binaryNumbers = File.ReadAllLines(@"D3\Day3.txt").ToList();
            numberOfBits = binaryNumbers[0].Length;
        }

        /// <summary>
        /// Solution of the first part in day 3 challenge
        /// </summary>
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

        /// <summary>
        /// Solution of the second part in day3 challenge
        /// </summary>
        public void Part2()
        {
            int oxygenGeneratorRating = GetOxygenGeneratorRating();
            int co2ScrubberRating = GetCO2ScrubberRating();

            //life support rating can be determined by multiplying the oxygen generator rating by the CO2 scrubber rating
            int lifeSupportRating = oxygenGeneratorRating * co2ScrubberRating;
            Console.WriteLine(lifeSupportRating);
        }

        /// <summary>
        /// Calculates oxygen generator rating
        /// </summary>
        /// <returns>oxygen generator rating</returns>
        private int GetOxygenGeneratorRating()
        {
            //To find oxygen generator rating, determine the most common value (0 or 1) in the current bit position,
            //and keep only numbers with that bit in that position.
            //If 0 and 1 are equally common, keep values with a 1 in the position being considered.
            List<string> numbers = binaryNumbers.ToList();

            for (int i = 0; i < numberOfBits; i++)
            {
                var mostCommonValue = numbers.Count(b => b[i] == '1') >= numbers.Count(b => b[i] == '0') ? '1' : '0';

                numbers.RemoveAll(c => c[i] != mostCommonValue);

                //If you only have one number left, stop; this is the rating value for which you are searching.
                if (numbers.Count == 1) break;

                //Otherwise, repeat the process, considering the next bit to the right
            }

            return Convert.ToInt32(numbers.First(), 2);
        }

        /// <summary>
        /// Calculates the CO2 scrubber rating
        /// </summary>
        /// <returns>CO2 scrubber rating</returns>
        private int GetCO2ScrubberRating()
        {
            //To find CO2 scrubber rating, determine the least common value (0 or 1) in the current bit position,
            //and keep only numbers with that bit in that position.
            //If 0 and 1 are equally common, keep values with a 0 in the position being considered.
            List<string> numbers = binaryNumbers.ToList();

            for (int i = 0; i < numberOfBits; i++)
            {
                var leastCommonValue = numbers.Count(c => c[i] == '1') < numbers.Count(c => c[i] == '0') ? '1' : '0';

                numbers.RemoveAll(x => x[i] != leastCommonValue);

                //If you only have one number left, stop; this is the rating value for which you are searching.
                if (numbers.Count == 1) break;
                //Otherwise, repeat the process, considering the next bit to the right
            }

            return Convert.ToInt32(numbers.First(), 2);
        }
    }
}