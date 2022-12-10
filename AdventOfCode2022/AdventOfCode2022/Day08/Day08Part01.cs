namespace AdventOfCode2022.Day08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day08Part01
    {
        public static int CalculateResult(string[] input)
        {
            var treeGrid = TreeElementGrid.Create(input);
            var visibleTreeCount = 0;

            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    treeGrid[j][i].MaxHeightFromAbove = GetMaxHeightFromAbove(treeGrid, i, j);
                    treeGrid[j][i].MaxHeightFromBelow = GetMaxHeightFromBelow(treeGrid, i, j);
                    treeGrid[j][i].MaxHeightFromLeft = GetMaxHeightFromLeft(treeGrid, i, j);
                    treeGrid[j][i].MaxHeightFromRight = GetMaxHeightFromRight(treeGrid, i, j);

                    if (treeGrid[j][i].IsVisible) visibleTreeCount++;
                }
            }

            //For debugging: Display visibility for each tree
            //for (int j = 0; j < input.Length; j++)
            //{
            //    for (int i = 0; i < input[0].Length; i++)
            //    {
            //        Console.Write(treeGrid[j][i].IsVisible);
            //    }
            //    Console.WriteLine();
            //}

            return visibleTreeCount;
        }

        private static int GetMaxHeightFromAbove(TreeElement[][] treeGrid, int i, int j)
        {
            var currentTreeElement = treeGrid[j][i];

            if (j == 0)
            {
                return -1;
            }

            if (currentTreeElement.MaxHeightFromAbove is not null)
            {
                return currentTreeElement.MaxHeightFromAbove.Value;
            }

            return Math.Max(treeGrid[j-1][i].Height, GetMaxHeightFromAbove(treeGrid, i, j-1));
        }

        private static int GetMaxHeightFromBelow(TreeElement[][] treeGrid, int i, int j)
        {
            var currentTreeElement = treeGrid[j][i];

            if (j == treeGrid.Length-1)
            {
                return -1;
            }

            if (currentTreeElement.MaxHeightFromBelow is not null)
            {
                return currentTreeElement.MaxHeightFromBelow.Value;
            }

            return Math.Max(treeGrid[j+1][i].Height, GetMaxHeightFromBelow(treeGrid, i, j+1));
        }

        private static int GetMaxHeightFromLeft(TreeElement[][] treeGrid, int i, int j)
        {
            var currentTreeElement = treeGrid[j][i];

            if (i == 0)
            {
                return -1;
            }

            if (currentTreeElement.MaxHeightFromLeft is not null)
            {
                return currentTreeElement.MaxHeightFromLeft.Value;
            }

            return Math.Max(treeGrid[j][i-1].Height, GetMaxHeightFromLeft(treeGrid, i-1, j));
        }

        private static int GetMaxHeightFromRight(TreeElement[][] treeGrid, int i, int j)
        {
            var currentTreeElement = treeGrid[j][i];

            if (i == treeGrid[0].Length - 1)
            {
                return -1;
            }

            if (currentTreeElement.MaxHeightFromRight is not null)
            {
                return currentTreeElement.MaxHeightFromRight.Value;
            }

            return Math.Max(treeGrid[j][i+1].Height, GetMaxHeightFromRight(treeGrid, i+1, j));
        }
    }
}
