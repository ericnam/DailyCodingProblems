using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace Problems
{
    class Problem29
    {
        const string PROMPT = @"This problem was asked by Amazon.
                                Run-length encoding is a fast and simple method of encoding strings. The basic idea is to represent repeated successive characters as a single count and character. For example, the string 'AAAABBBCCDAA' would be encoded as '4A3B2C1D2A'.
                                Implement run-length encoding and decoding. You can assume the string to be encoded have no digits and consists solely of alphabetic characters. You can assume the string to be decoded is valid.";

        public void Main()
        {
            Console.WriteLine("asdf");
            string decodedString =  "AAAABBCCCDEE";
            Console.WriteLine(Encode(decodedString));
            string encodedString =  "4A2B3C1D2E";
            Console.WriteLine(Decode(encodedString));
            Console.ReadLine();
        } 

        static string Encode(string input)
        {
            string[] inputArray = input.Split("").ToArray();
            string encodedString = string.Empty;
            string cur = string.Empty;
            int count = 0;
            
            foreach(string str in inputArray) {
                if (cur != str && count > 0) {
                    encodedString.Concat(count.ToString());
                    encodedString.Concat(cur);
                    count = 0;
                }
                else
                {
                    count += 1;
                }
                cur = str;
            }

            return encodedString;
        }
        
        static string Decode(string input)
        {
            string[] inputArray = input.Split("").ToArray();
            string decodedString = string.Empty;

            for (int y = 0; y < inputArray.Length; y++) {
                int i = 0;
                if (Int32.TryParse(inputArray[y], out i)) {
                    string s = inputArray[y+1];
                    decodedString.Concat(string.Concat(Enumerable.Repeat(s, i)));
                }
                else
                {
                    continue;
                }
            }

            return decodedString;
        }
    }
}
