namespace AdventOfCode2022.Day07
{
    public class FileElement
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public DirectoryElement Parent { get; set; }
    }
}