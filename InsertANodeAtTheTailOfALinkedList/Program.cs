using System;

namespace InsertANodeAtTheTailOfALinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
        {
            if(head == null) return new SinglyLinkedListNode(data);

            var node = head;

            while (node.next != null)
                node = node.next;

            node.next = new SinglyLinkedListNode(data);

            return head;
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
