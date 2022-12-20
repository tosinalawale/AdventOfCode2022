namespace AdventOfCode2022.Tests.Day13
{
    using AdventOfCode2022.Day13;

    public class Day13Part01Tests
    {
        [Test]
        public void CanParsePacket1()
        {
            var packet = "[1,1,3,1,1]";

            var expectedParsedPacket = new[] { 1, 1, 3, 1, 1 };

            new PacketElement(packet).Contents().Should().BeEquivalentTo(expectedParsedPacket);
        }

        [Test]
        public void CanParsePacket2()
        {
            var packet = "[[1],[2,3,4]]";

            var expectedParsedPacket = new[] { new[] { 1 }, new[] { 2, 3, 4 } };

            new PacketElement(packet).Contents().Should().BeEquivalentTo(expectedParsedPacket);
        }

        [TestCase("[1,1,3,1,1]", "[1,1,5,1,1]", 1)]
        public void CanComparePairOfPackets(string left, string right, int expectedResult)
        {
            Day13Part01.Compare(left, right).Should().Be(expectedResult);
        }

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
                "            [3]",
                "",
                "[[[]]]",
                "[[]]",
                "",
                "[1,[2,[3,[4,[5,6,7]]]],8,9]",
                "[1,[2,[3,[4,[5,6,0]]]],8,9]",
            };

            Day13Part01.CalculateResult(input).Should().Be(13);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input13.txt");
            Console.WriteLine(Day13Part01.CalculateResult(input));
        }
    }
}