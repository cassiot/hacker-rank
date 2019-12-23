using System;
using System.Collections.Generic;

namespace DeleteDuplicateValueNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static SinglyLinkedListNode removeDuplicates(SinglyLinkedListNode head)
        {
            var dic = new Dictionary<int, int>();
            var auxNode = new SinglyLinkedListNode(0);
            var retNode = auxNode;

            while (head != null)
            {
                if (dic.ContainsKey(head.data) == false)
                {
                    dic.Add(head.data, head.data);
                    auxNode.next = new SinglyLinkedListNode(head.data);
                    auxNode = auxNode.next;
                }
                head = head.next;
            }

            return retNode.next;
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
