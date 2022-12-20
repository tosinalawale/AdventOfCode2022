namespace AdventOfCode2022.Day13
{
    public class Day13Part01
    {
        public static int CalculateResult(string[] input)
        {
            throw new NotImplementedException();
        }

        public static int Compare(string left, string right)
        {
            var leftPacket = new PacketElement(left);
            var rightPacket = new PacketElement(right);

            if (leftPacket.Value.HasValue && rightPacket.Value.HasValue)
            {
                return leftPacket.Value <= rightPacket.Value ? 1 : 0;
            }

            return -1;
        }
    }
}
