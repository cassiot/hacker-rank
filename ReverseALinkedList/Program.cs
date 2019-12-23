using System;
using System.Collections.Generic;

namespace ReverseALinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static SinglyLinkedListNode reverse(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode reverseHead = null;
            SinglyLinkedListNode reverseNode = null;
            var stack = new Stack<SinglyLinkedListNode>();

            while (head != null)
            {
                stack.Push(head);
                head = head.next;
            }

            while (stack.Count > 0)
            {
                var popNode = stack.Pop();

                if (reverseHead == null)
                {
                    reverseHead = new SinglyLinkedListNode(popNode.data);
                    reverseNode = reverseHead;
                }
                else
                {
                    reverseNode.next = new SinglyLinkedListNode(popNode.data);
                    reverseNode = reverseNode.next;
                }
            }

            return reverseHead;
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
