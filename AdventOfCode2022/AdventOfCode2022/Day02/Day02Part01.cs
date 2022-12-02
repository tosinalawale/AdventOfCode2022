namespace AdventOfCode2022.Day02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day02Part01
    {
        public static int CalculateResult(string[] input)
        {
            return input.Sum(x => CalculateScore(x));
        }

        private static int CalculateScore(string round)
        {
            var handShapes = round.Split(" ");
            var handShapeA = ToShape(handShapes[0]);
            var handShapeB = ToShape(handShapes[1]);

            var scoreForShapeB = GetScoreForShape(handShapeB);

            var scoreForOutcome = GetScoreForOutCome(handShapeA, handShapeB);

            return scoreForShapeB + scoreForOutcome;
        }

        private static int GetScoreForOutCome(Shape handShapeA, Shape handShapeB)
        {
            if (handShapeA == handShapeB) return 3;

            if (SecondShapeWins(handShapeA, handShapeB)) return 6;

            return 0;
        }

        private static Shape ToShape(string shape) => shape switch
        {
            "A" => Shape.Rock,
            "B" => Shape.Paper,
            "C" => Shape.Scissors,
            "X" => Shape.Rock,
            "Y" => Shape.Paper,
            "Z" => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(shape), $"Not expected shape value: {shape}"),
        };

        private static bool SecondShapeWins(Shape handShapeA, Shape handShapeB)
        {
            return handShapeB == Shape.Rock && handShapeA == Shape.Scissors ||
                handShapeB == Shape.Scissors && handShapeA == Shape.Paper ||
                handShapeB == Shape.Paper && handShapeA == Shape.Rock;
        }

        private static int GetScoreForShape(Shape shape) => shape switch
        {
            Shape.Rock => 1,
            Shape.Paper => 2,
            Shape.Scissors => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(shape), $"Unexpected shape value: {shape}")
        };
    }
}
