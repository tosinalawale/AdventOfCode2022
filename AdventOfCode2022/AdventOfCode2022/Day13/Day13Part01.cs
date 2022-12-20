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
            return ComparePackets(leftPacket, rightPacket) ? 1 : 0;
        }

        private static bool ComparePackets(PacketElement leftPacket, PacketElement rightPacket)
        {
            if (leftPacket.Value.HasValue && rightPacket.Value.HasValue)
            {
                return leftPacket.Value <= rightPacket.Value;
            }

            var leftElements = leftPacket.Elements;
            var rightElements = rightPacket.Elements;

            if (leftElements != null && rightElements != null)
            {
                var results = true;

                for (int i = 0; i < leftElements.Count; i++)
                {
                    try
                    {
                        results = results && ComparePackets(leftElements[i], rightElements[i]);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                return results;
            }

            if (leftElements == null)
            {
                return ComparePackets(new PacketElement("[" + leftPacket.Value + "]"), rightPacket);
            }
            else
            {
                return ComparePackets(leftPacket, new PacketElement("[" + rightPacket.Value + "]"));
            }
        }
    }
}
