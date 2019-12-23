using System;

namespace MergeTwoSortedLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            if (head1 == null && head2 == null)
                return null;

            if (head1 == null) return head2;
            if (head2 == null) return head1;

            SinglyLinkedListNode newNodeHead = new SinglyLinkedListNode(0);
            SinglyLinkedListNode newNode = newNodeHead;

            while (head1 != null || head2 != null)
            {
                if (head1 != null)
                {
                    if (head2 != null)
                    {
                        if (head1.data > head2.data)
                        {
                            newNode.next = new SinglyLinkedListNode(head2.data);
                            head2 = head2.next;
                        }
                        else
                        {
                            newNode.next = new SinglyLinkedListNode(head1.data);
                            head1 = head1.next;
                        }
                    }
                    else
                    {
                        newNode.next = new SinglyLinkedListNode(head1.data);
                        head1 = head1.next;
                    }
                }
                else if (head2 != null)
                {
                    newNode.next = new SinglyLinkedListNode(head2.data);
                    head2 = head2.next;
                }

                newNode = newNode.next;

                //if (head1 != null)
                //    head1 = head1.next;
                //if (head2 != null)
                //    head2 = head2.next;
            }

            newNodeHead = newNodeHead.next;

            return newNodeHead;
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
