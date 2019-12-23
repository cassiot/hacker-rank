using System;

namespace InsertingANodeIntoASortedDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data)
        {
            var newNode = new DoublyLinkedListNode(data);

            if (head == null) 
                return newNode;

            var node = head;

            while (true)
            {
                if (node.data > data)
                {
                    if (node.prev != null)
                    {
                        node.prev.next = newNode;
                        newNode.prev = node.prev;
                    }
                    else
                        head = newNode;

                    node.prev = newNode;
                    newNode.next = node;

                    break;
                }

                if (node.next == null)
                {
                    node.next = newNode;
                    newNode.prev = node;

                    break;
                }

                node = node.next;
            }

            return head;
        }
    }

    class DoublyLinkedListNode
    {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }
}
