using System;
using System.Collections.Generic;

namespace ReverseADoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var n = new DoublyLinkedListNode(1);
            n.next = new DoublyLinkedListNode(2);
            n.next.prev = n;

            n.next.next = new DoublyLinkedListNode(3);
            n.next.next.prev = n.next;

            n.next.next.next = new DoublyLinkedListNode(4);
            n.next.next.next.prev = n.next.next;

            reverse(n);
        }

        static DoublyLinkedListNode reverse(DoublyLinkedListNode head)
        {
            var node = head;
            var stack = new Stack<DoublyLinkedListNode>();

            while (node != null)
            {
                stack.Push(node);
                node = node.next;
            }

            var ret = new DoublyLinkedListNode(0);
            DoublyLinkedListNode lastNode = ret;

            while (stack.Count > 0)
            {
                var popNode = stack.Pop();

                popNode.prev = lastNode;
                lastNode.next = popNode;
                popNode.next = null;

                lastNode = popNode;
            }

            ret.next.prev = null;
            return ret.next;
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
