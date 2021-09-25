using System;

namespace InterviewPrepCSharp
{
    internal class SubSequenceSum
    {
        public SubSequenceSum()
        {
            int k = 1; //index element
            int[] nums = new int[] { 1, 23, 4, 5, 6, 67, 7, 8 };
            SumSubSequence(nums, k);
        }

        /// <summary>
        /// e.g. input ={1,23,4,5,6,67,7,8} k=1 result = 23 k=0 result = 67  
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private int SumSubSequence(int[] nums, int k)
        {
            int max = 0;
            int count = k;
            
            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1;
                if (j < nums.Length)
                {
                    if (nums[i] < nums[j] && max < nums[j])
                        max = nums[j];
                    else if (max < nums[i])
                        max = nums[i];
                }
            }
            return max;
        }
    }
}