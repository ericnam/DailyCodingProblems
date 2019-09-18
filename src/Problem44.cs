using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace Problems
{
    class Problem44
    {
        const string PROMPT = @"This problem was asked by Google.
                                We can determine how 'out of order' an array A is by counting the number of inversions it has. Two elements A[i] and A[j] form an inversion if A[i] > A[j] but i < j. That is, a smaller element appears after a larger element.
                                Given an array, count the number of inversions it has. Do this faster than O(N^2) time.
                                You may assume each element in the array is distinct.
                                For example, a sorted list has zero inversions. The array [2, 4, 1, 3, 5] has three inversions: (2, 1), (4, 1), and (4, 3). The array [5, 4, 3, 2, 1] has ten inversions: every distinct pair forms an inversion.";


        public void Main() {
            int[] input = new int[] {2, 4, 1, 3, 5};
            int[] input2 = new int[] {6, 4, 1, 3, 5, 2};
            int result = Execute(input2);
            Console.WriteLine("Result");
            Console.WriteLine(result);
            Console.ReadLine();
        }

        // Brute force algo
        // Complexity: O(n^2)
        static int Execute (int[] input) {
            int swaps = 0;
            QuickSort(0, input.Length - 1, ref input, ref swaps);

            return swaps;            
        }

        static void QuickSort(int b, int e, ref int[] arr, ref int swaps) {
            if (b < e) {
                int p_index = Partition(b, e, ref arr, ref swaps);

                QuickSort(b, p_index - 1, ref arr, ref swaps);
                QuickSort(p_index + 1, e, ref arr, ref swaps);
            }
        }

        static int Partition(int b, int e, ref int[] arr, ref int swaps) {
            int p_val = arr[e];
            int l = b - 1;

            for (int j = b; j < e; j++) {
                if (arr[j] <= p_val) {
                    l += 1;
                    if (j > l) {
                        swaps += j - l;
                    }
                    
                    List<int> tempList = arr.ToList();
                    int temp = arr[j];
                    tempList.RemoveAt(j);
                    tempList.Insert(l, temp);
                    
                    arr = tempList.ToArray();
                }
            }

            List<int> list = arr.ToList();
            list.RemoveAt(e);
            list.Insert(l + 1, p_val);
            
            swaps += (e - (l+1));

            arr = list.ToArray();

            return l + 1;
        }
    }
}
