namespace AdventOfCode2022.Day12
{
    internal class GridElement
    {
        public int Height { get; set; }
        public bool Visited { get; set; }
        public bool IsGoalPosition { get; set; }
        public int StepsToPosition { get; set; }
    }
}