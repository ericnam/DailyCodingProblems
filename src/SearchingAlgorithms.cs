using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace Problems
{
    class SearchingAlgorithms
    {
        static void printArray(int []arr, int n) 
        { 
            for (int i = 0; i < n; ++i) 
                Console.Write(arr[i] + " "); 
                
            Console.WriteLine(); 
        } 
    
        // Driver program 
        public void Main() 
        { 
            // int[] arr = {1, 2, 5, 9, 15, 20, 60, 91, 102};
            // Console.WriteLine(BinarySearch(arr, 0, arr.Length - 1, 1));
            // Console.WriteLine(BinarySearch(arr, 0, arr.Length - 1, 2));
            // Console.WriteLine(BinarySearch(arr, 0, arr.Length - 1, 5));
            // Console.WriteLine(BinarySearch(arr, 0, arr.Length - 1, 9));
            // Console.WriteLine(BinarySearch(arr, 0, arr.Length - 1, 15));
            // Console.WriteLine(BinarySearch(arr, 0, arr.Length - 1, 20));
            // Console.WriteLine(BinarySearch(arr, 0, arr.Length - 1, 60));
            // Console.WriteLine(BinarySearch(arr, 0, arr.Length - 1, 91));
            // Console.WriteLine(BinarySearch(arr, 0, arr.Length - 1, 102));

            int[] arr = {3, 4, 5, 1, 2};
            Console.WriteLine(SearchSortedAndRotatedArray(arr, 0, 4, 3));
            Console.WriteLine(SearchSortedAndRotatedArray(arr, 0, 4, 4));
            Console.WriteLine(SearchSortedAndRotatedArray(arr, 0, 4, 5));
            Console.WriteLine(SearchSortedAndRotatedArray(arr, 0, 4, 1));
            Console.WriteLine(SearchSortedAndRotatedArray(arr, 0, 4, 2));
            Console.ReadLine();
        } 

        public int BinarySearch(int[] arr, int l, int r, int x) {
            int m = (r + l) / 2;
            if (arr[m] == x) {
                return m;
            }

            if (x > arr[m]) {
                return BinarySearch(arr, m + 1, r, x);
            }
            else
            {
                return BinarySearch(arr, l, m - 1, x);
            }
        }

        public int SearchSortedAndRotatedArray(int[] arr, int l, int r, int x) {
            int m = (l + r) / 2;
            if (arr[m] == x) {
                return m;
            }
            
            if (x <= arr[r]) {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }

            return SearchSortedAndRotatedArray(arr, l, r, x);
        }
    }
}
