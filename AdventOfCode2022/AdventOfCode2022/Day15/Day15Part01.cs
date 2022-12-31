namespace AdventOfCode2022.Day15
{
    using System.Collections.Generic;

    public class Day15Part01
    {
        public static int CalculateResult(string[] input)
        {
            return GetNumberOfPositionsWithoutBeaconsOnRow(input, 2000000);
        }

        private static int ManhattanDistance((int x, int y) sensorCoords, (int x, int y) beaconCoords)
        {
            return Math.Abs(beaconCoords.x - sensorCoords.x) + Math.Abs(beaconCoords.y - sensorCoords.y);
        }

        public static int GetNumberOfPositionsWithoutBeaconsOnRow(string[] input, int row)
        {
            var positionsWithNoBeacons = GetCellRangesWithNoBeacon(input, row);

            return positionsWithNoBeacons.Count;
        }

        private static HashSet<int> GetCellRangesWithNoBeacon(string[] input, int row)
        {
            var beaconPositions = new HashSet<int>();
            var positionsWithNoBeacons = new HashSet<int>();

            foreach (var line in input)
            {
                //"Sensor at x=2, y=18: closest beacon is at x=-2, y=15"
                var lineParts = line.Split(": ");
                var sensorParts = lineParts[0].Replace("Sensor at x=", "").Split(", y=");
                var beaconParts = lineParts[1].Replace("closest beacon is at x=", "").Split(", y=");

                var sensorCoords = (x: int.Parse(sensorParts[0]), y: int.Parse(sensorParts[1]));
                var beaconCoords = (x: int.Parse(beaconParts[0]), y: int.Parse(beaconParts[1]));

                //e.g. for "Sensor at x=2, y=2: closest beacon is at x=4, y=5"
                //if required row is 7
                //absolute y distance of row to sensor (n) is 7 - 2 = 5
                //manhattan distance (m) = 5
                //no of positions with no beacons:
                //if distance to sensor is 1 : 1 + (m - 1)*2
                //if distance to sensor is 2 : 1 + (m - 2)*2
                //if distance to sensor is n : 1 + (m - n)*2
                //range of x positions on required row (where y is absolute distance to sensor is n):
                //s.x - (m-n) to s.x + (m-n)

                int m = ManhattanDistance(sensorCoords, beaconCoords);
                int n = Math.Abs(row - sensorCoords.y);

                if (sensorCoords.y - m <= row && row <= sensorCoords.y + m)
                {
                    if (beaconCoords.y == row) beaconPositions.Add(beaconCoords.x);

                    for (int i = sensorCoords.x - (m - n); i <= sensorCoords.x + (m - n); i++)
                    {
                        positionsWithNoBeacons.Add(i);
                    }
                }
            }

            positionsWithNoBeacons.ExceptWith(beaconPositions);

            return positionsWithNoBeacons;
        }
    }
}
