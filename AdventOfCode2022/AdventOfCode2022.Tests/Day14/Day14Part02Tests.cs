namespace AdventOfCode2022.Tests.Day14
{
    using AdventOfCode2022.Day14;

    public class Day14Part02Tests
    {
        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "498,4 -> 498,6 -> 496,6",
                "503,4 -> 502,4 -> 502,9 -> 494,9"
            };

            Day14Part02.CalculateResult(input).Should().Be(93);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input14.txt");
            Console.WriteLine(Day14Part02.CalculateResult(input));
        }
    }
}