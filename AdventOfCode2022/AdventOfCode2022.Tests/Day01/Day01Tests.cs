namespace AdventOfCode2022.Tests.Day01
{
    using AdventOfCode2022.Day01;

    public class Day01Tests
    {
        [Test]
        public void Part1_CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "1000",
                "2000",
                "3000",
                "",
                "4000",
                "",
                "5000",
                "6000",
                "",
                "7000",
                "8000",
                "9000",
                "",
                "10000"
            };

            Day01.CalculateResultForPartOne(input).Should().Be(24000);
        }

        [Test]
        public void Part1_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input01.txt");
            Console.WriteLine(Day01.CalculateResultForPartOne(input));
        }

        [Test]
        public void Part2_CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "1000",
                "2000",
                "3000",
                "",
                "4000",
                "",
                "5000",
                "6000",
                "",
                "7000",
                "8000",
                "9000",
                "",
                "10000"
            };

            Day01.CalculateResultForPartTwo(input).Should().Be(45000);
        }

        [Test]
        public void Part2_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input01.txt");
            Console.WriteLine(Day01.CalculateResultForPartTwo(input));
        }
    }
}