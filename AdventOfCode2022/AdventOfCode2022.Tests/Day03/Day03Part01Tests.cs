namespace AdventOfCode2022.Tests.Day03
{
    using AdventOfCode2022.Day03;

    public class Day03Part01Tests
    {
        [TestCase("a",1)]
        [TestCase("z",26)]
        [TestCase("A",27)]
        [TestCase("Z",52)]
        public void CanConvertItemToItemPriority(string item, int expectedItemPriority) 
        {
            AdventOfCode2022.Day03.ItemPriorityConverter.ToItemPriority(item).Should().Be(expectedItemPriority);
        }

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

            Day03Part01.CalculateResult(input).Should().Be(157);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input03.txt");
            Console.WriteLine(Day03Part01.CalculateResult(input));
        }
    }
}