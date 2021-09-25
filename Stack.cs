using System;
using System.Collections;
using System.Collections.Generic;

namespace InterviewPrepCSharp
{
    public class Stack 
    {
        private int maxSize;
        private string[] stackArray;
        private int top;

        public Stack(int size)
        {
            maxSize = size;
            stackArray = new string[maxSize];
            top = -1;
        }


        public string peek()
        {
            return stackArray[top];
        }

        public void push(string m)
        {
            if (isFull())
            {
                Console.WriteLine("This Stack is full");
            }
            else
            {
                top++;
                stackArray[top] = m;
            }
        }

        public string pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is Empty.");
                return "--";
            }
            else
            {
                int old_top = top;
                top--;
                return stackArray[old_top];
            }
        }

        public bool isEmpty()
        {
            return (top == -1);
        }

        private bool isFull()
        {
            return maxSize - 1 == top;
        }
    }
}
