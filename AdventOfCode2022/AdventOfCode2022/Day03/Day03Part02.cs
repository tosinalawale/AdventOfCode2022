namespace AdventOfCode2022.Day03
{
    using System;

    public class Day03Part02
    {
        public static int CalculateResult(string[] input)
        {
            var total = 0;
            for (int i = 0; i < input.Length-2; i+=3)
            {
                var commonItem = FindCommonItem(input[i], input[i + 1], input[i + 2]);

                total += ItemPriorityConverter.ToItemPriority(commonItem);
            }

            return total;
        }

        private static string FindCommonItem(string firstItem, string secondItem, string thirdItem)
        {
            var commonCharacters = firstItem.Intersect(secondItem).Intersect(thirdItem);

            return new string(commonCharacters.ToArray());
        }
    }
}