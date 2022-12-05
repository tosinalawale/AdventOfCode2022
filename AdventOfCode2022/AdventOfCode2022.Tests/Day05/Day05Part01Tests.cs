namespace AdventOfCode2022.Tests.Day05
{
    using AdventOfCode2022.Day05;
    using System.Collections;

    public class Day05Part01Tests
    {
        [Test]
        public void CanBuildStacksFromInput()
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

            var expectedStacks = new List<Stack>
            {
                new Stack(new[] { 'Z', 'N'}),
                new Stack(new[] { 'M', 'C', 'D'}),
                new Stack(new[] { 'P'})
            };

            var stacks = Day05Part01.BuildStacksFromInput(input, 4);
            stacks.Should().BeEquivalentTo(expectedStacks);
        }

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

            Day05Part01.CalculateResult(input).Should().Be("CMZ");
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input05.txt");
            Console.WriteLine(Day05Part01.CalculateResult(input));
        }
    }
}