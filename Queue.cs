using System;
using System.Collections;

namespace InterviewPrepCSharp
{
    public class Queue :IEnumerator
    {

        private int maxSize;
        private long[] myQueue;
        private int front;
        private int rear;
        private int items;

        public object Current => throw new NotImplementedException();

        public Queue(int size)
        {
            maxSize = size;
            myQueue = new long[maxSize];
            front = 0;
            rear = -1;
            items = 0;
        }
        public void insert(long j)
        {
            if (isFull())
            {
                Console.WriteLine("Queue is Full");
            }
            if(rear == maxSize - 1)
            {
                rear = -1;
            }
            rear++;
            myQueue[rear] = j;
            items++;
        }
        public long remove()
        {
            long temp = myQueue[front];
            front++;
            if (front == maxSize)
                front = 0;
            return temp;
        }
        public long peekFront()
        {
            return myQueue[front];
        }
        public long peekRear()
        {
            return myQueue[rear];
        }
        public bool isEmpty()
        {
            return (items == 0); 
        }
        public bool isFull()
        {
            return (items == maxSize);
        }
        public void View()
        {
            Console.Write("[");
            for (int i = 0; i < myQueue.Length; i++)
            {
                Console.Write(myQueue[i] + " ");
            }
            Console.WriteLine("]");

        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
