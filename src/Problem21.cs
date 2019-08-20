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

            List<int[]> testData1 = new List<int[]>() {
                new int[] {30,75},
                new int[] {0, 50},
                new int[] {60, 150}
            };
            Console.WriteLine(Execute(testData1));
            Console.ReadLine();
        }

        //sorting problem but with buckets
        //lets utilize binary sort
        static int Execute (List<int[]> input) {
            Dictionary<int, List<int[]>> rooms = new Dictionary<int, List<int[]>>();
            int roomCount = 1;
            foreach (int[] intArray in input) {
                bool foundRoom = false;
                foreach (KeyValuePair<int, List<int[]>> kvp in rooms) {
                    int roomIndex = 0;
                    foreach (int[] occupied in kvp.Value) {
                        if (intArray[0] > occupied[1] &&
                           (kvp.Value.Count > 0 && kvp.Value.Count - 1 == roomIndex) ? true : intArray[1] < kvp.Value[roomIndex][0]) 
                        {
                            kvp.Value.Insert(roomIndex, intArray);
                            foundRoom = true;
                            break;
                        }
                        roomIndex++;
                    }
                    if (foundRoom) {
                        break;
                    }
                }
                if (!foundRoom) {
                    rooms.Add(roomCount, new List<int[]>(){intArray});
                    roomCount++;
                }
            }

            return rooms.Count;
        }
    
        static int Execute2 (List<int[]> input) {
            
        }
    }
}
