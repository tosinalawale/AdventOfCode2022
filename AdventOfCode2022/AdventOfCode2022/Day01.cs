namespace AdventOfCode2022
{
    using System;

    public class Day01
    {
        public static int CalculateResultForPartOne(string[] input)
        {
            var elfCalorieTotals = CalculateElfCalorieTotals(input);

            return elfCalorieTotals.Max();
        }

        public static int CalculateResultForPartTwo(string[] input)
        {
            var elfCalorieTotals = CalculateElfCalorieTotals(input);

            return elfCalorieTotals.OrderByDescending(x => x).Take(3).Sum();
        }

        private static List<int> CalculateElfCalorieTotals(string[] input)
        {
            var currentSum = 0;
            var elfCalorieTotals = new List<int>();

            foreach (var line in input)
            {
                if (line.Equals(string.Empty))
                {
                    elfCalorieTotals.Add(currentSum);
                    currentSum = 0;
                    continue;
                }

                currentSum += int.Parse(line);
            }

            //need this if input doesn't end with a blank line
            if (currentSum > 0) elfCalorieTotals.Add(currentSum);

            return elfCalorieTotals;
        }
    }
}