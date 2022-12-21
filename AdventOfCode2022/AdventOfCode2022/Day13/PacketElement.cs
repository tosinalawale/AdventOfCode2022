namespace AdventOfCode2022.Day13
{
    using System;
    using System.Collections.Generic;

    public class PacketElement
    {
        public int? Number { get; set; }
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
                Number = int.Parse(packet);
                return;
            }

            Elements = new List<PacketElement>();
            var packetContents = SplitElements(packet.Substring(1, packet.Length - 2));

            foreach (var element in packetContents)
            {
                Elements.Add(new PacketElement(element));
            }
        }

        private List<string> SplitElements(string v)
        {
            var stack = new Stack<char>();
            var elements = new List<string>();
            var previousSplitPosition = 0;

            for (int i = 0; i < v.Length; i++)
            {
                if (v[i].Equals(',') && stack.Count == 0) 
                {
                    elements.Add(v[previousSplitPosition..i]);
                    previousSplitPosition = i + 1;
                }
                else if (v[i].Equals('[')) { stack.Push(v[i]); }
                else if (v[i].Equals(']')) { stack.Pop(); }
            }

            elements.Add(v.Substring(previousSplitPosition));

            return elements;
        }

        public object? Contents()
        {
            if (Number.HasValue) { return Number.Value; }

            if (Elements != null) { return Elements.Select(e => e.Contents()).ToList(); }

            return null;
        }
    }
}
