namespace AdventOfCode2022.Day08
{
    using System.Linq;

    internal static class TreeElementGrid
    {
        internal static TreeElement[][] Create(string[] input)
        {
            var treeGrid = new TreeElement[input.Length][];
            for (int i = 0; i < input.Length; i++)
            {
                treeGrid[i] = input[i].Select(c =>
                    new TreeElement
                    {
                        Height = int.Parse(c.ToString())
                    })
                    .ToArray();
            }

            return treeGrid;
        }
    }
}