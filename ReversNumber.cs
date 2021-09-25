using System;

namespace InterviewPrepCSharp
{
    internal class ReversNumber
    {
        public ReversNumber()
        {
            ReverseTheNumber();

        }

        private void ReverseTheNumber()
        {
            Int64 n = -1234;
            Int64 left = n;
            Int64 rev = 0;
            while (Convert.ToBoolean(left)) // instead of left>0 , to reverse signed numbers as well
            {
                Int64 r = left % 10;
                rev = rev * 10 + r;
                left = left / 10;  //left = Math.floor(left / 10); 
            }

            Console.WriteLine(rev);
        }
    }
}