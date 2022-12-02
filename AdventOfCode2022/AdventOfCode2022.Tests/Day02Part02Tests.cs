namespace AdventOfCode2022.Tests
{
    using AdventOfCode2022.Day02;

    public class Day02Part02Tests
    {
        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "A Y",
                "B X",
                "C Z",
            };

            Day02Part02.CalculateResult(input).Should().Be(12);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input02.txt");
            System.Console.WriteLine(Day02Part02.CalculateResult(input));
        }
    }
}