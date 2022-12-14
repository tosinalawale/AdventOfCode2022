namespace AdventOfCode2022.Tests.Day10
{
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
    }
}