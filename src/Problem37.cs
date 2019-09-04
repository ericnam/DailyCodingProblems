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
            
        }

        static List<List<int>> Execute (List<int> input) {
            List<List<int>> result = new List<List<int>>();
            List<int> subArray = new List<int>();

            result.Add(subArray);

            foreach (int i in input) {


            }

            return result;
        }
    }
}
