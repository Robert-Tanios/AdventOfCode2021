using AdventOfCode2021.D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDay(13);

            //TestAllDays();
            Console.ReadKey();
        }

        private static void TestDay(int dayToTest)
        {
            var d = new DayAncestor();
            switch (dayToTest)
            {
                case 1:
                    d = new D1.Day1();
                    break;

                case 2:
                    d = new D2.Day2();
                    break;

                case 3:
                    d = new D3.Day3();
                    break;

                case 4:
                    d = new D4.Day4();
                    break;

                case 5:
                    d = new D5.Day5();
                    break;

                case 6:
                    d = new D6.Day6();
                    break;

                case 7:
                    d = new D7.Day7();
                    break;

                case 8:
                    d = new D8.Day8();
                    break;

                case 9:
                    d = new D9.Day9();
                    break;

                case 10:
                    d = new D10.Day10();
                    break;

                case 11:
                    d = new D11.Day11();
                    break;

                case 12:
                    d = new D12.Day12();
                    break;

                case 13:
                    d = new D13.Day13();
                    break;
            }
            d.GetResults();
        }


        private static void TestAllDays()
        {
            var d = new DayAncestor();

            d = new D1.Day1();
            d.GetResults();

            d = new D2.Day2();
            d.GetResults();

            d = new D3.Day3();
            d.GetResults();

            d = new D4.Day4();
            d.GetResults();

            d = new D5.Day5();
            d.GetResults();

            d = new D6.Day6();
            d.GetResults();

            d = new D7.Day7();
            d.GetResults();

            d = new D8.Day8();
            d.GetResults();

            d = new D9.Day9();
            d.GetResults();

            d = new D10.Day10();
            d.GetResults();

            d = new D11.Day11();
            d.GetResults();

            d = new D12.Day12();
            d.GetResults();

            d = new D13.Day13();
            d.GetResults();
        }
 

    }
}
