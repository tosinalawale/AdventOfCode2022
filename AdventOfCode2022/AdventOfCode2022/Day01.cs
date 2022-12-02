namespace AdventOfCode2022
{
    using System;

    public class Day01
    {
        public static int CalculateResultForPartOne(string[] input)
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

            return elfCalorieTotals.Max();
        }
    }
}