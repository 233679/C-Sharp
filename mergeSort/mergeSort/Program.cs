using System;
using System.Linq;

namespace mergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = { 12, 3, 5, 7, 2, 11, 9, 6, 1, 4, 8, 10 };
            //for (int i = 0;i<12;i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            //Console.WriteLine();
            //for (int i = 0;i<12;i++)
            //{
            //    Console.WriteLine(MergeSort.mergeSort(numbers)[i]);
            //}

        }

        public static int[] mergeSort(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums;
            }

            int middle = nums.Length / 2;
            int[] left = nums.Take(middle).ToArray();
            int[] right = nums.Skip(middle).ToArray();

            int[] sortedLeft = mergeSort(left);
            int[] sortedRight = mergeSort(right);

            int[] sorted = new int[nums.Length];
            int longest = int.Max(sortedLeft.Length, sortedRight.Length);

            int sortedIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;
            while (sortedIndex != sorted.Length)
            {
                if (leftIndex > sortedLeft.Length)
                {
                    sorted[sortedIndex] = sortedRight[rightIndex];
                    rightIndex++;
                    sortedIndex++;
                    continue;
                }

                if (rightIndex > sortedRight.Length) {
                    sorted[sortedIndex] = sortedLeft[leftIndex];
                    leftIndex++;
                    sortedIndex++;
                    continue;
                }

                int leftElement = ;
                //if (leftIndex < sortedLeft.Length) {
                //    leftElement = sortedLeft[leftIndex];
                //}

                int? rightElement = null;
                if (rightIndex < sortedRight.Length)
                {
                    rightElement = sortedRight[rightIndex];
                }

                
            }

            return sorted;
        }

        //private static int[] (merge)
    }
    class MergeSort
    {
        public static int[] mergeSort(int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];
            //As this is a recursive algorithm, we need to have a base case to 
            //avoid an infinite recursion and therfore a stackoverflow
            if (array.Length <= 1)
                return array;
            // The exact midpoint of our array  
            int midPoint = array.Length / 2;
            //Will represent our 'left' array
            left = new int[midPoint];

            //if array has an even number of elements, the left and right array will have the same number of 
            //elements
            if (array.Length % 2 == 0)
                right = new int[midPoint];
            //if array has an odd number of elements, the right array will have one more element than left
            else
                right = new int[midPoint + 1];
            //populate left array
            for (int i = 0; i < midPoint; i++)
                left[i] = array[i];
            //populate right array   
            int x = 0;
            //We start our index from the midpoint, as we have already populated the left array from 0 to midpont

            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            //Recursively sort the left array
            left = mergeSort(left);
            //Recursively sort the right array
            right = mergeSort(right);
            //Merge our two sorted arrays
            result = merge(left, right);
            return result;
        }

        //This method will be responsible for combining our two sorted arrays into one giant array
        public static int[] merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];
            //
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            //while either array still has an element
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                //if both arrays have elements  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //If item on left array is less than item on right array, add that item to the result array 
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array wll be added to the results array
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                //if only the left array still has elements, add all its items to the results array
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                //if only the right array still has elements, add all its items to the results array
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }
    }
}
