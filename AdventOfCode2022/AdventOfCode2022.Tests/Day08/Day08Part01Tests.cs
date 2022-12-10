namespace AdventOfCode2022.Tests.Day08
{
    using AdventOfCode2022.Day08;

    public class Day08Part01Tests
    {
        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "30373",
                "25512",
                "65332",
                "33549",
                "35390"
            };

            Day08Part01.CalculateResult(input).Should().Be(21);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input08.txt");
            Console.WriteLine(Day08Part01.CalculateResult(input));
        }
    }
}