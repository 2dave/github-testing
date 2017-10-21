using System;

namespace TwoDave.Lister
{
    public class MyLinkedList
    {
        public class Node
        {
            public object data;
            public Node next;
        }

        private Node head;
        private Node current;
        private int size;

        public MyLinkedList()
        {
            this.head = null;
            this.size = 0;
        }

        public bool Empty
        {
            get { return this.size == 0;}
        }

        public int Count
        {
            get { return this.size; }
        }

        public void AddToEnd(object newdata)
        {
            //var tempnode = new Node()
            //{
            //    data = newdata
            //};

            size++;

            var tempnode = new Node();
            tempnode.data = newdata;

            if (head == null)
            {
                head = tempnode;
            }
            else
            {
                current.next = tempnode;
            }

            current = tempnode;
        }

        public void AddToBeginning(object newdata)
        {
            head = new Node()
            {
                next = head,
                data = newdata
            };

            if (head == null)
            {
                head = new Node();
                head.data = newdata;
            }
            else
            {
                Node tempnode = new Node();
                tempnode.next = head;
                head = tempnode;
            }
        }

        public int IndexOf(object data)
        {
            Node current = this.head;
            
            for (int i = 0; i < this.Count; i++)
            {
                if (current.data.Equals(data))
                return i;
                current = current.next;
            }

            return -1;
        }

        public bool Contains(object data)
        {
            return this.IndexOf(data) != -1;
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