namespace AdventOfCode2022.Tests.Day15
{
    using AdventOfCode2022.Day15;

    public class Day15Part01Tests
    {
        [TestCase("Sensor at x=2, y=2: closest beacon is at x=4, y=5", 2, 11)]
        [TestCase("Sensor at x=2, y=2: closest beacon is at x=4, y=5", 7, 1)]
        public void CalculateNumberOfPositionsWithoutBeaconsForSingleSensor(string sensorInput, int row, int expectedNumberOfPositions)
        {
            var input = new[]
            {
                sensorInput,
            };

            Day15Part01.GetNumberOfPositionsWithoutBeaconsOnRow(input, row).Should().Be(expectedNumberOfPositions);
        }

        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "Sensor at x=2, y=18: closest beacon is at x=-2, y=15",
                "Sensor at x=9, y=16: closest beacon is at x=10, y=16",
                "Sensor at x=13, y=2: closest beacon is at x=15, y=3",
                "Sensor at x=12, y=14: closest beacon is at x=10, y=16",
                "Sensor at x=10, y=20: closest beacon is at x=10, y=16",
                "Sensor at x=14, y=17: closest beacon is at x=10, y=16",
                "Sensor at x=8, y=7: closest beacon is at x=2, y=10",
                "Sensor at x=2, y=0: closest beacon is at x=2, y=10",
                "Sensor at x=0, y=11: closest beacon is at x=2, y=10",
                "Sensor at x=20, y=14: closest beacon is at x=25, y=17",
                "Sensor at x=17, y=20: closest beacon is at x=21, y=22",
                "Sensor at x=16, y=7: closest beacon is at x=15, y=3",
                "Sensor at x=14, y=3: closest beacon is at x=15, y=3",
                "Sensor at x=20, y=1: closest beacon is at x=15, y=3",
            };

            Day15Part01.GetNumberOfPositionsWithoutBeaconsOnRow(input, 10).Should().Be(26);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input15.txt");
            Console.WriteLine(Day15Part01.CalculateResult(input));
        }
    }
}