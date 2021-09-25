using System;

namespace InterviewPrepCSharp
{
    internal class TrappingWater
    {
        int res = 0; 
        public TrappingWater()
        {
            TrappingWaterHelper();
        }

        private void TrappingWaterHelper()
        {
            int[] steps = new int[] { 3, 0, 2, 0, 4 };

            for (int i = 1; i < steps.Length - 1; i++)
            {
                int left = steps[i];
                for (int j = 0; j < i; j++)
                {
                    left = Math.Max(left, steps[i]);
                }

                int right = steps[i];
                for (int j = i+1; j < steps.Length; j++)
                {
                    right = Math.Max(right, steps[j]);
                }

                res += Math.Min(left, right) - steps[i];
            }
        }



    }
}