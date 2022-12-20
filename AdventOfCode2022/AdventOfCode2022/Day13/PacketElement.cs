namespace AdventOfCode2022.Day13
{
    using System.Collections.Generic;

    public class PacketElement
    {
        public int? Value { get; set; }
        public List<PacketElement>? Elements { get; set; }

        public PacketElement(string packet)
        {
            if (string.IsNullOrWhiteSpace(packet))
            {
                Elements = new List<PacketElement>();
                return;
            }

            if (!packet[0].Equals('['))
            {
                Value = int.Parse(packet);
                return;
            }

            Elements = new List<PacketElement>();
            var packetContents = packet.Substring(1, packet.Length - 2).Split(",");

            foreach (var element in packetContents)
            {
                Elements.Add(new PacketElement(element));
            }
        }

        public object? Contents()
        {
            if (Value.HasValue) { return Value.Value; }

            if (Elements != null) { return Elements.Select(e => e.Contents()).ToList(); }

            return null;
        }
    }
}
