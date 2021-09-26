using System;

namespace LeetCode.Problems.Solution
{
    class Progrnam
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 5, 7, 8, 93, 4, 5, 67, 3, 6 };
            int index = 2;
            PrintArray(nums);
            Console.WriteLine($"The {index} Highest  Number in the array is {GetHighestNumberFromArray(nums, index)}");
        }

        public static void PrintArray(int[] nums)
        {
            Console.WriteLine();
            Array.ForEach(nums, x => Console.Write(" " + x));
            Console.WriteLine();

        }
        public static int GetHighestNumberFromArray(int[] nums, int index)
        {
            //Sorting the array
            Array.Sort(nums);
            PrintArray(nums);

            //Reverse the sorted array
            Array.Reverse(nums);
            PrintArray(nums);

            return nums[index];
        }


    }
}
