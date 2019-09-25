using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace Problems
{
    class Fib
    {        
        
        public Dictionary<int, int> FibMemo;

        public void Main() 
        { 
            FibMemo = new  Dictionary<int, int>();
            int n = FibonacciSequence(9);
            Console.WriteLine(n);
            n = FibSequenceMemoization(9);
            Console.WriteLine(n);
            FibMemo = new  Dictionary<int, int>();
            Console.WriteLine(FibSequenceTabulation(9));
            Console.WriteLine(FibSequenceUltimate(9));
            Console.ReadLine();
        } 

        public int FibonacciSequence (int n) {
            if (n <= 1) {
                return n;
            }
            return FibonacciSequence(n - 1) + FibonacciSequence(n - 2);
        }

        public int FibSequenceMemoization (int n) {
            if (FibMemo.TryGetValue(n, out int t)) {
                return t;
            }
            else
            {
                if (n <= 1) return n;
                FibMemo.Add(n, FibSequenceMemoization(n-1) + FibSequenceMemoization(n-2));
            }
            return FibMemo[n];
        }

        public int FibSequenceTabulation (int n) {
            FibMemo.Add(0, 0);
            FibMemo.Add(1, 1);

            for (int i = 2; i < n + 1; i++) {
                FibMemo.Add(i, FibMemo[i-1] + FibMemo[i-2]);
            }

            return FibMemo[n];
        }

        // 0 1 1       2 3 5 8 13 21
        // a b (a + b)
        public int FibSequenceUltimate (int n) {
            int a = 0;
            int b = 1;
            int c = 0;
            for (int i = 1; i <= n; i++) {
                c = a + b;
                b = a;
                a = c;
            }
            return c;
        }

    }
}
