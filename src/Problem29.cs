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
            string result1 = Encode(decodedString);
            Console.WriteLine(result1);
            string encodedString =  "4A2B3C1D2E";
            string result2 = Decode(encodedString);
            Console.WriteLine((result2));
            Console.ReadLine();
        } 

        static string Encode(string input)
        {
            char[] inputArray = input.ToCharArray();
            string encodedString = string.Empty;
            string cur = string.Empty;
            int count = 0;
            
            for (int i = 0; i < inputArray.Length; i++) {
                if ((cur != inputArray[i].ToString() && count > 0)) {
                    encodedString += count.ToString();
                    encodedString += cur;
                    count = 1;
                }
                else
                {
                    count += 1;
                    if (i == inputArray.Length - 1) {
                        encodedString += count.ToString();
                        encodedString += cur;
                    }
                }
                cur = inputArray[i].ToString();
            }

            return encodedString;
        }
        
        static string Decode(string input)
        {
            char[] inputArray = input.ToCharArray();
            string decodedString = string.Empty;

            for (int y = 0; y < inputArray.Length; y++) {
                int i = 0;
                if (Int32.TryParse(inputArray[y].ToString(), out i)) {
                    string s = inputArray[y+1].ToString();
                    decodedString += string.Concat(Enumerable.Repeat(s, i));
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
