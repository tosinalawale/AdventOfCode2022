namespace AdventOfCode2022.Day08
{
    public class TreeElement
    {
        public int Height { get; set; }
        public int? MaxHeightFromAbove { get; set; }
        public int? MaxHeightFromBelow { get; set; }
        public int? MaxHeightFromLeft { get; set; }
        public int? MaxHeightFromRight { get; set; }

        public bool IsVisible => (MaxHeightFromAbove != null && MaxHeightFromAbove.Value < Height) ||
            (MaxHeightFromBelow != null && MaxHeightFromBelow.Value < Height) ||
            (MaxHeightFromLeft != null && MaxHeightFromLeft.Value < Height) ||
            (MaxHeightFromRight != null && MaxHeightFromRight.Value < Height);
    }
}
