namespace AdventOfCode2022.Day02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day02Part02
    {
        public static int CalculateResult(string[] input)
        {
            return input.Sum(x => CalculateScore(x));
        }

        private static int CalculateScore(string round)
        {
            var columns = round.Split(" ");
            var opponentsShape = ToShape(columns[0]);
            var desiredOutcome = columns[1];

            var myShape = GetShapeForDesiredOutcome(opponentsShape, desiredOutcome);

            var scoreForMyShape = GetScoreForShape(myShape);

            var scoreForOutcome = GetScoreForOutcome(desiredOutcome);

            return scoreForMyShape + scoreForOutcome;
        }

        private static Shape GetShapeForDesiredOutcome(Shape opponentsShape, string desiredOutcome)
        {
            if (desiredOutcome.Equals("Y")) return opponentsShape;
            else if (desiredOutcome.Equals("X")) return GetLosingShape(opponentsShape);
            else return GetWinningShape(opponentsShape) ;
        }

        private static Shape GetWinningShape(Shape shape) => shape switch
        {
            Shape.Rock => Shape.Paper,
            Shape.Paper => Shape.Scissors,
            Shape.Scissors => Shape.Rock,
            _ => throw new ArgumentOutOfRangeException(nameof(shape), $"Unexpected shape value: {shape}")
        };

        private static Shape GetLosingShape(Shape shape) => shape switch
        {
            Shape.Rock => Shape.Scissors,
            Shape.Paper => Shape.Rock,
            Shape.Scissors => Shape.Paper,
            _ => throw new ArgumentOutOfRangeException(nameof(shape), $"Unexpected shape value: {shape}")
        };

        private static int GetScoreForOutcome(string outcome) => outcome switch
        {
            "X" => 0,
            "Y" => 3,
            "Z" => 6,
            _ => throw new ArgumentOutOfRangeException(nameof(outcome), $"Not expected value: {outcome}"),
        };

        private static Shape ToShape(string shape) => shape switch
        {
            "A" => Shape.Rock,
            "B" => Shape.Paper,
            "C" => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(shape), $"Not expected shape value: {shape}"),
        };

        private static int GetScoreForShape(Shape shape) => shape switch
        {
            Shape.Rock => 1,
            Shape.Paper => 2,
            Shape.Scissors => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(shape), $"Unexpected shape value: {shape}")
        };
    }
}
