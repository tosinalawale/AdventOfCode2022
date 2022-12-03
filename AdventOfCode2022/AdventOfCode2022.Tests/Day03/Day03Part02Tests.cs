namespace AdventOfCode2022.Tests.Day03
{
    using AdventOfCode2022.Day03;

    public class Day03Part02Tests
    {
        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw"
            };

            Day03Part02.CalculateResult(input).Should().Be(70);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input03.txt");
            Console.WriteLine(Day03Part02.CalculateResult(input));
        }
    }
}