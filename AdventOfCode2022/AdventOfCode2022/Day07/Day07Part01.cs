namespace AdventOfCode2022.Day07
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day07Part01
    {
        public static int CalculateResult(string[] input)
        {
            var directoryRegister = new Dictionary<DirectoryElement, int>();

            var rootDirectory = new DirectoryElement { Name = "/", Parent = null };

            ProcessDirectory(rootDirectory, input, 0, directoryRegister);

            return directoryRegister.Values.Where(v => v <= 100000).Sum();
        }

        private static int ProcessDirectory(DirectoryElement startDirectory, string[] input, int index, Dictionary<DirectoryElement, int> directoryRegister)
        {
            var currentTotalFileSize = 0;
            var currentIndexInInput = 0;
            for (int i = index; i < input.Length; i++)
            {
                var inputWords = input[i].Split(' ');
                currentIndexInInput = i;

                if (inputWords[0].Equals("$") && inputWords[1].Equals("cd"))
                {
                    if (inputWords[2].Equals("..") || inputWords[2].Equals(startDirectory.Name))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (inputWords[0].Equals("$") && inputWords[1].Equals("ls"))
                {
                }
                else if (inputWords[0].Equals("dir"))
                {
                    var childDirectory = new DirectoryElement
                    {
                        Name = inputWords[1],
                        Parent = startDirectory
                    };
                    startDirectory.Directories.Add(childDirectory);
                }
                else
                {
                    var file = new FileElement
                    {
                        Name = inputWords[1],
                        Size = int.Parse(inputWords[0]),
                        Parent= startDirectory
                    };
                    startDirectory.Files.Add(file);
                    currentTotalFileSize += file.Size;
                }
            }

            foreach (var directory in startDirectory.Directories)
            {
                currentIndexInInput = ProcessDirectory(directory, input, currentIndexInInput, directoryRegister);
            }

            directoryRegister.Add(startDirectory, startDirectory.Files.Sum(f => f.Size) + startDirectory.Directories.Sum(d => directoryRegister[d]));

            return currentIndexInInput;
        }

        public static int GetRootDirectorySize(string[] input)
        {
            var directoryRegister = new Dictionary<DirectoryElement, int>();

            var rootDirectory = new DirectoryElement { Name = "/", Parent = null };

            ProcessDirectory(rootDirectory, input, 1, directoryRegister);

            return directoryRegister[rootDirectory];
        }
    }
}
