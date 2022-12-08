namespace AdventOfCode2022.Day07
{
    using System.Collections.Generic;

    public class DirectoryElement
    {
        public string? Name { get; set; }
        public DirectoryElement? Parent { get; set; }
        public List<FileElement> Files { get; set; } = new List<FileElement>();
        public List<DirectoryElement> Directories { get; set; } = new List<DirectoryElement>();
    }
}
