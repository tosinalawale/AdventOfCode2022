namespace AdventOfCode2022.Tests.Day07
{
    using AdventOfCode2022.Day07;

    public class Day07Part02Tests
    {
        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "$ cd /",
                "$ ls",
                "dir a",
                "14848514 b.txt",
                "8504156 c.dat",
                "dir d",
                "$ cd a",
                "$ ls",
                "dir e",
                "29116 f",
                "2557 g",
                "62596 h.lst",
                "$ cd e",
                "$ ls",
                "584 i",
                "$ cd ..",
                "$ cd ..",
                "$ cd d",
                "$ ls",
                "4060174 j",
                "8033020 d.log",
                "5626152 d.ext",
                "7214296 k"
            };

            Day07Part02.CalculateResult(input).Should().Be(24933642);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input07.txt");
            Console.WriteLine(Day07Part02.CalculateResult(input));
        }
    }
}