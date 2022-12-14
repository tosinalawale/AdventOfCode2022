namespace AdventOfCode2022.Day11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Monkey
    {
        public List<int> StartingItems { get; set; }
        public Func<int, int> Operation { get; set; }
        public Func<int, bool> Test { get; set; }
        public int TrueMonkey { get; set; }
        public int FalseMonkey { get; set; }
        public int NumberOfInspections { get; set; }

        public Monkey(List<int> startingItems, Func<int, int> operation, Func<int, bool> test, int trueMonkey, int falseMonkey)
        {
            StartingItems = startingItems;
            Operation = operation;
            Test = test;
            TrueMonkey = trueMonkey;
            FalseMonkey = falseMonkey;
        }
    }
}
