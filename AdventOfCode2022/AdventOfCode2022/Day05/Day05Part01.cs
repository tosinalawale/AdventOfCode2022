namespace AdventOfCode2022.Day05
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day05Part01
    {
        public static string CalculateResult(string[] input)
        {
            var endOfStacksDrawing = Array.FindIndex(input, s => s.Equals(string.Empty));

            List<Stack<char>> stacks = BuildStacksFromInput(input, endOfStacksDrawing);

            ProcessInstructions(stacks, endOfStacksDrawing, input);

            return new string(stacks.Select(s => s.Peek()).ToArray());
        }

        private static void ProcessInstructions(List<Stack<char>> stacks, int endOfStacksDrawing, string[] input)
        {
            for (int i = endOfStacksDrawing + 1; i < input.Length; i++)
            {
                var instructions = input[i].Split(' ');
                var numberOfCratesToMove = int.Parse(instructions[1]);
                var startingStack = int.Parse(instructions[3]);
                var destinationStack = int.Parse(instructions[5]);

                for (int j = 0; j < numberOfCratesToMove; j++)
                {
                    var crate = stacks[startingStack - 1].Pop();
                    stacks[destinationStack - 1].Push(crate);
                }
            }
        }

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
