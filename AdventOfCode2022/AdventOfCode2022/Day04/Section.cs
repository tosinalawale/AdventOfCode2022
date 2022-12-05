namespace AdventOfCode2022.Day04
{
    using System;

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

        public bool IsFullyContainedIn(Section otherSection)
        {
            return otherSection.Start <= this.Start && this.End <= otherSection.End;
        }

        public bool Overlaps(Section otherSection)
        {
            return otherSection.Start >= this.Start && otherSection.Start <= this.End ||
                this.Start >= otherSection.Start && this.Start <= otherSection.End;
        }
    }
}
