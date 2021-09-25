using System;

namespace InterviewPrepCSharp
{
    internal class NumberFactorial
    {
        public NumberFactorial()
        {
            int number = 9;
            Console.WriteLine("Factorial of a Number {0} is {1}", number, Factorial(number));
            Console.WriteLine("Factorial of a Number {0} is {1}", number, RecursiveFactorial(number));

        }

        private int Factorial(int number)
        {
            if (number == 0)
                return 1;

            int factorial = 1;
            for (int i = number ; i > 0  ; i--)
            {
                factorial = factorial * i;
            }

            return factorial;
        }

        private int RecursiveFactorial(int number)
        {
            if (number == 0)
                return 1;
            return number * RecursiveFactorial(number - 1);
        }
    }
}