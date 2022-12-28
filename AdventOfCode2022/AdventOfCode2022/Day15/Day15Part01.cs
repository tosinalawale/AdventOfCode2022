namespace AdventOfCode2022.Day15
{
    public class Day15Part01
    {
        public static int CalculateResult(string[] input)
        {
            var grid = CreateGridFromInput(input);

            return grid.Keys.Where(k => k.y == 10 && !grid[(k.x, k.y)].Equals('B')).Count();
        }

        private static Dictionary<(int x, int y), char> CreateGridFromInput(string[] input)
        {
            var grid = new Dictionary<(int x, int y), char>();

            foreach (var line in input)
            {
                //"Sensor at x=2, y=18: closest beacon is at x=-2, y=15"
                var lineParts = line.Split(": ");
                var sensorParts = lineParts[0].Replace("Sensor at x=", "").Split(", y=");
                var beaconParts = lineParts[1].Replace("closest beacon is at x=", "").Split(", y=");

                var sensorCoords = (x: int.Parse(sensorParts[0]), y: int.Parse(sensorParts[1]));
                var beaconCoords = (x: int.Parse(beaconParts[0]), y: int.Parse(beaconParts[1]));

                grid[sensorCoords] = 'S'; //this will add the value if the key doesn't already exist, or update the existing value if it does
                grid.TryAdd(beaconCoords, 'B');

                MarkPositionsWithNoBeacon(grid, sensorCoords, beaconCoords);
            }

            return grid;
        }

        private static void MarkPositionsWithNoBeacon(Dictionary<(int x, int y), char> grid, (int x, int y) sensorCoords, (int x, int y) beaconCoords)
        {
            var manhattanDistance = Math.Abs(beaconCoords.x - sensorCoords.x) + Math.Abs(beaconCoords.y - sensorCoords.y);

            var permutations = GetPermutations(manhattanDistance);

            foreach (var (x, y) in permutations)
            {
                for (int i = sensorCoords.x + Math.Sign(x); Math.Abs(i - sensorCoords.x) <= Math.Abs(x); i += x == 0 ? 1 : Math.Sign(x))
                {
                    for (int j = sensorCoords.y + Math.Sign(y); Math.Abs(j - sensorCoords.y) <= Math.Abs(y); j += y == 0 ? 1 : Math.Sign(y))
                    {
                        grid.TryAdd((x: i, y: j), '#');
                    }
                }
            }
        }

        private static HashSet<(int x, int y)> GetPermutations(int manhattanDistance)
        {
            var permutations = new HashSet<(int x, int y)>();

            for (int i = 0; i <= manhattanDistance; i++)
            {
                permutations.Add((x: i, y: manhattanDistance - i));
                permutations.Add((x: i, y: -(manhattanDistance - i)));
                permutations.Add((x: -i, y: manhattanDistance - i));
                permutations.Add((x: -i, y: -(manhattanDistance - i)));
            }

            return permutations;
        }

        public static int GetNumberOfPositionsWithoutBeacons(string[] input)
        {
            var grid = CreateGridFromInput(input);

            return grid.Keys.Where(k => !grid[(k.x, k.y)].Equals('B')).Count();
        }
    }
}
