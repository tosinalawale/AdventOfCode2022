namespace AdventOfCode2022.Day03
{
    public static class ItemPriorityConverter
    {
        public static int ToItemPriority(string item)
        {
            var asciiCode = (int)char.Parse(item);

            return (asciiCode >= 97) ? asciiCode - 96 : asciiCode - 38;
        }
    }
}