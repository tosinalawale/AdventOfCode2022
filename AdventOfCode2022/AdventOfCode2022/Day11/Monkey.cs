namespace AdventOfCode2022.Day11
{
    using System;
    using System.Collections.Generic;

    public class Monkey
    {
        public List<long> StartingItems { get; set; }
        public Func<long, long> Operation { get; set; }
        public Func<long, bool> Test { get; set; }
        public int TrueMonkey { get; set; }
        public int FalseMonkey { get; set; }
        public long NumberOfInspections { get; set; }

        public Monkey(List<long> startingItems, Func<long, long> operation, Func<long, bool> test, int trueMonkey, int falseMonkey)
        {
            StartingItems = startingItems;
            Operation = operation;
            Test = test;
            TrueMonkey = trueMonkey;
            FalseMonkey = falseMonkey;
        }
    }
}
