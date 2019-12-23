using System;
using System.Collections.Generic;

namespace GetNodeValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int getNode(SinglyLinkedListNode head, int positionFromTail)
        {
            var list = new List<int>();

            while (head != null)
            {
                list.Add(head.data);
                head = head.next;
            }
            
            return list[list.Count -1 - positionFromTail];
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
