namespace AdventOfCode2022.Day14
{
    public class Day14Part02
    {
        public static int CalculateResult(string[] input)
        {
            var grid = BuildGrid(input);

            var lowestRockYPosition = GetLowestRockPositionInGrid(grid) + 2;

            var numberOfGrainsWithARestingPosition = 0;

            while (!grid.ContainsKey((x: 500, y: 0)))
            {
                var restingPosition = DropGrainOfSand(grid, lowestRockYPosition);
                if (restingPosition != null) numberOfGrainsWithARestingPosition++;
            }

            return numberOfGrainsWithARestingPosition;
        }

        private static int GetLowestRockPositionInGrid(Dictionary<(int x, int y), char> grid)
        {
            return grid.Keys.Max(k => k.y);
        }

        private static (int x, int y)? DropGrainOfSand(Dictionary<(int x, int y), char> grid, int lowestRockYPosition)
        {
            var sandGrainPosition = (x: 500, y: 0);

            while (sandGrainPosition.y < lowestRockYPosition)
            {
                if (sandGrainPosition.y + 1 != lowestRockYPosition && !grid.ContainsKey((x: sandGrainPosition.x, y: sandGrainPosition.y + 1)))
                {
                    sandGrainPosition = (x: sandGrainPosition.x, y: sandGrainPosition.y + 1);
                }
                else if (sandGrainPosition.y + 1 != lowestRockYPosition && !grid.ContainsKey((x: sandGrainPosition.x - 1, y: sandGrainPosition.y + 1)))
                {
                    sandGrainPosition = (x: sandGrainPosition.x - 1, y: sandGrainPosition.y + 1);
                }
                else if (sandGrainPosition.y + 1 != lowestRockYPosition && !grid.ContainsKey((x: sandGrainPosition.x + 1, y: sandGrainPosition.y + 1)))
                {
                    sandGrainPosition = (x: sandGrainPosition.x + 1, y: sandGrainPosition.y + 1);
                }
                else
                {
                    grid.Add(sandGrainPosition, 'o');
                    return sandGrainPosition;
                }
            }

            return null;
        }

        private static Dictionary<(int x, int y), char> BuildGrid(string[] input)
        {
            var grid = new Dictionary<(int x, int y), char>();

            foreach (var line in input)
            {
                var coordinates = line.Split(" -> ");

                for (int i = 0; i < coordinates.Length - 1; i++)
                {
                    var startCoordParts = coordinates[i].Split(',');
                    var endCoordParts = coordinates[i+1].Split(',');
                    var start = (x: int.Parse(startCoordParts[0]), y: int.Parse(startCoordParts[1]));
                    var end = (x: int.Parse(endCoordParts[0]), y: int.Parse(endCoordParts[1]));

                    UpdateGrid(grid, start, end);
                }
            }

            return grid;
        }

        private static void UpdateGrid(Dictionary<(int x, int y), char> grid, (int x, int y) start, (int x, int y) end)
        {
            if (start.x == end.x)
            {
                for (int i = start.y; i != end.y + Math.Sign(end.y - start.y); i += Math.Sign(end.y - start.y))
                {
                    _ = grid.TryAdd((x: start.x, y: i), '#');
                }
            }
            else
            {
                for (int i = start.x; i != end.x + Math.Sign(end.x - start.x); i += Math.Sign(end.x - start.x))
                {
                    _ = grid.TryAdd((x: i, y: start.y), '#');
                }
            }
        }
    }
}
