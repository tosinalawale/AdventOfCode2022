namespace AdventOfCode2022.Day06
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day06Part02
    {
        public static object CalculateResult(string[] input)
        {
            var currentChar = 0;
            for (int i = 0; i < input[0].Length - 13; i++)
            {
                if (AreAllDifferent(input[0][i], input[0][i + 1], input[0][i + 2], input[0][i + 3],
                    input[0][i + 4], input[0][i + 5], input[0][i + 6], 
                    input[0][i + 7], input[0][i + 8], input[0][i + 9],
                    input[0][i + 10], input[0][i + 11], input[0][i + 12], input[0][i + 13]))
                {
                    currentChar = i + 14;
                    break;
                }
            }

            return currentChar;
        }

        private static bool AreAllDifferent(params char[] characters)
        {
            return characters.Distinct().Count() == characters.Length;
        }
    }
}
