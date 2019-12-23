using System;
using System.Collections;
using System.Collections.Generic;

namespace PrintInReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void reversePrint(SinglyLinkedListNode head)
        {
            var stack = new Stack<SinglyLinkedListNode>();

            while (head != null)
            {
                stack.Push(head);
                head = head.next;
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop().data);
            }
        }
    }

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

}
