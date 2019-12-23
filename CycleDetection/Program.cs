using System;

namespace CycleDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static bool hasCycle(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode aux = head.next;

            while (head != null && aux != null)
            {
                if (aux == head)
                    return true;

                head = head.next;
                aux = aux.next;

                if (aux != null)
                    aux = aux.next;
            }

            return false;
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
