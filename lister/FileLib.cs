using System;
using System.IO;
using System.Collections.Generic;

namespace TwoDave.Lister
{
    internal class FileLib
    {
        public static void ReadCommand(string path)
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

                DisplayData(newnodes);
            }
        }

        public static void DisplayData(List<Node> lon)
        {
            Console.WriteLine("---LIST OF NODES---");

            foreach (Node n in lon)
            {
                Console.Write(" {0} ", n.data.ToString());

                if (n.next != null)
                {
                    Console.Write(" > ");
                }
            }

            Console.WriteLine(" ");
        }        
    }
}