namespace AdventOfCode2022.Tests.Day07
{
    using AdventOfCode2022.Day07;

    public class Day07Part01Tests
    {
        [Test]
        public void CanGetDirectorySizeForBaseCase()
        {
            var input = new[]
            {
                "$ cd /",
                "$ ls",
                "14848514 b.txt",
                "8504156 c.dat",
                "4060174 j"
            };

            Day07Part01.GetRootDirectorySize(input).Should().Be(27412844);
        }

        [Test]
        public void CanGetDirectorySizeForMoreCaseWithNestedFolder()
        {
            var input = new[]
            {
                "$ cd /",
                "$ ls",
                "dir a",
                "14848514 b.txt",
                "8504156 c.dat",
                "4060174 j",
                "$ cd a",
                "$ ls",
                "29116 f",
            };

            Day07Part01.GetRootDirectorySize(input).Should().Be(27441960);
        }


        [Test]
        public void CanGetTotalDirectorySizeForSimpleExample()
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

            Day07Part01.GetRootDirectorySize(input).Should().Be(48381165);
        }

        //        [Test]
        //        public void CanBuildDirectoryTreeFromInput()
        //        {
        //            var input = new[]
        //            {
        //                "$ cd /",
        //                "$ ls",
        //                "dir a",
        //                "14848514 b.txt",
        //                "8504156 c.dat",
        //                "dir d",
        //                "$ cd a",
        //                "$ ls",
        //                "29116 f",
        //                "$ cd d",
        //                "$ ls",
        //                "4060174 j"
        //            };

        //            var directoryA = new FileSystemElement
        //            {
        //                Name = "a",
        //                Contents = new List<FileSystemElement>
        //                {

        //                }
        //            };

        //            var expectedFileSystemTree = new FileSystemElement
        //            {
        //                Name = "/",
        //                Contents = new List<FileSystemElement>
        //                {

        //                }
        //            };

        ///*@"- / (dir)
        //    - a(dir)
        //    - e(dir)
        //        - i(file, size = 584)
        //    - f(file, size = 29116)
        //    - g(file, size = 2557)
        //    - h.lst(file, size = 62596)
        //    - b.txt(file, size = 14848514)
        //    - c.dat(file, size = 8504156)
        //    - d(dir)
        //    - j(file, size = 4060174)
        //    - d.log(file, size = 8033020)
        //    - d.ext(file, size = 5626152)
        //    - k(file, size = 7214296)"*/

        //        }

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

            Day07Part01.CalculateResult(input).Should().Be(95437);
        }

        [Test]
        public void CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input07.txt");
            Console.WriteLine(Day07Part01.CalculateResult(input));
        }
    }
}