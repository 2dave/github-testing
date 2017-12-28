using System;
using System.IO;
using System.Collections.Generic;

namespace TwoDave.Lister
{
    public class FileLib
    {
        public static Node ReadCommand(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                string line;

                List<Node> newnodes = new List<Node>();

                while ((line = file.ReadLine()) != null)
                {
                    var temp = line.Split(' ');
                    Node tempnode1 = null;
                    Node tempnode2 = null;

                    foreach (Node n in newnodes) //Get
                    {
                        if (temp[0] == (string)n.data)
                        {
                            tempnode1 = n;
                        }
                        if (temp[2] == (string)n.data)
                        {
                            tempnode2 = n;
                        }
                    }

                    if (tempnode1 == null) //Create
                    {
                        tempnode1 = new Node();
                        tempnode1.data = temp[0];
                        newnodes.Add(tempnode1);
                    }
                    if (tempnode2 == null)
                    {
                        tempnode2 = new Node();
                        tempnode2.data = temp[2];
                        newnodes.Add(tempnode2);
                    }

                    // for (int i = 0; i < newnodes.Count; i++)
                    // {
                    //     Node n = newnodes[i];
                    // }

                    string capturecommand = temp[1];

                    if (capturecommand == ">")
                    {
                        tempnode1.next = tempnode2;
                    }
                    else if (capturecommand == "<")
                    {
                        tempnode2.next = tempnode1;
                    }
                }

                Node head = FindHead(newnodes);
                //Node head = newnodes[2];
                //DisplayData(head);

                return head;
            }
        }

        public static void DisplayData(Node head)
        {
            Node node = head;

            while (node != null)
            {
                Console.Write(node.data);

                if (node.next != null)
                {
                    Console.Write(" > ");
                }

                node = node.next;
            }

            Console.WriteLine();
        }

        // Used this in order to eliminate the need for a helper DisplayData just to display
        // Instead I can just use Console.WriteLine on a string
        public static string GenerateString(Node head)
        {
            Node node = head;
            string result = string.Empty;

            while (node != null)
            {
                //Console.Write(node.data);
                result += node.data;

                if (node.next != null)
                {                    
                    //Console.Write(" > ");
                    result += " > ";
                }

                node = node.next;
            }                     
           return result;
        }

        public static Node FindHead(List<Node> lon)
        {
            List<Node> heads = new List<Node>(lon);

            foreach (var node in lon)
            {
                if (node.next != null)
                {
                    heads.Remove(node.next);
                }
            }
            return heads[0];
        }
    }
}