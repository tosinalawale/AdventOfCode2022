namespace AdventOfCode2022.Day11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class Day11Part02
    {
        public static long CalculateResult(string[] input)
        {
            var monkeys = SimulateRounds(input, 10000);

            return monkeys.Select(m => m.NumberOfInspections).OrderDescending().Take(2).Aggregate((a, b) => a * b);
        }

        public static List<Monkey> SimulateRounds(string[] input, int rounds)
        {
            var monkeys = CreateMonkeys(input);

            var productOfAllDivisors = GetProductOfAllDivisors(input);

            for (int i = 0; i < rounds; i++)
            {
                for (int j = 0; j < monkeys.Count; j++)
                {
                    for (int k = 0; k < monkeys[j].StartingItems.Count; k++)
                    {
                        monkeys[j].StartingItems[k] = monkeys[j].Operation(monkeys[j].StartingItems[k]);

                        // transforming the number to the modulus/remainder from
                        // dividing it by the product of all the values that we test for divisibility
                        // keeps the number small while preserving it's divisibility property
                        monkeys[j].StartingItems[k] = monkeys[j].StartingItems[k] % productOfAllDivisors;

                        if (monkeys[j].Test(monkeys[j].StartingItems[k]))
                        {
                            monkeys[monkeys[j].TrueMonkey].StartingItems.Add(monkeys[j].StartingItems[k]);
                        }
                        else
                        {
                            monkeys[monkeys[j].FalseMonkey].StartingItems.Add(monkeys[j].StartingItems[k]);
                        }
                    }

                    monkeys[j].NumberOfInspections += monkeys[j].StartingItems.Count;

                    monkeys[j].StartingItems.Clear();
                }
            }

            return monkeys;
        }

        private static int GetProductOfAllDivisors(string[] input)
        {
            var divisors = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains("Test: divisible by "))
                {
                    var divisor = input[i].Replace("Test: divisible by ", "");
                    divisors.Add(int.Parse(divisor));
                }
            }

            return divisors.Aggregate((a, b) => a * b);
        }

        private static List<Monkey> CreateMonkeys(string[] input)
        {
            var monkeys = new List<Monkey>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith("Monkey"))
                {
                    monkeys.Add(
                        new Monkey(
                            input[i + 1].Replace("Starting items: ", "").Split(',').Select(long.Parse).ToList(),
                            GetOperation(input[i + 2]),
                            GetTest(input[i + 3]),
                            GetMonkey(input[i + 4]),
                            GetMonkey(input[i + 5])));

                    i += 5;
                }
            }

            return monkeys;
        }

        private static int GetMonkey(string s)
        {
            return int.Parse(s
                .TrimStart()
                .Replace("If true: throw to monkey ", "")
                .Replace("If false: throw to monkey ", ""));
        }

        private static Func<long, bool> GetTest(string s)
        {
            var number = long.Parse(s.Replace("Test: divisible by ", ""));

            return x => x % number == 0;
        }

        private static Func<long, long> GetOperation(string s)
        {
            var inputParts = s.TrimStart().Replace("Operation: new = old ", "").Split(' ');

            var secondArgumentIsNumber = long.TryParse(inputParts[1], out long operand);

            if (inputParts[0].Equals("*"))
            {
                return secondArgumentIsNumber ?
                    (x => x * operand) :
                    (x => x * x);
            }
            else
            {
                return secondArgumentIsNumber ?
                    (x => x + operand) :
                    (x => x + x);
            }
        }
    }
}
