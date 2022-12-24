namespace AdventOfCode2022.Tests.Day13
{
    using AdventOfCode2022.Day13;

    public class Day13Part02Tests
    {
        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "[1, 1, 3, 1, 1]",
                "[1, 1, 5, 1, 1]",
                "",
                "[[1],[2, 3, 4]]",
                "[[1],4]",
                "",
                "[9]",
                "[[8,7,6]]",
                "",
                "[[4,4],4,4]",
                "[[4,4],4,4,4]",
                "",
                "[7,7,7,7]",
                "[7,7,7]",
                "",
                "[]",
                "[3]",
                "",
                "[[[]]]",
                "[[]]",
                "",
                "[1,[2,[3,[4,[5,6,7]]]],8,9]",
                "[1,[2,[3,[4,[5,6,0]]]],8,9]",
            };

            Day13Part02.CalculateResult(input).Should().Be(140);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input13.txt");
            Console.WriteLine(Day13Part02.CalculateResult(input));
        }
    }
}