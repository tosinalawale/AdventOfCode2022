namespace AdventOfCode2022.Tests.Day06
{
    using AdventOfCode2022.Day06;
    using System.Collections;

    public class Day06Part01Tests
    {
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void CalculateResultForSimpleExamples(string inputString, int expectedResult)
        {
            var input = new[]
            {
                inputString
            };

            Day06Part01.CalculateResult(input).Should().Be(expectedResult);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input06.txt");
            Console.WriteLine(Day06Part01.CalculateResult(input));
        }
    }
}