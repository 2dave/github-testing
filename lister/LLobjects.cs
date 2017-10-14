using System;

namespace TwoDave.Lister
{
    public class Node
    {
        public object data;
        public Node next;
        public Node previous;

        public Node(object i)
        {
            data = i;
            next = null;
        }

        // A node can be in one of two situations - the 'next' Node can be null
        // (at the end of the list) or it can point to a valid node.
        public void AddToEnd(object data)
        {
            if (next == null) // At the end of the list
            {
                next = new Node(data);
            }
            else
            {
                next.AddToEnd(data); // Passing responsibility down the chain until getting 'next' == 'null'
            }
        }
    }

    public class MyLinkedList
    {
        public Node head;
        public Node current;

        public MyLinkedList()
        {
            head = null;
        }
        /*         public MyLinkedList(object data)
                {
                    // Now that I have a big object I need to split it up into different nodes
                    // TODO a bunch of stuff...
                } */
        public void AddToEnd(object data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                head.AddToEnd(data);
            }
        }
        public void AddToBeginning(object data) // Head node either null or a valid node
        {
            if (head == null) // Then you are already at the beginning
            {
                head = new Node(data);
            }
            else // Then need to add a temporary node and then adjust pointers
            {
                Node tempnode = new Node(data);
                tempnode.next = head; // Temp node is now pointing to what current head is pointing to
                head = tempnode; // Now adjust head pointer to what temp is pointing to
            }
        }
        public void PrintList()
        {
            Node curr = head;
            while (curr.next != null)
            {
                Console.Write(curr.data);
                Console.Write(" > ");
                curr = curr.next;
            }
            Console.Write(curr.data); // We need to display the final node because the loop above won't when .next == null
        }
    }
}