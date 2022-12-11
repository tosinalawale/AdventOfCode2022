namespace AdventOfCode2022.Day09
{
    internal class LargerRope
    {
        //KnotPositions[0] is now the Head knot's position and KnotPositions[9] is the Tail knot's position.
        //(There are now 10 knots in total).
        public List<(int x, int y)> KnotPositions { get; set; }
        public HashSet<(int, int)> UniqueTailPositions { get; set; }

        public LargerRope()
        {
            this.KnotPositions = Enumerable.Repeat((0, 0), 10).ToList();
            this.UniqueTailPositions = new HashSet<(int, int)> { (0, 0) };
        }

        public void ProcessMove(string move)
        {
            var moveParts = move.Split(' ');
            var direction = moveParts[0];
            var times = int.Parse(moveParts[1]);
            switch (direction)
            {
                case "U":
                    for (int i = 0; i < times; i++)
                    {
                        KnotPositions[0] = (KnotPositions[0].x, KnotPositions[0].y + 1);

                        this.MoveTailsIfNecessary();
                    }
                    break;
                case "D":
                    for (int i = 0; i < times; i++)
                    {
                        KnotPositions[0] = (KnotPositions[0].x, KnotPositions[0].y - 1);

                        this.MoveTailsIfNecessary();
                    }
                    break;
                case "L":
                    for (int i = 0; i < times; i++)
                    {
                        KnotPositions[0] = (KnotPositions[0].x - 1, KnotPositions[0].y);

                        this.MoveTailsIfNecessary();
                    }
                    break;
                case "R":
                    for (int i = 0; i < times; i++)
                    {
                        KnotPositions[0] = (KnotPositions[0].x + 1, KnotPositions[0].y);

                        this.MoveTailsIfNecessary();
                    }
                    break;
                default:
                    throw new Exception("Unexpected direction");
            }
        }

        private void MoveTailsIfNecessary()
        {
            for (int i = 0; i < this.KnotPositions.Count-1; i++)
            {
                if (!IsTouching(KnotPositions[i], KnotPositions[i + 1]))
                {
                    KnotPositions[i + 1] = GetUpdatedTailPosition(KnotPositions[i], KnotPositions[i + 1]);
                    this.UniqueTailPositions.Add(KnotPositions[9]);
                }
            }
        }

        private static bool IsTouching((int x, int y) headKnot, (int x, int y) tailKnot)
        {
            return Math.Abs(headKnot.x - tailKnot.x) <= 1 &&
                Math.Abs(headKnot.y - tailKnot.y) <= 1;
        }

        private static (int x, int y) GetUpdatedTailPosition((int x, int y) headKnot, (int x, int y) tailKnot)
        {
            var xDifference = headKnot.x - tailKnot.x;
            var yDifference = headKnot.y - tailKnot.y;

            return (tailKnot.x + Math.Sign(xDifference), tailKnot.y + Math.Sign(yDifference));
        }
    }
}