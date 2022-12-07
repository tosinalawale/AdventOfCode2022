namespace AdventOfCode2022.Tests.Day06
{
    using AdventOfCode2022.Day06;
    using System.Collections;

    public class Day06Part02Tests
    {
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        public void CalculateResultForSimpleExamples(string inputString, int expectedResult)
        {
            var input = new[]
            {
                inputString
            };

            Day06Part02.CalculateResult(input).Should().Be(expectedResult);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input06.txt");
            Console.WriteLine(Day06Part02.CalculateResult(input));
        }
    }
}