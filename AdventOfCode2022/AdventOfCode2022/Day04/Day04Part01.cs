namespace AdventOfCode2022.Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day04Part01
    {
        public static object CalculateResult(string[] input)
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

    internal class Section
    {
        public Section(string range)
        {
            var temp = range.Split('-');
            this.Start = int.Parse(temp[0]);
            this.End = int.Parse(temp[1]);
        }

        public int Start { get; set; }
        public int End { get; set; }

        internal bool IsFullyContainedIn(Section otherSection)
        {
            return otherSection.Start <= this.Start && this.End <= otherSection.End;
        }
    }
}
