using System;

namespace TwoDave.Lister
{
    public class Node // probably switch this and my linked list class to internal after I ask about namspace / assembly relationship
    {
        public object data;
        public Node next;

        public Node(object i) 
        {
            data = i;
            next = null;
        }
        public void PrintNode() 
        {
            Console.Write("|" + data + "|->");
            if (next != null)
            {
                next.PrintNode(); 
            }
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
        public Node HeadNode; 

        public MyLinkedList()
        {
            HeadNode = null;     
        }
        public void AddToEnd(object data) 
        {
            if (HeadNode == null)
            {
                HeadNode = new Node(data);
            }
            else 
            {
                HeadNode.AddToEnd(data); 
            }
        }
        public void AddToBeginning(object data) // Head node either null or a valid node
        {
            if (HeadNode == null) // Then you are already at the beginning
            {
                HeadNode = new Node(data);
            }
            else // Then need to add a temporary node and then adjust pointers
            {
                Node tempnode = new Node(data); 
                tempnode.next = HeadNode; // Temp node is now pointing to what current head is pointing to
                HeadNode = tempnode; // Now adjust head pointer to what temp is pointing to
            }
        }
        public void PrintList()
        {
            if (HeadNode != null) // This means it is a valid node
            {
                HeadNode.PrintNode(); 
            }
        }
    }
}