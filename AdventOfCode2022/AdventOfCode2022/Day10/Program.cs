namespace AdventOfCode2022.Tests.Day10
{
    using System.Text;

    public class Program
    {
        public Dictionary<int, int> RegisterValues { get; set; } = new Dictionary<int, int>();

        public void Execute(string[] input)
        {
            var currentCycle = 1;
            var xRegister = 1;
            foreach (var instruction in input)
            {
                var instructionParts = instruction.Split(' ');
                if (instructionParts[0].Equals("noop"))
                {
                    RegisterValues.Add(currentCycle, xRegister);
                    currentCycle++;
                }
                else
                {
                    RegisterValues.Add(currentCycle, xRegister);
                    currentCycle++;
                    xRegister += int.Parse(instructionParts[1]);
                    RegisterValues.Add(currentCycle, xRegister);
                    currentCycle++;
                }
            }
        }

        public string GenerateSpriteImage()
        {
            var stringBuilder = new StringBuilder();
            var registerValueDuringCurrentCycle = 1;

            //Remember - register value DURING a cycle is the value AFTER the last cycle,
            //hence why I'm looping through the cycles from 0.
            for (int currentCycle = 0; currentCycle < RegisterValues.Count; currentCycle++)
            {
                var currentPixelPosition = (currentCycle % 40);

                var pixelToDraw = 
                    (registerValueDuringCurrentCycle - 1 <= currentPixelPosition
                    && currentPixelPosition <= registerValueDuringCurrentCycle + 1)
                    ? "#"
                    : ".";

                stringBuilder.Append(pixelToDraw);

                registerValueDuringCurrentCycle = RegisterValues[currentCycle + 1];

                if (currentCycle % 40 == 39) stringBuilder.AppendLine();
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}