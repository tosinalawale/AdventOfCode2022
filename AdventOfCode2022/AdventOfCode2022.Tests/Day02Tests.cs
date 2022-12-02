namespace AdventOfCode2022.Tests
{
    using AdventOfCode2022;

    public class Day02Tests
    {
        [Test]
        public void Part1_CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "A Y",
                "B X",
                "C Z",
            };

            Day02.CalculateResultForPartOne(input).Should().Be(15);
        }

        [Test]
        public void Part1_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input02.txt");
            System.Console.WriteLine(Day02.CalculateResultForPartOne(input));
        }
    }
}