using System;
using System.IO;

namespace DeleteANode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static SinglyLinkedListNode deleteNode(SinglyLinkedListNode head, int position)
        {
            int i = 0;
            SinglyLinkedListNode node = head;

            if (position == 0)
            {
                head = node.next;
                return head;
            }

            while (i < position - 1)
            {
                node = node.next;
                i++;
            }

            node.next = node.next.next;

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

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }


        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
        {
            while (node != null)
            {
                textWriter.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    textWriter.Write(sep);
                }
            }
        }
    }
}
