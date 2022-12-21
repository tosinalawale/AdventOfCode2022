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
            return ComparePackets(leftPacket, rightPacket) <= 0 ? 1 : 0;
        }

        private static int ComparePackets(PacketElement leftPacket, PacketElement rightPacket)
        {
            if (leftPacket.Number.HasValue && rightPacket.Number.HasValue)
            {
                return leftPacket.Number.Value.CompareTo(rightPacket.Number);
            }

            var leftElements = leftPacket.Elements;
            var rightElements = rightPacket.Elements;

            if (leftElements != null && rightElements != null)
            {
                var result = 0;

                for (int i = 0; i < leftElements.Count; i++)
                {
                    try
                    {
                        result = ComparePackets(leftElements[i], rightElements[i]);
                        if (result != 0) break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        return 1;
                    }
                }
                return result;
            }

            if (leftElements == null)
            {
                return ComparePackets(new PacketElement("[" + leftPacket.Number + "]"), rightPacket);
            }
            else
            {
                return ComparePackets(leftPacket, new PacketElement("[" + rightPacket.Number + "]"));
            }
        }
    }
}
