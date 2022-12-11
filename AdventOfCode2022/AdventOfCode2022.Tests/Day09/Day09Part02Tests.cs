namespace AdventOfCode2022.Tests.Day09
{
    using AdventOfCode2022.Day09;

    public class Day09Part02Tests
    {
        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "R 4",
                "U 4",
                "L 3",
                "D 1",
                "R 4",
                "D 1",
                "L 5",
                "R 2"
            };

            Day09Part02.CalculateResult(input).Should().Be(1);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input09.txt");
            Console.WriteLine(Day09Part02.CalculateResult(input));
        }
    }
}