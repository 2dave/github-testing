using System.Collections.Generic;

namespace TwoDave.Lister
{
    public class NodeCollection
    {
        List<Node> nodes;

        public void Add(object data)
        {
        Node newnode = new Node();
        newnode.data = data;
        }
    }
}