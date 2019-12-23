using System;

namespace CompareTwoLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static bool CompareLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            if (head1 == head2)
                return true;

            while (head1 != null && head2 != null)
            {
                if (head1.data == head2.data)
                {
                    head1 = head1.next;
                    head2 = head2.next;
                }
                else
                    return false;
            }

            return head1 == head2;
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
