namespace AdventOfCode2022.Day06
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day06Part01
    {
        public static object CalculateResult(string[] input)
        {
            var currentChar = 0;
            for (int i = 0; i < input[0].Length - 3; i++)
            {
                if (AreAllDifferent(input[0][i], input[0][i + 1], input[0][i + 2], input[0][i + 3]))
                {
                    currentChar = i + 4;
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
