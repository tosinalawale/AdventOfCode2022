namespace AdventOfCode2022.Day05
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day05Part02
    {
        public static string CalculateResult(string[] input)
        {
            var endOfStacksDrawing = Array.FindIndex(input, s => s.Equals(string.Empty));

            List<Stack<char>> stacks = StackBuilder.BuildStacksFromInput(input, endOfStacksDrawing);

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
                var cratesToMove = new List<char>();

                for (int j = 0; j < numberOfCratesToMove; j++)
                {
                    cratesToMove.Add(stacks[startingStack - 1].Pop());
                }

                for (int k = cratesToMove.Count - 1; k >= 0; k--)
                {
                    stacks[destinationStack - 1].Push(cratesToMove[k]);
                }
            }
        }
    }
}
