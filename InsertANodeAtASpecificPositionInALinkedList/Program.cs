using System;

namespace InsertANodeAtASpecificPositionInALinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            var iNode = new SinglyLinkedListNode(data);
            
            if (head == null) return iNode;

            var node = head;

            var i = 1;
            
            while (i != position)
            {
                node = node.next;
                i++;
            }

            iNode.next = node.next;
            node.next = iNode;

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
