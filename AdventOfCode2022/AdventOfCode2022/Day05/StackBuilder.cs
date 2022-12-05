namespace AdventOfCode2022.Day05
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StackBuilder
    {
        public static List<Stack<char>> BuildStacksFromInput(string[] input, int endOfStacksDrawing)
        {
            var stackNumberRow = input[endOfStacksDrawing - 1];
            var stacks = new List<Stack<char>>();

            for (int i = 0; i < stackNumberRow.Length; i++)
            {
                if (!stackNumberRow[i].Equals(' '))
                {
                    stacks.Add(BuildStackFromColumn(i, endOfStacksDrawing, input));
                }
            }

            return stacks;
        }

        private static Stack<char> BuildStackFromColumn(int columnIndex, int endOfStacksDrawing, string[] input)
        {
            var stack = new Stack<char>();

            for (int i = endOfStacksDrawing - 2; i >= 0; i--)
            {
                var currentCrate = columnIndex < input[i].Length ? input[i][columnIndex] : ' ';

                if (currentCrate.Equals(' ')) break;

                stack.Push(currentCrate);
            }

            return stack;
        }
    }
}
