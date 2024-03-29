namespace AdventOfCode2022.Tests.Day02
{
    using AdventOfCode2022.Day02;

    public class Day02Part01Tests
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

            Day02Part01.CalculateResult(input).Should().Be(15);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input02.txt");
            Console.WriteLine(Day02Part01.CalculateResult(input));
        }
    }
}