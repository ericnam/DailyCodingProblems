using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace Problems
{
    class SortingAlgorithms
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
            int[] arr = {10, 7, 8, 9, 1, 5}; 
            int n = arr.Length; 
            QuickSort(arr, 0, n-1); 
            Console.WriteLine("quick sorted array "); 
            printArray(arr, n); 

            Console.WriteLine("merge sort array");
            printArray(MergeSort(arr, 0, n-1), n); 

            Console.ReadLine();
        } 


        // QuickSort Put into Words

        // In an unsorted array, we pick a pivot (chosen randomly, often last digit is chosen)

        // We take this pivot value and place it in the appropriate place in the array where all digits to the left of the 
        // digit is smaller, and all digits to the right is larger

        // We can do this by keeping track of the smallest value's integer as we increment through the array partition

        // if the value that we are currently on is smaller than the pivot value, increment the lowest value's index by 1 and switch this value with the value that is smaller than pivot

        // repeat until we reach the end of the array, at which point, we can switch the pivot's value and the last known lowest value's index + 1. 
        // this ensures that the values to the left of the pivot is smaller 

        static int[] QuickSort (int[] input, int beg_i, int end_i) {
            if (beg_i < end_i) {
                int partition_index = PartitionForQuickSort(input,beg_i,end_i);
                QuickSort(input, beg_i, partition_index - 1);
                QuickSort(input, partition_index + 1, end_i);
            }
            return input;
        }

        // Pick the last item as pivot value
        static int PartitionForQuickSort(int[] input, int beg_i, int end_i) {
            int pivot = input[end_i]; //pivot is the last value
            int lowest_i = beg_i - 1; //-1

            for (int j = beg_i; j < end_i; j++) {
                if (input[j] < pivot) {
                    lowest_i += 1;

                    //swap input[i] and input[j]
                    int temp = input[lowest_i];
                    input[lowest_i] = input[j];
                    input[j] = temp;
                }
            }

            //swap pivot with lowest value + 1
            input[end_i] = input[lowest_i + 1];
            input[lowest_i + 1] = pivot;

            return lowest_i;
        }


        // Merge sort put into words
        // Merge sort is a divide and conquer algorithm - nlogn complexity

        static int[] MergeSort (int[] input, int beg, int end) 
        {
            if (beg < end) {
                decimal mid1 = (end+beg)/2;
                int mid = Convert.ToInt32(mid1);
                return Merge(MergeSort(input, beg, mid), MergeSort(input, mid + 1, end));
            }
            else
            {
                return new int[] {input[beg]};
            }            
        }

        static int[] Merge (int[] input1, int[] input2) {
            int i1 = 0;
            int i2 = 0;

            List<int> list = new List<int>();

            while (i1 < input1.Length || i2 < input2.Length) {
                if (i1 >= input1.Length) {
                    list.AddRange(input2.ToList());
                    break;
                }

                if (i2 >=input2.Length) {
                    list.AddRange(input1.ToList());
                    break;
                }

                if (input1[i1] < input2[i2]) {
                    list.Add(input1[i1]);
                    i1 += 1;
                    continue;
                }

                if (input1[i1] > input2[i2]) {
                    list.Add(input2[i2]);
                    i2 += 1;
                    continue;
                }

                if (input1[i1] == input2[i2]) {
                    list.Add(input1[i1]);
                    list.Add(input1[i1]);
                    i1 += 1;
                    i2 += 1;
                    continue;
                }
            }

            return list.ToArray();
        }

        // static List<int> HeapSort (List<int> input) {
        // }

    }
}
