namespace AdventOfCode2022.Day13
{
    public class Day13Part01
    {
        public static int CalculateResult(string[] input)
        {
            var pairsInCorrectOrder = new List<int>();

            for (int i = 0; i < input.Length; i += 3)
            {
                var result = Compare(input[i], input[i + 1]);
                if (result == 1) pairsInCorrectOrder.Add((i / 3) + 1);
            }

            return pairsInCorrectOrder.Sum();
        }

        public static int Compare(string left, string right)
        {
            var leftPacket = new PacketElement(left);
            var rightPacket = new PacketElement(right);
            return ComparePackets(leftPacket, rightPacket) <= 0 ? 1 : 0;
        }

        public static int ComparePackets(PacketElement leftPacket, PacketElement rightPacket)
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

                if (leftElements.Count == 0 && rightElements.Count > 0) return -1;

                for (int i = 0; i < leftElements.Count; i++)
                {
                    try
                    {
                        result = ComparePackets(leftElements[i], rightElements[i]);
                        if (result != 0) break;
                        if (i == leftElements.Count - 1 && leftElements.Count < rightElements.Count) return -1;
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
