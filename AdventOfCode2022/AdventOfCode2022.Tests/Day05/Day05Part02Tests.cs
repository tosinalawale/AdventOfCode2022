namespace AdventOfCode2022.Tests.Day05
{
    using AdventOfCode2022.Day05;
    using System.Collections;

    public class Day05Part02Tests
    {
        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "    [D]",
                "[N] [C]",
                "[Z] [M] [P]",
                " 1   2   3",
                "",
                "move 1 from 2 to 1",
                "move 3 from 1 to 3",
                "move 2 from 2 to 1",
                "move 1 from 1 to 2",
            };

            Day05Part02.CalculateResult(input).Should().Be("MCD");
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input05.txt");
            Console.WriteLine(Day05Part02.CalculateResult(input));
        }
    }
}