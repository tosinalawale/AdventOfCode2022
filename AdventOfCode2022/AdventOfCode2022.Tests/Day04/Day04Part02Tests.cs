namespace AdventOfCode2022.Tests.Day04
{
    using AdventOfCode2022.Day04;

    public class Day04Part02Tests
    {
        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8"
            };

            Day04Part02.CalculateResult(input).Should().Be(4);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input04.txt");
            Console.WriteLine(Day04Part02.CalculateResult(input));
        }
    }
}