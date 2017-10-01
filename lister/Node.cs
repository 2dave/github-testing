namespace TwoDave.Lister
{
    // I don't think I can use 'internal' for this class because if I do then I cannot instantiate it from any other .cs file right?
    public class Node
    {
        public Node next;
        public object data;
        
    }
}