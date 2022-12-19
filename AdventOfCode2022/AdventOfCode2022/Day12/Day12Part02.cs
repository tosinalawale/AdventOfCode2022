namespace AdventOfCode2022.Day12
{
    using System.Collections.Generic;
    using System.Reflection.Metadata.Ecma335;

    public class Day12Part02
    {
        public static int CalculateResult(string[] input)
        {
            var startPositions = GetStartingPositions(input);
            var shortestStepsFromAllStartingPositions = new List<int>();

            foreach (var position in startPositions)
            {
                var grid = CreateMapGrid(input);
                shortestStepsFromAllStartingPositions.Add(
                    FindShortestStepsToDestinationPosition(grid, position));
            }

            return shortestStepsFromAllStartingPositions.Min();
        }

        private static List<(int y, int x)> GetStartingPositions(string[] input)
        {
            var startingPositions = new List<(int y, int x)>();

            for (int x = 0; x < input[0].Length; x++)
            {
                for (int y = 0; y < input.Length; y++)
                {
                    if (input[y][x].Equals('a') || input[y][x].Equals('S')) startingPositions.Add((y, x));
                }
            }

            return startingPositions;
        }

        private static int FindShortestStepsToDestinationPosition(GridElement[,] grid, (int y, int x) startPosition)
        {
            //This uses Breadth First Search algorithm

            var queue = new Queue<(int y, int x)>();
            grid[startPosition.y, startPosition.x].Visited = true;
            grid[startPosition.y, startPosition.x].StepsToPosition = 0;

            queue.Enqueue((startPosition.y, startPosition.x));

            while (queue.Count > 0)
            {
                var currentPos = queue.Dequeue();

                if (grid[currentPos.y, currentPos.x].IsGoalPosition) return grid[currentPos.y, currentPos.x].StepsToPosition;

                foreach (var position in GetAdjacentPositions(grid, currentPos))
                {
                    if (!grid[position.y, position.x].Visited)
                    {
                        grid[position.y, position.x].Visited = true;
                        grid[position.y, position.x].StepsToPosition = grid[currentPos.y, currentPos.x].StepsToPosition + 1;
                        queue.Enqueue(position);
                    }
                }
            }

            return int.MaxValue;
        }

        private static List<(int y, int x)> GetAdjacentPositions(GridElement[,] grid, (int y, int x) currentPosition)
        {
            var adjacentPositions = new List<(int y, int x)>();
            var gridWidth = grid.GetLength(1);
            var gridHeight = grid.GetLength(0);

            if (currentPosition.x < gridWidth - 1
                && CanClimbToNextPosition(grid, currentPosition, (currentPosition.y, currentPosition.x + 1)))
                adjacentPositions.Add((currentPosition.y, currentPosition.x + 1));

            if (currentPosition.x > 0 
                && CanClimbToNextPosition(grid, currentPosition, (currentPosition.y, currentPosition.x - 1))) 
                adjacentPositions.Add((currentPosition.y, currentPosition.x - 1));

            if (currentPosition.y < gridHeight - 1
                && CanClimbToNextPosition(grid, currentPosition, (currentPosition.y + 1, currentPosition.x))) 
                adjacentPositions.Add((currentPosition.y + 1, currentPosition.x));

            if (currentPosition.y > 0
                && CanClimbToNextPosition(grid, currentPosition, (currentPosition.y - 1, currentPosition.x)))
                adjacentPositions.Add((currentPosition.y - 1, currentPosition.x));

            return adjacentPositions;
        }

        private static bool CanClimbToNextPosition(GridElement[,] grid, (int y, int x) currentPosition, (int y, int x) nextPosition)
        {
            return grid[nextPosition.y, nextPosition.x].Height - grid[currentPosition.y, currentPosition.x].Height <= 1;
        }

        private static GridElement[,] CreateMapGrid(string[] input)
        {
            var mapGrid = new GridElement[input.Length, input[0].Length];

            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    var isGoalPosition = false;
                    int height;

                    switch (input[j][i])
                    {
                        case 'S':
                            height = (int)'a';
                            break;
                        case 'E':
                            height = (int)'z';
                            isGoalPosition = true;
                            break;
                        default:
                            height = (int)input[j][i];
                            break;
                    }

                    mapGrid[j, i] = new GridElement
                    {
                        Height = height, 
                        IsGoalPosition = isGoalPosition
                    };
                }
            }

            return mapGrid;
        }
    }
}
