namespace TwoDave.Lister
{
    // I don't think I can use 'internal' for this class because if I do then I cannot instantiate it from any other .cs file right?
    // On second thought, I think because it is in the same namespace it will. 
    internal class Node
    {
        public Node next;
        public object data;     
    }

    public class LinkedList
    {
        private Node head;
        private Node current;
        public int count;

        public LinkedList()
        {
            
        }

    }
}