namespace AdventOfCode2022.Tests.Day08
{
    using AdventOfCode2022.Day08;

    public class Day08Part01Tests
    {
        //[Test]
        //public void CanGetTotalDirectorySizeForBaseCase()
        //{
        //    var input = new[]
        //    {
        //        "$ cd /",
        //        "$ ls",
        //        "14848514 b.txt",
        //        "8504156 c.dat",
        //        "4060174 j"
        //    };

        //    Day08Part01.CalculateResult(input).Should().Be(27412844);
        //}

        //[Test]
        //public void CanGetTotalDirectorySizeForMoreCaseWithNestedFolder()
        //{
        //    var input = new[]
        //    {
        //        "$ cd /",
        //        "$ ls",
        //        "dir a",
        //        "14848514 b.txt",
        //        "8504156 c.dat",
        //        "4060174 j",
        //        "$ cd a",
        //        "$ ls",
        //        "29116 f",
        //    };

        //    Day08Part01.GetRootDirectorySize(input).Should().Be(27441960);
        //}


        //[Test]
        //public void CanGetTotalDirectorySizeForSimpleExample()
        //{
        //    var input = new[]
        //    {
        //        "$ cd /",
        //        "$ ls",
        //        "dir a",
        //        "14848514 b.txt",
        //        "8504156 c.dat",
        //        "dir d",
        //        "$ cd a",
        //        "$ ls",
        //        "dir e",
        //        "29116 f",
        //        "2557 g",
        //        "62596 h.lst",
        //        "$ cd e",
        //        "$ ls",
        //        "584 i",
        //        "$ cd ..",
        //        "$ cd ..",
        //        "$ cd d",
        //        "$ ls",
        //        "4060174 j",
        //        "8033020 d.log",
        //        "5626152 d.ext",
        //        "7214296 k"
        //    };

        //    Day08Part01.GetRootDirectorySize(input).Should().Be(48381165);
        //}

        [Test]
        public void CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "30373",
                "25512",
                "65332",
                "33549",
                "35390"
            };

            Day08Part01.CalculateResult(input).Should().Be(21);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input08.txt");
            Console.WriteLine(Day08Part01.CalculateResult(input));
        }
    }
}