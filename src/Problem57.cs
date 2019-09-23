using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace Problems
{
    class Problem57
    {
        const string PROMPT = @"Given a string s and an integer k, break up the string into multiple lines such that each line has a length of k or less. You must break it up so that words don't break across lines. Each line has to have the maximum possible amount of words. If there's no way to break the text up, then return null.
                                You can assume that there are no spaces at the ends of the string and that there is exactly one space between each word.
                                For example, given the string 'the quick brown fox jumps over the lazy dog' and k = 10, you should return: ['the quick', 'brown fox', 'jumps over', 'the lazy', 'dog']. No string in the list has a length of more than 10.";

        public void Main()
        {
            string s = "the quick brown fox jumps over the lazy dog";
            int k = 10;
            
            List <string> output = Execute2(s, k);

            foreach (string j in output){
                Console.WriteLine(j);
            }
            Console.ReadLine();
        } 

        public List<string> Execute (string s, int k) {
            int l = 0;
            int j = 0;
            List<string> output = new List<string>();

            while (j < s.Length) {                
                string t = string.Empty;
                int i = j;

                if (k > s.Length - j) {
                    output.Add(s.Substring(j, s.Length - j).Replace(" ", ""));
                    j += k;
                }
                else
                {
                    for (i = j; i < k + j; i++) {
                        if (s.ElementAt(i) == ' '){
                            l = i;
                        }

                        t = t + s.ElementAt(i);
                    }
                    i -= 1;
                    if (s.ElementAt(i) == ' ') {
                        output.Add(t.Substring(0, t.Length - 1));
                        j += k;
                    }
                    else if ((i == s.Length - 1) || (s.ElementAt(i + 1) == ' ')) {
                        output.Add(t);
                        j += k + 1;
                    }
                    else
                    {
                        output.Add(t.Substring(0, l - j));
                        j = l;
                    }
                }
            }

            return output;
        }

        public List<string> Execute2 (string s, int k) {
            List<string> output = new List<string>();
            string[] stringArr = s.Split(" ").ToArray();

            string t = String.Empty;

            foreach (string j in stringArr) {
                if (t.Length + j.Length <= k) {
                    t += j + " ";
                }
                else
                {
                    output.Add(t.Substring(0, t.Length - 1));
                    t = String.Empty;
                    t += j + " ";
                }
            }

            output.Add(t.Substring(0, t.Length - 1));

            return output;
        }
    }
}
