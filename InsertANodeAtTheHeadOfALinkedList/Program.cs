using System;

namespace InsertANodeAtTheHeadOfALinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode head, int data)
        {
            var newHead = new SinglyLinkedListNode(data);

            newHead.next = head;

            return newHead;
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
