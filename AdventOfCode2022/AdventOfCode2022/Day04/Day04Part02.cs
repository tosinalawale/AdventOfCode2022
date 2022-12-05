namespace AdventOfCode2022.Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day04Part02
    {
        public static int CalculateResult(string[] input)
        {
            var overlappingSections = 0;

            foreach (var line in input)
            {
                var pair = line.Split(',');
                var firstSection = new Section(pair[0]);
                var secondSection = new Section(pair[1]);

                if (firstSection.Overlaps(secondSection))
                {
                    overlappingSections++;
                }
            }

            return overlappingSections;
        }
    }
}
