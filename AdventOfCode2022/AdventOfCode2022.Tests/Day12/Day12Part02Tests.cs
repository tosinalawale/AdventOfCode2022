namespace AdventOfCode2022.Tests.Day12
{
    using AdventOfCode2022.Day12;

    public class Day12Part02Tests
    {
        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "Sabqponm",
                "abcryxxl",
                "accszExk",
                "acctuvwj",
                "abdefghi"
            };

            Day12Part02.CalculateResult(input).Should().Be(29);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input12.txt");
            Console.WriteLine(Day12Part02.CalculateResult(input));
        }
    }
}