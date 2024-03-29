﻿namespace AdventOfCode2022.Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day04Part01
    {
        public static int CalculateResult(string[] input)
        {
            var fullyContainedSections = 0;

            foreach (var line in input)
            {
                var pair = line.Split(',');
                var firstSection = new Section(pair[0]);
                var secondSection = new Section(pair[1]);

                if (firstSection.IsFullyContainedIn(secondSection) ||
                    secondSection.IsFullyContainedIn(firstSection))
                {
                    fullyContainedSections++;
                }
            }

            return fullyContainedSections;
        }
    }
}
