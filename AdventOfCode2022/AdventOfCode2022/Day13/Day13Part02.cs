namespace AdventOfCode2022.Day13
{
    using System.Collections.Immutable;

    public class Day13Part02
    {
        public static int CalculateResult(string[] input)
        {
            var filteredInput = input.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            var listOfPackets = filteredInput.Select(s => new PacketElement(s)).ToList();
            var twoPacket = new PacketElement("[[2]]");
            var sixPacket = new PacketElement("[[6]]");
            listOfPackets.Add(twoPacket);
            listOfPackets.Add(sixPacket);

            listOfPackets.Sort((p1, p2) => ComparePackets(p1, p2));

            var indexOfTwo = listOfPackets.IndexOf(twoPacket) + 1;
            var indexOfSix = listOfPackets.IndexOf(sixPacket) + 1;

            return indexOfTwo * indexOfSix;
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

                if (result == 0 && leftElements.Count < rightElements.Count) return -1;

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
