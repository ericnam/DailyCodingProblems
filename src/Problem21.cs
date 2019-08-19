using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace Problems
{
    class Problem21
    {
        const string PROMPT = "This problem was asked by Snapchat.\n" + 
            "Given an array of time intervals (start, end) for classroom lectures (possibly overlapping), find the minimum number of rooms required.\n" +
            "For example, given [(30, 75), (0, 50), (60, 150)], you should return 2.\n";

        public void Main()
        {
            ConsoleHelper.PrintPrompt(PROMPT);
            bool returnToMain = false;
            while (!returnToMain) {
                string userInput = ConsoleHelper.GetIntArrayInput();
                List<string> userInputSplit = userInput.Split(',').ToList();
                try {
                    int[] intArray = userInputSplit.Select(x => Convert.ToInt32(x)).ToArray();

                }
                catch (Exception ex) {
                    Console.WriteLine("Error has occured.");
                    Console.WriteLine(ex.Message);
                }                
            }
        }

        static int Execute (List<int[]> input) {
            int roomCount = 0;            
            foreach (int[] intArray in input) {

            }
        }
    }

}
