namespace AdventOfCode2022.Day10
{
    using AdventOfCode2022.Tests.Day10;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day10Part02
    {
        public static string CalculateResult(string[] input)
        {
            var program = new Program();
            program.Execute(input);

            return program.GenerateSpriteImage();
        }
    }
}
