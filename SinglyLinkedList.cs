using System;
using System.Collections.Generic;

namespace InterviewPrepCSharp
{
    public class SinglyLinkedList
    {
        public Node first;
        LinkedList<string> st = new LinkedList<string>();
        public bool IsEmpty()
        {
            return (first == null);
        }

        public void insertFirst(int data)
        {
            Node newnode = new Node();
            newnode.data = data;
            newnode.next = first;
            first = newnode;
        }

        public Node deleteFirst()
        {
            Node temp = first;
            first = first.next;
            return temp;
        }


        public void displayList()
        {
            Console.WriteLine("List ( First -- Last )");
            Node current = first;
            while (current != null)
            {
                current.displayNode();
                current = current.next;
            }
            Console.WriteLine();
        }


        public void inserLast(int data)
        {
            Node current = first;
            while (current.next != null)
            {
                current = current.next;
            }
            Node newNode = new Node();
            newNode.data = data;
            current.next = newNode;
        }
    }
}
