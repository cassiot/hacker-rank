using System;
using System.Collections.Generic;

namespace FindMergePointOfTwoLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            var dic1 = new Dictionary<SinglyLinkedListNode, int>();
            var dic2 = new Dictionary<SinglyLinkedListNode, int>();

            while (head1 != null) 
            {
                dic1.Add(head1, head1.data);
                head1 = head1.next; 
            }
            while (head2 != null)
            {
                dic2.Add(head2, head2.data);
                head2 = head2.next;
            }

            foreach (var kv in dic1)
            {
                if (dic2.ContainsKey(kv.Key))
                    return kv.Value;
            }

            return 0;
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
