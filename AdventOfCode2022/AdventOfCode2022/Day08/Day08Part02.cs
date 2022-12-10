namespace AdventOfCode2022.Day08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day08Part02
    {
        public static int CalculateResult(string[] input)
        {
            var treeGrid = TreeElementGrid.Create(input);
            var maxScenicDistance = 0;

            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    treeGrid[j][i].ViewingDistanceFromAbove = GetViewingDistanceFromAbove(treeGrid, i, j);
                    treeGrid[j][i].ViewingDistanceFromBelow = GetViewingDistanceFromBelow(treeGrid, i, j);
                    treeGrid[j][i].ViewingDistanceFromLeft = GetViewingDistanceFromLeft(treeGrid, i, j);
                    treeGrid[j][i].ViewingDistanceFromRight = GetViewingDistanceFromRight(treeGrid, i, j);

                    maxScenicDistance = Math.Max(maxScenicDistance, treeGrid[j][i].ScenicDistance);
                }
            }

            ////For debugging: Display scenic distance for each tree
            //for (int j = 0; j < input.Length; j++)
            //{
            //    for (int i = 0; i < input[0].Length; i++)
            //    {
            //        Console.Write(treeGrid[j][i].ScenicDistance);
            //    }
            //    Console.WriteLine();
            //}

            return maxScenicDistance;
        }

        private static int GetViewingDistanceFromAbove(TreeElement[][] treeGrid, int i, int j)
        {
            var currentTreeElement = treeGrid[j][i];

            if (j == 0)
            {
                return 0;
            }

            var viewingDistance = 0;
            for (int y = j - 1; y >= 0; y--)
            {
                if (currentTreeElement.Height <= treeGrid[y][i].Height)
                {
                    viewingDistance++;
                    break;
                }
                viewingDistance++;
            }

            return viewingDistance;
        }

        private static int GetViewingDistanceFromBelow(TreeElement[][] treeGrid, int i, int j)
        {
            var currentTreeElement = treeGrid[j][i];

            if (j == treeGrid.Length - 1)
            {
                return 0;
            }

            var viewingDistance = 0;
            for (int y = j + 1; y < treeGrid.Length; y++)
            {
                if (currentTreeElement.Height <= treeGrid[y][i].Height)
                {
                    viewingDistance++;
                    break;
                }
                viewingDistance++;
            }

            return viewingDistance;
        }

        private static int GetViewingDistanceFromLeft(TreeElement[][] treeGrid, int i, int j)
        {
            var currentTreeElement = treeGrid[j][i];

            if (i == 0)
            {
                return 0;
            }

            var viewingDistance = 0;
            for (int x = i - 1; x >= 0; x--)
            {
                if (currentTreeElement.Height <= treeGrid[j][x].Height)
                {
                    viewingDistance++;
                    break;
                }
                viewingDistance++;
            }

            return viewingDistance;
        }

        private static int GetViewingDistanceFromRight(TreeElement[][] treeGrid, int i, int j)
        {
            var currentTreeElement = treeGrid[j][i];

            if (i == treeGrid[0].Length - 1)
            {
                return 0;
            }

            var viewingDistance = 0;
            for (int x = i + 1; x < treeGrid[0].Length; x++)
            {
                if (currentTreeElement.Height <= treeGrid[j][x].Height)
                {
                    viewingDistance++;
                    break;
                }
                viewingDistance++;
            }

            return viewingDistance;
        }
    }
}
