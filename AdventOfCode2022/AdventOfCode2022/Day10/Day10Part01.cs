namespace AdventOfCode2022.Day10
{
    using AdventOfCode2022.Tests.Day10;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day10Part01
    {
        public static int CalculateResult(string[] input)
        {
            var program = new Program();
            program.Execute(input);

            // The problem asks for the value of the register *DURING* the 20th, 60th etc cycles
            // Hence, this is the value AFTER the previous cycle e.g. after cycle 19, 59 etc
            return 20*program.RegisterValues[19] + 60*program.RegisterValues[59] +
                100*program.RegisterValues[99] + 140*program.RegisterValues[139] +
                180*program.RegisterValues[179] + 220*program.RegisterValues[219];
        }
    }
}
