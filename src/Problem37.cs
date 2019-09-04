using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace Problems
{
    class Problem37
    {
        const string PROMPT = @"This problem was asked by Google.
                                The power set of a set is the set of all its subsets. Write a function that, given a set, generates its power set.
                                For example, given the set {1, 2, 3}, it should return {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}}.
                                You may also use a list or array to represent a set.";

        public void Main()
        {
            // Exmaple
            // [] = [{}]
            // [a] = [{}, {a}]
            // [a, b] = [{}, {a}, {b}, {a, b}]
            // [a, b, c] = [{}, {a}, {b}, {c}, {a,b}, {a,c}, {b,c}, {a,b,c}]
            foreach (List<int> j in PowerSet(new List<int>() {1, 2, 3})) {
                foreach(int i in j) {
                    Console.Write(i);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        } 

        static List<List<int>> PowerSet(List<int> input)
        {
            if (input.Count == 0) {
                return new List<List<int>>();
            }

            List<List<int>> result = PowerSet(input.GetRange(1, input.Count - 1));
            List<List<int>> result2 = new List<List<int>>();
            int i = input[0];
            foreach (List<int> r in result) {
                List<int> j = r;
                j.Add(i);
                result2.Add(r);
            }

            return result.Concat(result2).ToList();
        }
    }
}
