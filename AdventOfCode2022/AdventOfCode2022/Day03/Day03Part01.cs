namespace AdventOfCode2022.Day03
{
    using System;

    public class Day03Part01
    {
        public static int CalculateResult(string[] input)
        {
            return input.Select(r => FindItemInBothCompartments(r))
                .Select(i => ItemPriorityConverter.ToItemPriority(i))
                .Sum();
        }

        private static string FindItemInBothCompartments(string rucksackContents)
        {
            var firstCompartment = rucksackContents.Substring(0, rucksackContents.Length / 2);
            var secondCompartment = rucksackContents.Substring(rucksackContents.Length / 2);

            return new string(firstCompartment.Intersect(secondCompartment).ToArray());
        }
    }
}