namespace AdventOfCode2022.Day09
{
    using System;
    using System.Collections.Generic;

    public class Rope
    {
        public (int x, int y) HeadPosition { get; set; }
        public (int x, int y) TailPosition { get; set; }
        public HashSet<(int, int)> UniqueTailPositions { get; set; }

        public Rope()
        {
            this.HeadPosition = (0, 0);
            this.TailPosition= (0, 0);
            this.UniqueTailPositions = new HashSet<(int, int)> { (0, 0) };
        }

        public void ProcessMove(string move) 
        {
            var moveParts = move.Split(' ');
            var direction = moveParts[0];
            var times = int.Parse(moveParts[1]);
            switch (moveParts[0])
            {
                case "U":
                    for (int i = 0; i < times; i++)
                    {
                        this.HeadPosition = (this.HeadPosition.x, this.HeadPosition.y + 1);

                        this.MoveTailIfNecessary();
                    }
                    break;
                case "D":
                    for (int i = 0; i < times; i++)
                    {
                        this.HeadPosition = (this.HeadPosition.x, this.HeadPosition.y - 1);

                        this.MoveTailIfNecessary();
                    }
                    break;
                case "L":
                    for (int i = 0; i < times; i++)
                    {
                        this.HeadPosition = (this.HeadPosition.x - 1, this.HeadPosition.y);

                        this.MoveTailIfNecessary();
                    }
                    break;
                case "R":
                    for (int i = 0; i < times; i++)
                    {
                        this.HeadPosition = (this.HeadPosition.x + 1, this.HeadPosition.y);

                        this.MoveTailIfNecessary();
                    }
                    break;
                default:
                    throw new Exception("Unexpected direction");
            }
        }

        private void MoveTailIfNecessary()
        {
            if (!this.IsTouching())
            {
                this.UpdateTailPosition();
                this.UniqueTailPositions.Add(this.TailPosition);
            }
        }

        private bool IsTouching()
        {
            //H = 1,2
            //T = 2,1
            return Math.Abs(this.HeadPosition.x - this.TailPosition.x) <= 1 &&
                Math.Abs(this.HeadPosition.y - this.TailPosition.y) <= 1;
        }

        private void UpdateTailPosition()
        {
            var xDifference = this.HeadPosition.x - this.TailPosition.x;
            var yDifference = this.HeadPosition.y - this.TailPosition.y;

            this.TailPosition = (this.TailPosition.x + Math.Sign(xDifference), this.TailPosition.y + Math.Sign(yDifference));
        }
    }
}
