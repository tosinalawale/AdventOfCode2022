namespace AdventOfCode2022.Tests.Day09
{
    using AdventOfCode2022.Day09;

    public class Day09Part01Tests
    {
        [Test]
        public void CalculateResultForOneInstruction()
        {
            var input = new[]
            {
                "R 4"
            };

            Day09Part01.CalculateResult(input).Should().Be(4);
        }

        [Test]
        public void CalculateResultForTwoInstructions()
        {
            var input = new[]
            {
                "R 4",
                "U 2"
            };

            Day09Part01.CalculateResult(input).Should().Be(5);
        }

        [Test]
        public void CalculateResultForThreeInstructions()
        {
            var input = new[]
            {
                "R 4",
                "U 4",
                "L 3"
            };

            Day09Part01.CalculateResult(input).Should().Be(9);
        }

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

            Day09Part01.CalculateResult(input).Should().Be(13);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input09.txt");
            Console.WriteLine(Day09Part01.CalculateResult(input));
        }
    }
}