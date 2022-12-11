namespace AdventOfCode2022.Day09
{
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day09Part01
    {
        public static int CalculateResult(string[] input)
        {
            var rope = new Rope();
            
            foreach (var line in input) 
            {
                rope.ProcessMove(line);
            }

            return rope.UniqueTailPositions.Count;
        }
    }
}
