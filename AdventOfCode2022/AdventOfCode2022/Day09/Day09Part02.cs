namespace AdventOfCode2022.Day09
{
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day09Part02
    {
        public static int CalculateResult(string[] input)
        {
            var rope = new LargerRope();
            
            foreach (var line in input) 
            {
                rope.ProcessMove(line);
            }

            return rope.UniqueTailPositions.Count;
        }
    }
}
