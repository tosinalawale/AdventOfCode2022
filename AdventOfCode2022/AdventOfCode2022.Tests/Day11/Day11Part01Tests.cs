namespace AdventOfCode2022.Tests.Day11
{
    using AdventOfCode2022.Day11;

    public class Day11Part01Tests
    {
        [Test]
        public void CanSimulateFirstCoupleOfRounds()
        {
            var input = new[]
{
"Monkey 0:",
"  Starting items: 79, 98",
"  Operation: new = old * 19",
"  Test: divisible by 23",
"    If true: throw to monkey 2",
"    If false: throw to monkey 3",
"",
"Monkey 1:",
"  Starting items: 54, 65, 75, 74",
"  Operation: new = old + 6",
"  Test: divisible by 19",
"    If true: throw to monkey 2",
"    If false: throw to monkey 0",
"",
"Monkey 2:",
"  Starting items: 79, 60, 97",
"  Operation: new = old * old",
"  Test: divisible by 13",
"    If true: throw to monkey 1",
"    If false: throw to monkey 3",
"",
"Monkey 3:",
"  Starting items: 74",
"  Operation: new = old + 3",
"  Test: divisible by 17",
"    If true: throw to monkey 0",
"    If false: throw to monkey 1",
            };

            var monkeys = Day11Part01.SimulateRounds(input, 2);

            var expectedMonkeyStartingItems = new[]
            {
                new [] { 695, 10, 71, 135, 350 },
                new [] { 43, 49, 58, 55, 362 },
                Array.Empty<int>(),
                Array.Empty<int>()
            };

            monkeys.Select(m => m.StartingItems).Should().BeEquivalentTo(expectedMonkeyStartingItems);
        }

        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
"Monkey 0:",
"  Starting items: 79, 98",
"  Operation: new = old * 19",
"  Test: divisible by 23",
"    If true: throw to monkey 2",
"    If false: throw to monkey 3",
"",
"Monkey 1:",
"  Starting items: 54, 65, 75, 74",
"  Operation: new = old + 6",
"  Test: divisible by 19",
"    If true: throw to monkey 2",
"    If false: throw to monkey 0",
"",
"Monkey 2:",
"  Starting items: 79, 60, 97",
"  Operation: new = old * old",
"  Test: divisible by 13",
"    If true: throw to monkey 1",
"    If false: throw to monkey 3",
"",
"Monkey 3:",
"  Starting items: 74",
"  Operation: new = old + 3",
"  Test: divisible by 17",
"    If true: throw to monkey 0",
"    If false: throw to monkey 1",
            };

            Day11Part01.CalculateResult(input).Should().Be(10605);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input11.txt");
            Console.WriteLine(Day11Part01.CalculateResult(input));
        }
    }
}