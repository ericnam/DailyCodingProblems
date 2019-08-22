using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace Problems
{
    class Problem1
    {
        const string PROMPT = "This problem was recently asked by Google.\n" +
                                "Given a list of numbers and a number k, return whether any two numbers from the list add up to k.\n" +
                                "For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.\n" +
                                "Bonus: Can you do this in one pass?\n";

        public void Main()
        {
            ConsoleHelper.PrintPrompt(PROMPT);
            Console.WriteLine("Unit Test #1");
            Console.WriteLine("k = 17");
            Console.WriteLine("[10, 15, 3, 7]");
            
            int k1 = 17;
            List<int> testData1 = new List<int>() {
                10, 15, 3, 7
            };
            Console.WriteLine("Output: " + Execute(k1, testData1));
            
            Console.WriteLine("Unit Test #2");
            Console.WriteLine("k = 18");
            Console.WriteLine("[8, 15, 3, 7]");

            int k2 = 18;
            List<int> testData2 = new List<int>() {
                10, 15, 3, 7
            };
            Console.WriteLine("Output: " + Execute(k2, testData2));
            
            Console.WriteLine("Unit Test #3");
            Console.WriteLine("k = 20");
            Console.WriteLine("[8, 15, 3, 7]");

            int k3 = 120;
            List<int> testData3 = new List<int>() {
                10, 15, 3, 7
            };
            Console.WriteLine("Output: " + Execute(k3, testData3));
        }

        // Brute force algo
        // Complexity: O(n^2)
        static bool Execute (int k, List<int> input) {
            List<int> sums = new List<int>();
            for (var i = 0; i < input.Count - 1; i++) {
                for (var j = i + 1; j < input.Count; j++) {
                    if (input[i] + input[j] == k) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
